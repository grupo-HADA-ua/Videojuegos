using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Modelo.EN;

namespace Web.Usuario
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void logear(object sender, EventArgs e)
        {
            ClienteEN cliente = new ClienteEN();
            cliente.Nombre = "Visual studio 2013";
            cliente.Password = "Manuel";
            cliente.Email = "manu@manu.com";
            cliente.Direccion = "mi calle";
            cliente.Guardar();
            Response.Redirect("~/Default.aspx");
        }
    }
}