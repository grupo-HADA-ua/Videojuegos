using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using Modelo.EN;
using Modelo.Conexion;


namespace Modelo.CAD
{
    class LineaPedidoCAD : ILineaPedidoCAD
    {


        private SqlConnection BD;
        private Conectar conectar;



        public LineaPedidoCAD()
        {
            conectar = new Conectar();
            BD = conectar.Conexion;
        }

        public void Crear(LineaPedidoEN l)
        {
            //TODO
        }

        public LineaPedidoEN Obtener(int id)
        {
            //TODO
            return null;
        }

        public IList<LineaPedidoEN> ObtenerTodos()
        {
            // TODO
            return null;
        }

        public void Actualizar(LineaPedidoEN l)
        {
            // TODO
        }

        public void Borrar(LineaPedidoEN l)
        {
            // TODO
        }
    }
}
