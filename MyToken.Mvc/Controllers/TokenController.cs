using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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

            var loginUser = new { 
                UserCode = "test1",
                UserName = "测试用户1",
            };


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


            var accessUser = new { 
                UserCode = "test2",
                UserName = "测试用户2",
            };



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



    }
}
