using Modelo.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Administrador
{
    public partial class EditarPeriferico : System.Web.UI.Page
    {
        protected int _id;
        protected PerifericoEN _p;

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
                    _p = new PerifericoEN();
                    _p.Id = _id;
                    _p = _p.ObtenerPorId();
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
            var c = new PerifericoEN();
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
            Nombre.Text = _p.Nombre;
            Precio.Text = _p.Precio.ToString();
            Stock.Text = _p.CantidadStock.ToString();
            Descripcion.Text = _p.Descripcion;
        }
    }
}