[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(DCSPCS.REST_Api.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(DCSPCS.REST_Api.App_Start.NinjectWebCommon), "Stop")]

namespace DCSPCS.REST_Api.App_Start
{
    using System;
    using System.Data.Entity;
    using System.Web;
    using DCSPCS.DAL.DBProject.DbLayer;
    using DCSPCS.DAL.DBWarehouse.DbLayer;
    using DCSPCS.Repository.Abstract;
    using DCSPCS.Repository.Concrete;
    using DCSPCS.Repository.Repositories;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;
    using Template.Repository.Common;

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
            kernel.Bind<IMyContextFactory>().To<MyContextFactory>().InRequestScope();
            kernel.Bind<IGenericRepository<WREquipment>>().To<WREquipmentRepository>();
            kernel.Bind<IGenericRepository<WREquipVendor>>().To<WREquipVendorRepository>();
            kernel.Bind<IGenericRepository<PRProduct>>().To<PRProductRepository>();
            kernel.Bind<IGenericRepository<PREquipVendor>>().To<PREquipVendorRepository>();
            kernel.Bind<IGenericRepository<PREquipment>>().To<PREquipmentRepository>();
            kernel.Bind<IGenericRepository<PREquipDescription>>().To<PREquipDescriptionRepository>();
            kernel.Bind<IGenericRepository<PREqiupData>>().To<PREqiupDataRepository>();
            kernel.Bind<IGenericRepository<PRDescription>>().To<PRDescriptionRepository>();
        }        
    }
}