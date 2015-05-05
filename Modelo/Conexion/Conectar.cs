using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Modelo.Conexion
{
    public class Conectar
    {
        private SqlConnection db;
        private string nombreConexion;

        public Conectar()
        {
            nombreConexion = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            try
            {
                db = new SqlConnection(nombreConexion);
            }
            catch(Exception e)
            {
                e.ToString();
            }
        }

        public SqlConnection Conexion { get { return db; } }
    }
}
