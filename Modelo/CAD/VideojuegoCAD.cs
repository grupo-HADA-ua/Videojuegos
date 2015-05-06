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
    class VideojuegoCAD
    {
        private Conectar conectar;
        private SqlConnection conexion;

        public VideojuegoCAD()
        {
            conectar = new Conectar();
            conexion = conectar.Conexion;
        }

        public void Crear(VideojuegoEN v)
        {
            try
            {
                conexion.Open();
                var sql = "INSERT INTO videojuegos(nombre, precio, cantidadstock, edadminima, descripcion) " +
                    "values(@nombre, @precio, @cantidadstock, @edadminima, @descripcion);";
                var cmd = new SqlCommand(sql, conexion);
                cmd.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = v.Nombre;
                cmd.Parameters.Add("@precio", SqlDbType.Decimal).Value = v.Precio;
                cmd.Parameters.Add("@cantidadstock", SqlDbType.Int).Value = v.CantidadStock;
                cmd.Parameters.Add("@edadminima", SqlDbType.Int).Value = v.EdadMinima;
                cmd.Parameters.Add("@descripcion", SqlDbType.Text).Value = v.Descripcion;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                conexion.Close();
            }
        }

        public IList<VideojuegoEN> ObtenerTodos()
        {
            var videojuegos = new List<VideojuegoEN>();

            try
            {
                conexion.Open();
                var sql = "SELECT id, nombre, precio, cantidadstock, edadminima, descripcion FROM videojuegos";
                var cmd = new SqlCommand(sql, conexion);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var v = new VideojuegoEN();
                    v.Id = (int)reader["id"];
                    v.Nombre = (string)reader["nombre"];
                    v.CantidadStock = (int)reader["cantidadstock"];
                    v.EdadMinima = (int)reader["edadminima"];
                    v.Precio = (double)reader["precio"];
                    v.Descripcion = (string)reader["descripcion"];
                    videojuegos.Add(v);
                }
            }
            catch (Exception e)
            {
                e.ToString();
            }
            finally{
                conexion.Close();
            }

            return videojuegos;
        }

        public void BorrarTodos()
        {
            try
            {
                conexion.Open();
                var sql = "TRUNCATE TABLE videojuegos;";
                var cmd = new SqlCommand(sql, conexion);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                e.ToString();
            }
            finally
            {
                conexion.Close();
            }
        }
    }
}
