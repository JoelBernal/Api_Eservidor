namespace api_librerias_paco.Models
{

    public class Tiendas
    {
        public int Id { get; set; }

        

        public string? comunidad { get; set; }
        public string? localidad { get; set; }
        public string? calle { get; set; }

        public int? codigopostal { get; set; }

        public int? trabajadores { get; set; }

        public  int libroId {get;set;}

        public virtual Libros Libros { get; set; }
        

    }
}