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

        private VideojuegoCAD CAD_Videojuego;

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


        //Metodos
        //CRUD

        public void crearCad()
        {
            if (CAD_Videojuego == null)
                CAD_Videojuego = new VideojuegoCAD();
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
            if (CAD_Videojuego == null) CAD_Videojuego = new VideojuegoCAD();

          //  CAD_Videojuego.borrarVideojuego(this.id);
        }

        //Muestra un Videojuego de la bbdd
        public VideojuegoEN mostrarVideojuego()
        {
           // return CAD_Videojuego.mostrarVideojuego(this.id);
            return null;
        }
    }
}
