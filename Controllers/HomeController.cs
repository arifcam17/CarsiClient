using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CarsiClient.Models;
using CarsiClient.Repo;
using System.Text.Json;

namespace CarsiClient.Controllers;

public class HomeController : Controller
{
    //BIR TEK INDEX KALACAK SEKILDE TEMIZLEDIK



    public async Task<IActionResult> Index()
    {
        var rootProducts = new Root<List<ProductModel>>();
        var rootUser = new Root<UserModel>();

        using (var httpClient = new HttpClient())
        {
            using (HttpResponseMessage httpResponseMessage = await httpClient.GetAsync("http://localhost:5000/api/Product/homeproducts"))
            {
                if (!httpResponseMessage.IsSuccessStatusCode)
                {
                    return null;
                }
                string contentResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                rootProducts = JsonSerializer.Deserialize<Root<List<ProductModel>>>(contentResponse);
            }
        }


        var homePageModel = new HomePageModel
        {
            Products = rootProducts.Data,
            User = rootUser.Data,


        };

        return View(homePageModel);
    }




}
