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
           
        }

        protected IList<VideojuegoEN> ObtenerVideojuegos()
        {
            var v = new VideojuegoEN();
            IList<VideojuegoEN> videojuegos = v.ObtenerTodos();
            return videojuegos;
        }
    }
}