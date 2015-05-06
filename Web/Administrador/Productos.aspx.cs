using Modelo.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Administrador
{
    public partial class Productos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Administrador"] == null)
            {
                Response.Redirect("~/Administrador/Login.aspx");
            }
        }

        protected IList<VideojuegoEN> ObtenerVideojuegos()
        {
            return (new VideojuegoEN()).ObtenerTodos();
        }
    }
}