using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo.ENUM;

namespace Modelo.EN
{
    public class VideojuegoEN : ProductoEN
    {
        private string nombre;
        public string Nombre { get { return nombre; } set { nombre = value; } }

        private double precio;
        public double Precio { get { return precio; } set { precio = value; } }

        private int cantidadstock;
        public int CantidadStock { get { return cantidadstock; } set { cantidadstock = value; } }

        private int id;
        public int Id { get { return id; } set { id = value; } }

        private Edad edadminima;
        public Edad EdadMinima { get { return edadminima; } set { edadminima = value; } }

         public VideojuegoEN()
        {
        }

        public VideojuegoEN(int id, string nombre, double precio, int cantidadstock, Edad edadminima)
        {
            inicializar(id, nombre, precio, cantidadstock, edadminima);
        }

        public VideojuegoEN(VideojuegoEN c)
        {
            inicializar(c.Id, c.Nombre, c.Precio, c.CantidadStock, c.EdadMinima);
        }

        private void inicializar(int id, string nombre, double precio, int cantidadstock, Edad edadminima)
        {
            Id = id;
            Nombre = nombre;
            Precio = precio;
            CantidadStock = cantidadstock;
            EdadMinima = edadminima;
        }

        public override bool Equals(Object obj)
        {
            if (!(obj is VideojuegoEN)) return false;

            VideojuegoEN p = (VideojuegoEN)obj;
            return id == p.id & nombre == p.nombre & precio == p.precio & cantidadstock == p.cantidadstock & edadminima == p.edadminima;
        }
    }
}
