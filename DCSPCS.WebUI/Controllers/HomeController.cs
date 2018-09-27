using DCSPCS.BOL.DTO;
using DCSPCS.WebUI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Template.Repository.Common;

namespace DCSPCS.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public List<EquipVendorDTO> vendors { get; set; }
        public List<WREquipmentDTO> equipments { get; set; }
        public List<EquipCategoryDTO> equips { get; set; }
        public ActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> List()
        {
            var client = new HttpClient();
            var response = await client.GetAsync("http://localhost:50494/api/Warehouse");
            if (response.IsSuccessStatusCode)
            {
                equipments = JsonConvert.DeserializeObject<List<WREquipmentDTO>>(
                await response.Content.ReadAsStringAsync());
                var res = equipments.OrderBy(t => t.WREquipID);
                return View(res);
            }
            return HttpNotFound();
        }

        public async Task<ActionResult> Equipment(int? VendorId, int? Page)
        {
            var client = new HttpClient();
            var response = await client.GetAsync("http://localhost:50494/api/Warehouse");
            if (response.IsSuccessStatusCode)
            {
                //vendors = JsonConvert.DeserializeObject<List<WREquipVendor>>(
                //await response.Content.ReadAsStringAsync());
                //var res = vendors.OrderBy(t => t.WREquipVendorID);
                //if (VendorId == null)
                //{
                //    VendorId = res.First().WREquipVendorID;
                //}
                //ViewBag.Page = Page;

                //var resVendors = res;
                //ViewBag.VendorId = new SelectList(resVendors, "WREquipVendorID", "WREquipVendorName", VendorId);

                //return View();
            }
            return null;
        }
        [HttpPost]
        public async Task<ActionResult> CityList(int id, int CurrentPage = 1)
        {
            var client = new HttpClient();
            var response = await client.GetAsync("http://localhost:50494/api/Warehouse");
            if (response.IsSuccessStatusCode)
            {
                //equipments = JsonConvert.DeserializeObject<List<WREquipment>>(
                //await response.Content.ReadAsStringAsync());
                //var res = equipments.OrderBy(t => t.WREquipID);
                //var model = new vmWarehouseItemsList() { VendorId = id };
                //model.paging.CurrentPage = CurrentPage;
                //model.Equipment = res.Where(t => t.WREquipVendorID == id).AsQueryable();
                //return PartialView(model);
            }

            return null;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}