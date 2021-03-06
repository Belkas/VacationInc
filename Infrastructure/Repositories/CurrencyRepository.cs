using Application.Common.Interfaces;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private readonly HttpClient _client;

        public CurrencyRepository(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient(HttpClientConstants.CurrencyLayer);
        }

        public async Task<decimal> GetExchangeRate(string currency)
        {
            var result = await _client.GetAsync("Live");
            var json = JObject.Parse(await result.Content.ReadAsStringAsync());
            // Leaving USD as part of a key, since trial version only allows USD -> something, not something difficult to change after getting non trial version
            return (decimal)json["quotes"][$"USD{currency}"];
        }
    }
}
