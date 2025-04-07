using Microsoft.AspNetCore.Mvc;
using PAW.Models.Products;
using PAW.Services;
using PAW.Models.Products;

namespace PAW.API.Controllers.Products
{
    public class ProductGenController : Controller
    {
        private readonly IProductGenerationService _productGenerationService;

        public ProductGenController(IProductGenerationService productGenerationService)
        {
            _productGenerationService = productGenerationService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GenerateProducts(int count = 5)
        {
            var products = _productGenerationService.Generate(count);
            return Json(products);
        }
    }
}