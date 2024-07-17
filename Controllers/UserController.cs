using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using CarsiClient.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CarsiClient.Controllers;

// [Route("[controller]")]   KALDIRDIK
public class UserController : Controller
{
    public async Task<IActionResult> Index(string password, string email)
    {
        
        var rootUser = new Root<bool>();
        using (var httpClient = new HttpClient())
        {
            using (HttpResponseMessage httpResponseMessage = await httpClient.GetAsync("http://localhost:5000/api/User/password"))
            {
                if (!httpResponseMessage.IsSuccessStatusCode)
                {
                    return null;
                }
                string contentResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                rootUser = JsonSerializer.Deserialize<Root<bool>>(contentResponse);
            }
        }


      

        return View(rootUser.Data);
    }

    public IActionResult Create()
    {
        return View();
    }

}