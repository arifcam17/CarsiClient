using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CarsiClient.Models;
using CarsiClient.Repo;
using System.Text.Json;

namespace CarsiClient.Controllers
{
    public class SepetController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var rootProducts = new Root<List<ProductModel>>();
            
            using (var httpClient = new HttpClient())
            {
                using (HttpResponseMessage httpResponseMessage = await httpClient.GetAsync("http://localhost:5000/api/Product"))
                {
                    if (!httpResponseMessage.IsSuccessStatusCode)
                    {
                        return null;
                    }
                    string contentResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                    rootProducts = JsonSerializer.Deserialize<Root<List<ProductModel>>>(contentResponse);
                }
            }


           

            return View(rootProducts.Data);
        }
    
    }
}
