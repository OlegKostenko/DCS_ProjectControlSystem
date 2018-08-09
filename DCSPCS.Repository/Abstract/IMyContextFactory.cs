using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCSPCS.Repository.Abstract
{
    public interface IMyContextFactory
    {
        DbContext GetWarehouseContext();
        DbContext GetProjectContext();

    }
}
