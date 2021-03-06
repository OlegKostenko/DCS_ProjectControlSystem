[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(DCSPCS.REST_Api.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(DCSPCS.REST_Api.App_Start.NinjectWebCommon), "Stop")]

namespace DCSPCS.REST_Api.App_Start
{
    using System;
    using System.Data.Entity;
    using System.Web;
    using DCSPCS.BOL.DTO;
    using DCSPCS.BOL.Services;
    using DCSPCS.DAL.DbLayer;
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
            kernel.Bind<DbContext>().To<ProjectContext>().InRequestScope();
            kernel.Bind<IGenericRepository<WRProduct>>().To<WRProductRepository>();
            kernel.Bind<IGenericRepository<WREquipment>>().To<WREquipmentRepository>();
            kernel.Bind<IGenericRepository<PRProduct>>().To<PRProductRepository>();
            kernel.Bind<IGenericRepository<PREquipment>>().To<PREquipmentRepository>();
            kernel.Bind<IGenericRepository<PRDescription>>().To<PRDescriptionRepository>();
            kernel.Bind<IGenericRepository<EquipVendor>>().To<EquipVendorRepository>();
            kernel.Bind<IGenericRepository<EquipDescription>>().To<EquipDescriptionRepository>();
            kernel.Bind<IGenericRepository<EquipCategory>>().To<EquipCategoryRepository>();
            kernel.Bind<IGenericRepository<EqiupData>>().To<EqiupDataRepository>();
            kernel.Bind<IEntityService<EqiupDataDTO>>().To<EqiupDataService>();
            kernel.Bind<IEntityService<EquipCategoryDTO>>().To<EquipCategoryService>();
            kernel.Bind<IEntityService<EquipDescriptionDTO>>().To<EquipDescriptionService>();
            kernel.Bind<IEntityService<EquipVendorDTO>>().To<EquipVendorService>();
            kernel.Bind<IEntityService<PRDescriptionDTO>>().To<PRDescriptionService>();
            kernel.Bind<IEntityService<PRProductDTO>>().To<PRProductService>();
            kernel.Bind<IEntityService<WREquipmentDTO>>().To<WREquipmentService>();
            kernel.Bind<IEntityService<WRProductDTO>>().To<WRProductServise>();
        }        
    }
}