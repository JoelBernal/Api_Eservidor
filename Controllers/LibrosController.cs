using api_librerias_paco.Models;
using api_librerias_paco.Services;
using Microsoft.AspNetCore.Mvc;

namespace api_librerias_paco.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LibrosController : ControllerBase
    {
        public LibrosController()
        {
        }

        // GET all action
        [HttpGet]
        public ActionResult<List<Libros>> GetAll() =>
        LibrosService.GetAll();

        // GET by Id action
        [HttpGet("{id}")]
        public ActionResult<Libros> Get(int id)
        {
            var libro1 = LibrosService.Get(id);

            if (libro1 == null)
                return NotFound();

            return libro1;
        }

        // POST action
        [HttpPost]
        public IActionResult Create(Libros libros)
        {
            LibrosService.Add(libros);
            return CreatedAtAction(nameof(Get), new { id = libros.Id }, libros);
        }

        // PUT action
        [HttpPut("{id}")]
        public IActionResult Update(int id, Libros libros)
        {
            if (id != libros.Id)
                return BadRequest();

            var existingLibro = LibrosService.Get(id);
            if (existingLibro is null)
                return NotFound();

            LibrosService.Update(libros);

            return NoContent();
        }

        // DELETE action
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var libro = LibrosService.Get(id);

            if (libro is null)
                return NotFound();

            LibrosService.Delete(id);

            return NoContent();
        }
    }
}

