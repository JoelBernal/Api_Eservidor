namespace api_librerias_paco.Models
{

    public class Libros
    {
        public string? Titulo { get; set; }
        public decimal? Precio { get; set; }
        public string? Autor { get; set; }

        public int? Paginas { get; set; }

        public bool? enVenta { get; set; }
        public int? Id { get; set; }

        public string? FechaPublicacion { get; set; }
    }
}