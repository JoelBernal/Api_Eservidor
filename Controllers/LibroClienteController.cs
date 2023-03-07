using api_librerias_paco.Models;
using api_librerias_paco.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api_librerias_paco.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LibroClienteController : ControllerBase
    {
        private readonly LibreriaContext _dbContext;
        private readonly LibroClienteService _libroClienteService;

        public LibroClienteController(LibreriaContext dbContext)
        {
            _dbContext = dbContext;
            _libroClienteService = new LibroClienteService(_dbContext);
        }

        [HttpGet]
        public async Task<ActionResult<List<LibroCliente>>> GetAllLibros()
        {
            var librosCliente = await _libroClienteService.GetAllLibros();


            return Ok(librosCliente);
        }

        [HttpGet("{idCliente}")]
        public async Task<ActionResult<List<LibroCliente>>> GetLibrosCliente(int idCliente)
        {
            var librosCliente = await _libroClienteService.GetLibrosCliente(idCliente);

            if (librosCliente == null)
            {
                return NotFound();
            }

            return librosCliente;
        }

        [HttpPost]
        public async Task<ActionResult> AddLibroCliente(LibroCliente libroCliente)
        {
            bool exists = await _dbContext.LibrosCliente.AnyAsync(lc => lc.IdCliente == libroCliente.IdCliente && lc.IdLibro == libroCliente.IdLibro);
            bool prueba = await _dbContext.Clientes.AnyAsync(cc => cc.Id == libroCliente.IdCliente);

            if (exists)
            {
                return BadRequest("El libro ya está asignado a este cliente.");
            }

            if (prueba == false)
            {

                return BadRequest("No hay ningun cliente que tenga esta Id, tienes que asignar el libro a una Id que exista");
            }

            await _libroClienteService.AddLibroCliente(libroCliente);
            return Ok();
        }

        [HttpPut("{idCliente}/{idLibro}")]
        public async Task<ActionResult> UpdateLibroCliente(int Id, [FromBody] LibroCliente libroCliente)
        {
            await _libroClienteService.UpdateLibroCliente(Id, libroCliente);

            return Ok();
        }

        [HttpDelete("{idCliente}/{idLibro}")]
        public async Task<ActionResult> DeleteLibroCliente(int idCliente, int idLibro)
        {
            await _libroClienteService.DeleteLibroCliente(idCliente, idLibro);

            return Ok();
        }
    }


}

