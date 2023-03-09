using Microsoft.EntityFrameworkCore;
using api_librerias_paco.Models;

namespace api_librerias_paco.Context
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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
{ 

            modelBuilder.Entity<Tiendas>()
            .HasOne(p => p.Libros)
            .WithMany(p => p.Tiendas)
            .HasForeignKey(p => p.libroId);

             modelBuilder.Entity<Clientes>()
            .HasOne(p => p.Libros)
            .WithMany(p => p.Clientes)
            .HasForeignKey(p => p.libroId);
}


    }}