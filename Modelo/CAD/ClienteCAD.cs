using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo.EN;
using System.Data;

namespace Modelo.CAD
{
    class ClienteCAD
    {
        public int Crear(string nombre, string email, string password)
        {
            ClienteEN c = new ClienteEN();
            return 1;
        }

        public ClienteEN Obtener(int id)
        {
            return new ClienteEN();
        }

        public DataSet ObtenerTodos()
        {
            return new DataSet();
        }

        public void Actualizar(ClienteEN c)
        {

        }

        public void Borrar(int id)
        {

        }
    }
}
