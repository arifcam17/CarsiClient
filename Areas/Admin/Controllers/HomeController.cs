using Microsoft.AspNetCore.Mvc;

namespace CarsiClient.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        [Area ("admin")]   //BUNU EKLIYOTUZ
        public IActionResult Index()
        {
            return View();
        }
    }
}
