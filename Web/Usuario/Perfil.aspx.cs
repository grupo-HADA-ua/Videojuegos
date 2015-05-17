using Modelo.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Modelo.Carrito;

namespace Web.Usuario
{
    public partial class Perfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public ClienteEN getUsuarioActual()
        {
            var c = (ClienteEN) Session["Cliente"];
            return c;
        }

        public Carrito ObtenerCarrito()
        {
            return (Carrito)Session["Carrito"];
        }
    }
}