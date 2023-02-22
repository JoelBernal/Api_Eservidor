using Microsoft.EntityFrameworkCore;
using api_librerias_paco.Models;

namespace api_librerias_paco.Models
{

    public class LibreriaContext : DbContext
    {
        public LibreriaContext(DbContextOptions<LibreriaContext> options)
           : base(options)
        {
        }
        public DbSet<Libros> Libro { get; set; } = null!;
        public DbSet<Clientes> Clientes { get; set; } = null!;
        public DbSet<Tiendas> Tiendas { get; set; } = null!;
        public DbSet<LibroCliente> LibrosCliente { get; set; } = null!;
    }

}

// public class LibreriaContext : DbContext
// {
//     public LibreriaContext(DbContextOptions<LibreriaContext> options)
//     : base(options)
//     {
//     }
//     public DbSet<Libros> Libro { get; set; } = null!;
//     public DbSet<Clientes> Clientes { get; set; } = null!;
//     public DbSet<Tiendas> Tiendas { get; set; } = null!;
//     public DbSet<LibroCliente> LibrosCliente { get; set; } = null!;
// }
