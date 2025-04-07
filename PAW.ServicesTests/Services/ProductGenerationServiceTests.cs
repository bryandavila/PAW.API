using Xunit;
using PAW.Services;
using PAW.Models.Products;
using System.Linq;

namespace PAW.ServicesTests.Services
{
    public class ProductGenerationServiceTests
    {
        [Fact]
        public void Generate_ShouldReturnProducts()
        {
            // Arrange
            var service = new ProductGenerationService();

            // Act
            var result = service.Generate(5);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(5, result.Count());
            Assert.All(result, p =>
            {
                Assert.False(string.IsNullOrWhiteSpace(p.ProductName));
                Assert.True(p.UnitPrice > 0);
            });
        }

        [Fact]
        public void Generate_DefaultCount_ShouldReturnFiveProducts()
        {
            var service = new ProductGenerationService();
            var result = service.Generate();
            Assert.Equal(5, result.Count());
        }
    }
}
