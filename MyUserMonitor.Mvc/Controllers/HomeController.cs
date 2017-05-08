using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyUserMonitor.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }



        /// <summary>
        /// 测试页.
        /// </summary>
        /// <returns></returns>
        public ActionResult Test()
        {
            return View();
        }


        /// <summary>
        /// 管理页.
        /// </summary>
        /// <returns></returns>
        public ActionResult Manager()
        {
            return View();
        }


    }
}