using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Com.Interface.Web.Models;

namespace Com.Interface.Web.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserAccount account)
        {
            if (ModelState.IsValid)
            {
                // Add user here
                Console.WriteLine("User registered {0}", account.Username);

                // Add user to dbcontext here


                ModelState.Clear();
                ViewBag.message = account.FirstName + " " + account.LastName + " successfully registered.";

            }

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserAccount account)
        {
            // Retreive user from dbcontext here

            if (true)
            {
                Session["UserID"] = 0;
                Session["Username"] = "";

                return RedirectToAction("Login");
            }
            else
            {

                ModelState.AddModelError("", "Username or Password is wrong");
                return View();
            }
        }

        public ActionResult LoggedIn()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}