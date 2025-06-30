using CatGifBackend.Context;
using CatGifBackend.DTOs;

namespace CatGifBackend.Services
{
    public class HistorialCatGifService
    {
        private readonly CatGifContext _catGifContext;

        public HistorialCatGifService(CatGifContext catGifContext)
        {
            _catGifContext = catGifContext;
        }

        public async Task<Historial_catgif?> GuardarBusquedaAsync(GetFactGifDTO dto)
        {
            try
            {
                Console.WriteLine($"Guardando búsqueda: Fact='{dto.Fact}', Query='{dto.Query}', Gif='{dto.GifUrl}'");

                var historial = new Historial_catgif
                {
                    Fact = dto.Fact,
                    fecha = DateTime.Now,
                    gif_url = dto.GifUrl,
                    query_text = dto.Query
                };

                _catGifContext.Historial_catgif.Add(historial);
                await _catGifContext.SaveChangesAsync();
                Console.WriteLine($"Guardado con ID: {historial.id_cat}");

                return historial;
            }
            catch (Exception ex)
            {
                // Aquí podrías loguear el error con ILogger
                return null;
            }
        }
    }
}
