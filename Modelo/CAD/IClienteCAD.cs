using Modelo.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo.CAD
{
    interface IClienteCAD
    {
        int Crear(ClienteEN c);
        ClienteEN Obtener(int id);
        IList<ClienteEN> ObtenerTodos();
        void Actualizar(ClienteEN c);
        void Borrar(ClienteEN c);
    }
}
