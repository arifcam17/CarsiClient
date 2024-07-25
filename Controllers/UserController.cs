using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CarsiClient.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CarsiClient.Controllers;

// [Route("[controller]")]   KALDIRDIK
public class UserController : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        return View();

    }



    [HttpPost]
    public async Task<IActionResult> Login(string password, string email)
    {
        
        
        var rootUser = new Root<bool>();
        using (var httpClient = new HttpClient())
        {
           
            using (HttpResponseMessage httpResponseMessage = await httpClient.GetAsync($"http://localhost:5000/api/User/password?password={password}&email={email}"))
            {
                if (!httpResponseMessage.IsSuccessStatusCode)
                {
                    return null;
                }
                string contentResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                rootUser = JsonSerializer.Deserialize<Root<bool>>(contentResponse);
            }
        }
        if (rootUser?.Data == true)
        {
            //Controller Seper -> Action Index
            return RedirectToAction("Index","Sepet");
        }
        else
        {
            // Aynı sayfa gelecek
            return RedirectToAction("Index", "User");
        } 
        
    }

    [HttpPost]
    public async Task<IActionResult> Create(UserModel user)
    {
        var rootUser = new Root<UserModel>();
        using (var httpClient = new HttpClient())
        {
            var content = new StringContent(JsonSerializer.Serialize(user), Encoding.UTF8, "application/json");

            using (HttpResponseMessage httpResponseMessage = await httpClient.PostAsync("http://localhost:5000/api/User",content))
            {
                if (!httpResponseMessage.IsSuccessStatusCode) 
                { return null; } 
                string contentResponse =await httpResponseMessage.Content.ReadAsStringAsync();

                rootUser = JsonSerializer.Deserialize<Root<UserModel>>(contentResponse);
            }
        }
        if (rootUser.Data == null)
        {
            return RedirectToAction("Create", "User");
        }
        else
        {
            return View(rootUser.Data);
        }
    }

}