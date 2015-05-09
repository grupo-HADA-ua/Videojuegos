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

        protected void CrearConsola(object sender, EventArgs e)
        {
            var c = new ConsolaEN();
            c.Nombre = NombreConsola.Text;
            c.Precio = double.Parse(PrecioConsola.Text);
            c.CantidadStock = int.Parse(StockConsola.Text);
            c.Descripcion = DescripcionConsola.Text;
            c.Guardar();
            Response.Redirect("~/Administrador/Productos.aspx");
        }

        protected void CrearPeriferico(object sender, EventArgs e)
        {
            var p = new PerifericoEN();
            p.Nombre = NombrePeriferico.Text;
            p.Precio = double.Parse(PrecioPeriferico.Text);
            p.CantidadStock = int.Parse(StockPeriferico.Text);
            p.Descripcion = Descripcion.Text;
            p.Guardar();
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