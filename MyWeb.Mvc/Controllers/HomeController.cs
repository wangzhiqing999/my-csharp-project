using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


using MyWeb.Model;
using MyWeb.Service;
using MyWeb.ServiceImpl;



namespace MyWeb.Mvc.Controllers
{
    public class HomeController : Controller
    {


        private IPageService pageService = new DefaultPageService();




        // GET: Home
        public ActionResult Index()
        {

            List<Page> pageList = this.pageService.GetSubPageList("home");


            return View(model: pageList);
        }


    }
}