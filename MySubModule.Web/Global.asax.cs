using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;


using System.Data.Entity;

using MyArticle.DataAccess;
using MyBanner.DataAccess;
using MyFx678Kx.DataAccess;


namespace MySubModule.Web
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // EF 配置.
            // 当 Code First 与数据库结构不一致时， 忽略.
            Database.SetInitializer(new NullDatabaseInitializer<MyArticleContext>());
            Database.SetInitializer(new NullDatabaseInitializer<MyBannerContext>());
            Database.SetInitializer(new NullDatabaseInitializer<MyFx678KxContext>());


            // Web 配置.
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
