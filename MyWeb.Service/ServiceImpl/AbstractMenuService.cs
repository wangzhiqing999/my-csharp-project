using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyWeb.Model;

using MyWeb.Service;



namespace MyWeb.ServiceImpl
{

    /// <summary>
    /// 抽象菜单处理服务.
    /// </summary>
    public abstract class AbstractMenuService : IMenuService
    {


        /// <summary>
        /// 最大支持多少层的模块.
        /// </summary>
        protected static int maxSupportModuleLevel = 5;


        /// <summary>
        /// 最大支持多少层的模块.
        /// </summary>
        public static int MaxSupportModuleLevel
        {
            set
            {
                maxSupportModuleLevel = value;
            }
        }


        /// <summary>
        /// 获取全部的菜单数据.
        /// </summary>
        /// <returns></returns>
        protected abstract List<Menu> GetAllMenuData();


        /// <summary>
        /// 获取指定菜单.
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public abstract Menu GetMenu(string code);



        public List<Menu> GetMenuTree()
        {
            // 获取全部的菜单数据.
            List<Menu> allMenuList = this.GetAllMenuData();

            // 结果 = 根节点的列表.
            var query =
                from data in allMenuList
                where
                    data.ParentMenuCode == null
                orderby
                    data.DisplayIndex
                select 
                    data;

            List<Menu> resultList = query.ToList();


            // 依次加载每一个根节点的子菜单.
            foreach (var rootMenu in resultList)
            {
                ReadSubMenu(allMenuList, rootMenu, 0);
            }

            // 返回.
            return resultList;
        }



        /// <summary>
        /// 读取子菜单.
        /// </summary>
        /// <param name="allMenuList"></param>
        /// <param name="menu"></param>
        /// <param name="level"></param>
        /// <param name="skipMenuCode"></param>
        private static void ReadSubMenu(List<Menu> allMenuList, Menu menu, int level, string skipMenuCode = null)
        {
            // 设置当前菜单的 层次.
            menu.MenuLevel = level;

            if (level > maxSupportModuleLevel)
            {
                // 为了避免数据异常.
                // 导致堆栈溢出.
                //超出最大层次后，不处理.
                return;
            }


            // 查询子菜单数据.
            var query =
                from data in allMenuList
                where
                    data.ParentMenuCode == menu.MenuCode
                select data;

            if (!String.IsNullOrEmpty(skipMenuCode))
            {
                // 如果存在  需要排除的 模块代码， 那么排除掉.
                query = query.Where(p => p.MenuCode != skipMenuCode);
            }

            // 获取子菜单列表.
            menu.MenuSubMenuList = query.OrderBy(p=>p.DisplayIndex).ToList();

            if (menu.MenuSubMenuList.Count > 0)
            {
                // 存在有子节点.
                foreach (Menu subMenu in menu.MenuSubMenuList)
                {
                    // 加载子菜单 的 子菜单.
                    ReadSubMenu(allMenuList, subMenu, level + 1, skipMenuCode);
                }
            }
        }







        /// <summary>
        /// 取得顶级菜单.
        /// </summary>
        /// <returns></returns>
        public virtual List<Menu> GetRootMenu()
        {
            return this.GetSubMenu(null);
        }



        /// <summary>
        /// 获取指定菜单的子菜单.
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public virtual List<Menu> GetSubMenu(string code)
        {
            // 获取全部的菜单数据.
            List<Menu> allMenuList = this.GetAllMenuData();

            var query =
                from data in allMenuList
                where
                    data.ParentMenuCode == code
                orderby
                    data.DisplayIndex
                select data;

            List<Menu> resultList = query.ToList();

            return query.ToList();
        }



        /// <summary>
        /// 添加新菜单
        /// </summary>
        /// <param name="data"></param>
        /// <param name="resultMsg"></param>
        /// <returns></returns>
        public abstract bool AddMenu(Menu data, ref string resultMsg);



        /// <summary>
        /// 编辑菜单.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="resultMsg"></param>
        /// <returns></returns>
        public abstract bool EditMenu(Menu data, ref string resultMsg);


        /// <summary>
        /// 删除菜单.
        /// </summary>
        /// <param name="menuCode"></param>
        /// <param name="resultMsg"></param>
        /// <returns></returns>
        public abstract bool RemoveMenu(string menuCode, ref string resultMsg);



        /// <summary>
        /// 移动菜单到.
        /// </summary>
        /// <param name="menuCode">当前菜单节点.</param>
        /// <param name="parentMenuCode">父菜单代码</param>
        /// <param name="prevMenuCode">同等级别，上一个菜单代码</param>
        /// <param name="resultMsg"></param>
        /// <returns></returns>
        public virtual bool MoveMenuTo(string menuCode, string parentMenuCode, string prevMenuCode, ref string resultMsg)
        {

            try{

                // 取得移动的当前菜单.
                Menu currentMenu = this.GetMenu(menuCode);

                if (currentMenu == null)
                {
                    resultMsg = String.Format("代码为 {0} 的数据不存在！", menuCode);
                    return false;
                }

                if (!String.IsNullOrEmpty(parentMenuCode))
                {
                    // 指定了父节点.
                    Menu parentMenu = this.GetMenu(parentMenuCode);

                    if (parentMenu == null)
                    {
                        resultMsg = String.Format("代码为 {0} 的数据不存在！", parentMenuCode);
                        return false;
                    }
                }

                // 同级别菜单列表.
                List<Menu> sameLevelMenuList;

                if (String.IsNullOrEmpty(parentMenuCode))
                {
                    // 移动到根节点.
                    sameLevelMenuList = this.GetRootMenu();
                }
                else
                {
                    // 移动到特定节点.
                    sameLevelMenuList = this.GetSubMenu(parentMenuCode);
                }


                if(!sameLevelMenuList.Exists(p=>p.MenuCode == menuCode))
                {
                    // 跨范围移动.

                    // 修改当前菜单的 父节点.
                    currentMenu.ParentMenuCode = parentMenuCode;

                    sameLevelMenuList.Add(currentMenu);
                }


                currentMenu.DisplayIndex = 0;

                if (String.IsNullOrEmpty(prevMenuCode))
                {
                    // 插入到顶部.                    
                    foreach(var menu in sameLevelMenuList) {

                        if (menu.MenuCode == currentMenu.MenuCode)
                        {
                            menu.DisplayIndex = 1;
                        }
                        else
                        {
                            menu.DisplayIndex++;
                        }
                        
                        if (!this.EditMenu(menu, ref resultMsg))
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    // 插入到指定项目之后.
                    var targetMenu = sameLevelMenuList.FirstOrDefault(p => p.MenuCode == prevMenuCode);

                    if (targetMenu == null)
                    {
                        resultMsg = String.Format("代码为 {0} 的数据不存在！", prevMenuCode);
                        return false;
                    }

                    foreach (var menu in sameLevelMenuList)
                    {
                        if (menu.DisplayIndex > targetMenu.DisplayIndex)
                        {
                            // 后续的递增.
                            menu.DisplayIndex++;
                            if (!this.EditMenu(menu, ref resultMsg))
                            {
                                return false;
                            }
                        }                       
                    }

                    // 更新当前菜单.
                    currentMenu.DisplayIndex = targetMenu.DisplayIndex + 1;
                    if (!this.EditMenu(currentMenu, ref resultMsg))
                    {
                        return false;
                    }
                }



                return true;

            } catch (Exception ex){

                resultMsg = ex.Message;
                return false;
            }
        }

    }


}
