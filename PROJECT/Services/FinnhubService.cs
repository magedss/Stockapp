using PROJECT.ServiceContracts;
using System.Text.Json;

namespace PROJECT.Services
{
    public class FinnhubService : IFinnhubService

    {
        private readonly HttpClient httpClient;
        private readonly string token;

        public FinnhubService(HttpClient httpClient, IConfiguration configuration)
        {
            this.httpClient = httpClient;
            token = configuration["Finnhub:Token"] ?? throw new ArgumentNullException("API token is missing");
        }

        public Task<Dictionary<string, object>?> GetCompanyProfile(string stockSymbol)
        {
            return GetResponse($"https://finnhub.io/api/v1/stock/profile2?symbol={stockSymbol}&token={token}");
        }

        public Task<Dictionary<string, object>?> GetStockPriceQuote(string stockSymbol)
        {
            return GetResponse($"https://finnhub.io/api/v1/quote?symbol={stockSymbol}&token={token}");
        }

        public async Task<Dictionary<string, object>?> GetResponse(string url)
        {
            var  resp = await httpClient.GetAsync(url);
            if (!resp.IsSuccessStatusCode)
            {
                return null;
            }
            var responseString= await resp.Content.ReadAsStringAsync();
            var DeserializedResult=JsonSerializer.Deserialize<Dictionary<string, object>>(responseString);
            return DeserializedResult;
        }

    }
}
