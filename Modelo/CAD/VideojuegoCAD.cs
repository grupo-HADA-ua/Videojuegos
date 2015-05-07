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
        private Conectar _conectar;
        private SqlConnection _conexion;

        public VideojuegoCAD()
        {
            _conectar = new Conectar();
            _conexion = _conectar.Conexion;
        }

        public void Crear(VideojuegoEN v)
        {
            try
            {
                _conexion.Open();
                var sql = "INSERT INTO videojuegos(nombre, precio, cantidadstock, edadminima, descripcion) " +
                    "values(@nombre, @precio, @cantidadstock, @edadminima, @descripcion);";
                var cmd = new SqlCommand(sql, _conexion);
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
                _conexion.Close();
            }
        }

        public void Actualizar(VideojuegoEN v)
        {
            try
            {
                _conexion.Open();

                var sql = "UPDATE videojuegos SET nombre=@nombre, edadminima=@edadminima, " +
                    "cantidadstock=@cantidadstock, precio=@precio, descripcion=@descripcion " +
                    "WHERE id=@id";
                var cmd = new SqlCommand(sql, _conexion);
                cmd.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = v.Nombre;
                cmd.Parameters.Add("@edadminima", SqlDbType.Int).Value = v.EdadMinima;
                cmd.Parameters.Add("@cantidadstock", SqlDbType.Int).Value = v.CantidadStock;
                cmd.Parameters.Add("@precio", SqlDbType.Float).Value = v.Precio;
                cmd.Parameters.Add("@descripcion", SqlDbType.Text).Value = v.Descripcion;
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = v.Id;
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

        public VideojuegoEN ObtenerPorId(int id)
        {
            var v = new VideojuegoEN();

            try
            {
                _conexion.Open();

                var sql = "SELECT id, nombre, precio, cantidadstock, edadminima, descripcion FROM videojuegos " +
                    "WHERE id=@id";
                var cmd = new SqlCommand(sql, _conexion);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                var r = cmd.ExecuteReader();

                while (r.Read())
                {
                    v.Id = (int)r["id"];
                    v.Nombre = (string)r["nombre"];
                    v.Precio = (double)r["precio"];
                    v.CantidadStock = (int)r["cantidadstock"];
                    v.EdadMinima = (int)r["edadminima"];
                    v.Descripcion = (string)r["descripcion"];
                }
            }
            catch (Exception e)
            {
                e.ToString();
            }
            finally
            {
                _conexion.Close();
            }

            return v;
        }

        public IList<VideojuegoEN> ObtenerTodos()
        {
            var videojuegos = new List<VideojuegoEN>();

            try
            {
                _conexion.Open();
                var sql = "SELECT id, nombre, precio, cantidadstock, edadminima, descripcion FROM videojuegos";
                var cmd = new SqlCommand(sql, _conexion);
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
                _conexion.Close();
            }

            return videojuegos;
        }

        public void BorrarTodos()
        {
            try
            {
                _conexion.Open();
                var sql = "TRUNCATE TABLE videojuegos;";
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
