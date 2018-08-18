using DCSPCS.DAL.DBWarehouse.DbLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Repository.Common;

namespace DCSPCS.Repository.Abstract
{
    public interface IUnitOfWorkWarehouse : IDisposable
    {
        IGenericRepository<WREquipment> Equipments { get; }
        IGenericRepository<WREquipVendor> EquipVendors { get; }
        void Save();
    }
}
