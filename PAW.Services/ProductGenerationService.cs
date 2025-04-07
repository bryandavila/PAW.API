using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PAW.Services.Factory;
using PAW.Models.Products;


namespace PAW.Services
{
    public interface IProductGenerationService
    {
        IEnumerable<Product> Generate(int count = 5);
    }

    public class ProductGenerationService : IProductGenerationService
    {
        private readonly ProductFactory _factory;

        public ProductGenerationService()
        {
            _factory = new ProductFactory();
        }

        public IEnumerable<Product> Generate(int count = 5)
        {
            return _factory.CreateMany(count);
        }
    }
}

