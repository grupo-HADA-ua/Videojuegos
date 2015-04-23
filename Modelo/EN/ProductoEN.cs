using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo.CAD;

namespace Modelo.EN
{
    public class ProductoEN
    {

        private ProductoCAD CAD_Producto;

        private bool descuento;
        public bool Descuento { get { return descuento; } set { descuento = value; } }

        private DescuentoEN descontar;

        private string nombre;
        public string Nombre { get { return nombre; } set { nombre = value; } }

        private double precio;
        public double Precio { 
            get {
                if (descuento)
                    return precio = precio - (precio * descontar.Descuento);
                else
                    return precio;
            }
            set { precio = value; } 
        }

        private int cantidadstock;
        public int CantidadStock { get { return cantidadstock; } set { cantidadstock = value; } }

        private int id;
        public int Id { get { return id; } set { id = value; } }

         public ProductoEN()
        {
        }

        public ProductoEN(int id, string nombre, double precio, int cantidadstock)
        {
            inicializar(id, nombre, precio, cantidadstock);
        }

        public ProductoEN(ProductoEN c)
        {
            inicializar(c.Id, c.Nombre, c.Precio, c.CantidadStock);
        }

        private void inicializar(int id, string nombre, double precio, int cantidadstock)
        {
            Id = id;
            Nombre = nombre;
            Precio = precio;
            CantidadStock = cantidadstock;
        }

        public override bool Equals(Object obj)
        {
            if (!(obj is ProductoEN)) return false;

            ProductoEN p = (ProductoEN)obj;
            return id == p.id & nombre == p.nombre & precio == p.precio & cantidadstock == p.cantidadstock;
        }

        //METODOS
        //CRUD

        //Metodo para crear el cad
        public void crearCad()
        {
            if (CAD_Producto == null) CAD_Producto = new ProductoCAD();
        }

        //Crea en la base de datos un Producto con los datos de la instancia actual
        public void crearProducto()
        {
            crearCad();

            try
            {
               // CAD_Producto.crearProducto(this);
            }
            catch (Exception)
            {//especificar tipo de excepcion
                Console.Write("Error insertando Producto %s\n");
            }
        }

        //Metodo que actualiza en la bbdd un Producto
        public void actualizarProducto()
        {
            crearCad();
            try
            {
                //CAD_Producto.actualizarProducto(this);
            }
            catch (Exception)
            {//especificar tipo de excepcion
                Console.Write("Error modificanco Producto: %s\n");
            }
        }

        //Metodo que borra de la bbdd un Producto
        public void borrarProducto()
        {
            crearCad();

            try
            {
               // CAD_Producto.borrarProducto(this.id);
            }
            catch (Exception)
            {//especificar tipo de excepcion
                Console.Write("Error borrando Producto: %s\n");
            }
        }

        //Metodo para mostrar un Producto
        public ProductoEN mostrarArticulo()
        {
           // return CAD_Producto.mostrarProducto(this.id);
            return null;
        }


    }
}
