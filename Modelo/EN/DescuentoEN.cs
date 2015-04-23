using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo.EN
{
    public class DescuentoEN
    {

        private double descuento;
        public double Descuento { get { return descuento; } set { descuento = value; } }

        public DescuentoEN() { }

        public DescuentoEN(double descuento) {

            Descuento = descuento;

        }

        public DescuentoEN(DescuentoEN p) {

            Descuento = p.descuento;
        
        }
    }
}
