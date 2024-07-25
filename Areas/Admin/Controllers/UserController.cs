using CarsiClient.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CarsiClient.Areas.Admin.Controllers
{

    [Area("admin")]
    public class UserController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            
            var rootUser = new Root<User>();
            using (var httpClient = new HttpClient())
            {
                using (HttpResponseMessage httpResponseMessage = await httpClient.GetAsync("http://localhost:5000/api/User/password"))
                {
                    if (!httpResponseMessage.IsSuccessStatusCode)
                    {
                        return null;
                    }
                    string contentResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                    rootUser = JsonSerializer.Deserialize<Root<User>>(contentResponse);
                }
            }
            return View(rootUser.Data);
        }

        
        public async Task<IActionResult> Create() 
        {
            var rootUser = new Root<List<User>>();
            using (var httpClient = new HttpClient())
            {
                using (HttpResponseMessage httpResponseMessage = await httpClient.GetAsync("http://localhost:5000/api/User"))
                {
                    if (!httpResponseMessage.IsSuccessStatusCode)
                    {
                        return null;
                    }
                    string contentResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                    rootUser = JsonSerializer.Deserialize<Root<List<User>>>(contentResponse);
                }
            }
            return View(rootUser.Data);
        }


    

        [HttpDelete]
        public IActionResult Delete()
        {
            return View();
        }
        [HttpPut]
        public IActionResult Update()
        {
            return View();
        }

       
    }
}
