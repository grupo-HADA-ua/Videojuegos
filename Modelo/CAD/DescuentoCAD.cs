using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using Modelo.EN;
using Modelo.Conexion;

namespace Modelo.CAD
{
    class DescuentoCAD
    {
        private SqlConnection BD;
        private Conectar conectar;



        public DescuentoCAD()
        {
            conectar = new Conectar();
            BD = conectar.Conexion;
        }

        public void Crear(DescuentoEN descuentoEN)
        {
            Conectar();

            string orden = "insert into descuento values (";
            orden += descuentoEN.Cod.ToString();
            orden += ", '";
            orden += descuentoEN.FechaI.ToString();
            orden += "', ";
            orden += descuentoEN.FechaF.ToString();
            orden += ", '";
            orden += descuentoEN.Descuento;
            orden += "')";

 
            try
            {
                SqlCommand comando = new SqlCommand(orden, BD);

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

        public void Actualizar(DescuentoEN descuentoEN)
        {
            Conectar();

            string orden = "update descuento set fechai = '" + descuentoEN.FechaI.ToString();
            orden += "', fechaf = " + descuentoEN.FechaF.ToString();
            orden += ", descuento = '" + descuentoEN.Descuento;
            orden += "' where cod = " + descuentoEN.Cod.ToString() + ";";

            try
            {
                SqlCommand comando = new SqlCommand(orden, BD);

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

        public void Borrar(string p)
        {
            Conectar();

            string orden = "delete from descuento where cod = " + p + ")";

            try
            {
                SqlCommand comando = new SqlCommand(orden, BD);

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

        public DescuentoEN Mostrar(string p)
        {
            DescuentoEN artic = new DescuentoEN();

            try
            {
                BD.Open();

                string com = "select * from descuento where cod = '" + p + "';";

                SqlCommand comand = new SqlCommand(com, BD);
                SqlDataReader reader = comand.ExecuteReader();

                if (reader.Read())
                {
                    artic.Cod = reader["cod"].ToString();
                    artic.FechaI = reader["fechai"].ToString();
                    artic.FechaF = reader["fechaf"].ToString();
                    artic.Descuento = (int)reader["descuento"];

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

            return artic;
        }
        private void Conectar()
        {
            if (BD.State != System.Data.ConnectionState.Open)
                BD.Open();
        }
        private void Desconectar()
        {
            if (BD.State == System.Data.ConnectionState.Open)
                BD.Close();
        }
   }
}
