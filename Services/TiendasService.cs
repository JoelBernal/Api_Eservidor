using api_librerias_paco.Models;

namespace api_librerias_paco.Services
{
    public static class TiendasService
    {
        static List<Tiendas> Tiendas { get; }
        static int nextId = 3;
        static TiendasService()
        {
            Tiendas = new List<Tiendas>
        {
            new Tiendas  { comunidad = "Aragon", localidad = "Zaragoza", calle =  "C/Alfonso 14" , codigopostal= 50012, trabajadores =6 , id =1 },
            new Tiendas  { comunidad = "Asturias", localidad = "Gijon", calle = "C/Cabezahuevo 61" , codigopostal= 23456 , trabajadores =3 , id =2 },
            new Tiendas  { comunidad = "Madrid", localidad = "Madrid", calle = "C/Buena agua 94" , codigopostal=47270 , trabajadores =10 , id =3 },
            new Tiendas  { comunidad = "Cataluña", localidad = "Barcelona", calle = "C/Indepencia 155" , codigopostal=13169 , trabajadores =7 , id =4 }
        };
        }

        public static List<Tiendas> GetAll() => Tiendas;

        public static Tiendas? Get(int id) => Tiendas.FirstOrDefault(p => p.id == id);

        public static void Add(Tiendas tiendas)
        {
            tiendas.id = nextId++;
            Tiendas.Add(tiendas);
        }

        public static void Delete(int id)
        {
            var tiendas = Get(id);
            if (tiendas is null)
                return;

            Tiendas.Remove(tiendas);
        }

        public static void Update(Tiendas tiendas)
        {
            var index = Tiendas.FindIndex(p => p.id == tiendas.id);
            if (index == -1)
                return;

            Tiendas[index] = tiendas;
        }
    }

}

