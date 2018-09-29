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
        //IEntityService<WREquipmentDTO> WREquipment;
        IEntityService<EquipVendorDTO> EqVendors;
        public WarehouseController(IEntityService<EquipVendorDTO> EqVendors)
        {
            this.EqVendors = EqVendors;
        }

        public IHttpActionResult GetAllItems()
        {
            return Ok(EqVendors.GetAll());
        }

        public HttpResponseMessage Get(int id)
        {
            EquipVendorDTO vendorDTO = EqVendors.Get(id);
            if (vendorDTO == null)
                return Request.CreateResponse(HttpStatusCode.NotFound, "NotFound");
            return Request.CreateResponse(HttpStatusCode.OK, vendorDTO);
        }
        [HttpPost]
        public HttpResponseMessage Post([FromBody]EquipVendorDTO equipVendor)
        {
            EqVendors.AddOrUpdate(equipVendor);
            string tmp = string.Format($"{equipVendor.EquipVendorID} has been saved");
            HttpResponseMessage msg = Request.CreateResponse(HttpStatusCode.OK, tmp);
            string url = Url.Link("DefaultApi", new { id = equipVendor.EquipVendorID });
            msg.Headers.Location = new Uri(url);
            return msg;
        }
        [HttpDelete]
        public HttpResponseMessage Remove([FromBody]EquipVendorDTO equipVendor)
        {
            if (equipVendor != null)
            {
                EqVendors.Delete(equipVendor);
                string tmp = string.Format($"{equipVendor.EquipVendorID} has been deleted");
                HttpResponseMessage msg = Request.CreateResponse(HttpStatusCode.Gone, tmp);
                string url = Url.Link("DefaultApi", new { id = equipVendor.EquipVendorID });
                msg.Headers.Location = new Uri(url);
                return msg;
            }
            //else
            //    HttpResponseMessage message = Request.CreateResponse(HttpStatusCode.Gone);
            return null;
        }

    } 
}
