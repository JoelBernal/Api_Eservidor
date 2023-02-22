using System.ComponentModel.DataAnnotations;


namespace api_librerias_paco.Models{

public class LibroCliente
{
    [Key]
    public int? Id { get; set; }
    public int? IdCliente { get; set; }
    public int? IdLibro { get; set; }
    public string? NombreLibro { get; set; }
    public virtual Clientes? Clientes { get; set; }
    public virtual Libros? Libros { get; set; }
}





}


