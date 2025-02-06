using PAW.Models.Models;
using PAW.Data.Repository;
using System.Collections.Generic;

namespace PAW.Business
{
    public interface IProductManager
    {
        IEnumerable<Products> CreateProduct();
        IEnumerable<Products> GetAllProducts();
    }

    public class ProductManager : IProductManager
    {
        private readonly IProductRepository _productRepository;

        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<Products> CreateProduct()
        {
            var products = new List<Products>();
            for (var i = 0; i < 1000; i++)
                products.Add(new Products
                {
                    ProductId = i,
                    ProductName = i % 2 == 0 ? "Coca Cola" : "Play Station 5",
                    SupplierId = i % 2 == 0 ? 1 : 2,
                    CategoryId = i % 2 == 0 ? 1 : 2,
                    UnitPrice = i % 2 == 0 ? 100 : 349.67M,
                    QuantityPerUnit = i % 2 == 0 ? "1 liter" : "1 unit",
                    UnitsInStock = 100
                });

            return products;
        }

        public IEnumerable<Products> GetAllProducts()
        {
            return _productRepository.GetAll();
        }
    }
}