using CatGifBackend.DTOs;
using CatGifBackend.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CatGifBackend.Services
{
    public class CatFactService
    {
        private readonly HttpClient _httpClient;
        private readonly GiphyService _giphyService;

        public CatFactService(HttpClient httpClient, GiphyService giphyService)
        {
            _httpClient = httpClient;
            _giphyService = giphyService;
        }

        public async Task<GetFactGifDTO?> GetRandomFactAsync()
        {
            var catFact = await _httpClient.GetFromJsonAsync<CatFact>("https://catfact.ninja/fact");

            if (catFact == null || string.IsNullOrWhiteSpace(catFact.Fact))
                return null;

            // Limpiar y dividir la frase
            var words = catFact.Fact.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var query = string.Join(" ", words.Take(3));

            // Buscar el gif relacionado
            string gifUrl = await _giphyService.GetGifUrlAsync(query, 1);

            // Crear el resultado
            return new GetFactGifDTO
            {
                Fact = catFact.Fact,
                Query = query,
                GifUrl = gifUrl,
                Offset = 1
            };
        }
    }
}
