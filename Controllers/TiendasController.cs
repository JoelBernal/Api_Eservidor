using api_librerias_paco.Models;
using api_librerias_paco.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api_librerias_paco.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TiendasController : ControllerBase
    {
        private readonly LibreriaContext _dbContext;
        public TiendasController(LibreriaContext dbContext)
        {
            _dbContext = dbContext;
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

        // GET: api/Tiendas
        [HttpGet("GetDatosBBDD")]
        public async Task<ActionResult<IEnumerable<Tiendas>>> GetTiendas()
        {
            if (_dbContext.Tiendas == null)
            {
                return NotFound();
            }
            return await _dbContext.Tiendas.ToListAsync();
        }

        // GET clientes de la base por id
        [HttpGet("GETidBBDD/{id}")]
        public async Task<ActionResult<Tiendas>> GetTiendas(int id)
        {
            if (_dbContext.Tiendas == null)
            {
                return NotFound();
            }
            var tienda = await _dbContext.Tiendas.FindAsync(id);

            if (tienda == null)
            {
                return NotFound();
            }
            return tienda;

        }

        [HttpPost("POSTBBDD")]

        public async Task<ActionResult<Tiendas>> PostTiendas(Tiendas tiendas)
        {
            _dbContext.Tiendas.Add(tiendas);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTiendas), new { id = tiendas.id }, tiendas);
        }

        [HttpPut("PutBBDD")]
        public async Task<IActionResult> PutClientes([FromBody] Tiendas tiendas)
        {
            _dbContext.Entry(tiendas).State = EntityState.Modified;

            try
            {
                _dbContext.Tiendas.Update(tiendas);
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

                throw;
            }
            return Ok();
        }

        private bool TiendasExists(long id)
        {
            return (_dbContext.Tiendas?.Any(e => e.id == id)).GetValueOrDefault();
        }


        [HttpDelete("DeleteBBDD/{id}")]

        public async Task<IActionResult> DeleteTiendas(int id)
        {
            if (_dbContext.Tiendas == null)
            {
                return NotFound();
            }
            var tienda = await _dbContext.Tiendas.FindAsync(id);
            if (tienda == null)
            {
                return NotFound();
            }
            _dbContext.Tiendas.Remove(tienda);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("OrdenarPorMasTrabajadores-BBDD")]
        public async Task<ActionResult<IEnumerable<Tiendas>>> GetTiendasOrderByTrabajadores()
        {
            var donOmar = await _dbContext.Tiendas
                .OrderByDescending(l => l.trabajadores)
                .ToListAsync();

            return Ok(donOmar);
        }

    }
}

