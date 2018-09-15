using DCSPCS.DAL.DbLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Repository.Common;

namespace DCSPCS.BOL.Services
{
    public class PREquipmentService : GenericRepository<PREquipment>
    {
        public PREquipmentService(DbContext context) : base(context)
        {

        }
    }
}
