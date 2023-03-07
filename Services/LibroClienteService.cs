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

        public async Task<List<LibroCliente>> GetAllLibros()
        {
            return await _dbContext.LibrosCliente




                .ToListAsync();
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

        public async Task UpdateLibroCliente(int Id, LibroCliente libroCliente)
        {
            var libroClienteToUpdate = await _dbContext.LibrosCliente.FindAsync(Id);

            if (libroClienteToUpdate == null)
            {
                throw new ArgumentException("El id proporcionado no corresponde a ningún registro en la tabla LibrosLibrerias.");
            }

            
            libroClienteToUpdate.IdCliente = libroCliente.IdCliente;
            libroClienteToUpdate.IdLibro = libroCliente.IdLibro;
            libroClienteToUpdate.NombreLibro = libroCliente.NombreLibro;
            

            await _dbContext.SaveChangesAsync();
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
