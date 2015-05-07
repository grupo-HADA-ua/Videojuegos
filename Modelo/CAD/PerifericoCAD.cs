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
    class PerifericoCAD
    {
        private Conectar _conectar;
        private SqlConnection _conexion;

        public PerifericoCAD()
        {
            _conectar = new Conectar();
            _conexion = _conectar.Conexion;
        }

        public void Crear(PerifericoEN p)
        {
            try
            {
                _conexion.Open();

                var sql = "INSERT INTO perifericos(nombre, precio, cantidadstock, descripcion) " +
                    "VALUES(@nombre, @precio, @cantidadstock, @descripcion);";
                var cmd = new SqlCommand(sql, _conexion);
                cmd.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = p.Nombre;
                cmd.Parameters.Add("@precio", SqlDbType.Float).Value = p.Precio;
                cmd.Parameters.Add("@cantidadstock", SqlDbType.Int).Value = p.CantidadStock;
                cmd.Parameters.Add("@descripcion", SqlDbType.Text).Value = p.Descripcion;
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

        public IList<PerifericoEN> ObtenerTodos()
        {
            var perifericos = new List<PerifericoEN>();

            try
            {
                _conexion.Open();

                var sql = "SELECT id, nombre, precio, cantidadstock, descripcion FROM perifericos;";
                var cmd = new SqlCommand(sql, _conexion);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var p = new PerifericoEN();
                    p.Id = (int)reader["id"];
                    p.Nombre = (string)reader["nombre"];
                    p.Precio = (double)reader["precio"];
                    p.Descripcion = (string)reader["descripcion"];
                    perifericos.Add(p);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                e.ToString();
            }
            finally
            {
                _conexion.Close();
            }

            return perifericos;
        }

        public void BorrarTodos()
        {
            try
            {
                _conexion.Open();

                var sql = "TRUNCATE TABLE perifericos";
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
