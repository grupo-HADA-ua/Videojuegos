using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo.CAD;

namespace Modelo.EN
{
    public class DescuentoEN
    {

        private DescuentoCAD CAD_Descuento;

        private double descuento;
        public double Descuento { get { return descuento; } set { descuento = value; } }

        public DescuentoEN() { }

        public DescuentoEN(double descuento) {

            Descuento = descuento;

        }

        public DescuentoEN(DescuentoEN p) {

            Descuento = p.descuento;
        
        }

        //METODOS
        //CRUD

        public void crearCad()
        {
            if (CAD_Descuento == null)
                CAD_Descuento = new DescuentoCAD();
        }

        //Inserta un Descuento en la bbdd
        public void crearDescuento()
        {
            crearCad();
            try
            {
                //CAD_Descuento.crearDescuento(this);
            }
            catch (Exception)
            {
                Console.Write("Error al insertar un Descuento: %s\n");
            }
        }

        //Actualiza un Descuento en la bbdd
        public void actualizarDescuento()
        {
            crearCad();
            try
            {
               // CAD_Descuento.actualizarDescuento(this);
            }
            catch (Exception)
            {
                Console.Write("Error al actualizar un Descuento: %s\n");
            }
        }

        //Borrar una Descuento en la bbdd
        public void borrarDescuento()
        {
            crearCad();
            try
            {
               // CAD_Descuento.borrarOferta(this.descuento);
            }
            catch (Exception)
            {
                Console.Write("Error al borrar un Descuento: %s\n");
            }
        }

        //Mostrar Descuento de la bbdd
        public DescuentoEN mostrarDescuento()
        {
           // return CAD_Descuento.mostrarDescuento(this.descuento);
            return null;
        }
    }
}
