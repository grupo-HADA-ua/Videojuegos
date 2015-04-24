using Modelo.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo.CAD
{
    interface ILineaPedidoCAD
    {
        void Crear(LineaPedidoEN l);
        LineaPedidoEN Obtener(int id);
        IList<LineaPedidoEN> ObtenerTodos();
        void Actualizar(LineaPedidoEN l);
        void Borrar(LineaPedidoEN l);
    }
}
