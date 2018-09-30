using DCSPCS.BOL.DTO;
using DCSPCS.BOL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DCSPCS.REST_Api.Controllers
{
    public class PREquipmentController : ApiController
    {
        IEntityService<PREquipmentDTO> PREquipmentService;
        public PREquipmentController(IEntityService<PREquipmentDTO> PREquipmentService)
        {
            this.PREquipmentService = PREquipmentService;
        }

        public IHttpActionResult GetAllItems()
        {
            return Ok(PREquipmentService.GetAll());
        }

        public HttpResponseMessage Get(int id)
        {
            PREquipmentDTO pREquipmentDTO = PREquipmentService.Get(id);
            if (pREquipmentDTO == null)
                return Request.CreateResponse(HttpStatusCode.NotFound, "NotFound");
            return Request.CreateResponse(HttpStatusCode.OK, pREquipmentDTO);
        }
        [System.Web.Http.HttpPost]
        public HttpResponseMessage Post([FromBody]PREquipmentDTO pREquipmentDTO)
        {
            PREquipmentService.AddOrUpdate(pREquipmentDTO);
            string tmp = string.Format($"{pREquipmentDTO.PREquipID} has been saved");
            HttpResponseMessage msg = Request.CreateResponse(HttpStatusCode.OK, tmp);
            string url = Url.Link("DefaultApi", new { id = pREquipmentDTO.PREquipID });
            msg.Headers.Location = new Uri(url);
            return msg;
        }
        [System.Web.Http.HttpDelete]
        public HttpResponseMessage Delete([FromBody]PREquipmentDTO pREquipmentDTO)
        {
            PREquipmentService.Delete(pREquipmentDTO);
            string tmp = string.Format($"{ pREquipmentDTO.PREquipID } has been deleted");
            HttpResponseMessage msg = Request.CreateResponse(HttpStatusCode.OK, tmp);
            string url = Url.Link("DefaultApi", new { id = pREquipmentDTO.PREquipID });
            msg.Headers.Location = new Uri(url);
            return msg;
        }
    }
}
