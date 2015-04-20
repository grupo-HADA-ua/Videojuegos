using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo.EN
{
    public class LinpedEN
    {
        private int id;
        public int Id { get { return id; } set { id = value; } }

        private IList<ProductoEN> productos;
        public IList<ProductoEN> Productos { get { return productos; } set { productos = value; } }

        public LinpedEN()
        {

        }
    }
}
