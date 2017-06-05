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
    public class MenuController : Controller
    {

        /// <summary>
        /// 菜单服务.
        /// </summary>
        private IMenuService menuService = new DefaultMenuService();


        // GET: Menu
        public ActionResult Index()
        {
            List<Menu> rootMenuList = this.menuService.GetMenuTree();
            return PartialView(model: rootMenuList);
        }


    }
}