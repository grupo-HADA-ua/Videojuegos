using System;

namespace Web.Administrador
{
    public partial class Administrador : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Salir(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/Administrador/Login.aspx");
        }
    }
}