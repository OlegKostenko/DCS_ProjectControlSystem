using DCSPCS.DAL.DBWarehouse.DbLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Template.Repository.Common;

namespace DCSPCS.REST_Api.Controllers
{
    public class WarehouseController : Controller
    {
        IGenericRepository<WREquipment> repository;

        public WarehouseController(IGenericRepository<WREquipment> repository)
        {
            this.repository = repository;
        }

        public IEnumerable<WREquipment> Index()
        {
            var model = repository.GetAll();
            return model;
        }
    }
}