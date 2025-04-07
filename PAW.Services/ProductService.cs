using APW.Architecture;
using PAW.Architecture.Providers;
using PAW.Services.Factory;
using ProductModel = PAW.Models.Products.Product;
using System.Threading.Tasks;
using static PAW.Services.ProductService;

namespace PAW.Services;

public interface IProductService
{
    Task<IEnumerable<ProductModel>> GetAllProductsAsync();
    Task<IEnumerable<HaughProduct>> GetDataFromSqlAzureAsync();
    Task<IEnumerable<ProductModel>> GetFiveFromFactoryAsync();
}

public class ProductService(IRestProvider restProvider) : IProductService
{
    private readonly IRestProvider _restProvider = restProvider;

    public async Task<IEnumerable<ProductModel>> GetAllProductsAsync()
    {
        var data = await _restProvider.GetAsync($"http://localhost:5202/ProductApi/all", null);
        var products = JsonProvider.DeserializeSimple<IEnumerable<ProductModel>>(data);
        return products;
    }

    public class HaughProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    public async Task<IEnumerable<HaughProduct>> GetDataFromSqlAzureAsync()
    {
        var data = await _restProvider.GetAsync($"https://haughapi.azurewebsites.net/haugh", null);
        var products = JsonProvider.DeserializeSimple<IEnumerable<HaughProduct>>(data);
        return products;
    }

    public async Task<IEnumerable<ProductModel>> GetFiveFromFactoryAsync()
    {
        var factory = new ProductFactory();
        return await Task.FromResult(factory.CreateMany(5));
    }
}
