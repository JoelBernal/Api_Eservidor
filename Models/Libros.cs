using Newtonsoft.Json;


namespace api_librerias_paco.Models
{

    public class Libros
    {
        public int Id { get; set; }

        public string? Titulo { get; set; }
        public decimal? Precio { get; set; }
        public string? Autor { get; set; }

        public int? Paginas { get; set; }

        public bool? enVenta { get; set; }

        public string? FechaPublicacion { get; set; }
        
        public virtual ICollection<Tiendas> Tiendas { get; set; }

        public virtual ICollection<LibrosClientes> LibrosClientes { get; set; } 

    }
}