using Xunit;
using PAW.Repository.Products;
using PAW.Models.Products;
using System.Linq;
using System.Collections.Generic;

namespace PAW.RepositoryTests.Products
{
    public class ProductRepositoryTests
    {
        private readonly ProductRepository _repository;

        public ProductRepositoryTests()
        {
            _repository = new ProductRepository();
        }

        [Fact]
        public async System.Threading.Tasks.Task GetAllProductsAsync_ShouldReturnProducts()
        {
            var products = await _repository.GetAllProductsAsync();
            Assert.NotNull(products);
            Assert.NotEmpty(products);
        }

        [Fact]
        public async System.Threading.Tasks.Task FindAsync_ShouldReturnProductById()
        {
            var product = await _repository.FindAsync(1);
            Assert.NotNull(product);
            Assert.Equal(1, product.ProductId);
        }

        [Fact]
        public async System.Threading.Tasks.Task GetHighCostByIdAsync_ShouldReturnProductWithExpectedPrice()
        {
            var value = 999m;
            var product = await _repository.GetHighCostByIdAsync(2, value);
            Assert.NotNull(product);
            Assert.Equal(2, product.ProductId);
            Assert.Equal(value, product.UnitPrice);
        }
    }
}
