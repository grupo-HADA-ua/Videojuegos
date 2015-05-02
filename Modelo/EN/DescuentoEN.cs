using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo.CAD;

namespace Modelo.EN
{
    public class DescuentoEN
    {
        //Atributos
        private string cod;
        private string fechaI;
        private string fechaF;
        private int descuento;
        private List<ProductoEN> articulos;

        private DescuentoCAD CAD_descuento;

        public DescuentoEN(string cod = "", string fechaI = "", string fechaF = "", int descuento = -1)
        {
            this.cod = cod;
            this.fechaI = fechaI;
            this.fechaF = fechaF;
            this.descuento = descuento;
            this.articulos = new List<ProductoEN>();
        }

        public string Cod
        {
            get { return cod; }
            set { cod = value; }
        }
        public string FechaI
        {
            get { return fechaI; }
            set { fechaI = value; }
        }

        public string FechaF
        {
            get { return FechaF; }
            set { fechaF = value; }
        }

        public int Descuento
        {
            get { return descuento; }
            set { descuento = value; }
        }

        public List<ProductoEN> Articulo
        {
            get { return articulos; }
        }

        //METODOS
        //CRUD

        public void crearCad()
        {
            if (CAD_descuento == null)
                CAD_descuento = new DescuentoCAD();
        }

        //Inserta una oferta en la bbdd
        public void Crear()
        {
            crearCad();
            try
            {
                CAD_descuento.Crear(this);
            }
            catch (Exception)
            {
                Console.Write("Error al insertar un descuento: %s\n");
            }
        }

        //Actualiza una oferta en la bbdd
        public void Actualizar()
        {
            crearCad();
            try
            {
                CAD_descuento.Actualizar(this);
            }
            catch (Exception)
            {
                Console.Write("Error al actualizar un descuento: %s\n");
            }
        }

        //Borrar una oferta en la bbdd
        public void Borrar()
        {
            crearCad();
            try
            {
                CAD_descuento.Borrar(this.cod);
            }
            catch (Exception)
            {
                Console.Write("Error al borrar un descuento: %s\n");
            }
        }

        //Mostrar oferta de la bbdd
        public DescuentoEN Mostrar()
        {
            return CAD_descuento.Mostrar(this.Cod);
        }
    }
}
