using APW.Architecture;
using PAW.Architecture.Providers;
using PAW.Services.Models;

namespace PAW.Services
{
    public interface IFinanceService
    {
        Task<ExchangeRate> GetTodaysExchangeRateAsync();
    }

    public class FinanceService(IRestProvider restProvider) : IFinanceService
    {
        private readonly IRestProvider _restProvider = restProvider;

        public async Task<ExchangeRate> GetTodaysExchangeRateAsync()
        {
            var today = DateTime.Today;
            var data = await _restProvider.GetAsync($"https://tipodecambio.paginasweb.cr/api//{today.Day}/{today.Month}/{today.Year}", null);
            //var products = await JsonProvider.DeserializeAsync<IEnumerable<Product>>(data);
            var result = await JsonProvider.DeserializeAsync<ExchangeRate>(data);
            return result;
        }
    }
}
