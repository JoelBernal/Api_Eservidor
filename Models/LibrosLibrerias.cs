using System.ComponentModel.DataAnnotations;


namespace api_librerias_paco.Models{

public class LibrosLibrerias
{
    [Key]

    public int? IdGeneric { get; set; }
    public int? IdCliente { get; set; }
    public int? IdLibro { get; set; }
    public int? IdLibreria { get; set; }
    public string? Comunidad { get; set; }
    public bool? Recoger { get; set; }
}




}

