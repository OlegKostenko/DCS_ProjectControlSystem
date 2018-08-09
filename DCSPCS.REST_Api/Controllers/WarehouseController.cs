using DCSPCS.DAL.DBWarehouse.DbLayer;
using DCSPCS.Repository.Abstract;
using DCSPCS.Repository.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DCSPCS.REST_Api.Controllers
{
    public class WarehouseController : ApiController
    {
        IMyContextFactory factory;

        public WarehouseController(IMyContextFactory factory)
        {
            this.factory = factory;
        }

        public IHttpActionResult GetAllItems()
        {
            var context = factory.GetWarehouseContext();

                var repo = context.Set<WREquipment>().ToList();
                return Ok(repo);

        }
        //public Reservation GetReservation(int id)
        //{
        //    return repo.Get(id);
        //}
        //public Reservation PostReservation(Reservation item)
        //{
        //    return repo.Add(item);
        //}
        //public bool PutReservation(Reservation item)
        //{
        //    return repo.Update(item);
        //}
        //public void DeleteReservation(int id)
        //{
        //    repo.Remove(id);
        //}
    }
}
