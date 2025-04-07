using Microsoft.AspNetCore.Mvc;
using PAW.Models.Products;
using PAW.Services;

namespace PAW.API.Controllers.Products;

public class ProductGenController : Controller
{
    private readonly IProductGenerationService _productGenerationService;
    private readonly IProductService _productService;

    public ProductGenController(
        IProductGenerationService productGenerationService,
        IProductService productService)
    {
        _productGenerationService = productGenerationService;
        _productService = productService;
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

    [HttpGet]
    public async Task<IActionResult> GetFivePartial()
    {
        var products = await _productService.GetFiveFromFactoryAsync();
        return PartialView("_ProductTablePartial", products);
    }
}
