using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo.CAD;

namespace Modelo.EN
{
    public class PerifericoEN : ProductoEN
    {
        private PerifericoCAD _cad;

         public PerifericoEN()
        {
            _cad = new PerifericoCAD();
        }

        public PerifericoEN(int id, string nombre, double precio, int cantidadstock)
        {
            inicializar(id, nombre, precio, cantidadstock);
        }

        public PerifericoEN(string nombre, double precio, int cantidadstock, string descripcion)
        {
            Nombre = nombre;
            Precio = precio;
            CantidadStock = cantidadstock;
            Descripcion = descripcion;
        }

        public PerifericoEN(PerifericoEN c)
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
            if (!(obj is PerifericoEN)) return false;

            PerifericoEN p = (PerifericoEN)obj;
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

        override public void Guardar()
        {
            _cad.Crear(this);
        }

        public IList<PerifericoEN> ObtenerTodos()
        {
            return _cad.ObtenerTodos();
        }

        public void BorrarTodos()
        {
            _cad.BorrarTodos();
        }


        public void crearCad()
        {
            if (_cad == null)
                _cad = new PerifericoCAD();
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
            if (_cad == null) _cad = new PerifericoCAD();

           // CAD_Periferico.borrarPeriferico(this.id);
        }

        public PerifericoEN mostrarPeriferico()
        {
            //return CAD_Periferico.mostrarPeriferico(this.id);
            return null;
        }

    }
}
