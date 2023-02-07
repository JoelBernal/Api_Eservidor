using Microsoft.EntityFrameworkCore;

namespace api_librerias_paco.Models
{

public class LibrosContext : DbContext
{
    public LibrosContext(DbContextOptions<LibrosContext>options)
    : base(options)
    {
}
    DbSet<Libros> Libro {get;set;}= null!;
    DbSet<Clientes> Clientes {get;set;}= null!;

    DbSet<Tiendas> Tiendas {get;set;}= null!;

}

}
