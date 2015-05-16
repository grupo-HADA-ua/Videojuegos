using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo.CAD;

namespace Modelo.EN
{
    public class LineaPedidoEN
    {
        private LineaPedidoCAD _cad;
        public int Id { get; set; }
        public int Pedido { get; set; }
        public int Videojuego { get; set; }
        public int Consola { get; set; }
        public int Periferico { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }

        public LineaPedidoEN()
        {
            _cad = new LineaPedidoCAD();
            Videojuego = -1;
            Consola = -1;
            Periferico = -1;
        }

        public void Guardar()
        {
            _cad.Crear(this);
        }

        public void BorrarTodos()
        {
            _cad.BorrarTodos();
        }

        public ProductoEN Producto()
        {
            if (Videojuego != -1)
            {
                var v = new VideojuegoEN();
                v.Id = Videojuego;
                return v.ObtenerPorId();
                
            }
            else if(Consola != -1)
            {
                var c = new ConsolaEN();
                c.Id = Consola;
                return c.ObtenerPorId();
            }
            var p = new PerifericoEN();
            p.Id = Periferico;
            return p.ObtenerPorId();
        }

    }
}