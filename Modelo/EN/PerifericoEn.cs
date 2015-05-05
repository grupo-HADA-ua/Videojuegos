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
            return Id == p.Id & Nombre == p.Nombre & Precio == p.Precio & CantidadStock == p.CantidadStock;
        }

        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 37 * Nombre.GetHashCode();
            return hash;
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
                CAD_Periferico.Crear(this);
            }
            catch (Exception)
            {
                Console.Write("Error al insertar un periferico: %s\n");
            }
        }

        public void actualizarPeriferico()
        {
            crearCad();
            try
            {
                CAD_Periferico.Actualizar(this);
            }
            catch (Exception)
            {
                Console.Write("Error al insertar un periferico: %s\n");
            }
        }

        public void borrarPeriferico()
        {
            if (CAD_Periferico == null) CAD_Periferico = new PerifericoCAD();

            CAD_Periferico.Borrar(this.Id);
        }

        public PerifericoEn mostrarPeriferico()
        {
            return CAD_Periferico.Mostrar(this.Id);
            
        }

    }
}
