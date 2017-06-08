using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Data.Entity;
using System.Data.Entity.Infrastructure;

using log4net;

using MyFramework.Util;

using MyDocument.Model;
using MyDocument.DataAccess;

using MyDocument.Mvc.Common;


namespace MyDocument.Mvc.Controllers
{
    public class HomeController : Controller
    {

        /// <summary>
        /// 日志处理类.
        /// </summary>
        private static ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        //
        // GET: /Home/

        public ActionResult Index()
        {
			// 显示画面.
            return View();
        }

    }
}
