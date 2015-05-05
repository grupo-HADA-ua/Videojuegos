using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using Modelo.EN;
using Modelo.Conexion;

namespace Modelo.CAD
{
    class ConsolaCAD : ProductoCAD
    {
        
        
        private ProductoCAD CAD_Producto;
        private SqlConnection BD;
        private Conectar conectar;



        public ConsolaCAD()
        {
            conectar = new Conectar();
            BD = conectar.Conexion;
        }

        //METODOS
        //CRUD
        public void Crear(ConsolaEN consolaEN)
        {
            Conectar();

            string orden = "insert into Consola values (";
            orden += consolaEN.Id;
            orden += ", '";
            orden += consolaEN.Nombre;
            orden += ", '";
            orden += consolaEN.Precio;
            orden += ", '";
            orden += consolaEN.CantidadStock;
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

  
        public void Actualizar(ConsolaEN consolaEN)
        {
            Conectar();

            string orden = "update Consola set nombre = '" + consolaEN.Nombre;
            orden += "', precio = " + consolaEN.Precio.ToString();
            orden += "', cantidadstock = " + consolaEN.CantidadStock.ToString();
            orden += "' where id = " + consolaEN.Id.ToString() + ";";

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

  
        public void Borrar(int p)
        {
            BorrarConsola(p.ToString());
        }
        public void BorrarConsola(string id)
        {
            Conectar();

            string orden = "delete from Consola where id = " + id + ")";

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

        public ConsolaEN Mostrar(int id)
        {
            ProductoEN producto = new ConsolaEN();
            CAD_Producto.Cargar(id, producto.TipoProducto, out producto);
            ConsolaEN consola = (ConsolaEN)producto;

            Conectar();

            string orden = "select * from Consola where id = " + id + ";";

            try
            {
                SqlCommand conectar = new SqlCommand(orden, BD);
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
