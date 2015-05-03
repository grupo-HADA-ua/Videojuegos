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

        protected void Logear(object sender, EventArgs e)
        {
            var c = new ClienteEN();
            c.Email = Email.Text;
            c.Password = Password.Text;
            Session.Add("Cliente", null);
            if (LoginCorrecto(Email.Text, Password.Text))
            {
                Session.Add("Cliente", c.Obtener());
                Response.Redirect("Perfil");
            }
            Response.Redirect("Login");
            
        }

        protected void ComprobarDatos(object sender, ServerValidateEventArgs e)
        {
            e.IsValid = false;
            var c = new ClienteEN();
            c.Email = Email.Text;
            c.Password = Password.Text;
            if (c.LoginCorrecto())
            {
                e.IsValid = true;
            }
        }

        private bool LoginCorrecto(string email, string password)
        {
            var c = new ClienteEN();
            c.Email = email;
            c.Password = password;
            if (c.LoginCorrecto())
            {
                return true;
            }
            return false;
        }
    }
}