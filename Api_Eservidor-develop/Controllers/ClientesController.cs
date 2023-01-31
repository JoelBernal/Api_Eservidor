using api_librerias_paco.Models;
using api_librerias_paco.Services;
using Microsoft.AspNetCore.Mvc;

namespace api_librerias_paco.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientesController : ControllerBase
    {
        public ClientesController()
        {
        }

        // GET all action
        [HttpGet]
        public ActionResult<List<Clientes>> GetAll() =>
        ClientesService.GetAll();

        // GET by Id action
        [HttpGet("{id}")]
        public ActionResult<Clientes> Get(int id)
        {
            var cl1 = ClientesService.Get(id);

            if (cl1 == null)
                return NotFound();

            return cl1;
        }



// GET by Id action
        [HttpGet("findByEmail/{correo}")]
        public ActionResult<Clientes> Get(string correo)
        {
            var cl2 = ClientesService.Get(correo);

            if (cl2 == null)
                return NotFound();

            return cl2;
        }






        // POST action
        [HttpPost]
        public IActionResult Create(Clientes Clientes)
        {
            ClientesService.Add(Clientes);
            return CreatedAtAction(nameof(Get), new { id = Clientes.Id }, Clientes);
        }

        // PUT action
        [HttpPut("{id}")]
        public IActionResult Update(int id, Clientes Clientes)
        {
            if (id != Clientes.Id)
                return BadRequest();

            var existingCl = ClientesService.Get(id);
            if (existingCl is null)
                return NotFound();

            ClientesService.Update(Clientes);

            return NoContent();
        }

        // DELETE action
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var cl2 = ClientesService.Get(id);

            if (cl2 is null)
                return NotFound();

            ClientesService.Delete(id);

            return NoContent();
        }
    }
}
