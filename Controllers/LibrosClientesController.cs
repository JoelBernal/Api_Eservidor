
using api_librerias_paco.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api_librerias_paco.Services;
using api_librerias_paco.Models;

namespace api_librerias_paco.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LibrosClientesController : ControllerBase
    {
        private readonly LibreriaContext _dbContext;
        private readonly LibroClienteService _libroClienteService;

        public LibrosClientesController(LibreriaContext dbContext, LibroClienteService libroClienteService)
        {
            _dbContext = dbContext;
            _libroClienteService = libroClienteService;
        }

        [HttpGet("{idCliente}")]
        public async Task<ActionResult<List<LibrosClientes>>> GetLibrosCliente(int idCliente)
        {
            var librosCliente = await _libroClienteService.GetLibrosCliente(idCliente);

            if (librosCliente == null)
            {
                return NotFound();
            }

            return librosCliente;
        }

        [HttpPost]
        public async Task<ActionResult> AddLibroCliente(LibrosClientes libroCliente)
        {
            bool exists = await _dbContext.LibrosClientes.AnyAsync(lc => lc.IdCliente == libroCliente.IdCliente && lc.Idlibro == libroCliente.Idlibro);
            bool prueba = await _dbContext.Clientes.AnyAsync(cc => cc.Id == libroCliente.IdCliente);
            bool prueba2 = await _dbContext.Libro.AnyAsync(cc => cc.Id == libroCliente.Idlibro);

            if (exists)
            {
                return BadRequest("El libro ya está asignado a este cliente.");
            }

            if (prueba == false)
            {

                return BadRequest("No hay ningun cliente que tenga esta Id, tienes que asignar el libro a una Id que exista");
            }

            if (prueba2 == false)
            {

                return BadRequest("No hay ningun libro que tenga esta Id");
            }

            await _libroClienteService.AddLibroCliente(libroCliente);
            return Ok();
        }

        [HttpPut("{idCliente}/{idLibro}")]
        public async Task<ActionResult> UpdateLibroCliente(int idCliente, int idLibro, string nombreLibro)
        {
            await _libroClienteService.UpdateLibroCliente(idCliente, idLibro, nombreLibro);

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