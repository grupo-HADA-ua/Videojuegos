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
    public class AdministradorCAD
    {
        private Conectar _conectar;
        private SqlConnection _conexion;

        public AdministradorCAD()
        {
            _conectar = new Conectar();
            _conexion = _conectar.Conexion;
        }

        public void Crear(AdministradorEN admin)
        {
            try
            {
                _conexion.Open();
                var sql = "INSERT INTO administradores(usuario, password) " +
                    "values (@usuario, @password);";
                var cmd = new SqlCommand(sql, _conexion);
                cmd.Parameters.Add("@usuario", SqlDbType.NVarChar).Value = admin.Usuario;
                cmd.Parameters.Add("@password", SqlDbType.NVarChar).Value = admin.Password;
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

        public AdministradorEN Obtener(AdministradorEN a)
        {
            try
            {
                _conexion.Open();
                var sql = "SELECT id, usuario, password FROM administradores" +
                    "WHERE usuario=@usuario;";
                var cmd = new SqlCommand(sql, _conexion);
                cmd.Parameters.Add("@usuario", SqlDbType.NVarChar).Value = a.Usuario;
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    a.Id = reader["id"].ToString();
                    a.Usuario = (string)reader["usuario"];
                    a.Password = (string)reader["password"];
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
            return a;
        }

        public bool LoginCorrecto(AdministradorEN a)
        {
            bool correcto = false;
            try
            {
                _conexion.Open();
                var sql = "SELECT usuario, password FROM administradores WHERE usuario=@usuario AND password=@password;";
                var cmd = new SqlCommand(sql, _conexion);
                cmd.Parameters.Add("@usuario", SqlDbType.NVarChar).Value = a.Usuario;
                cmd.Parameters.Add("@password", SqlDbType.NVarChar).Value = a.Password;
                var r = cmd.ExecuteReader();
                if (r.Read())
                {
                    var usuario = (string)r["usuario"];
                    var password = (string)r["password"];
                    correcto = DatosCoinciden(a, usuario, password);
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

            return correcto;
        }

        private bool DatosCoinciden(AdministradorEN admin, string u, string p)
        {
            return admin.Usuario == u && admin.Password == p;
        }

        public void BorrarTodos()
        {
            try
            {
                _conexion.Open();
                var sql = "TRUNCATE TABLE administradores;";
                var cmd = new SqlCommand(sql, _conexion);
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
    }
}
