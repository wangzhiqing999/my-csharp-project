[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(MyChatRoom.Mvc.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(MyChatRoom.Mvc.App_Start.NinjectWebCommon), "Stop")]

namespace MyChatRoom.Mvc.App_Start
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

            // �����ҷ������.
            kernel.Bind<MyChatRoom.Service.IChatRoomHouseService>().To<MyChatRoom.ServiceImpl.DefaultChatRoomHouseService>();



            // ��Ϣ����.
            kernel.Bind<MyChatRoom.Service.IChatRoomMessageService>().To<MyChatRoom.ServiceImpl.DefaultChatRoomMessageService>();




            // �û�����
            kernel.Bind<MyChatRoom.Service.IChatRoomUserService>().To<MyChatRoom.ServiceImpl.DefaultChatRoomUserService>();

        }


    }
}
