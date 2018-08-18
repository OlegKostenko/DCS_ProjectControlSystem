using DCSPCS.DAL.DBProject.DbLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Repository.Common;

namespace DCSPCS.Repository.Abstract
{
    public interface IUnitOfWorkProject : IDisposable
    {
        IGenericRepository<PRProduct> PRProducts { get; }
        IGenericRepository<PREquipVendor> PREquipVendors { get; }
        IGenericRepository<PREquipment> PREquipments { get; }
        IGenericRepository<PREquipDescription> PREquipDescriptions { get; }
        IGenericRepository<PREqiupData> PREquipDatas { get; }
        IGenericRepository<PRDescription> PRDescriptions { get; }
        void Save();
     }
}
