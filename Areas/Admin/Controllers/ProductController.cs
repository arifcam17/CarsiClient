
using CarsiClient.Areas.Admin.Models;

using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CarsiClient.Areas.Admin.Controllers
{
    [Area("admin")]
    public class ProductController : Controller
    {
        
       public async Task<IActionResult> Index()
        {
            var rootProducts = new Root<List<Product>> ();
            var rootUser = new Root<List<User>>();
            using (var httpClient = new HttpClient())
            {
                using (HttpResponseMessage httpResponseMessage = await httpClient.GetAsync("http://localhost:5000/api/Product"))
                {
                    if (!httpResponseMessage.IsSuccessStatusCode)
                    {
                        return null;
                    }
                    string contentResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                    rootProducts = JsonSerializer.Deserialize<Root<List<Product>>>(contentResponse);
                }
            }
            return View(rootProducts.Data);
        }

        
       public async Task<IActionResult> Create() 
        {
            

            var rootProducts = new Root<List<Product>>();
            var rootUser = new Root<List<User>>();
            using (var httpClient = new HttpClient())
            {
                using (HttpResponseMessage httpResponseMessage = await httpClient.GetAsync("http://localhost:5000/api/Product"))
                {
                    if (!httpResponseMessage.IsSuccessStatusCode)
                    {
                        return null;
                    }
                    string contentResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                    rootProducts = JsonSerializer.Deserialize<Root<List<Product>>>(contentResponse);
                }
            }
            AddProduct addProduct = new AddProduct();

            return View(addProduct);
        }

        public IActionResult Delete()
        {
            return View();
        }


        public IActionResult Update()
        {
            return View();
        }
    }
}
