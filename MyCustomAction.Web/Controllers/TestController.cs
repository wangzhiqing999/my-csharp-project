using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyCustomAction.Web.Controllers
{
    public class TestController : Controller
    {

        private static List<TestUser> testUserList = new List<TestUser> () {
            new TestUser() { UserID = 3, UserName = "Zhang3" },
            new TestUser() { UserID = 4, UserName = "Li4" },
            new TestUser() { UserID = 5, UserName = "Wang5" },
            new TestUser() { UserID = 6, UserName = "Zhao6" },
        };


        //
        public ActionResult LoginAs(string id)
        {
            TestUser user = testUserList.FirstOrDefault(p => p.UserName == id);
            if (user == null)
            {
                return HttpNotFound();
            }

            // 登录成功.
            FormsAuthentication.SetAuthCookie(id, true);

            Session["USER_ID"] = user.UserID;

            return RedirectToAction("Index", "Test");
        }

        // 登出.
        // GET: /Test/LogOff
        public ActionResult LogOff()
        {

            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Test");
        }




        // GET: Test
        public ActionResult Index()
        {
            return View();
        }



        /// <summary>
        /// 测试模块1.
        /// </summary>
        /// <returns></returns>
        public ActionResult TestModule1()
        {
            return View();
        }


        /// <summary>
        /// 测试模块2.
        /// </summary>
        /// <returns></returns>
        public ActionResult TestModule2()
        {
            return View();
        }


        /// <summary>
        /// 测试模块3.
        /// </summary>
        /// <returns></returns>
        public ActionResult TestModule3()
        {
            return View();
        }




        /// <summary>
        /// 测试管理页 - 指定顾客
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult TestManager(string id)
        {
            TestUser user = testUserList.FirstOrDefault(p => p.UserName == id);
            if (user == null)
            {
                return HttpNotFound();
            }

            ViewBag.User = user;

            return View();
        }



        /// <summary>
        /// 测试管理页 - 全部顾客
        /// </summary>
        /// <returns></returns>
        public ActionResult TestManagerAll()
        {
            List<TestUser> userList = new List<TestUser>();
            userList.AddRange(testUserList);

            // 这里加一堆测试数据， 是为了观察对前端页面布局会有啥影响.
            for (int i = 0; i < 20; i++)
            {
                TestUser t = new TestUser()
                {
                    UserID = 100 + i,
                    UserName = "测试用户100" + i
                };
                userList.Add(t);
            }

            ViewBag.Users = userList;

            return View();
        }



    }


    public class TestUser
    {
        public long UserID { set; get; }
        public string UserName { set; get; }
    }


}