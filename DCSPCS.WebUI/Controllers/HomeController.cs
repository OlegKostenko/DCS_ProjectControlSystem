using DCSPCS.DAL.DBWarehouse.DbLayer;
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
        public List<WREquipment> items { get; set; }

        public ActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> List()
        {
            var client = new HttpClient();
            var response = await client.GetAsync("http://localhost:50494//api/Warehouse");
            if (response.IsSuccessStatusCode)
            {
                items = JsonConvert.DeserializeObject<List<WREquipment>>(
                await response.Content.ReadAsStringAsync());
                return View(items);
            }
            return HttpNotFound();
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