using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo.EN
{
    class CarritoEN
    {
        private IList<LineaPedidoEN> lineas;
        public IList<LineaPedidoEN> Lineas
        {
            get
            {
                return new List<LineaPedidoEN>(lineas);
            }
            set
            {
                lineas = new List<LineaPedidoEN>(value);
            }
        }

        public CarritoEN()
        { }

        public CarritoEN(CarritoEN c)
        {
            inicializar(c.Lineas);
        }

        public CarritoEN(IList<LineaPedidoEN> l)
        {
            inicializar(l);
        }

        private void inicializar(IList<LineaPedidoEN> l){
            Lineas = l;
        }
    }
}
