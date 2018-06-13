using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyExamination.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }




        public ActionResult Test()
        {
            ViewBag.Title = "Test Page";
            return View();
        }


        public ActionResult TestDetail(long id)
        {
            ViewBag.ID = id;
            ViewBag.Title = "Test Detail Page";
            return View();
        }

        public ActionResult TestDetail2(long id)
        {
            ViewBag.ID = id;
            ViewBag.Title = "Test Detail Page 2";
            return View();
        }


        public ActionResult TestSummary(long id)
        {
            ViewBag.ID = id;
            ViewBag.Title = "Test Summary Page";
            return View();
        }

    }
}
