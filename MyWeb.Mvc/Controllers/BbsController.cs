using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWeb.Mvc.Controllers
{
    public class BbsController : Controller
    {
        // GET: Bbs
        public ActionResult Index()
        {
            return View();
        }




        public ActionResult BbsList()
        {
            return View();
        }


        public ActionResult BbsDetail()
        {
            return View();
        }





        public ActionResult Top5Bbs()
        {
            return PartialView();
        }

        

    }
}