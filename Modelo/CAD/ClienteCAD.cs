using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo.EN;
using System.Data;

namespace Modelo.CAD
{
    public class ClienteCAD
    {
        private static IList<ClienteEN> clientes = new List<ClienteEN>();
        
        private static void IniciarListaClientes()
        {
            clientes.Add(new ClienteEN(1, "Manu", "Manu@hada.com", "manuPassword"));
            clientes.Add(new ClienteEN(2, "Ana", "Ana@hada.com", "anaPassword"));
            clientes.Add(new ClienteEN(3, "Andres", "Andres@hada.com", "andresPassword"));
        }

        public int Crear(string nombre, string email, string password)
        {
            ClienteEN c = new ClienteEN();
            return 1;
        }

        public ClienteEN Obtener(int id)
        {
            return new ClienteEN();
        }

        public static IList<ClienteEN> ObtenerTodos()
        {
            IniciarListaClientes();
            return clientes;
        }

        public void Actualizar(ClienteEN c)
        {

        }

        public void Borrar(int id)
        {

        }
    }
}
