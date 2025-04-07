using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;
using PAW.Models.Products;
using PAW.Services.Factory;


namespace PAW.Services.Factory;

    public class ProductFactory
    {
        private readonly Faker<Product> _faker;

        public ProductFactory()
        {
            _faker = new Faker<Product>()
                .RuleFor(p => p.ProductId, f => f.IndexFaker + 1)
                .RuleFor(p => p.ProductName, f => f.Commerce.ProductName())
                .RuleFor(p => p.Description, f => f.Commerce.ProductDescription())
                .RuleFor(p => p.UnitPrice, f => f.Random.Decimal(10, 100))
                .RuleFor(p => p.CategoryId, f => f.Random.Int(1, 5));
        }

        public Product CreateOne()
        {
            return _faker.Generate();
        }

        public IEnumerable<Product> CreateMany(int count = 5)
        {
            return _faker.Generate(count);
        }
    }


