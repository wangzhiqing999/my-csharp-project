using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBallot.Mvc.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {

            // 初始化 用户 Cookie.
            InitRandomGuestCode();

            return View();
        }




        private void InitRandomGuestCode()
        {

            // 通过Request对象读取得到Cookies的值
            HttpCookie newCookie = Request.Cookies["MyBallot"];

            if (newCookie == null)
            {
                newCookie = new HttpCookie("MyBallot");

                Guid newValue = Guid.NewGuid();
                // 32位.
                string result = newValue.ToString("N");

                //2。Cookie中添加信息项：为键值对，key/value
                newCookie.Values.Add("Name", result);

                //3。如果不设置Expires属性，即为临时Cookie，浏览器关闭即消失
                newCookie.Expires = DateTime.Now.AddDays(2);  //设置过期天数为2天

                //4。写入Cookies集合
                Response.AppendCookie(newCookie);
            }
        }





    }
}
