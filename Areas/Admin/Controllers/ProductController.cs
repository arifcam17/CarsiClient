
using CarsiClient.Areas.Admin.Models;
using CarsiClient.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;
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
            

           
            var rootProduct = new Root<List<Product>>();
            
            using (var httpClient = new HttpClient())
            {
                using (HttpResponseMessage httpResponseMessage = await httpClient.GetAsync("http://localhost:5000/api/Product"))
                {
                    if (!httpResponseMessage.IsSuccessStatusCode)
                    {
                        return null;
                    }
                    string contentResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                    rootProduct = JsonSerializer.Deserialize<Root<List<Product>>>(contentResponse);
                }
            }

            AddProduct product = new AddProduct
            {

            };
            

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddProduct product)
        {
            if (ModelState.IsValid)
            {

                using (var httpClient = new HttpClient())
                {
                    var content = new StringContent(JsonSerializer.Serialize(product), Encoding.UTF8, "application/json");
                    var result = await httpClient.PostAsync("http://localhost:5000/api/Product", content);


                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }


                }

            }   

            return View(product);
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
