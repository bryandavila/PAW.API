using APW.Architecture;
using PAW.Architecture.Providers;
using PAW.Services.Models;

namespace PAW.Services;

public class GamingService(IRestProvider restProvider)
{
    public async Task<ExchangeRate> GetAllGames()
    {
        var today = DateTime.Today;
        var data = await restProvider.GetAsync($"https://gaming/get", null);
        //var products = await JsonProvider.DeserializeAsync<IEnumerable<Product>>(data);
        var result = await JsonProvider.DeserializeAsync<ExchangeRate>(data);
        return result;
    }

    //
}
