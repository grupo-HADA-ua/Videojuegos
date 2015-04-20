using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Modelo.EN;

namespace Web
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected IList<ClienteEN> ObtenerClientes()
        {
            IList<ClienteEN> clientes = new List<ClienteEN>();
            clientes.Add(new ClienteEN(1, "Manu", "Manu@hada.com", "manuPassword"));
            clientes.Add(new ClienteEN(2, "Ana", "Ana@hada.com", "anaPassword"));
            clientes.Add(new ClienteEN(3, "Andres", "Andres@hada.com", "andresPassword"));

            return clientes;
        }

        protected string Hola()
        {
            return "hola";
        }
    }
}
