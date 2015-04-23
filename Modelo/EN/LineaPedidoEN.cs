using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo.CAD;

namespace Modelo.EN
{
    public class LineaPedidoEN
    {

        private LineaPedidoCAD CAD_lineaPedido;

        private int id;
        public int Id { get { return id; } set { id = value; } }

        private ProductoEN producto;
        public ProductoEN Producto { get { return producto; } set { producto = value; } }

        private int cantidad;
        public int Cantidad { get { return cantidad; } set { cantidad = value; } }

        public LineaPedidoEN()
        {

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

        //METODOS
        //CRUD

        public void crearCad()
        {
            if (CAD_lineaPedido == null)
                CAD_lineaPedido = new LineaPedidoCAD();
        }

        //Inserta una LineaPedido en la bbdd
        public void crearOferta()
        {
            crearCad();
            try
            {
              //  CAD_lineaPedido.crearLineaPedido(this);
            }
            catch (Exception)
            {
                Console.Write("Error al insertar una LineaPedido: %s\n");
            }
        }

        //Actualiza una LineaPedido en la bbdd
        public void actualizarLineaPedido()
        {
            crearCad();
            try
            {
               // CAD_lineaPedido.actualizarLineaPedido(this);
            }
            catch (Exception)
            {
                Console.Write("Error al actualizar una LineaPedido: %s\n");
            }
        }

        //Borrar una LineaPedido en la bbdd
        public void borrarLineaPedido()
        {
            crearCad();
            try
            {
                //CAD_lineaPedido.borrarLineaPedido(this.id);
            }
            catch (Exception)
            {
                Console.Write("Error al borrar una LineaPedido: %s\n");
            }
        }

        //Mostrar LineaPedido de la bbdd
        public LineaPedidoEN mostrarLineaPedido()
        {
           // return CAD_lineaPedido.mostrarLineaPedido(this.id);
            return null;
        }
    }
}