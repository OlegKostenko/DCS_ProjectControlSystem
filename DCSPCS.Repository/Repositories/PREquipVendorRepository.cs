using DCSPCS.DAL.DbLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Repository.Common;

namespace DCSPCS.Repository.Repositories
{
    public class PREquipVendorRepository : GenericRepository<PREquipVendor>
    {
        public PREquipVendorRepository(DbContext context) : base(context)
        {

        }
    }
}
