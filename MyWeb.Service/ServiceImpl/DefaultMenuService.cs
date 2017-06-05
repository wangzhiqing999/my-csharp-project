using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyWeb.Model;
using MyWeb.DataAccess;

using MyWeb.Service;


namespace MyWeb.ServiceImpl
{

    /// <summary>
    /// 默认菜单服务实现.
    /// </summary>
    public class DefaultMenuService : AbstractMenuService
    {


        /// <summary>
        /// 获取全部的菜单数据.
        /// </summary>
        /// <returns></returns>
        protected override List<Menu> GetAllMenuData()
        {
            using (MyWebContext context = new MyWebContext())
            {
                var query =
                    from data in context.Menus.Include("MenuPage")
                    select data;

                List<Menu> resultList = query.ToList();

                return resultList;
            }
        }

        public override Menu GetMenu(string code)
        {
            using (MyWebContext context = new MyWebContext())
            {
                var query =
                    from data in context.Menus.Include("MenuPage")
                    where
                        data.MenuCode == code
                    select data;

                Menu result = query.FirstOrDefault();

                return result;
            }
        }


        /// <summary>
        /// 取得顶级菜单.
        /// </summary>
        /// <returns></returns>
        public override List<Menu> GetRootMenu()
        {
            using (MyWebContext context = new MyWebContext())
            {
                var query =
                    from data in context.Menus.Include("MenuPage")
                    where
                        data.ParentMenuCode == null
                    orderby
                        data.DisplayIndex
                    select data;

                List<Menu> resultList = query.ToList();

                return resultList;
            }
        }



        /// <summary>
        /// 获取指定菜单的子菜单.
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public override List<Menu> GetSubMenu(string code)
        {
            using (MyWebContext context = new MyWebContext())
            {
                var query =
                    from data in context.Menus.Include("MenuPage")
                    where
                        data.ParentMenuCode == code
                    orderby
                        data.DisplayIndex
                    select data;

                List<Menu> resultList = query.ToList();

                return resultList;
            }
        }




        /// <summary>
        /// 添加新菜单
        /// </summary>
        /// <param name="data"></param>
        /// <param name="resultMsg"></param>
        /// <returns></returns>
        public override bool AddMenu(Menu data, ref string resultMsg)
        {
            try
            {
                using (MyWebContext context = new MyWebContext())
                {

                    var dbData = context.Menus.Find(data.MenuCode);
                    if (dbData != null)
                    {
                        resultMsg = String.Format("代码为 {0} 的数据已存在！", data.MenuCode);
                        return false;
                    }

                    if (String.IsNullOrEmpty(data.ParentMenuCode))
                    {
                        // 根节点的 父节点为空.
                        data.ParentMenuCode = null;
                    }

                    context.Menus.Add(data);

                    // 物理保存.
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                resultMsg = ex.Message;
                return false;
            }
        }


        /// <summary>
        /// 编辑菜单.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="resultMsg"></param>
        /// <returns></returns>
        public override bool EditMenu(Menu data, ref string resultMsg)
        {
            try
            {
                using (MyWebContext context = new MyWebContext())
                {
                    var dbData = context.Menus.Find(data.MenuCode);
                    if (dbData == null)
                    {
                        resultMsg = String.Format("代码为 {0} 的数据不存在！", data.MenuCode);
                        return false;
                    }

                    // 父节点.
                    dbData.ParentMenuCode = data.ParentMenuCode;
                    if (String.IsNullOrEmpty(dbData.ParentMenuCode))
                    {
                        // 根节点的 父节点为空.
                        dbData.ParentMenuCode = null;
                    }
                    // 显示顺序.
                    dbData.DisplayIndex = data.DisplayIndex;
                    // 菜单文本.
                    dbData.MenuText = data.MenuText;
                    // 描述.
                    dbData.MenuDesc = data.MenuDesc;
                    // 扩展信息.
                    dbData.MenuExpand = data.MenuExpand;

                    // 物理保存.
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                resultMsg = ex.Message;
                return false;
            }
        }



        /// <summary>
        /// 删除菜单.
        /// </summary>
        /// <param name="menuCode"></param>
        /// <param name="resultMsg"></param>
        /// <returns></returns>
        public override bool RemoveMenu(string menuCode, ref string resultMsg)
        {
            try
            {
                using (MyWebContext context = new MyWebContext())
                {
                    var dbData = context.Menus.Find(menuCode);

                    if (dbData == null)
                    {
                        resultMsg = String.Format("代码为 {0} 的数据不存在！", menuCode);
                        return false;
                    }

                    // 判断当前菜单， 是否有子菜单.
                    if (dbData.SubMenus.Count() > 0)
                    {
                        foreach (var subMenu in dbData.SubMenus)
                        {
                            // 子节点的父节点 = 当前被删除节点的父节点.
                            subMenu.ParentMenuCode = dbData.ParentMenuCode;
                        }
                    }

                    // 删除.
                    context.Menus.Remove(dbData);

                    // 物理保存.
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                resultMsg = ex.Message;
                return false;
            }
        }


    }


}
