using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Text;

using MyToken.Model;
using MyToken.Service;



namespace MyToken.Mvc.Controllers
{
    public class TokenController : Controller
    {

        /// <summary>
        /// Token 管理器.
        /// </summary>
        private ITokenManager tokenManager;



        /// <summary>
        /// 构造函数.
        /// </summary>
        /// <param name="tokenManager"></param>
        public TokenController( ITokenManager tokenManager) 
        {
            this.tokenManager = tokenManager;
        }




        //
        // GET: /Token/

        public ActionResult Index(string token)
        {

            ViewBag.Token = token;

            return View();
        }






        




        /// <summary>
        /// 新分配一个 Token.
        /// </summary>
        /// <returns></returns>
        public ActionResult NewToken(string typeCode)
        {

            Dictionary<string, object> loginUser = new Dictionary<string, object>();
            loginUser.Add("UserCode", "test1");
            loginUser.Add("UserName", "测试用户1");

            string resultMsg = null;

            Guid token = this.tokenManager.NewToken(typeCode, loginUser, ref resultMsg);


            return RedirectToAction(actionName: "Index", routeValues: new { token = token.ToString() });
            
        }




        /// <summary>
        /// 取得 Token.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetToken(string id)
        {


            Dictionary<string, object> accessUser = new Dictionary<string, object>();
            accessUser.Add("UserCode", "test2");
            accessUser.Add("UserName", "测试用户2");



            Guid guid;

            if (!Guid.TryParse(id, out guid))
            {
                return Content("Fail", "text/plain", Encoding.UTF8);
            }

            string resultMsg = null;

            TokenData tokenData = this.tokenManager.AccessToken(guid, accessUser, ref resultMsg);

            if (tokenData == null)
            {
                return Content("Not Found", "text/plain", Encoding.UTF8);
            }


            return View(model: tokenData);
            
        }









        #region 网页调用.

        /// <summary>
        /// 二维码登录页面使用.
        /// </summary>
        /// <returns></returns>
        public JsonResult CodeLogin()
        {
            // 申请一个新的 Token.
            string resultMsg = null;
            Guid token = this.tokenManager.NewToken("TEST_LOGIN", null, ref resultMsg);

            if(token == Guid.Empty)
            {
                // 失败.
                var errorResult = new
                {
                    ResultCode = "LOGIN_FAIL",
                    ResultMessage = resultMsg,
                };
                return Json(errorResult, JsonRequestBehavior.AllowGet);
            }


            Session["LOGIN_CODE"] = token;

            // 正常操作， 是返回一个 可访问的 url 地址.
            // 这里就简单返回 Token 了.
            var successResult = new
            {
                ResultCode = "0",
                ResultMessage = "success",
                ResultData = token
            };
            return Json(successResult, JsonRequestBehavior.AllowGet);            
        }

