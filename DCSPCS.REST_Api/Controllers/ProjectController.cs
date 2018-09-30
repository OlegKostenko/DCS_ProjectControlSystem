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
    public class ProjectController : ApiController
    {
        //IEntityService<WREquipmentDTO> WREquipment;
        IEntityService<PRProductDTO> ProdService;
        public ProjectController(IEntityService<PRProductDTO> ProdService)
        {
            this.ProdService = ProdService;
        }

        public IHttpActionResult GetAllItems()
        {
            return Ok(ProdService.GetAll());
        }

        public HttpResponseMessage Get(int id)
        {
            PRProductDTO productDTO = ProdService.Get(id);
            if (productDTO == null)
                return Request.CreateResponse(HttpStatusCode.NotFound, "NotFound");
            return Request.CreateResponse(HttpStatusCode.OK, productDTO);
        }
        [HttpPost]
        public HttpResponseMessage Post([FromBody]PRProductDTO productDTO)
        {
            ProdService.AddOrUpdate(productDTO);
            string tmp = string.Format($"{productDTO.PRProdID} has been saved");
            HttpResponseMessage msg = Request.CreateResponse(HttpStatusCode.OK, tmp);
            string url = Url.Link("DefaultApi", new { id = productDTO.PRProdID});
            msg.Headers.Location = new Uri(url);
            return msg;
        }
        [HttpDelete]
        public HttpResponseMessage Delete([FromBody]PRProductDTO productDTO)
        {
            ProdService.Delete(productDTO);
            string tmp = string.Format($"{productDTO.PRProdID} has been deleted");
            HttpResponseMessage msg = Request.CreateResponse(HttpStatusCode.OK, tmp);
            string url = Url.Link("DefaultApi", new { id = productDTO.PRProdID });
            msg.Headers.Location = new Uri(url);
            return msg;
        }
    }
}
