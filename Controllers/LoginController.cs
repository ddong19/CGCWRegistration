using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CGCWRegistration.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Authenticate(string username, string password)
        {
            if (username == "view" && password == "view123")
            {
                Session["auth"] = "view";
                return RedirectToAction("Index", "Users");
            }
            else if (username == "admin" && password == "admin123")
            {
                Session["auth"] = "admin";
                return RedirectToAction("Index", "Users");
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid credentials. Please try again.";
                return View("Login");
            }
        }
    }
}