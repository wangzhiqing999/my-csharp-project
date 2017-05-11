using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using MyMenu.Model;


namespace MyMenu.Service
{

    /// <summary>
    /// 菜单服务.
    /// </summary>
    public interface IMenuService
    {


        #region 读取方法.


        /// <summary>
        /// 取得菜单树形结构.
        /// </summary>
        /// <returns></returns>
        List<Menu> GetMenuTree();


        /// <summary>
        /// 获取指定菜单.
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        Menu GetMenu(string code);


        /// <summary>
        /// 取得顶级菜单.
        /// </summary>
        /// <returns></returns>
        List<Menu> GetRootMenu();


        /// <summary>
        /// 获取指定菜单的子菜单.
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        List<Menu> GetSubMenu(string code);


        #endregion 









        #region 管理方法.



        /// <summary>
        /// 添加新菜单
        /// </summary>
        /// <param name="data"></param>
        /// <param name="resultMsg"></param>
        /// <returns></returns>
        bool AddMenu(Menu data, ref string resultMsg);



        /// <summary>
        /// 编辑菜单.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="resultMsg"></param>
        /// <returns></returns>
        bool EditMenu(Menu data, ref string resultMsg);



        /// <summary>
        /// 删除菜单.
        /// </summary>
        /// <param name="menuCode"></param>
        /// <param name="resultMsg"></param>
        /// <returns></returns>
        bool RemoveMenu(string menuCode, ref string resultMsg);



        /// <summary>
        /// 移动菜单到.
        /// </summary>
        /// <param name="menuCode">当前菜单节点.</param>
        /// <param name="parentMenuCode">父菜单代码</param>
        /// <param name="prevMenuCode">同等级别，上一个菜单代码</param>
        /// <param name="resultMsg"></param>
        /// <returns></returns>
        bool MoveMenuTo(string menuCode, string parentMenuCode, string prevMenuCode, ref string resultMsg);


        #endregion
    }


}
