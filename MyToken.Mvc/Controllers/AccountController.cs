using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

using MyToken.Mvc.Models;


namespace MyToken.Mvc.Controllers
{

    [Authorize]
    public class AccountController : Controller
    {


        public ActionResult Index()
        {
            return View();
        }





        // 进入登录页.
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }




        // 提交登录
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Message = "提供的用户名或密码不正确！";
                return View(model);
            }

            if (model.UserName != "test")
            {
                ViewBag.Message = "您输入的用户名或密码不正确。";
                return View(model);
            }

            // 执行到这里， 认为登录成功了.
            FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
            return RedirectToLocal(returnUrl);
        }



        // 登出.
        // GET: /Account/LogOff
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }






        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }



    }
}