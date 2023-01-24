namespace api_librerias_paco.Models
{

    public class Clientes
    {
        public string? Correo { get; set; }
        public string? Contraseña { get; set; }
        public string? NombreUser { get; set; }

        public decimal? saldo { get; set; }

        private int? Id { get; set; }

        private DateTime? fechaCreacion { get; set; }
       
       
    }
}