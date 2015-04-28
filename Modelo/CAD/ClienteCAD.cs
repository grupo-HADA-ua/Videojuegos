using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using Modelo.EN;


namespace Modelo.CAD
{
    public class ClienteCAD : IClienteCAD
    {
        private SqlConnection BD;
        private string s;



        public ClienteCAD(string conexion = "")
        {
            if (conexion == "") s = ConfigurationManager.ConnectionStrings["BD"].ToString();
            else
                s = conexion;

            try
            {
                BD = new SqlConnection(s);
            }
            catch (Exception e)
            {
                e.ToString();
            }
        }

        //METODOS
        //CRUD

        //Insertar un usuario en la bbdd
        public void Crear(ClienteEN clienteEN)
        {
            try
            {
                BD.Open();

                string com = "insert into Cliente values (";
                com += "'" + clienteEN.Id + "', ";
                com += "'" + clienteEN.Nombre + "', ";
                com += "'" + clienteEN.Email + "', ";
                com += "'" + clienteEN.Password + "', ";
                com += "'" + clienteEN.Direccion + "') ";
                SqlCommand comand = new SqlCommand(com, BD);
                //int index= comand.ExecuteNonQuery();
                comand.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                e.ToString();
            }
            finally
            {

                BD.Close();
            }
        }

        public ClienteEN Obtener(int id)
        {
            return null;
        }
        

        //Actualizar un usuario en la bbdd
        public void Actualizar(ClienteEN clienteEN)
        {
            try
            {
                BD.Open();
                string com = "update Cliente set ";
                com += "id = '" + clienteEN.Id.ToString() + "', ";
                com += "nombre = '" + clienteEN.Nombre.ToString() + "', ";
                com += "email = '" + clienteEN.Email.ToString() + "', ";
                com += "password = '" + clienteEN.Password.ToString() + "', ";
                com += "direccion = '" + clienteEN.Direccion.ToString() + "', ";





                SqlCommand comand = new SqlCommand(com, BD);
                comand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                e.ToString();
            }
            finally
            {
                BD.Close();
            }
        }

        //borrar un usuario de la bbdd
        public void Borrar(ClienteEN c)
        {
            try
            {
                BD.Open();
                string com = "delete from Cliente where id = '" + c.Id + "'";

                SqlCommand comand = new SqlCommand(com, BD);
                comand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                e.ToString();
            }
            finally
            {
                BD.Close();
            }
        }

        //Se llamará desde las clases derivadas y cargará los datos de la tabla articulo
        public void cargarDatoscliente(string id, out ClienteEN cliente)
        {
            cliente = new ClienteEN();
            BD.Open();

            string orden = "select * from Cliente where id = " + id + ";";

            try
            {
                SqlCommand comando = new SqlCommand(orden, BD);
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
                BD.Close();
            }
        }

        //Leemos un usuario en la base de datos pasandole el nick puesto que es único
        public ClienteEN leercliente(string id)
        {
            ClienteEN cliente = new ClienteEN();

            try
            {
                BD.Open();

                string com = "select * from Cliente where email = '" + id + "';";

                SqlCommand comand = new SqlCommand(com, BD);
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
                BD.Close();
            }

            return cliente;
        }

        public IList<ClienteEN> ObtenerTodos()
        {
            return null;
        }



        public List<string> getAllId()
        {
            List<string> ids = new List<string>();

            try
            {
                BD.Open();

                string com = "select id from Cliente";

                SqlCommand comand = new SqlCommand(com, BD);
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
                BD.Close();
            }

            return ids;

        }



    }
}
