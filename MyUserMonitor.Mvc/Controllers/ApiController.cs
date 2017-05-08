using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MyUserMonitor.Model;
using MyUserMonitor.ServiceImpl;


namespace MyUserMonitor.Mvc.Controllers
{
    public class ApiController : Controller
    {

        /// <summary>
        /// 用户监控服务.
        /// </summary>
        private DefaultUserMonitorService userMonitorService = DefaultUserMonitorService.GetUserMonitorService();


        /// <summary>
        /// 成功时的结果.
        /// </summary>
        private static dynamic successResult = new
        {
            ResultCode = 0,
            ResultMessage = "success"
        };



        /// <summary>
        /// 用户进入.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public JsonResult Enter(string id, string name)
        {
            try
            {
                // 用户进入.
                this.userMonitorService.UserAccess(groupCode: id, userName: name);
                
                // 返回.
                return Json(successResult, JsonRequestBehavior.AllowGet);

            } catch (Exception ex){

                var errorResult = new
                {
                    ResultCode = -1,
                    ResultMessage = ex.Message
                };

                // 返回.
                return Json(errorResult, JsonRequestBehavior.AllowGet);
            }

        }



        /// <summary>
        /// 用户数统计.
        /// </summary>
        /// <returns></returns>
        public JsonResult UserSummary()
        {
            try
            {


                // 获取当前用户列表.
                var userList = this.userMonitorService.GetCurrentUserList();
                var groupQuery =
                    from data in userList
                    group data by data.GroupCode;

                var resultQuery =
                    from data in groupQuery
                    select new {
                        GroupCode = data.Key,
                        UserCount = data.Count(),
                    };

                var successResult = new
                {
                    ResultCode = 0,
                    ResultMessage = "success",
                    ResultData = resultQuery.ToList()
                };

                // 返回.
                return Json(successResult, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                var errorResult = new
                {
                    ResultCode = -1,
                    ResultMessage = ex.Message
                };

                // 返回.
                return Json(errorResult, JsonRequestBehavior.AllowGet);
            }
        }



        public JsonResult UserList(string id)
        {
            try
            {
                // 获取当前用户列表.
                var userList = this.userMonitorService.GetCurrentUserList();
                var query =
                    from data in userList
                    where data.GroupCode == id
                    select new {
                        GroupCode = data.GroupCode,
                        UserName = data.UserName,
                        EnterTime = data.EnterTime.ToString("yyyy-MM-dd HH:mm:ss"),
                        LastAccessTime = data.LastAccessTime.ToString("yyyy-MM-dd HH:mm:ss"),
                        AccessCount = data.AccessCount
                    };

                var resultData = query.ToList();

                var successResult = new
                {
                    ResultCode = 0,
                    ResultMessage = "success",
                    ResultData = resultData
                };

                // 返回.
                return Json(successResult, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                var errorResult = new
                {
                    ResultCode = -1,
                    ResultMessage = ex.Message
                };

                // 返回.
                return Json(errorResult, JsonRequestBehavior.AllowGet);
            }

        }

    }
}