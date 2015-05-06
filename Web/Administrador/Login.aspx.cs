using Modelo.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Administrador
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Logear(object sender, EventArgs e)
        {
            var admin = new AdministradorEN();
            admin.Usuario = Usuario.Text;
            admin.Password = Password.Text;
            if (LoginCorrecto(admin.Usuario, admin.Password))
            {
                Session.Add("Administrador", admin.Obtener());
                Response.Redirect("~/Administrador/PanelDeControl.aspx");
            }
            Response.Redirect("~/Administrador/Login.aspx");
        }

        protected void ComprobarDatos(object sender, ServerValidateEventArgs e)
        {
            e.IsValid = false;
            var a = new AdministradorEN();
            a.Usuario = Usuario.Text;
            a.Password = Password.Text;
            if (a.LoginCorrecto())
            {
                e.IsValid = true;
            }
        }

        protected bool LoginCorrecto(string usuario, string password)
        {
            var admin = new AdministradorEN(usuario, password);
            return admin.LoginCorrecto();
        }
    }
}