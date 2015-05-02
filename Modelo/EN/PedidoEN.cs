using Modelo.CAD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo.EN
{
    public class PedidoEN
    {
        private IPedidoCAD cad;

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


        private string fecha;
        public string Fecha { get { return fecha; } set { fecha = value; } }


        private bool confirmado;
        public bool Confirmado
        {
            get { return confirmado; }
            set { confirmado = value; }
        }

        private bool enviado;
        public bool Enviado
        {
            get { return enviado; }
            set { enviado = value; }
        }



        public PedidoEN()
        {
            Lineas = new List<LineaPedidoEN>();
            cad = new PedidoCAD();
        }

        public PedidoEN(PedidoEN p)
        {
            inicializar(p.Id, p.IdCliente, p.Lineas,p.Fecha,p.Confirmado,p.Enviado);
        }

        public PedidoEN(int id, int idCliente, IList<LineaPedidoEN> l,string fecha="",bool confirmado= false, bool enviado = false)
        {
            inicializar(id, idCliente, l,fecha, confirmado, enviado);
        }

        private void inicializar(int id, int idCliente, IList<LineaPedidoEN> l,string fecha="",bool confirmado= false, bool enviado = false)
        {
            Id = id;
            IdCliente = idCliente;
            Lineas = new List<LineaPedidoEN>(l);
            Fecha = fecha;
            Confirmado = confirmado;
            Enviado = enviado;
            cad = new PedidoCAD();
        }

        public void Guardar()
        {
            cad.Crear(this);
        }

        public PedidoEN Obtener(int id)
        {
            return cad.Obtener(id);
        }

        public IList<PedidoEN> ObtenerTodos()
        {
            return cad.ObtenerTodos();
        }

        public void Actualizar()
        {
            cad.Actualizar(this);
        }

        public void Borrar()
        {
            cad.Borrar(this);
        }
    }
}
