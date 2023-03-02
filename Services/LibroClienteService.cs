using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using api_librerias_paco.Models;

namespace api_librerias_paco.Services
{
    public class LibroClienteService
    {
        private readonly LibreriaContext _dbContext;

        public LibroClienteService(LibreriaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<LibroCliente>> GetLibrosCliente(int idCliente)
        {
            return await _dbContext.LibrosCliente

                
               // .Include(lc => lc.Libros)
                .Where(lc => lc.IdCliente == idCliente)
                .ToListAsync();
        }

        public async Task AddLibroCliente(LibroCliente libroCliente)
        {
            _dbContext.LibrosCliente.Add(libroCliente);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateLibroCliente(int idCliente, int idLibro, string nombreLibro)
        {
            var libroCliente = await _dbContext.LibrosCliente
                .SingleOrDefaultAsync(lc => lc.IdCliente == idCliente && lc.IdLibro == idLibro);

            if (libroCliente != null)
            {
                libroCliente.NombreLibro = nombreLibro;
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteLibroCliente(int idCliente, int idLibro)
        {
            var libroCliente = await _dbContext.LibrosCliente
                .SingleOrDefaultAsync(lc => lc.IdCliente == idCliente && lc.IdLibro == idLibro);

            if (libroCliente != null)
            {
                _dbContext.LibrosCliente.Remove(libroCliente);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
