using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

using System.Data.Entity;
using System.Data.Entity.Migrations;

using log4net;


namespace MyChatRoom.Mvc
{
    public class MvcApplication : System.Web.HttpApplication
    {

        /// <summary>
        /// 日志处理类.
        /// </summary>
        private static ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);



        protected void Application_Start()
        {

            // ##########  Log4Net 配置.  ##########
            string webConfigFile = Server.MapPath("web.config");
            if (System.IO.File.Exists(webConfigFile))
            {
                System.Diagnostics.Debug.WriteLine("log4net.Config.XmlConfigurator.Configure...");
                log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo(webConfigFile));
            }



            // ##########  数据库配置.  ##########

            // 当 Code First 与数据库结构不一致时, 忽略.
            Database.SetInitializer(new NullDatabaseInitializer<MyChatRoom.DataAccess.MyChatRoomContext>());






            // ##########  MVC 配置.  ##########
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
