using DCSPCS.DAL.DBProject.DbLayer;
using DCSPCS.Repository.Abstract;
using DCSPCS.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Repository.Common;

namespace DCSPCS.Repository.Concrete
{
    public class UnitOfWorkProject : IUnitOfWorkProject
    {
        private ProjectContext context;
        private PRProductRepository pRProductRepository;
        private PREquipVendorRepository pREquipVendorRepository;
        private PREquipmentRepository pREquipmentRepository;
        private PREquipDescriptionRepository pREquipDescriptionRepository;
        private PREqiupDataRepository pREqiupDataRepository;
        private PRDescriptionRepository pRDescriptionRepository;
        public UnitOfWorkProject(string connectionString)
        {
            context = new ProjectContext(connectionString);
        }
        public IGenericRepository<PRProduct> PRProducts
        {
            get
            {
                if (pRProductRepository == null)
                    pRProductRepository = new PRProductRepository(context);
                return pRProductRepository;
            }
        }

        public IGenericRepository<PREquipVendor> PREquipVendors
        {
            get
            {
                if (pREquipVendorRepository == null)
                    pREquipVendorRepository = new PREquipVendorRepository(context);
                return pREquipVendorRepository;
            }
        }

        public IGenericRepository<PREquipment> PREquipments
        {
            get
            {
                if (pREquipmentRepository == null)
                    pREquipmentRepository = new PREquipmentRepository(context);
                return pREquipmentRepository;
            }
        }

        public IGenericRepository<PREquipDescription> PREquipDescriptions
        {
            get
            {
                if (pREquipDescriptionRepository == null)
                    pREquipDescriptionRepository = new PREquipDescriptionRepository(context);
                return pREquipDescriptionRepository;
            }
        }

        public IGenericRepository<PREqiupData> PREquipDatas
        {
            get
            {
                if (pREqiupDataRepository == null)
                    pREqiupDataRepository = new PREqiupDataRepository(context);
                return pREqiupDataRepository;
            }
        }

        public IGenericRepository<PRDescription> PRDescriptions
        {
            get
            {
                if (pRDescriptionRepository == null)
                    pRDescriptionRepository = new PRDescriptionRepository(context);
                return pRDescriptionRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
