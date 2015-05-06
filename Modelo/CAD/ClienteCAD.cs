using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using Modelo.EN;
using Modelo.Conexion;
using System.Data;

namespace Modelo.CAD
{
    public class ClienteCAD : IClienteCAD
    {
        private Conectar _conectar;
        private SqlConnection _conexion; 

        public ClienteCAD()
        {
            _conectar = new Conectar();
            _conexion = _conectar.Conexion;
        }

        //METODOS
        //CRUD

        //Insertar un usuario en la bbdd
        public void Crear(ClienteEN c)
        {
            try
            {
                _conexion.Open();
                string sql = "INSERT INTO cliente(nombre, email, password, direccion) values (@nombre, @email, @password, @direccion);";
                SqlCommand cmd = new SqlCommand(sql, _conexion);
                cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = c.Nombre;
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = c.Email;
                cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = c.Password;
                cmd.Parameters.Add("@direccion", SqlDbType.VarChar).Value = c.Direccion;
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

        public bool Existe(ClienteEN c)
        {
            bool existe = false;
            try
            {
                _conexion.Open();
                var sql = "SELECT email FROM Cliente WHERE email LIKE @email;";
                var cmd = new SqlCommand(sql, _conexion);
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = c.Email;
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    existe = true;
                }

            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                _conexion.Close();
            }
            return existe;
        }

        public bool LoginCorrecto(ClienteEN c) {
            bool datos = false;
            try{
                _conexion.Open();
                var sql = "SELECT email, password FROM Cliente WHERE email=@email AND password=@password;";
                var cmd = new SqlCommand(sql, _conexion);
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = c.Email;
                cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = c.Password;
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    datos = true;
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
            return datos;
        }

        public void BorrarTodos()
        {
            try
            {
                _conexion.Open();
                var sql = "TRUNCATE TABLE Cliente;";
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

        public ClienteEN Obtener(ClienteEN c)
        {
            try
            {
                _conexion.Open();
                var sql = "SELECT id, nombre, email, password, direccion FROM Cliente WHERE " +
                    "email LIKE @email;";
                var cmd = new SqlCommand(sql, _conexion);
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = c.Email;
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    c.Id = reader["id"].ToString();
                    c.Nombre = reader["nombre"].ToString();
                    c.Email = reader["email"].ToString();
                    c.Password = reader["email"].ToString();
                    c.Direccion = reader["direccion"].ToString();
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
            return c;
        }

        public IList<ClienteEN> ObtenerTodos()
        {
            var clientes = new List<ClienteEN>();

            try
            {
                _conexion.Open();

                var sql = "SELECT id, nombre, email, direccion FROM Cliente;";
                var cmd = new SqlCommand(sql, _conexion);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var c = new ClienteEN();
                    c.Id = reader["id"].ToString();
                    c.Nombre = (string)reader["nombre"];
                    c.Email = (string)reader["email"];
                    c.Direccion = (string)reader["direccion"];
                    clientes.Add(c);
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

            return clientes;
        }
        

        //Actualizar un usuario en la bbdd
        public void Actualizar(ClienteEN clienteEN)
        {
            try
            {
                _conexion.Open();
                string com = "update Cliente set ";
                com += "id = '" + clienteEN.Id.ToString() + "', ";
                com += "nombre = '" + clienteEN.Nombre.ToString() + "', ";
                com += "email = '" + clienteEN.Email.ToString() + "', ";
                com += "password = '" + clienteEN.Password.ToString() + "', ";
                com += "direccion = '" + clienteEN.Direccion.ToString() + "', ";
                SqlCommand comand = new SqlCommand(com, _conexion);
                comand.ExecuteNonQuery();
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

        //borrar un usuario de la bbdd
        public void Borrar(ClienteEN c)
        {
            try
            {
                _conexion.Open();
                string com = "delete from Cliente where id = '" + c.Id + "'";

                SqlCommand comand = new SqlCommand(com, _conexion);
                comand.ExecuteNonQuery();
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

        //Se llamará desde las clases derivadas y cargará los datos de la tabla articulo
        public void cargarDatoscliente(string id, out ClienteEN cliente)
        {
            cliente = new ClienteEN();
            _conexion.Open();

            string orden = "select * from Cliente where id = " + id + ";";

            try
            {
                SqlCommand comando = new SqlCommand(orden, _conexion);
                SqlDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    cliente.Id = reader["id"].ToString();
                    cliente.Nombre = reader["nombre"].ToString();
                    cliente.Email = (reader["email"].ToString());
                    cliente.Password = reader["password"].ToString();
                    cliente.Direccion = (reader["direccion"].ToString());

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
        }

        //Leemos un usuario en la base de datos pasandole el nick puesto que es único
        public ClienteEN leercliente(string id)
        {
            ClienteEN cliente = new ClienteEN();

            try
            {
                _conexion.Open();

                string com = "select * from Cliente where email = '" + id + "';";

                SqlCommand comand = new SqlCommand(com, _conexion);
                SqlDataReader reader = comand.ExecuteReader();

                if (reader.Read())
                {
                    cliente.Id = reader["id"].ToString();
                    cliente.Nombre = reader["nombre"].ToString();
                    cliente.Email = (reader["email"].ToString());
                    cliente.Password = reader["password"].ToString();
                    cliente.Direccion = (reader["direccion"].ToString());
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

            return cliente;
        }

        public List<string> getAllId()
        {
            List<string> ids = new List<string>();

            try
            {
                _conexion.Open();

                string com = "select id from Cliente";

                SqlCommand comand = new SqlCommand(com, _conexion);
                SqlDataReader reader = comand.ExecuteReader();

                while (reader.Read())
                    ids.Add(reader["id"].ToString());

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

            return ids;
        }
    }
}
