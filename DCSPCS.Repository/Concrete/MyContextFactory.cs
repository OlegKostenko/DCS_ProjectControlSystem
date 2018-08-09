using DCSPCS.DAL.DBProject.DbLayer;
using DCSPCS.DAL.DBWarehouse.DbLayer;
using DCSPCS.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCSPCS.Repository.Concrete
{
    public class MyContextFactory : IMyContextFactory
    {
        public DbContext GetProjectContext()
        {
            return new ProjectContext();
        }

        public DbContext GetWarehouseContext()
        {
            return new WarehouseContext();
        }
    }
}
