using Microsoft.AspNetCore.Mvc;
using PAW.Models.Products;
using PAW.Services;

namespace PAW.API.Controllers.Products
{
    public class ProductGenController(IProductGenerationService service) : Controller
    {
        [HttpGet("/products/generate")]
        public IActionResult GenerateProducts()
        {
            return View();
        }

        [HttpGet("/products/generate/ajax")]
        public IActionResult GetProductsAjax(int count = 5)
        {
            var products = service.Generate(count);
            return Json(products);
        }
    }
}
