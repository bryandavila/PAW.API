using Microsoft.AspNetCore.Mvc;
using PAW.Business;
using PAW.Models;
using PAW.Models.Models;

namespace PAW.Mvc.Controllers
{
    public abstract class MainController : Controller
    {
        protected readonly IProductManager _productManager; // Se cambia a protected
        protected readonly ICategoriesManager _categoriesManager;
        protected readonly ISuppliersManager _suppliersManager;

        public MainController(IProductManager productManager, ICategoriesManager categoriesManager, ISuppliersManager suppliersManager)
        {
            _productManager = productManager;
            _categoriesManager = categoriesManager;
            _suppliersManager = suppliersManager;
        }

        public IEnumerable<Products> GetMyProduct => _productManager.CreateProduct();
        public IEnumerable<Categories> GetMyCategories => _categoriesManager.GetCategories();
        public IEnumerable<Suppliers> GetMySuppliers => _suppliersManager.GetSuppliers();
    }
}