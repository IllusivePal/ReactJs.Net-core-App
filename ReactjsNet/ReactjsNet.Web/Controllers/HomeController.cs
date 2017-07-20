using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReactjsNet.Web.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReactjsNet.Web.Controllers
{
    public class HomeController : Controller
    {
        private static readonly IList<CommentModel> _comments;
        static HomeController()
        {
            _comments = new List<CommentModel>
            {
                new CommentModel
                {
                    id=1,
                    Author = "Daniel March",
                    Text = "Irish Vlogger"
                },
                new CommentModel
                {
                    id = 2,
                    Author = "Christian leblanc",
                    Text = "Canadian Vlogger"

                },
                new CommentModel
                {
                    id=3,
                    Author= "Wil Dasovich",
                    Text = "American Vlogger"
                },
            };

        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        [Route("comments")]
        [ResponseCache(Location = ResponseCacheLocation.None,NoStore =true)]
        public ActionResult Comments()
        {
            return Json(_comments);
        }
        [Route("comments/new")]
        [HttpPost]
        public ActionResult AddComment(CommentModel comment)
        {
            comment.id = _comments.Count + 1;
            _comments.Add(comment);
            return Content("SuccessL) ");

        }
    }
}
