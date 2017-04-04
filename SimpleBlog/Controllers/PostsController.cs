using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleBlog.Controllers
{
    public class PostsController : Controller
    {
        public ActionResult Index()
        {
            return View();
            //return Content("<h1>Hey There!</h1>");
            /*other possible choices
            return Redirect
            return File
            return View*/
        }
    }
}