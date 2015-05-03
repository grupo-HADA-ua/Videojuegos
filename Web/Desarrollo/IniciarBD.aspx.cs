using Modelo.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Desarrollo
{
    public partial class IniciarBD : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            generarClientes();
        }

        private void generarClientes()
        {
            var cliente = new ClienteEN();
            cliente.BorrarTodos();
            cliente = new ClienteEN("manu", "manu@manu.com", "manuel", "no quiero decir mi direccion");
            cliente.Guardar();
            cliente = new ClienteEN("ana", "ana@ana.com", "anamaria", "por donde la lonja");
            cliente.Guardar();
            cliente = new ClienteEN("andres", "andres@andres.com", "andresprimo", "por ahí por altabix");
            cliente.Guardar();
        }
    }
}