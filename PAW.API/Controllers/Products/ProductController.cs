using Microsoft.AspNetCore.Mvc;

namespace PAW.API.Controllers.Products
{
    public class ProductController : Controller
    {
        [HttpGet]
        public IActionResult View()
        {
            return View("Index");
        }
    }
}
