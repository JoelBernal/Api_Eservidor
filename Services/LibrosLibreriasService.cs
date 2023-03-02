using api_librerias_paco.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_librerias_paco.Services
{
    public class LibroLibreriaService
    {
        private readonly LibreriaContext _context;


        public LibroLibreriaService(LibreriaContext context)
        {
            _context = context;
        }

        public async Task<List<LibrosLibrerias>> GetLibrosLibrerias()
        {
            return await _context.LibroLibrerias.ToListAsync();
        }

        public async Task<LibrosLibrerias> AddLibroLibreria(LibrosLibrerias libroLibreria)
        {
            _context.LibroLibrerias.Add(libroLibreria);
            await _context.SaveChangesAsync();
            return libroLibreria;
        }

        public async Task UpdateLibroLibreria(int idCliente, int idLibro, int idLibreria, LibrosLibrerias libroLibreria)
        {
            var libroLibreriaToUpdate = await _context.LibroLibrerias.FindAsync(idCliente, idLibro, idLibreria);
            if (libroLibreriaToUpdate != null)
            {
                libroLibreriaToUpdate.Recoger = libroLibreria.Recoger;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> DeleteLibroLibreria(int idCliente, int idLibro, int idLibreria)
        {
            var libroLibreriaToDelete = await _context.LibroLibrerias.FirstOrDefaultAsync(l => l.IdCliente == idCliente && l.IdLibro == idLibro && l.IdLibreria == idLibreria);

            if (libroLibreriaToDelete != null)
            {
                _context.LibroLibrerias.Remove(libroLibreriaToDelete);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
