using Modelo.CAD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo.EN
{
    public class PedidoEN
    {
        private PedidoCAD _cad;

        private int id;
        public int Id { get { return id; } set { id = value; } }

        private int cliente;
        public int Cliente { get { return cliente; } set { cliente = value; } }

        public double Total { get; set; }

        private IList<LineaPedidoEN> lineas;
        public IList<LineaPedidoEN> Lineas 
        { get 
          { return new List<LineaPedidoEN>(lineas); } 
          set 
          { lineas = new List<LineaPedidoEN>(value); } 
        }

        public PedidoEN()
        {
            Lineas = new List<LineaPedidoEN>();
            _cad = new PedidoCAD();
        }

        public PedidoEN(PedidoEN p)
        {
            inicializar(p.Id, p.Cliente, p.Lineas);
        }

        public PedidoEN(int id, int idCliente, IList<LineaPedidoEN> l)
        {
            inicializar(id, idCliente, l);
        }

        private void inicializar(int id, int idCliente, IList<LineaPedidoEN> l)
        {
            Id = id;
            Cliente = idCliente;
            Lineas = new List<LineaPedidoEN>(l);
            _cad = new PedidoCAD();
        }

        public void Guardar()
        {
            _cad.Crear(this);
        }

        public PedidoEN Obtener(int id)
        {
            return _cad.Obtener(id);
        }

        public IList<PedidoEN> ObtenerTodos()
        {
            return _cad.ObtenerTodos();
        }

        public void Actualizar()
        {
            _cad.Actualizar(this);
        }

        public void Borrar()
        {
            _cad.Borrar(this);
        }

        public void BorrarTodos()
        {
            _cad.BorrarTodos();
        }
    }
}
