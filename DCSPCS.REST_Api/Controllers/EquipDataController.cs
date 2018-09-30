using DCSPCS.BOL.DTO;
using DCSPCS.BOL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace DCSPCS.REST_Api.Controllers
{
    public class EquipDataController : ApiController
    {
        IEntityService<EqiupDataDTO> EqDataService;
        public EquipDataController(IEntityService<EqiupDataDTO> EqDataService)
        {
            this.EqDataService = EqDataService;
        }

        public IHttpActionResult GetAllItems()
        {
            return Ok(EqDataService.GetAll());
        }

        public HttpResponseMessage Get(int id)
        {
            EqiupDataDTO eqDataDTO = EqDataService.Get(id);
            if (eqDataDTO == null)
                return Request.CreateResponse(HttpStatusCode.NotFound, "NotFound");
            return Request.CreateResponse(HttpStatusCode.OK, eqDataDTO);
        }
        [System.Web.Http.HttpPost]
        public HttpResponseMessage Post([FromBody]EqiupDataDTO eqDataDTO)
        {
            EqDataService.AddOrUpdate(eqDataDTO);
            string tmp = string.Format($"{eqDataDTO.EquipDataID} has been saved");
            HttpResponseMessage msg = Request.CreateResponse(HttpStatusCode.OK, tmp);
            string url = Url.Link("DefaultApi", new { id = eqDataDTO.EquipDataID });
            msg.Headers.Location = new Uri(url);
            return msg;
        }
        [System.Web.Http.HttpDelete]
        public HttpResponseMessage Delete([FromBody]EqiupDataDTO eqDataDTO)
        {
            EqDataService.Delete(eqDataDTO);
            string tmp = string.Format($"{eqDataDTO.EquipDataID} has been deleted");
            HttpResponseMessage msg = Request.CreateResponse(HttpStatusCode.OK, tmp);
            string url = Url.Link("DefaultApi", new { id = eqDataDTO.EquipDataID });
            msg.Headers.Location = new Uri(url);
            return msg;
        }
    }
}