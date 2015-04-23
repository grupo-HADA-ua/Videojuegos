using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo.EN
{
    public class PedidoEN
    {
        private int id;
        public int Id { get { return id; } set { id = value; } }

        private int idCliente;
        public int IdCliente { get { return idCliente; } set { idCliente = value; } }

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
        }

        public PedidoEN(PedidoEN p)
        {
            inicializar(p.Id, p.IdCliente, p.Lineas);
        }

        public PedidoEN(int id, int idCliente, IList<LineaPedidoEN> l)
        {
            inicializar(id, idCliente, l);
        }

        private void inicializar(int id, int idCliente, IList<LineaPedidoEN> l)
        {
            Id = id;
            IdCliente = idCliente;
            Lineas = new List<LineaPedidoEN>(l);
        }
    }
}
