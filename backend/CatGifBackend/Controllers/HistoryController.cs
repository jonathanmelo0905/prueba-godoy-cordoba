using CatGifBackend.Context;
using CatGifBackend.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CatGifBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HistoryController : ControllerBase
    {
        private readonly CatGifContext _context;

        public HistoryController(CatGifContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetHistory()
        {
            try
            {
                var historial = await _context.Historial_catgif
                    .AsNoTracking()
                    .OrderByDescending(h => h.fecha)
                    .Select(h => new HistorialDTO
                    {
                        Fecha = h.fecha,
                        Fact = h.Fact,
                        Query = h.query_text,
                        GifUrl = h.gif_url
                    })
                    .ToListAsync();

                return Ok(historial);
            }
            catch (Exception)
            {
                return BadRequest("Error al obtener el historial.");
            }
        }
    }
}
