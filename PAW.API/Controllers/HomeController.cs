using Microsoft.AspNetCore.Mvc;

namespace PAW.API.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
