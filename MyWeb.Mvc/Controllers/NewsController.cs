using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWeb.Mvc.Controllers
{


    /// <summary>
    /// 新闻.
    /// </summary>
    public class NewsController : Controller
    {
        // GET: News
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult NewsList()
        {
            return View();
        }


        public ActionResult NewsDetail()
        {
            return View();
        }



        public ActionResult Top5News()
        {
            return PartialView();
        }

    }
}