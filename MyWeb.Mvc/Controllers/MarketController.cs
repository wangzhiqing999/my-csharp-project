using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWeb.Mvc.Controllers
{
    public class MarketController : Controller
    {
        // GET: Market
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult MarketList()
        {
            return View();
        }


        public ActionResult MarketDetail()
        {
            return View();
        } 
    }
}