        /// <summary>
        /// 判断生成的二维码，是否被扫了.
        /// </summary>
        /// <returns></returns>
        public JsonResult IsScan()
        {
            var loginData = Session["LOGIN_CODE"];
            if(loginData == null)
            {
                // 失败.
                var errorResult = new
                {
                    ResultCode = "LOGIN_CODE_NOT_FOUND",
                    ResultMessage = "没有生成二维码页面！",
                };
                return Json(errorResult, JsonRequestBehavior.AllowGet);
            }

            // 取得 Token.
            Guid token = (Guid)loginData;

            // 获取日志.
            List<TokenAccessLog> accessLog = this.tokenManager.GetTokenAccessLog(token);


            var successResult = new
            {
                ResultCode = "0",
                ResultMessage = "success",
                ResultData = accessLog.Count
            };
            return Json(successResult, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 判断生成的二维码，是否确认登录了.
        /// </summary>
        /// <returns></returns>
        public JsonResult IsLogin()
        {
            object loginData = Session["LOGIN_CODE"];
            if (loginData == null)
            {
                // 失败.
                var errorResult = new
                {
                    ResultCode = "LOGIN_CODE_NOT_FOUND",
                    ResultMessage = "没有生成二维码页面！",
                };
                return Json(errorResult, JsonRequestBehavior.AllowGet);
            }

            // 取得 Token.
            Guid token = (Guid)loginData;

            // 获取日志.
            List<TokenAccessLog> accessLog = this.tokenManager.GetTokenAccessLog(token);

            if (accessLog.Count == 0)
            {
                // 从未扫过.
                var errorResult = new
                {
                    ResultCode = "LOGIN_CODE_INACTIVE",
                    ResultMessage = "无效的二维码数据！",
                };
                return Json(errorResult, JsonRequestBehavior.AllowGet);
            }


            if (accessLog.Count == 1)
            {
                // 只扫了一次，处于待确认状态.
                var errorResult = new
                {
                    ResultCode = "LOGIN_CODE_WAITING",
                    ResultMessage = "处于等待客户端确认状态下！",
                };
                return Json(errorResult, JsonRequestBehavior.AllowGet);
            }

            TokenAccessLog resultData = accessLog.Last();

            if(resultData.AccessResult != "success")
            {
                // 最后访问是失败的.
                var errorResult = new
                {
                    ResultCode = "LOGIN_CODE_FAIL",
                    ResultMessage = resultData.AccessResult,
                };
                return Json(errorResult, JsonRequestBehavior.AllowGet);
            }


            // 未能获取 App 方面的用户数据.
            if (resultData.UserDataObject == null
                || resultData.UserDataObject["UserCode"] == null )
            {
                var errorResult = new
                {
                    ResultCode = "LOGIN_CODE_FAIL",
                    ResultMessage = "无效的用户数据",
                };
                return Json(errorResult, JsonRequestBehavior.AllowGet);
            }

            // 访问成功的情况下.
            string userName = resultData.UserDataObject["UserCode"].ToString();

            // 执行到这里， 认为登录成功了.
            FormsAuthentication.SetAuthCookie(userName, true);


            var successResult = new
            {
                ResultCode = "0",
                ResultMessage = "success"
            };
            return Json(successResult, JsonRequestBehavior.AllowGet);
        }


        #endregion




        #region 手机客户端调用.


        /// <summary>
        /// 用于演示的 App 客户端.
        /// </summary>
        /// <returns></returns>
        public ActionResult DemoApp()
        {
            return View();
        }


        /// <summary>
        /// App 首次扫码.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult DoScan(Guid id)
        {
            string resultMsg = null;
            TokenData tokenData = this.tokenManager.AccessToken(id, null, ref resultMsg);

            if (tokenData == null)
            {
                // 失败.
                var errorResult = new
                {
                    ResultCode = "LOGIN_CODE_TIME_OUT",
                    ResultMessage = "生成的二维码超时！",
                };
                return Json(errorResult, JsonRequestBehavior.AllowGet);
            }


            var successResult = new
            {
                ResultCode = "0",
                ResultMessage = "success",
            };
            return Json(successResult, JsonRequestBehavior.AllowGet);
        }



        /// <summary>
        /// App 扫码后，确认登录.
        /// </summary>
        /// <returns></returns>
        public JsonResult Makesure(Guid id)
        {
            // 注： 
            // 这里应该是 从 Http Header 中。
            // 获取当前 App 具体是哪一个用户登录的.
            // 然后，获取当前 App 登录的用户信息
            Dictionary<string, object> accessUser = new Dictionary<string, object>();
            accessUser.Add("UserCode", "test2");
            accessUser.Add("UserName", "测试用户2");



            string resultMsg = null;

            TokenData tokenData = this.tokenManager.AccessToken(id, accessUser, ref resultMsg);

            if (tokenData == null)
            {
                // 失败.
                var errorResult = new
                {
                    ResultCode = "LOGIN_CODE_TIME_OUT",
                    ResultMessage = "生成的二维码超时！",
                };
                return Json(errorResult, JsonRequestBehavior.AllowGet);
            }


            var successResult = new
            {
                ResultCode = "0",
                ResultMessage = "success",
            };
            return Json(successResult, JsonRequestBehavior.AllowGet);
        }


        #endregion


    }
}
