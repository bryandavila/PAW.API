using Microsoft.AspNetCore.Mvc;
using PAW.Services;

namespace PAW.API.Controllers.Products
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("/Product")]
        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpGet("/Product/GetFivePartial")]
        public async Task<IActionResult> GetFivePartial()
        {
            var products = await _productService.GetFiveFromFactoryAsync();
            return PartialView("~/Views/ProductGen/_ProductTablePartial.cshtml", products);
        }
    }
}
