using Modelo.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Administrador
{
    public partial class EditarVideojuego : System.Web.UI.Page
    {
        protected int _id;
        protected VideojuegoEN _v;

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
                    _v = new VideojuegoEN();
                    _v.Id = _id;
                    _v = _v.ObtenerPorId();
                    InformacionActual();
                }
                else
                {
                    Response.Redirect("~/Administrador/Productos.aspx");
                }
                
            }           
        }

        protected void Actualizar(object sender, EventArgs e)
        {
            var v = new VideojuegoEN();
            v.Id = int.Parse(Request["id"]);
            v.Nombre = Nombre.Text;
            v.EdadMinima = int.Parse(Edad.Text);
            v.Precio = double.Parse(Precio.Text);
            v.CantidadStock = int.Parse(Stock.Text);
            v.Descripcion = Descripcion.Text;
            v.Actualizar();
            Response.Redirect("Productos.aspx");
        }

        private void InformacionActual()
        {
            Nombre.Text = _v.Nombre;
            Edad.Text = _v.EdadMinima.ToString();
            Precio.Text = _v.Precio.ToString();
            Stock.Text = _v.CantidadStock.ToString();
            Descripcion.Text = _v.Descripcion;
        }
    }    
}