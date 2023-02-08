using api_librerias_paco.Models;
using api_librerias_paco.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api_librerias_paco.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly LibreriaContext _dbContext;
        public ClientesController(LibreriaContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET all action
        [HttpGet("ClientesApiCode")]
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

        // GET: api/Clientes
        [HttpGet("GetDatosBBDD")]
        public async Task<ActionResult<IEnumerable<Clientes>>> GetClientes()
        {
            if (_dbContext.Clientes == null)
            {
                return NotFound();
            }
            return await _dbContext.Clientes.ToListAsync();
        }

        // GET clientes de la base por id
        [HttpGet("GETidBBDD/{id}")]
        public async Task<ActionResult<Clientes>> GetClientes(int id)
        {
            if (_dbContext.Clientes == null)
            {
                return NotFound();
            }
            var cliente = await _dbContext.Clientes.FindAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }
            return cliente;

        }

        [HttpPost("POSTBBDD")]

        public async Task<ActionResult<Clientes>> PostClientes(Clientes clientes)
        {
            _dbContext.Clientes.Add(clientes);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetClientes), new { id = clientes.Id }, clientes);
        }


    }
}
