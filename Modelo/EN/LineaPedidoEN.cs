using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo.CAD;

namespace Modelo.EN
{
    public class LineaPedidoEN
    {

        private ILineaPedidoCAD cad;

        private int id;
        public int Id { get { return id; } set { id = value; } }

        private ProductoEN producto;
        public ProductoEN Producto { get { return producto; } set { producto = value; } }

        private int cantidad;
        public int Cantidad { get { return cantidad; } set { cantidad = value; } }

        public LineaPedidoEN()
        {
            cad = new LineaPedidoCAD();
        }

        public LineaPedidoEN(int id, ProductoEN producto, int cantidad)
        {
            inicializar(id, producto, cantidad);
        }

        public LineaPedidoEN(LineaPedidoEN l)
        {
            inicializar(l.Id, l.Producto, l.Cantidad);
        }

        private void inicializar(int id, ProductoEN producto, int cantidad)
        {
            Id = id;
            Producto = new ProductoEN(producto);
            Cantidad = cantidad;
            cad = new LineaPedidoCAD();
        }

        public override bool  Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            LineaPedidoEN l = (LineaPedidoEN)obj;
            return (Id == l.Id) && (Producto.Equals(l.Producto) && (Cantidad == l.Cantidad)); 	        
        }

        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 37 + Producto.GetHashCode();
            return hash;
        }

        public void Guardar()
        {
            cad.Crear(this);
        }

        public LineaPedidoEN Obtener(int id)
        {
            return cad.Obtener(id);
        }

        public IList<LineaPedidoEN> ObtenerTodos()
        {
            return cad.ObtenerTodos();
        }

        public void Actualizar()
        {
            cad.Actualizar(this);
        }

        public void Borrar()
        {
            cad.Borrar(this);
        }
    }
}