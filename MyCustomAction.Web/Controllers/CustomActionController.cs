using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MyCustomAction.Model;

using MyCustomAction.Service;
using MyCustomAction.ServiceImpl;



namespace MyCustomAction.Web.Controllers
{
    public class CustomActionController : Controller
    {

        /// <summary>
        /// 客户行为服务
        /// </summary>
        private ICustomActionService _CustomActionService = new DefaultCustomActionService();


        // GET: CustomAction
        public ActionResult Index()
        {
            return View();
        }



        #region 顾客用相关方法.


        /// <summary>
        /// 新的行为
        /// </summary>
        /// <param name="customID"></param>
        /// <param name="moduleCode"></param>
        /// <param name="expData"></param>
        /// <returns></returns>
        public JsonResult NewAction(string moduleCode, string expData = null)
        {

            long customID = Convert.ToInt64(Session["USER_ID"]);

            long resultID = this._CustomActionService.NewAction(customID, moduleCode, expData);

            var result = new
            {
                Result = resultID > 0,
                ResultData = resultID
            };

            return Json(result, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// 后续行为.
        /// </summary>
        /// <param name="actionID"></param>
        /// <param name="moduleCode"></param>
        /// <returns></returns>
        public JsonResult ContinueAction(long actionID, string moduleCode)
        {
            long customID = Convert.ToInt64(Session["USER_ID"]);
            bool result = this._CustomActionService.ContinueAction(actionID, customID, moduleCode);
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// 放置 js 脚本的分布视图
        /// </summary>
        /// <param name="moduleCode"></param>
        /// <param name="expData"></param>
        /// <returns></returns>
        public ActionResult Require(string moduleCode, string expData = null)
        {
            // 模块代码.
            ViewBag.ModuleCode = moduleCode;

            // 模块代码.
            ViewBag.ExpData = expData;

            return PartialView();
        }


        #endregion







        #region 管理页相关方法.


        public JsonResult QueryCustomAction(long? id, DateTime? fromTime)
        {
            if (fromTime == null)
            {
                // 参数不传的情况下， 仅仅查询最近一天.
                fromTime = DateTime.Now.AddDays(-1);
            }


            List<CustomAction> dataList = this._CustomActionService.QueryCustomAction(id, fromTime, null);


            var query =
                from data in dataList
                orderby data.LastAccessTime
                select new
                {
                    // 流水.
                    ID = data.ID,

                    // 客户代码
                    CustomID = data.CustomID,

                    // 模块代码.
                    ModuleCode = data.ModuleCode,

                    // 模块名.
                    ModuleName = data.AccessServiceModule.ModuleName,

                    // 进入时间.
                    EnterTime = data.EnterTime.ToString("yyyy-MM-dd HH:mm:ss"),

                    // 最后访问时间
                    LastAccessTime = data.LastAccessTime.ToString("yyyy-MM-dd HH:mm:ss"),

                    // 访问分钟.
                    AccessMinutes = data.AccessMinutes,

                    // 附加数据.
                    ExpData = data.ExpData,
                };

            var resultList = query.ToList();

            return Json(resultList);
        }




        #endregion


    }
}