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
                vendors = JsonConvert.DeserializeObject<List<EquipVendorDTO>>(
                await response.Content.ReadAsStringAsync());
                var res = vendors.OrderBy(t => t.EquipVendorID);
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
        public ViewResult Create()
        {
            return View("Edit", new EquipVendorDTO());
        }
        public async Task<ActionResult> Edit(int? Id)
        {
            var client = new HttpClient();
            var response = await client.GetAsync("http://localhost:50494/api/Warehouse");
            if (response.IsSuccessStatusCode)
            {
                vendors = JsonConvert.DeserializeObject<List<EquipVendorDTO>>(
                await response.Content.ReadAsStringAsync());
                var res = vendors.Find(s => s.EquipVendorID == Id);
                if (res != null)
                {
                    return View(res);
                }
                return View("Error");
            }
            return HttpNotFound();
        }
        [HttpPost]
        public async Task<ActionResult> AddOrUpdate(EquipVendorDTO equip)
        {
            var client = new HttpClient();
            
            var response = await client.PostAsJsonAsync("http://localhost:50494/api/Warehouse", equip);

            if (response.IsSuccessStatusCode)
            {
                // Deserialize the updated product from the response body.
                equip = JsonConvert.DeserializeObject<EquipVendorDTO>(await response.Content.ReadAsStringAsync());
                if (equip != null)
                {
                    TempData["message"] = string.Format($"{equip.EquipVendorName} is exists!");
                }
            }
            return RedirectToAction("List");
        }

        [HttpPost]
        public async Task<ActionResult> Delete(EquipVendorDTO equip)
        {
            var client = new HttpClient();
            HttpResponseMessage response = await client.DeleteAsync(
                $"http://localhost:50494/api/Warehouse/{equip}");
            String stCode = "410";
            if (response.StatusCode.ToString() == stCode)
            {
                TempData["message"] = string.Format($"{equip.EquipVendorName} was deleted!");
            }
            return RedirectToAction("List");
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