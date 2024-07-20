using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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


    public IActionResult Create()
    {
        return View();
    }

}