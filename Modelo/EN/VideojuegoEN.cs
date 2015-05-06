using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo.ENUM;
using Modelo.CAD;

namespace Modelo.EN
{
    public class VideojuegoEN : ProductoEN
    {
        private VideojuegoCAD cad = new VideojuegoCAD();

        private int edadminima;
        public int EdadMinima { get { return edadminima; } set { edadminima = value; } }

         public VideojuegoEN()
        {
        }

        public VideojuegoEN(int id, string nombre, double precio, int cantidadstock, int edadminima)
        {
            inicializar(id, nombre, precio, cantidadstock, edadminima);
        }

        public VideojuegoEN(string nombre, double precio, int cantidadStock, int edadMinima, string descripcion)
        {
            Nombre = nombre;
            Precio = precio;
            CantidadStock = cantidadStock;
            EdadMinima = edadMinima;
            Descripcion = descripcion;
        }

        public VideojuegoEN(VideojuegoEN c)
        {
            inicializar(c.Id, c.Nombre, c.Precio, c.CantidadStock, c.EdadMinima);
        }

        private void inicializar(int id, string nombre, double precio, int cantidadstock, int edadminima)
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
            return (Id == p.Id && Nombre == p.Nombre && 
                Precio == p.Precio && CantidadStock == p.CantidadStock 
                && edadminima == p.edadminima);
        }

        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 37 + Nombre.GetHashCode();
            return hash;
        }


        //Metodos
        //CRUD

        public void crearCad()
        {
            if (cad == null)
                cad = new VideojuegoCAD();
        }

        //INtroduce un nuevo Videojuego en la bbdd
        public void crearVideojuego()
        {
            crearCad();
            try
            {
               // CAD_Videojuego.crearVideojuego(this);
            }
            catch (Exception)
            {
                Console.Write("Error al insertar el Videojuego: %s\n");
            }
        }

        //Actualiza el Videojuego en la bbdd
        public void actualizarVideojuego()
        {
            crearCad();

            try
            {
               // CAD_Videojuego.actualizarVideojuego(this);
            }
            catch (Exception)
            {
                Console.Write("Error al actualizar el Videojuego: %s\n");
            }
        }

        //Borramos un Videojuego de la bbdd
        public void borrarVideojuego()
        {
            if (cad == null) cad = new VideojuegoCAD();

          //  CAD_Videojuego.borrarVideojuego(this.id);
        }

        //Muestra un Videojuego de la bbdd
        public VideojuegoEN mostrarVideojuego()
        {
           // return CAD_Videojuego.mostrarVideojuego(this.id);
            return null;
        }

        override public void Guardar()
        {
            cad.Crear(this);
        }

        public IList<VideojuegoEN> ObtenerTodos()
        {
            return cad.ObtenerTodos();
        }

        public void BorrarTodos()
        {
            cad.BorrarTodos();
        }
    }
}
