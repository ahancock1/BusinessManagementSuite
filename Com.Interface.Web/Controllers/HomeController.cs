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
        private IEmployeeHub employeeHub;

        public HomeController(IEmployeeHub employeeHub)
        {
            this.employeeHub = employeeHub;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}