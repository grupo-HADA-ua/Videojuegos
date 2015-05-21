using Modelo.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Modelo.Carrito;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace Web.Usuario
{
    public partial class Perfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["id"] != null)
            {
                var c = (Carrito)Session["Carrito"];
                var p = new ProductoEN();
                p.Id = int.Parse(Request["id"]);
                p.Nombre = Request["nombre"];
                c.Remove(p);
                Session["Carrito"] = c;
                Response.Redirect("~/Usuario/Perfil.aspx");
            }
        }

        public ClienteEN getUsuarioActual()
        {
            var c = (ClienteEN) Session["Cliente"];
            return c;
        }

        public Carrito ObtenerCarrito()
        {
            return (Carrito)Session["Carrito"];
        }

        public void Comprar(object sender, EventArgs e)
        {
            var compra = new Document(PageSize.LETTER);
            var writer = PdfWriter.GetInstance(compra, new FileStream(@"c:\Users\Manuel\compra.pdf", FileMode.Create));

            compra.AddTitle("Compra Otrogami");
            compra.AddCreator("BalumaProject");

            compra.Open();
            iTextSharp.text.Font standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            iTextSharp.text.Font boldFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.BOLD, BaseColor.BLACK);

            var fecha = DateTime.Today;
            var p = new Paragraph();
            p.Add(new Chunk("FECHA DE COMPRA: " + fecha.ToString(), boldFont));

            compra.Add(p);

            var c = (Carrito)Session["Carrito"];
            var total = 0.0;
            c.Productos.ForEach(prod => {
                var p2 = new Paragraph();
                p2.Add(new Chunk(prod.Nombre + ", precio: " + prod.Precio.ToString(), standardFont));
                compra.Add(p2);
                total += prod.Precio;
            });
            var precio = new Paragraph();
            precio.Add(new Chunk("TOTAL: " + total.ToString(), boldFont));
            compra.Add(precio);

            compra.Close();
            writer.Close();

            c.Productos.Clear();

            Response.ContentType = "application/pdf";
            Response.AppendHeader("Content-Disposition", "attachmend; filename=compra.pdf");
            Response.TransmitFile(@"c:\Users\Manuel\compra.pdf");
            Response.End();
            Response.Redirect("Perfil.aspx");
        }
    }
}