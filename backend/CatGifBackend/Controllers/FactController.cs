using CatGifBackend.Context;
using CatGifBackend.DTOs;
using CatGifBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace CatGifBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FactController : ControllerBase
    {
        private readonly CatFactService _catFactService;
        private readonly GiphyService _giphyService;
        private readonly HistorialCatGifService _historialService;

        public FactController(CatFactService catFactService, GiphyService giphyService, HistorialCatGifService historialService)
        {
            _catFactService = catFactService;
            _giphyService = giphyService;
            _historialService = historialService;
        }

        [HttpGet]
        public async Task<ActionResult<GetFactGifDTO>> GetFact()
        {
            var fact = await _catFactService.GetRandomFactAsync();
            Console.WriteLine("MELO => " + fact);
            if (fact == null)return StatusCode(503, "No se pudo obtener el dato del API externo.");

            Console.WriteLine($"MELO => Fact: {fact.Fact}, Query: {fact.Query}, Gif: {fact.GifUrl}");

            await _historialService.GuardarBusquedaAsync(fact);
            if (fact == null) return StatusCode(503, "No se pudo obtener el dato del API externo.");
            return Ok(fact);
        }
    }
}
