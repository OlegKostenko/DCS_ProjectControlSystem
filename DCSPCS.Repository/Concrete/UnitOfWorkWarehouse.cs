using DCSPCS.DAL.DBWarehouse.DbLayer;
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
    public class UnitOfWorkWarehouse : IUnitOfWorkWarehouse
    {
        private WarehouseContext context;
        private WREquipmentRepository wREquipmentRepository;
        private WREquipVendorRepository wREquipVendorRepository;

        public UnitOfWorkWarehouse(string connectionString)
        {
            context = new WarehouseContext(connectionString);
        }

        public IGenericRepository<WREquipment> Equipments
        {
            get
            {
                if (wREquipmentRepository == null)
                    wREquipmentRepository = new WREquipmentRepository(context);
                return wREquipmentRepository;
            }
        }

        public IGenericRepository<WREquipVendor> EquipVendors
        {
            get
            {
                if (wREquipVendorRepository == null)
                    wREquipVendorRepository = new WREquipVendorRepository(context);
                return wREquipVendorRepository;
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
