using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

using log4net;

using MyUserMonitor.ServiceImpl;


namespace MyUserMonitor.Mvc
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // MVC 配置.
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            // Log4Net 配置.
            string webConfigFile = Server.MapPath("web.config");
            if (System.IO.File.Exists(webConfigFile))
            {
                System.Diagnostics.Debug.WriteLine("log4net.Config.XmlConfigurator.Configure...");
                log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo(webConfigFile));
            }



            // 日志存储处理.
            string logFile = String.Format("/LogFile/UserMonitor_{0:yyyyMMdd}.csv", DateTime.Today);
            CsvFileUserAccessInfoWriter csvFileUserAccessInfoWriter = new CsvFileUserAccessInfoWriter()
            {
                CsvFileName = Server.MapPath(logFile)
            };


            // 初始化的时候， 启动超时清理服务.
            DefaultUserMonitorService userMonitorService = DefaultUserMonitorService.GetUserMonitorService() ;
            userMonitorService.UserAccessInfoWriter = csvFileUserAccessInfoWriter;            
            userMonitorService.StartTimeoutClean();
        }


    }
}
