[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(MySubModule.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(MySubModule.Web.App_Start.NinjectWebCommon), "Stop")]

namespace MySubModule.Web.App_Start
{
    using System;
    using System.Web;

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

            string localPath = System.Web.Hosting.HostingEnvironment.MapPath("~/FinanceCalenda");
            // �ƾ�����.
            kernel.Bind<MyFinanceCalendar.Service.IFinanceDataReader>().ToMethod(context =>
                MyFinanceCalendar.ServiceImpl.LocalFinanceDataReader.GetInstance(localPath));


            // ���·���.
            kernel.Bind<MyArticle.Service.IArticleService>().To<MyArticle.ServiceImpl.DefaultArticleService>();

            // �������.
            kernel.Bind<MyBanner.Service.IBannerService>().To<MyBanner.ServiceImpl.DefaultBannerService>();

            // ��Ѷ����.
            kernel.Bind<MyFx678Kx.Service.IFx678KxService>().To<MyFx678Kx.ServiceImpl.DefaultFx678KxService>();
        }        
    }
}
