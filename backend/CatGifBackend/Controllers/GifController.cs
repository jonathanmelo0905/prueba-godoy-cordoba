using CatGifBackend.DTOs;
using CatGifBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace CatGifBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GifController : ControllerBase
    {
        private readonly GiphyService _giphyService;
        private readonly HistorialCatGifService _historialCatGifService;

        public GifController(GiphyService giphyService, HistorialCatGifService historialCatGifService)
        {
            _giphyService = giphyService;
            _historialCatGifService = historialCatGifService;
        }

        [HttpPost]
        public async Task<IActionResult> GetGif([FromBody] GetFactGifDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Query))
                return BadRequest("El parámetro 'query' es obligatorio.");
            if(!dto.Offset.HasValue)return BadRequest("El parámetro 'offset' es obligatorio.");
            Console.WriteLine("gif viejo" + dto.GifUrl);
            var gifUrl = await _giphyService.GetGifUrlAsync(dto.Query, dto.Offset.Value);
            Console.WriteLine("gif nuevo" + gifUrl);
            if (string.IsNullOrEmpty(gifUrl))
                return NotFound("No se encontró ningún gif para la búsqueda.");

            dto.GifUrl = gifUrl;

            var historial = await _historialCatGifService.GuardarBusquedaAsync(dto);

            if (historial == null) return BadRequest("No se puedo Guardar en el Historial");
            return Ok(new { url = gifUrl });
        }
    }
}
