using CatGifBackend.Models;

namespace CatGifBackend.Services
{
    public class GiphyService
    {
        private readonly HttpClient _httpClient;
        private const string ApiKey = "voaNIOg1u7ONPbckzWK71C48YqCOkhVP";
        private const string GiphyBaseUrl = "https://api.giphy.com/v1/gifs/search";

        public GiphyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string?> GetGifUrlAsync(string query, int offset)
        {
            Console.WriteLine("Query " + query);
            var url = $"{GiphyBaseUrl}?api_key={ApiKey}&q={Uri.EscapeDataString(query)}&limit=1&offset={offset}";

            var response = await _httpClient.GetFromJsonAsync<GiphyResponse>(url);

            return response?.Data?.FirstOrDefault()?.Images?.Original?.Url;
        }
    }
}
