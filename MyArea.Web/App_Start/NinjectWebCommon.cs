[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(MyArea.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(MyArea.Web.App_Start.NinjectWebCommon), "Stop")]

namespace MyArea.Web.App_Start
{
    using System;
    using System.Web;
    using System.Web.Hosting;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {

            // 区域服务 - 使用数据库实现.
            // kernel.Bind<MyArea.Service.IAreaInfoService>().To<MyArea.ServiceImpl.DefaultAreaInfoService>();



            // 区域服务 - 使用 xml 实现.
            // 注意， 在这个时候， HttpContext.Current 为空.
            // 因此， 在这里使用 System.Web.HttpContext.Current.Server.MapPath 将发生问题.
            //string areaInfoFile = HostingEnvironment.MapPath("~/Info/AreaInfo.xml");
            //kernel.Bind<MyArea.Service.IAreaInfoService>().To<MyArea.ServiceImpl.XmlAreaInfoService>().WithConstructorArgument(areaInfoFile);




            // 使用 数据库 + 本地json 文件缓存.
            string areaInfoCachePath = HostingEnvironment.MapPath("~/Info");
            kernel.Bind<MyArea.Service.IAreaInfoService>()
                .To<MyArea.ServiceImpl.LocalCahceAreaInfoService>()
                .WithConstructorArgument("realAreaInfoService", new MyArea.ServiceImpl.DefaultAreaInfoService())
                .WithConstructorArgument("localCachePath", areaInfoCachePath)
                .WithConstructorArgument("localCacheUseAbleHours", 24);

        }



    }
}
