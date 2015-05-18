using Modelo.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Administrador
{
    public partial class EditarConsola : System.Web.UI.Page
    {
        protected int _id;
        protected ConsolaEN _c;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Administrador"] == null)
            {
                Response.Redirect("~/Administrador/Login.aspx");
            }

            if (!IsPostBack)
            {
                if (Request["id"] != null)
                {
                    _id = int.Parse(Request["id"]);
                    _c = new ConsolaEN();
                    _c.Id = _id;
                    _c = _c.ObtenerPorId();
                    InformacionActual();
                }
                else
                {
                    Response.Redirect("~/Administrador/Productos.aspx");
                }
            }
        }

        protected void Actualizar(object sender, EventArgs r)
        {
            var c = new ConsolaEN();
            c.Id = int.Parse(Request["id"]);
            c.Nombre = Nombre.Text;
            c.Precio = double.Parse(Precio.Text);
            c.CantidadStock = int.Parse(Stock.Text);
            c.Descripcion = Descripcion.Text;
            c.Actualizar();
            Response.Redirect("Productos.aspx");
        }

        private void InformacionActual()
        {
            Nombre.Text = _c.Nombre;
            Precio.Text = _c.Precio.ToString();
            Stock.Text = _c.CantidadStock.ToString();
            Descripcion.Text = _c.Descripcion;
        }
    }
}