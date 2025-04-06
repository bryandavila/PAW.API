using PAW.Models;
using PAW.Repository;
using PAW.Services;

namespace PAW.Business
{
    public interface IProductManager
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task<Product> GetHighCoasByIdAsync(int id, decimal value);
    }

    public class ProductManager(IProductRepository productRepository, IFinanceService financeService) : IProductManager
    {
        private readonly IProductRepository _productRepository = productRepository;
        private readonly IFinanceService _financeService = financeService;

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var products = new List<Product>();
            return await _productRepository.GetAllProductsAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _productRepository.FindAsync(id);
        }

        public async Task<Product> GetHighCoasByIdAsync(int id, decimal value)
        {
            var exchange = await _financeService.GetTodaysExchangeRateAsync();
            var product= await _productRepository.GetHighCostByIdAsync(id, value);
            product.LastRetreived = DateTime.UtcNow;
            product.UnitPrice*= exchange.Buy; 
            product.IsDirty = true;
            return product;
        }

	}
}
