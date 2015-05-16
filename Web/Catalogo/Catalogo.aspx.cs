using Modelo.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Catalogo
{
    public partial class Catalogo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           if (IsPostBack)
            {
                
            }
        }

        protected string Tipo(ProductoEN p)
        {
            if (p is VideojuegoEN)
            {
                return "videojuego";
            }
            else if (p is ConsolaEN)
            {
                return "consola";
            }
            return "periferico";
        }

        protected IList<VideojuegoEN> ObtenerVideojuegos()
        {
            var v = new VideojuegoEN();
            IList<VideojuegoEN> videojuegos = v.ObtenerTodos();
            return videojuegos;
        }

        protected IList<ProductoEN> ObtenerProductos()
        {
            var p = new ProductoEN();
            IList<ProductoEN> productos = p.ObtenerTodos();
            return productos;
        }
    }
}