namespace api_librerias_paco.Models
{
    public class LibrosClientes
    {

        public int Id { get; set; }
        public int? IdCliente { get; set; }
        public int? Idlibro { get; set; }
        public string? NombreLibro { get; set; }

        public Clientes Cliente { get; set; }
        public Libros Libro { get; set; }


    }
}

