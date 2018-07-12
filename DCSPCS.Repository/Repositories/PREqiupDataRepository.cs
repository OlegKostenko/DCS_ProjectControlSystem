﻿using DCSPCS.DAL.DBProject.DbLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Repository.Common;

namespace DCSPCS.Repository.Repositories
{
    public class PREqiupDataRepository : GenericRepository<PREqiupData>
    {
        public PREqiupDataRepository(DbContext context) : base(context)
        {

        }
    }
}