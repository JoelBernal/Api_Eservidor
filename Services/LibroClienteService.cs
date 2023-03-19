using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using api_librerias_paco.Models;
using api_librerias_paco.Context;
using api_librerias_paco.Services;
using api_librerias_paco.Controllers;

namespace api_librerias_paco.Services
{
    public class LibroClienteService
    {
        private readonly LibreriaContext _dbContext;

        public LibroClienteService(LibreriaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<LibrosClientes>> GetLibrosCliente(int idCliente)
        {
            return await _dbContext.LibrosClientes

                
               // .Include(lc => lc.Libros)
                .Where(lc => lc.IdCliente == idCliente)
                .ToListAsync();
        }

        public async Task AddLibroCliente(LibrosClientes libroCliente)
        {
            _dbContext.LibrosClientes.Add(libroCliente);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateLibroCliente(int idCliente, int idLibro, string nombreLibro)
        {
            var libroCliente = await _dbContext.LibrosClientes
                .SingleOrDefaultAsync(lc => lc.IdCliente == idCliente && lc.Idlibro == idLibro);

            if (libroCliente != null)
            {
                libroCliente.NombreLibro = nombreLibro;
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteLibroCliente(int idCliente, int idLibro)
        {
            var libroCliente = await _dbContext.LibrosClientes
                .SingleOrDefaultAsync(lc => lc.IdCliente == idCliente && lc.Idlibro == idLibro);

            if (libroCliente != null)
            {
                _dbContext.LibrosClientes.Remove(libroCliente);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}