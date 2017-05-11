using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MyMenu.Model;
using MyMenu.Service;
using MyMenu.ServiceImpl;

namespace MyMenu.Mvc.Controllers
{
    public class UserController : Controller
    {

        /// <summary>
        /// 菜单服务.
        /// </summary>
        private IMenuService menuService = new DefaultMenuService();



        // GET: User
        public ActionResult Index()
        {
            // 查询菜单树形结构.
            List<Menu> menuTree = this.menuService.GetMenuTree();

            // 迁移视图.
            return View(model: menuTree);
        }
    }
}