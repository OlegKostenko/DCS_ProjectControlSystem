﻿using DCSPCS.DAL.DbLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Repository.Common;

namespace DCSPCS.Repository.Repositories
{
    public class EqiupDataRepository : GenericRepository<EqiupData>
    {
        public EqiupDataRepository(DbContext context) : base(context)
        {

        }
    }
}
