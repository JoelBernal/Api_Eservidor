namespace api_librerias_paco.Models
{

    public class Clientes

    {       
        public int Id { get; set; }

        public string? Correo { get; set; }
        public string? Contraseña { get; set; }
        public string? NombreUser { get; set; }

        public decimal? saldo { get; set; }

        private DateTime? fechaCreacion { get; set; }

       
        public virtual ICollection<LibrosClientes> LibrosClientes { get; set; } 
        

    }
}