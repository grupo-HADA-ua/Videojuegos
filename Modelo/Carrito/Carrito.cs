using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo.EN;

namespace Modelo.Carrito
{
    public class Carrito
    {
        public IList<ProductoEN> Productos { get; set; }

        public Carrito()
        {
            Productos = new List<ProductoEN>();
        }

        public void Add(ProductoEN p)
        {
            Productos.Add(p);
        }
    }
}
