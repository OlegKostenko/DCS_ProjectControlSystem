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
    public class EquipCategoryController : ApiController
    {
        IEntityService<EquipCategoryDTO> EquipCategoryService;
        public EquipCategoryController(IEntityService<EquipCategoryDTO> EquipCategoryService)
        {
            this.EquipCategoryService = EquipCategoryService;
        }

        public IHttpActionResult GetAllItems()
        {
            return Ok(EquipCategoryService.GetAll());
        }

        public HttpResponseMessage Get(int id)
        {
            EquipCategoryDTO equipCategoryDTO = EquipCategoryService.Get(id);
            if (equipCategoryDTO == null)
                return Request.CreateResponse(HttpStatusCode.NotFound, "NotFound");
            return Request.CreateResponse(HttpStatusCode.OK, equipCategoryDTO);
        }
        [System.Web.Http.HttpPost]
        public HttpResponseMessage Post([FromBody]EquipCategoryDTO equipCategoryDTO)
        {
            EquipCategoryService.AddOrUpdate(equipCategoryDTO);
            string tmp = string.Format($"{equipCategoryDTO.EquipCategoryID} has been saved");
            HttpResponseMessage msg = Request.CreateResponse(HttpStatusCode.OK, tmp);
            string url = Url.Link("DefaultApi", new { id = equipCategoryDTO.EquipCategoryID });
            msg.Headers.Location = new Uri(url);
            return msg;
        }
        [System.Web.Http.HttpDelete]
        public HttpResponseMessage Delete([FromBody]EquipCategoryDTO equipCategoryDTO)
        {
            EquipCategoryService.Delete(equipCategoryDTO);
            string tmp = string.Format($"{ equipCategoryDTO.EquipCategoryID } has been deleted");
            HttpResponseMessage msg = Request.CreateResponse(HttpStatusCode.OK, tmp);
            string url = Url.Link("DefaultApi", new { id = equipCategoryDTO.EquipCategoryID });
            msg.Headers.Location = new Uri(url);
            return msg;
        }
    }
}
