using SimpleBlog.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SimpleBlog.Controllers
{
    public class AuthController : Controller
    {
        
        public ActionResult Login()
        {
            //return Content("Login!");
            //instead of returning content Login, it will return a view
            return View(new AuthLogin
            {
                Test = "This is my test value set in my controller."
            });
        }

        [HttpPost]
        public ActionResult Login(AuthLogin form, string returnUrl)
        {
            //use when non-strongly typed
            //return Content("Hey there, " + form.Username);

            ///when strongly typed:
            form.Test = "This is a value set in my post action.";

            if (!ModelState.IsValid)
                return View(form);

            //***this is the authentication
            FormsAuthentication.SetAuthCookie(form.Username, true);


            //add additional checks to our action results
            //if checks are related to business logic
            //if (form.Username != "gee")
            //{
            //    ModelState.AddModelError("Username", "Username or password isn't 20% cooler.");
            //    return View(form);
            //}

            //return Content("The form is valid.");
            //instead it will use the return url to know where to redirect.
            if (!string.IsNullOrWhiteSpace(returnUrl))
                return Redirect(returnUrl);

            return RedirectToRoute("home");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToRoute("home");
        }
    }
}