using Modelo.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Usuario
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Registrarse(object sender, EventArgs e)
        {
            var cliente = new ClienteEN();
            cliente.Nombre = Nombre.Text;
            cliente.Email = Email.Text;
            cliente.Password = Password.Text;
            cliente.Direccion = Direccion.Text;
            cliente.Guardar();
        }

        protected void MismoPassword(object sender, ServerValidateEventArgs e)
        {
            if (Password.Text == PasswordConfirmation.Text)
            {
                e.IsValid = true;
            }
            else
            {
                e.IsValid = false;
            }
        }

        protected void ExisteUsuario(object sender, ServerValidateEventArgs e)
        {
            var cliente = new ClienteEN();
            cliente.Email = Email.Text;
            if (cliente.Existe())
            {
                e.IsValid = false;
            }
            else
            {
                e.IsValid = true;
            }
        }
    }
}