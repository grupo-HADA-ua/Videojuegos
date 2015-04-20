using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo.EN
{
    public class LinpedEN
    {
        private int id;
        public int Id { get { return id; } set { id = value; } }

        private ProductoEN producto;
        public ProductoEN Producto { get { return producto; } set { producto = value; } }

        private int cantidad;
        public int Cantidad { get { return cantidad; } set { cantidad = value; } }

        public LinpedEN()
        {

        }

        public LinpedEN(int id, ProductoEN producto, int cantidad)
        {
            inicializar(id, producto, cantidad);
        }

        public LinpedEN(LinpedEN l)
        {
            inicializar(l.Id, l.Producto, l.Cantidad);
        }

        private void inicializar(int id, ProductoEN producto, int cantidad)
        {
            Id = id;
            Producto = new ProductoEN(producto);
            Cantidad = cantidad;
        }

        public override bool  Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            LinpedEN l = (LinpedEN)obj;
            return (Id == l.Id) && (Producto.Equals(l.Producto) && (Cantidad == l.Cantidad); 	        
        }
    }
}