using api_librerias_paco.Models;
using api_librerias_paco.Services;
using Microsoft.AspNetCore.Mvc;

namespace api_librerias_paco.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TiendasController : ControllerBase
    {
        public TiendasController()
        {
        }

        // GET all action
        [HttpGet]
        public ActionResult<List<Tiendas>> GetAll() =>
        TiendasService.GetAll();

        // GET by Id action
        [HttpGet("{id}")]
        public ActionResult<Tiendas> Get(int id)
        {
            var tienda1 = TiendasService.Get(id);

            if (tienda1 == null)
                return NotFound();

            return tienda1;
        }

        // POST action
        [HttpPost]
        public IActionResult Create(Tiendas tiendas)
        {
            TiendasService.Add(tiendas);
            return CreatedAtAction(nameof(Get), new { id = tiendas.id }, tiendas);
        }

        // PUT action
        [HttpPut("{id}")]
        public IActionResult Update(int id, Tiendas tiendas)
        {
            if (id != tiendas.id)
                return BadRequest();

            var existingTienda = TiendasService.Get(id);
            if (existingTienda is null)
                return NotFound();

            TiendasService.Update(tiendas);

            return NoContent();
        }

        // DELETE action
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var tnd = TiendasService.Get(id);

            if (tnd is null)
                return NotFound();

            TiendasService.Delete(id);

            return NoContent();
        }
    }
}

