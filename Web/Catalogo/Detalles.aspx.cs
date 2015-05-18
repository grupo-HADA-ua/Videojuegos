using Modelo.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Catalogo
{
    public partial class Detalles : System.Web.UI.Page
    {
        protected ProductoEN _producto = new ProductoEN();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["id"] != null)
            {
                var id = int.Parse(Request["id"]);
                switch (Request["clase"].ToString())
                {
                    case "videojuego":
                        var v = new VideojuegoEN();
                        v.Id = id;
                        v = v.ObtenerPorId();
                        _producto = v;
                        break;
                    case "consola":
                        var con = new ConsolaEN();
                        con.Id = id;
                        con = con.ObtenerPorId();
                        _producto = con;
                        break;
                    case "periferico":
                        var per = new PerifericoEN();
                        per.Id = id;
                        per = per.ObtenerPorId();
                        _producto = per;
                        break;
                }
            }
            else
            {
                Response.Redirect("~/Catalogo/Catalogo.aspx");
            }
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
    }
}