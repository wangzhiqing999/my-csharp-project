using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;


using MyUserMonitor.ServiceImpl;


namespace MyUserMonitor.Mvc
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);




            // 初始化的时候， 启动超时清理服务.
            DefaultUserMonitorService userMonitorService = DefaultUserMonitorService.GetUserMonitorService();
            userMonitorService.StartTimeoutClean();
        }


    }
}
