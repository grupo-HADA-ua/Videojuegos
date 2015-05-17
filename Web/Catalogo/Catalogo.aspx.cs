using Modelo.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Modelo.Carrito;

namespace Web.Catalogo
{
    public partial class Catalogo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["id"] != null)
            {
                var id = int.Parse(Request["id"]);
                var c = (Carrito)Session["Carrito"];
                switch (Request["clase"].ToString())
                {
                    case "videojuego":
                        var v = new VideojuegoEN();
                        v.Id = id;
                        v = v.ObtenerPorId();
                        v.CantidadStock -= 1;
                        v.Actualizar();
                        c.Add(v);
                        break;
                    case "consola":
                        var con = new ConsolaEN();
                        con.Id = id;
                        con = con.ObtenerPorId();
                        con.CantidadStock -= 1;
                        con.Actualizar();
                        c.Add(con);
                        break;
                    case "periferico":
                        var per = new PerifericoEN();
                        per.Id = id;
                        per = per.ObtenerPorId();
                        per.CantidadStock -= 1;
                        per.Actualizar();
                        c.Add(per);
                        break;
                }
                Session["Carrito"] = c;
            }

        }

        protected string Tipo(ProductoEN p)
        {
            if (p is VideojuegoEN)
            {
                return "videojuego";
            }
            else if (p is ConsolaEN)
            {
                return "consola";
            }
            return "periferico";
        }

        protected IList<VideojuegoEN> ObtenerVideojuegos()
        {
            var v = new VideojuegoEN();
            IList<VideojuegoEN> videojuegos = v.ObtenerTodos();
            return videojuegos;
        }

        protected IList<ProductoEN> ObtenerProductos()
        {
            var p = new ProductoEN();
            IList<ProductoEN> productos = p.ObtenerTodos();
            return productos;
        }

        protected string ObtenerClase(ProductoEN p)
        {
            if (p is VideojuegoEN)
            {
                return "videojuego";
            }
            else if (p is ConsolaEN)
            {
                return "consola";
            }
            return "periferico";
        }

        protected bool IsLogedIn()
        {
            if (Session["Cliente"] != null)
            {
                return true;
            }
            return false;
        }
    }
}