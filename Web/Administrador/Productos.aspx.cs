using Modelo.EN;
using System;
using System.Collections.Generic;

namespace Web.Administrador
{
    public partial class Productos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Administrador"] == null)
            {
                Response.Redirect("~/Administrador/Login.aspx");
            }
        }

        protected void CrearVideojuego(object sender, EventArgs e)
        {
            var v = new VideojuegoEN();
            v.Nombre = Nombre.Text;
            v.Precio = double.Parse(Precio.Text);
            v.EdadMinima = int.Parse(Edad.Text);
            v.CantidadStock = int.Parse(Stock.Text);
            v.Descripcion = Descripcion.Text;
            v.Guardar();
            Response.Redirect("~/Administrador/Productos.aspx");
        }

        protected IList<VideojuegoEN> ObtenerVideojuegos()
        {
            return (new VideojuegoEN()).ObtenerTodos();
        }

        protected IList<ConsolaEN> ObtenerConsolas()
        {
            return (new ConsolaEN()).ObtenerTodos();
        }

        protected IList<PerifericoEN> ObtenerPerifericos()
        {
            return (new PerifericoEN()).ObtenerTodos();
        }
    }
}