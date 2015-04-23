using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo.CAD;

namespace Modelo.EN
{
    public class PerifericoEn : ProductoEN
    {

        private PerifericoCAD CAD_Periferico;

        private string nombre;
        public string Nombre { get { return nombre; } set { nombre = value; } }

        private double precio;
        public double Precio { get { return precio; } set { precio = value; } }

        private int cantidadstock;
        public int CantidadStock { get { return cantidadstock; } set { cantidadstock = value; } }

        private int id;
        public int Id { get { return id; } set { id = value; } }

         public PerifericoEn()
        {
        }

        public PerifericoEn(int id, string nombre, double precio, int cantidadstock)
        {
            inicializar(id, nombre, precio, cantidadstock);
        }

        public PerifericoEn(PerifericoEn c)
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
            if (!(obj is PerifericoEn)) return false;

            PerifericoEn p = (PerifericoEn)obj;
            return id == p.id & nombre == p.nombre & precio == p.precio & cantidadstock == p.cantidadstock;
        }

        //Metodos
        //CRUD
        public void crearCad()
        {
            if (CAD_Periferico == null)
                CAD_Periferico = new PerifericoCAD();
        }

        public void crearPeriferico()
        {
            crearCad();
            try
            {
               // CAD_Periferico.crearPeriferico(this);
            }
            catch (Exception)
            {
                Console.Write("Error al insertar el articulo: %s\n");
            }
        }

        public void actualizarPeriferico()
        {
            crearCad();
            try
            {
               // CAD_Periferico.actualizarPeriferico(this);
            }
            catch (Exception)
            {
                Console.Write("Error al actualizar el articulo: %s\n");
            }
        }

        public void borrarPeriferico()
        {
            if (CAD_Periferico == null) CAD_Periferico = new PerifericoCAD();

           // CAD_Periferico.borrarPeriferico(this.id);
        }

        public PerifericoEn mostrarPeriferico()
        {
            //return CAD_Periferico.mostrarPeriferico(this.id);
            return null;
        }

    }
}
