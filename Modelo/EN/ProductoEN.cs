using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo.EN
{
    public class ProductoEN
    {
        

        private string nombre;
        public string Nombre { get { return nombre; } set { nombre = value; } }

        private double precio;
        public double Precio { get { return precio; } set { precio = value; } }

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

    }
}
