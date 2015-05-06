using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using Modelo.EN;
using Modelo.Conexion;
using System.Data;

namespace Modelo.CAD
{
    class ConsolaCAD : ProductoCAD
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

        //Actualiza un movil en la bbdd
        public void Actualizar(ConsolaEN consolaEN)
        {
            Conectar();

            string orden = "update Consola set nombre = '" + consolaEN.Nombre;
            orden += "', precio = " + consolaEN.Precio.ToString();
            orden += "', cantidadstock = " + consolaEN.CantidadStock.ToString();
            orden += "' where id = " + consolaEN.Id.ToString() + ";";

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

        //Metodo para mostrar un movil de la bbdd
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
