using Modelo.Conexion;
using Modelo.EN;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Modelo.CAD
{
    class LineaPedidoCAD : ILineaPedidoCAD
    {
        private Conectar _conectar;
        private SqlConnection _conexion;

        public LineaPedidoCAD()
        {
            _conectar = new Conectar();
            _conexion = _conectar.Conexion;
        }

        public void Crear(LineaPedidoEN l)
        {
            try
            {
                _conexion.Open();

                var sql = "INSERT INTO lineapedido(pedido, cantidad, precio, videojuego, consola, periferico) " +
                    "VALUES(@pedido, @cantidad, @precio, @videojuego, @consola, @periferico);";
                var cmd = new SqlCommand(sql, _conexion);
                cmd.Parameters.Add("@pedido", SqlDbType.Int).Value = l.Pedido;
                cmd.Parameters.Add("@cantidad", SqlDbType.Int).Value = l.Cantidad;
                cmd.Parameters.Add("@videojuego", SqlDbType.Int).Value = l.Videojuego;
                cmd.Parameters.Add("@consola", SqlDbType.Int).Value = l.Consola;
                cmd.Parameters.Add("@periferico", SqlDbType.Int).Value = l.Periferico;
                var producto = l.Producto();
                l.Precio = producto.Precio;
                cmd.Parameters.Add("@precio", SqlDbType.Float).Value = l.Precio;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                e.ToString();
            }
            finally
            {
                _conexion.Close();
            }
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

        public void BorrarTodos()
        {
            try
            {
                _conexion.Open();

                var sql = "TRUNCATE TABLE lineapedido;";
                var cmd = new SqlCommand(sql, _conexion);
               
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                e.ToString();
            }
            finally
            {
                _conexion.Close();
            }
        }
    }
}
