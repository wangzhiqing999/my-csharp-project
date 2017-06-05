using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWeb.Mvc.Controllers
{
    public class DocController : Controller
    {
        // GET: Doc
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult DocList()
        {
            return View();
        }


        public ActionResult DocDetail()
        {
            return View();
        }



        public ActionResult Top5Doc()
        {
            return PartialView();
        }
    }
}