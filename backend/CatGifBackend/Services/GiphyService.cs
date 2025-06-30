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
            var url = $"{GiphyBaseUrl}?api_key={ApiKey}&q={Uri.EscapeDataString(query)}&limit=1&offset={offset}";

            var response = await _httpClient.GetAsync(url);

            if (response.StatusCode == System.Net.HttpStatusCode.TooManyRequests)
            {
                return null; // Deja que el controlador maneje la respuesta
            }

            response.EnsureSuccessStatusCode();

            var giphyResponse = await response.Content.ReadFromJsonAsync<GiphyResponse>();
            return giphyResponse?.Data?.FirstOrDefault()?.Images?.Original?.Url;
        }
    }
}
