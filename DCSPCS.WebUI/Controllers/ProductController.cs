using DCSPCS.BOL.DTO;
using DCSPCS.BOL.Services;
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
    public class ProductController : Controller
    {
        // GET: Product
        public List<PRProductDTO> Products { get; set; }
        public ActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> List()
        {
            var client = new HttpClient();
            var response = await client.GetAsync("http://localhost:50494/api/Project");
            if (response.IsSuccessStatusCode)
            {
                Products = JsonConvert.DeserializeObject<List<PRProductDTO>>(
                await response.Content.ReadAsStringAsync());
                var res = Products.OrderBy(t => t.PRProdID);
                return View(res);
            }
            return HttpNotFound();
        }
    }
}