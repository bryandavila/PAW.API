using Xunit;
using PAW.Services.Factory;
using PAW.Models.Products;
using System.Linq;

namespace PAW.ServicesTests.Factory
{
    public class ProductFactoryTests
    {
        [Fact]
        public void CreateOne_ShouldReturnValidProduct()
        {
            var factory = new ProductFactory();
            var product = factory.CreateOne();

            Assert.NotNull(product);
            Assert.False(string.IsNullOrWhiteSpace(product.ProductName));
            Assert.True(product.UnitPrice > 0);
        }


        [Fact]
        public void CreateMany_ShouldReturnExactCount()
        {
            var factory = new ProductFactory();
            var products = factory.CreateMany(5);

            Assert.Equal(5, products.Count());
        }
    }
}
