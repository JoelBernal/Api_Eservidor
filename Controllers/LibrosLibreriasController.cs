using System.Collections.Generic;
using System.Threading.Tasks;
using api_librerias_paco.Models;
using api_librerias_paco.Services;
using Microsoft.AspNetCore.Mvc;

namespace api_librerias_paco.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibrosLibreriasController : ControllerBase
    {

        private readonly LibroLibreriaService _librosLibreriasService;
        private readonly LibreriaContext _context;

        public LibrosLibreriasController(LibreriaContext context)
        {
            _context = context;
            _librosLibreriasService = new LibroLibreriaService(_context);
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<LibrosLibrerias>>> GetLibrosLibrerias()
        {
            var librosLibrerias = await _librosLibreriasService.GetLibrosLibrerias();
            return Ok(librosLibrerias);
        }

      //  [HttpGet("{idLibreria}")]
      //  public async Task<IEnumerable<LibrosLibrerias>> GetLibrosLibreria(int idLibreria)
       // {
      //      var YSYA = await _librosLibreriasService.GetLibrosLibrerias(idLibreria);

       //     if (YSYA == null)
       //     {
         //       return NotFound();
         //   }

       //     return YSYA;
      //  }


        [HttpPost]
        public async Task<ActionResult<LibrosLibrerias>> AddLibroLibreria(LibrosLibrerias libroLibreria)
        {
            await _librosLibreriasService.AddLibroLibreria(libroLibreria);
            return Ok(libroLibreria);
        }

        [HttpPut("{idCliente}/{idLibro}/{idLibreria}")]
        public async Task<IActionResult> UpdateLibroLibreria(int idCliente, int idLibro, int idLibreria, [FromBody] LibrosLibrerias libroLibreria)
        {
            if (idCliente != libroLibreria.IdCliente || idLibro != libroLibreria.IdLibro || idLibreria != libroLibreria.IdLibreria)
            {
                return BadRequest();
            }

            await _librosLibreriasService.UpdateLibroLibreria(idCliente, idLibro, idLibreria, libroLibreria);
            return NoContent();
        }


        [HttpDelete("{idCliente}/{idLibro}/{idLibreria}")]
        public async Task<IActionResult> DeleteLibroLibreria(int idCliente, int idLibro, int idLibreria)
        {
            await _librosLibreriasService.DeleteLibroLibreria(idCliente, idLibro, idLibreria);
            return NoContent();
        }
    }
}
