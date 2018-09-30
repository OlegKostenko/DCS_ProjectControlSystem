using DCSPCS.BOL.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DCSPCS.WebUI.Controllers
{
    public class EquipDatasController : Controller
    {
        public List<EqiupDataDTO> equips { get; set; }
        public ActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> List()
        {
            var client = new HttpClient();
            var response = await client.GetAsync("http://localhost:50494/api/EquipData");
            if (response.IsSuccessStatusCode)
            {
                equips = JsonConvert.DeserializeObject<List<EqiupDataDTO>>(
                await response.Content.ReadAsStringAsync());
                var res = equips.OrderBy(t => t.EquipDataID);
                return View(res);
            }
            return HttpNotFound();
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
                var equipT = await response.Content.ReadAsStringAsync();
                var equipDeS = JsonConvert.DeserializeObject<String>(equipT);
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