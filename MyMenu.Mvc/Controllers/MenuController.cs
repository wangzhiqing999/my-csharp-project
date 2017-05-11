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
    public class MenuController : Controller
    {
        /// <summary>
        /// 菜单服务.
        /// </summary>
        private IMenuService menuService = new DefaultMenuService();


        /// <summary>
        /// 取得顶级菜单.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetRootMenu()
        {
            List<Menu> menuList = this.menuService.GetRootMenu();
            return ConvertToJsonResult(menuList);
        }


        /// <summary>
        /// 获取指定菜单的子菜单.
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetSubMenu(string id)
        {
            List<Menu> menuList = this.menuService.GetSubMenu(id);
            return ConvertToJsonResult(menuList);
        }




        /// <summary>
        /// 数据类型转换.
        /// </summary>
        /// <param name="menuList"></param>
        /// <returns></returns>
        private JsonResult ConvertToJsonResult(List<Menu> menuList)
        {
            var query =
                from data in menuList
                select new
                {                   
                    // 菜单代码.
                    menuCode = data.MenuCode,
                    // 父菜单代码.
                    parentMenuCode = data.ParentMenuCode,

                    // 显示顺序.
                    displayIndex = data.DisplayIndex,
                    // 菜单文字.
                    menuText = data.MenuText,
                    // 菜单备注.
                    menuDesc = data.MenuDesc,
                    // 菜单扩展信息.
                    menuExpand = data.MenuExpand,
                };

            var resultList = query.ToList();

            return Json(resultList);
        }





        /// <summary>
        /// 移动菜单到.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pid"></param>
        /// <param name="previd"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult MoveMenuTo(string id, string pid, string previd)
        {
            string msg = null;
            bool result = this.menuService.MoveMenuTo(id, pid, previd, ref msg);

            var jsonResult = new
            {
                resultCode = result ? 0 : -1,
                resultMessage = msg
            };

            return Json(jsonResult);
        }






        /// <summary>
        /// 更新菜单.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pid"></param>
        /// <param name="index"></param>
        /// <param name="text"></param>
        /// <param name="desc"></param>
        /// <param name="exp"></param>
        /// <returns></returns>
        public JsonResult UpdateMenu(string id, string pid, int index, string text, string desc, string exp)
        {
            Menu menu = new Menu()
            {
                // 菜单代码.
                MenuCode = id,

                // 父代码.
                ParentMenuCode = pid,

                // 显示顺序.
                DisplayIndex = index,

                // 菜单文本.
                MenuText = text,

                // 描述.
                MenuDesc = desc,

                // 扩展信息.
                MenuExpand = exp,
            };

            string msg = null;
            bool result = this.menuService.EditMenu(menu, ref msg);

            var jsonResult = new
            {
                resultCode = result ? 0 : -1,
                resultMessage = msg
            };

            return Json(jsonResult);
        }



        /// <summary>
        /// 新增菜单.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pid"></param>
        /// <param name="index"></param>
        /// <param name="text"></param>
        /// <param name="desc"></param>
        /// <param name="exp"></param>
        /// <returns></returns>
        public JsonResult InsertMenu(string id, string pid, int index, string text, string desc, string exp)
        {
            Menu menu = new Menu()
            {
                // 菜单代码.
                MenuCode = id,

                // 父代码.
                ParentMenuCode = pid,

                // 显示顺序.
                DisplayIndex = index,

                // 菜单文本.
                MenuText = text,

                // 描述.
                MenuDesc = desc,

                // 扩展信息.
                MenuExpand = exp,
            };

            string msg = null;
            bool result = this.menuService.AddMenu(menu, ref msg);

            var jsonResult = new
            {
                resultCode = result ? 0 : -1,
                resultMessage = msg
            };

            return Json(jsonResult);

        }



        /// <summary>
        /// 删除菜单.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult DeleteMenu(string id)
        {
            string msg = null;
            bool result = this.menuService.RemoveMenu(id, ref msg);

            var jsonResult = new
            {
                resultCode = result ? 0 : -1,
                resultMessage = msg
            };

            return Json(jsonResult);
        }


    }
}