using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo.EN;

namespace Modelo.Carrito
{
    public class Carrito
    {
        public List<ProductoEN> Productos { get; set; }

        public Carrito()
        {
            Productos = new List<ProductoEN>();
        }

        public void Add(ProductoEN p)
        {
            Productos.Add(p);
        }

        public void Remove(ProductoEN producto)
        {
            var index = Productos.FindIndex(p => p.Nombre == producto.Nombre);
            Productos.RemoveAt(index);
            //Productos.RemoveAll(p => p.Nombre == producto.Nombre);
        }
    }
}
