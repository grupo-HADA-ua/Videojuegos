using Modelo.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo.CAD
{
    interface IPedidoCAD
    {
        void Crear(PedidoEN p);
        PedidoEN Obtener(int id);
        IList<PedidoEN> ObtenerTodos();
        void Actualizar(PedidoEN p);
        void Borrar(PedidoEN c);
    }
}
