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
    class PedidoCAD
    {
        private Conectar _conectar;
        private SqlConnection _conexion;

        public PedidoCAD()
        {
            _conectar = new Conectar();
            _conexion = _conectar.Conexion;
        }

        public void Crear(PedidoEN p)
        {
            try
            {
                _conexion.Open();

                var sql = "INSERT INTO pedido(cliente, total) " +
                    "VALUES(@cliente, @total);";
                var cmd = new SqlCommand(sql, _conexion);
                cmd.Parameters.Add("@cliente", SqlDbType.Int).Value = p.Cliente;
                cmd.Parameters.Add("@total", SqlDbType.Float).Value = p.Total;
                cmd.ExecuteNonQuery();

            }
            catch(Exception e)
            {
                e.ToString();
            }
            finally
            {
                _conexion.Close();
            }
        }

        public PedidoEN Obtener(int id)
        {
            // TODO
            return null;
        }

        public IList<PedidoEN> ObtenerTodos()
        {
            // TODO
            return null;
        }

        public void Actualizar(PedidoEN p)
        {
            // TODO
        }

        public void Borrar(PedidoEN p)
        {
            // TODO
        }

        public void BorrarTodos()
        {
            try
            {
                _conexion.Open();

                var sql = "TRUNCATE TABLE pedido;";
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
