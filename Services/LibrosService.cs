using api_librerias_paco.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace api_librerias_paco.Services
{
    public static class LibrosService
    {
        static List<Libros> Libros { get; }
        static int nextId = 11;
        static LibrosService()
        {
            Libros = new List<Libros>
        {
            new Libros { Titulo = "La cenidoscientas", Precio = 18, Autor ="Manolo el del Bombo", Paginas = 121 , FechaPublicacion= "15/07/2000", enVenta= true , Id=1 },
            new Libros { Titulo = "Los tres cochinillos", Precio = 9, Autor ="Kiko Cocotera", Paginas = 540 , FechaPublicacion= "30/12/2007", enVenta= true , Id=2 },
            new Libros { Titulo = "Peter Punk", Precio = 8, Autor ="Eustaquio de Pitis", Paginas = 347 , FechaPublicacion= "05/01/2013", enVenta= true , Id=3 },
            new Libros { Titulo = "Blancalluvias", Precio = 13, Autor ="Antonela", Paginas = 98 , FechaPublicacion= "24/12/2005", enVenta= true , Id=4 },
            new Libros { Titulo = "El libro de la jungla", Precio = 15, Autor ="Zacarías", Paginas = 188 , FechaPublicacion= "18/07/2015", enVenta= true , Id=5 },
            new Libros { Titulo = "El rey sapo", Precio = 23, Autor ="Delfín", Paginas = 392 , FechaPublicacion= "27/02/2019", enVenta= true , Id=6 },
            new Libros { Titulo = "Diana y el Leon", Precio = 9, Autor ="Gervasio", Paginas = 213 , FechaPublicacion= "14/03/1998", enVenta= true , Id=7 },
            new Libros { Titulo = "Down", Precio = 4, Autor ="Moyorz", Paginas = 102 , FechaPublicacion= "10/12/2002", enVenta= true , Id=8 },
            new Libros { Titulo = "Como entrenar a tu foca", Precio = 5, Autor ="Manuela Pacheco", Paginas = 326 , FechaPublicacion= "31/11/2011", enVenta= true , Id=9 },
            new Libros { Titulo = "La bella y el oso", Precio = 5, Autor ="Pepe Palomas", Paginas = 473 , FechaPublicacion= "09/11/2003", enVenta= true , Id=10 },
            new Libros { Titulo = "Chicken Big", Precio = 14, Autor ="Bertín Osborne", Paginas = 64 , FechaPublicacion= "10/05/2000", enVenta= true , Id=11 },
        };
        }

        public static List<Libros> GetAll() => Libros;

        public static Libros? Get(int id) => Libros.FirstOrDefault(p => p.Id == id);

        public static Libros? Get(string Titulo) => Libros.FirstOrDefault(p => p.Titulo == Titulo);


        public static void Add(Libros libros)
        {
            libros.Id = nextId++;
            Libros.Add(libros);
        }

        public static void Delete(int id)
        {
            var libros = Get(id);
            if (libros is null)
                return;

            Libros.Remove(libros);
        }

        public static void Update(Libros libros)
        {
            var index = Libros.FindIndex(p => p.Id == libros.Id);
            if (index == -1)
                return;

            Libros[index] = libros;
        }



    }

}

