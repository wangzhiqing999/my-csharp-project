using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Mapping;
using System.Data.Entity.Core.Metadata.Edm;


namespace MyBuying.Mvc
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            // ##########  Log4Net 配置.  ##########
            string webConfigFile = Server.MapPath("web.config");
            if (System.IO.File.Exists(webConfigFile))
            {
                System.Diagnostics.Debug.WriteLine("log4net.Config.XmlConfigurator.Configure...");
                log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo(webConfigFile));
            }

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            // ##########  EF 配置.  ########## 
            // 当 Code First 与数据库结构不一致时， 忽略.
            Database.SetInitializer(new NullDatabaseInitializer<MyBuying.DataAccess.MyBuyingContext>());
            // 提前加载.
            InitContext<MyBuying.DataAccess.MyBuyingContext>();

        }



        private void InitContext<T>() where T : DbContext, new()
        {
            // ##### EF Pre-Generated Mapping Views #####

            // 由于 EF 在首次加载的时候， 非常耗时
            // 因此，初始化的操作， 放置在 Application_Start 里面进行处理。
            // 这样一来， 首次查询操作， 将不会发生速度非常慢的现象。
            // 对程序中定义的所有DbContext逐一进行这个操作
            using (var dbcontext = new T())
            {
                var objectContext = ((IObjectContextAdapter)dbcontext).ObjectContext;
                var mappingCollection = (StorageMappingItemCollection)objectContext.MetadataWorkspace.GetItemCollection(DataSpace.CSSpace);
                mappingCollection.GenerateViews(new List<EdmSchemaError>());
            }

        }

    }
}
