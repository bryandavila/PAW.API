using Microsoft.AspNetCore.Mvc;

namespace PAW.API.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
