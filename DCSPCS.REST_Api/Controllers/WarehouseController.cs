using AutoMapper;
using DCSPCS.BOL.DTO;
using DCSPCS.BOL.Services;
using DCSPCS.DAL.DbLayer;
using DCSPCS.REST_Api.Models.WarehouseViewModels;
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
        IEntityService<WREquipmentDTO> WREquipment;
        IEntityService<EquipVendorDTO> EqVendors;
        public WarehouseController(IEntityService<WREquipmentDTO> WREquipment, IEntityService<EquipVendorDTO> EqVendors)
        {
            this.WREquipment = WREquipment;
            this.EqVendors = EqVendors;
        }

        public IHttpActionResult GetAllItems()
        {
            return Ok(WREquipment.GetAll());
        }
        //public IHttpActionResult EquipmentList()
        //{
        //    return null;
        //}

        public HttpResponseMessage Get(int id)
        {
            WREquipmentDTO equipmentDTO = WREquipment.Get(id);
            if (equipmentDTO == null)
                return Request.CreateResponse(HttpStatusCode.NotFound, "NotFound");
            return Request.CreateResponse(HttpStatusCode.OK, equipmentDTO);
        }
        public HttpResponseMessage Post([FromBody]WREquipmentDTO wREquipment)
        {
            WREquipment.AddOrUpdate(wREquipment);
            string tmp = string.Format($"{wREquipment.WREquipID} has been saved");
            HttpResponseMessage msg = Request.CreateResponse(HttpStatusCode.Created, tmp);
            string url = Url.Link("DefaultApi", new { id = wREquipment.WREquipID });
            msg.Headers.Location = new Uri(url);
            return msg;
        }

        public HttpResponseMessage Remove([FromBody]WREquipmentDTO wREquipment)
        {
            WREquipment.Delete(wREquipment);
            string tmp = string.Format($"{wREquipment.WREquipID} has been deleted");
            HttpResponseMessage msg = Request.CreateResponse(HttpStatusCode.Moved, tmp);
            string url = Url.Link("DefaultApi", new { id = wREquipment.WREquipID });
            msg.Headers.Location = new Uri(url);
            return msg;
        }

    } 
}
