using Modelo.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo.CAD
{
    interface IProductoCAD
    {
        void Crear(ProductoEN p);
        ProductoEN Obtener(int id);
        IList<ProductoEN> ObtenerTodos();
        void Actualizar(ProductoEN p);
        void Borrar(ProductoEN p);
    }
}
