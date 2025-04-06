using APW.Architecture;
using PAW.Architecture.Providers;
using PAW.Models.Products;
using static PAW.Services.ProductService;

namespace PAW.Services;

public interface IProductService
{
    Task<IEnumerable<Product>> GetAllProductsAsync();
    Task<IEnumerable<HaughProduct>> GetDataFromSqlAzureAsync();
}

public class ProductService(IRestProvider restProvider) : IProductService
{
    private readonly IRestProvider _restProvider = restProvider;

    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        var data = await _restProvider.GetAsync($"http://localhost:5202/ProductApi/all", null);
        var products = JsonProvider.DeserializeSimple<IEnumerable<Product>>(data);
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
}
