using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyHelp.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }



        public ActionResult TestHelp()
        {
            ViewBag.Title = "TestHelp";

            return View();
        }

    }
}
