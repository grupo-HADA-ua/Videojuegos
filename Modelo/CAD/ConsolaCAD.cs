using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using Modelo.EN;
using Modelo.Conexion;
using System.Data;

namespace Modelo.CAD
{
    class ConsolaCAD
    {
        private Conectar _conectar;
        private SqlConnection _conexion;
        private string cadena;
        //private ProductoCAD CAD_Producto;

        //Constructor
        public ConsolaCAD()
        {
            _conectar = new Conectar();
            _conexion = _conectar.Conexion;
        }

        public void Crear(ConsolaEN c)
        {
            try
            {
                _conexion.Open();
                var sql = "INSERT INTO consolas(nombre, precio, cantidadstock, descripcion) " +
                    "VALUES(@nombre, @precio, @cantidadstock, @descripcion);";
                var cmd = new SqlCommand(sql, _conexion);
                cmd.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = c.Nombre;
                cmd.Parameters.Add("@precio", SqlDbType.Float).Value = c.Precio;
                cmd.Parameters.Add("@cantidadstock", SqlDbType.Int).Value = c.CantidadStock;
                cmd.Parameters.Add("@descripcion", SqlDbType.Text).Value = c.Descripcion;
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

        public ConsolaEN ObtenerPorId(int id)
        {
            var c = new ConsolaEN();
            try
            {
                _conexion.Open();
                var sql = "SELECT id, nombre, precio, cantidadstock, descripcion " +
                    "FROM consolas WHERE id=@id";
                var cmd = new SqlCommand(sql, _conexion);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                var r = cmd.ExecuteReader();

                if (r.Read())
                {
                    c.Id = (int)r["id"];
                    c.Nombre = (string)r["nombre"];
                    c.Precio = (double)r["precio"];
                    c.CantidadStock = (int)r["cantidadstock"];
                    c.Descripcion = (string)r["descripcion"];
                }
                r.Close();
            }
            catch (Exception e)
            {
                e.ToString();
            }
            finally
            {
                _conexion.Close();
            }
            return c;
        }

        public IList<ConsolaEN> ObtenerTodos()
        {
            var consolas = new List<ConsolaEN>();

            try
            {
                _conexion.Open();
                var sql = "SELECT id, nombre, precio, cantidadstock, descripcion FROM consolas;";
                var cmd = new SqlCommand(sql, _conexion);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var c = new ConsolaEN();
                    c.Id = (int)reader["id"];
                    c.Nombre = (string)reader["nombre"];
                    c.Precio = (double)reader["precio"];
                    c.CantidadStock = (int)reader["cantidadstock"];
                    c.Descripcion = (string)reader["descripcion"];
                    consolas.Add(c);
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

            return consolas;
        }

        public void BorrarTodos()
        {
            try
            {
                _conexion.Open();
                var sql = "TRUNCATE TABLE consolas;";
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
        
        public void Actualizar(ConsolaEN c)
        {
            try
            {
                _conexion.Open();

                var sql = "UPDATE consolas SET nombre=@nombre, precio=@precio, " +
                    "cantidadstock=@cantidadstock, descripcion=@descripcion " +
                    "WHERE id=@id";
                var cmd = new SqlCommand(sql, _conexion);
                cmd.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = c.Nombre;
                cmd.Parameters.Add("@cantidadstock", SqlDbType.Int).Value = c.CantidadStock;
                cmd.Parameters.Add("@precio", SqlDbType.Float).Value = c.Precio;
                cmd.Parameters.Add("@descripcion", SqlDbType.Text).Value = c.Descripcion;
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = c.Id;
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

        //Metodo para borrar un movil de la bddd
        public void Borrar(int p)
        {
            BorrarConsola(p.ToString());
        }
        public void BorrarConsola(string id)
        {
            Conectar();

            string orden = "delete from consola where id = " + id + ")";

            try
            {
                SqlCommand comando = new SqlCommand(orden, _conexion);

                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                e.ToString();
            }
            finally
            {
                Desconectar();
            }
        }
        
        public ConsolaEN Mostrar(int id)
        {
            ProductoEN producto = new ConsolaEN();
            // CAD_Producto.cargarDatosProducto(id, producto.TipoProducto, out producto);
            ConsolaEN consola = (ConsolaEN)producto;

            Conectar();

            string orden = "select * from Consola where id = " + id + ";";

            try
            {
                SqlCommand conectar = new SqlCommand(orden, _conexion);
                SqlDataReader reader = conectar.ExecuteReader();

                if (reader.Read())
                {
                    consola.Nombre = (string)(reader["nombre"]);
                    consola.Precio = (double)(reader["precio"]);
                    consola.CantidadStock = (int)(reader["cantidadstock"]);
                }
                else throw new Exception("No es una consola");

                reader.Close();
            }
            catch (Exception e)
            {
                consola = new ConsolaEN();
                e.ToString();
            }

            return consola;
        }

        //Metodos para conectar y desconectar de la bbdd
        private void Conectar()
        {
            if (_conexion.State != System.Data.ConnectionState.Open)
                _conexion.Open();
        }
        private void Desconectar()
        {
            if (_conexion.State == System.Data.ConnectionState.Open)
                _conexion.Close();
        }
    }
}
