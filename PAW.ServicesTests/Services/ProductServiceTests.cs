using Xunit;
using PAW.Services;
using PAW.Models.Products;
using Moq;
using System.Collections.Generic;
using Task = System.Threading.Tasks.Task;
using PAW.Architecture.Providers;
using APW.Architecture;

namespace PAW.ServicesTests.Services
{
    public class ProductServiceTests
    {
        [Fact]
        public async Task GetFiveFromFactoryAsync_ShouldReturnFiveProducts()
        {
            // Arrange
            var mockRestProvider = new Mock<IRestProvider>();
            var service = new ProductService(mockRestProvider.Object);

            // Act
            var result = await service.GetFiveFromFactoryAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(5, new List<Product>(result).Count);
        }
    }
}
