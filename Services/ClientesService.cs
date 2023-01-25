using api_librerias_paco.Models;

namespace api_librerias_paco.Services
{
    public static class ClientesService
    {
        static List<Clientes> _Clientes { get; set; }
        static int nextId = 3;
        static ClientesService()
        {
            _Clientes = new List<Clientes>
        {
            new Clientes { Correo = "admin@admin.com" , Contraseña = "admin123", NombreUser = "admin" , saldo=0, Id=1  },
            new Clientes { Correo = "prueba1@gmail.com" , Contraseña = "prueba123", NombreUser = "develop" , saldo=0, Id=2 }
        };
        }

        public static List<Clientes> GetAll() => _Clientes;

        public static Clientes? Get(int id) => _Clientes.FirstOrDefault(p => p.Id == id);
        public static Clientes? Get(string correo) => _Clientes.FirstOrDefault(p => p.Correo == correo);

        public static void Add(Clientes clientes)
        {
            clientes.Id = nextId++;
            _Clientes.Add(clientes);
        }

        public static void Delete(int id)
        {
            var clientes = Get(id);
            if (clientes is null)
                return;

            _Clientes.Remove(clientes);
        }

        public static void Update(Clientes clientes)
        {
            var index = _Clientes.FindIndex(p => p.Id == clientes.Id);
            if (index == -1)
                return;

            _Clientes[index] = clientes;
        }
    }

}

