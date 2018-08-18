using DCSPCS.DAL.DBWarehouse.DbLayer;
using DCSPCS.Repository.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DCSPCS.ConsoleTestApp
{
    
    class Program
    {
        //static HttpClient client = new HttpClient();

        //static void ShowProduct(WREquipment product)
        //{
        //    Console.WriteLine($"Name: {product.WREquipUnits}\tDescription: " +
        //        $"{product.WREquipDescr}\tVendor: {product.WREquipVendorID}");
        //}


        //static async Task<Uri> CreateProductAsync(WREquipment product)
        //{
        //    HttpResponseMessage response = await client.PostAsJsonAsync(
        //        "api/Warehouse", product);
        //    response.EnsureSuccessStatusCode();

        //    // return URI of the created resource.
        //    return response.Headers.Location;
        //}

        //static async Task<WREquipment> GetProductAsync(string path)
        //{
        //    WREquipment product = null;
        //    HttpResponseMessage response = await client.GetAsync(path);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        product = await response.Content.ReadAsAsync<WREquipment>();
        //    }
        //    return product;
        //}
        static void Main(string[] args)
        {
            //MyContextFactory factory = new MyContextFactory();
            //var test = factory.GetWarehouseContext();
            //foreach(var item in test.Set<WREquipment>().ToList())
            //{
            //    Console.WriteLine(item.WREquipUnits);
            //}

        }

        //static async Task RunAsync()
        //{
        //    // Update port # in the following line.
        //    client.BaseAddress = new Uri("http://localhost:50494/");
        //    client.DefaultRequestHeaders.Accept.Clear();
        //    client.DefaultRequestHeaders.Accept.Add(
        //        new MediaTypeWithQualityHeaderValue("application/json"));

        //    try
        //    {
        //        // Create a new product
        //        WREquipment product = new WREquipment
        //        {
        //           WREquipUnits = "test",
        //           WREquipDescr = "some text",
        //           WREquipVendorID = 1
        //        };

        //        var url = await CreateProductAsync(product);
        //        Console.WriteLine($"Created at {url}");
        //        // Get the product
        //        product = await GetProductAsync(url.PathAndQuery);
        //        ShowProduct(product);

        //        // Update the product

        //        // Get the updated product
        //        product = await GetProductAsync(url.PathAndQuery);
        //        ShowProduct(product);

        //        // Delete the product

        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //    }

        //    Console.ReadLine();
        //}
    }
}
