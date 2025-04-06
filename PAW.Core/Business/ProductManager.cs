using PAW.Models.Products;
using PAW.Repository.Products;
using PAW.Services;

namespace PAW.Business
{
    public interface IProductManager
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
    }

    public class ProductManager(IProductRepository productRepository, IFinanceService financeService) : IProductManager
    {
        private readonly IProductRepository _productRepository = productRepository;
        private readonly IFinanceService _financeService = financeService;

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var products = new List<Product>();
            return await _productRepository.GetAsync(null);
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            var products = await _productRepository.GetAsync([id]);
            return products.FirstOrDefault();
        }
	}
}
