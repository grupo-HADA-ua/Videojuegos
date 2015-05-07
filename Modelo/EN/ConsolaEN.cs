using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo.CAD;

namespace Modelo.EN
{
    public class ConsolaEN : ProductoEN
    {
        private ConsolaCAD _cad = new ConsolaCAD();

         public ConsolaEN()
        {
        }

        public ConsolaEN(int id, string nombre, double precio, int cantidadstock)
        {
            inicializar(id, nombre, precio, cantidadstock);
        }

        public ConsolaEN(string nombre, double precio, int cantidadStock, string descripcion)
        {
            Nombre = nombre;
            Precio = precio;
            CantidadStock = cantidadStock;
            Descripcion = descripcion;
        }

        public ConsolaEN(ConsolaEN c)
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
            if (!(obj is ConsolaEN)) return false;

            ConsolaEN p = (ConsolaEN)obj;
            return (Id == p.Id & Nombre == p.Nombre & Precio == p.Precio & CantidadStock == p.CantidadStock);
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

        public IList<ConsolaEN> ObtenerTodos()
        {
            return _cad.ObtenerTodos();
        }

        public void Borrartodos()
        {
            _cad.BorrarTodos();
        }

        public void crearCad()
        {
            if (_cad == null)
                _cad = new ConsolaCAD();
        }

        //Introduce una nueva Consola en la bbdd
        public void crearConsola()
        {
            crearCad();
            try
            {
              //  CAD_Consola.crearConsola(this);
            }
            catch (Exception)
            {
                Console.Write("Error al insertar el articulo: %s\n");
            }
        }

        //Actualiza la Consola en la bbdd
        public void actualizarConsola()
        {
            crearCad();

            try
            {
               // CAD_Consola.actualizarConsola(this);
            }
            catch (Exception)
            {
                Console.Write("Error al actualizar el articulo: %s\n");
            }
        }

        //Borramos una Consola de la bbdd
        public void borrarConsola()
        {
            if (_cad == null) _cad = new ConsolaCAD();

            //CAD_Consola.borrarConsola(this.id);
        }

        //Muestra una Consola de la bbdd
        public ConsolaEN mostrarConsola()
        {
            //return CAD_Consola.mostrarConsola(this.id);
            return null;
        }


    }
}
