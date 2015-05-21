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
            if (Request["id"] != null)
            {
                var c = (Carrito)Session["Carrito"];
                var p = new ProductoEN();
                p.Id = int.Parse(Request["id"]);
                p.Nombre = Request["nombre"];
                c.Remove(p);
                Session["Carrito"] = c;
                Response.Redirect("~/Usuario/Perfil.aspx");
            }
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