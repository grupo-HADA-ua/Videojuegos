using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class Contacto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Email_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)//Se abre el programa predeterminado de correo para enviarle el mensaje
        {
            String Parametros;
            String Para = "mailto:greenrocks54@gmail.com";
            String Asunto = TextBox1.Text;//Origen (validado)
            String Mensaje = TextBox2.Text;//Mensaje del texto (no puede ser nulo)
            String Archivo = "";

            Parametros = Para + "?subject=" + Asunto + "&body=" + Mensaje + "&Attachment=" + Archivo;
            System.Diagnostics.Process.Start(Parametros);
        }
    }
}