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
        public DbSet<LibrosClientes> LibrosClientes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=tcp:apilibreriaspaco.database.windows.net,1433;Initial Catalog=LibreriaBBDD;Persist Security Info=False;User ID=SuperAdmin;Password=Mandangon123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
{ 

            modelBuilder.Entity<Tiendas>()
            .HasOne(p => p.Libros)
            .WithMany(p => p.Tiendas)
            .HasForeignKey(p => p.libroId)
            .OnDelete(DeleteBehavior.NoAction);

              modelBuilder.Entity<LibrosClientes>()
            .HasKey(lc => new { lc.Id });

            //conexion tabla intermedia y libros
                modelBuilder.Entity<LibrosClientes>()
            .HasOne(lc => lc.Libro) 
            .WithMany(l => l.LibrosClientes);
            //.HasForeignKey(lc => lc.Idlibro);

            //conexion tabla intermedia y clientes
                modelBuilder.Entity<LibrosClientes>()
            .HasOne(lc => lc.Cliente) 
            .WithMany(c => c.LibrosClientes);
           // .HasForeignKey(lc => lc.IdCliente);


}



}}