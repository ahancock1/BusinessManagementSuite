using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Com.Framework.Hubs;
using Com.Framework.Hubs.Core;

namespace Com.Interface.Web.Controllers
{
    public class HomeController : Controller
    {

        // Home Page
        public ActionResult Index()
        {
            return View();
        }

        // About Page
        public ActionResult About()
        {
            ViewBag.Title = "Business Management Suite";

            return View();
        }

        // Contact Page
        public ActionResult Contact()
        {
            ViewBag.Title = "Contact us";

            return View();
        }

    }
}