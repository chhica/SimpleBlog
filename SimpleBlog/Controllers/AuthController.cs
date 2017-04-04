using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleBlog.Controllers
{
    public class AuthController : Controller
    {
        
        public ActionResult Login()
        {
            //return Content("Login!");
            //instead of returning content Login, it will return a view
            return View();
        }
    }
}