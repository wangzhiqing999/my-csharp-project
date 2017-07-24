using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


using MyBallot.Model;
using MyBallot.ServiceImpl;


namespace MyBallot.Mvc.Controllers
{
    public class UserBallotController : Controller
    {
        //
        // GET: /UserBallot/

        public ActionResult Index()
        {
            return View();
        }






        private DefaultUserBallotService userBallotService = new DefaultUserBallotService();





        /// <summary>
        /// 投票.
        /// </summary>
        /// <returns></returns>
        public JsonResult DoBallot(int masterID, int detailID)
        {
            UserBallot userBallot = new UserBallot()
            {
                // 投票主表ID.
                BallotMasterID = masterID,

                // 投票明细ID.
                BallotDetailID = detailID,

                // 投票时间.
                BallotTime = DateTime.Now,

                // 投票用户IP.
                UserIp = Request.UserHostAddress,

                // 投票用户 cookie.
                UserCookie = GetRandomGuestCode(),

                // 投票用户代码（如果有的话）
                UserCode = "",
            };


            bool result = userBallotService.TakeUserBallot(userBallot);


            if (!result)
            {
                // 失败.
                var errorResult = new
                {
                    Result = false,
                    Message = userBallotService.ResultMessage,
                };
                return Json(errorResult);
            }


            // 成功.
            var jsonResult = new
            {
                Result = true
            };
            return Json(jsonResult);
        }





        private string GetRandomGuestCode()
        {
            // 游客的情况下， 昵称需要追加 随机代码.

            // 通过Request对象读取得到Cookies的值
            HttpCookie newCookie = Request.Cookies["MyBallot"];

            if (newCookie != null)
            {
                string username = newCookie.Values["Name"];

                if (!String.IsNullOrEmpty(username))
                {
                    return username;
                }
            }
            else
            {
                newCookie = new HttpCookie("MyBallot");
            }

            Guid newValue = Guid.NewGuid();
            string result = newValue.ToString("N");

            //2。Cookie中添加信息项：为键值对，key/value
            newCookie.Values.Add("Name", result);

            //3。如果不设置Expires属性，即为临时Cookie，浏览器关闭即消失
            newCookie.Expires = DateTime.Now.AddDays(2);  //设置过期天数为2天

            //4。写入Cookies集合
            Response.AppendCookie(newCookie);

            return result;
        }


    }
}
