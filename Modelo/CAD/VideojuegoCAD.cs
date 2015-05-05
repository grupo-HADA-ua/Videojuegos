using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using Modelo.EN;
namespace Modelo.CAD
{
    class VideojuegoCAD : ProductoCAD
    {
        private SqlConnection BD;
        private string cadena;
        private ProductoCAD CAD_Producto;

        //Constructor
        public VideojuegoCAD(string bbdd = "")
        {
            if (bbdd == "") cadena = ConfigurationManager.ConnectionStrings["BD"].ToString();
            else cadena = bbdd;

            try
            {
                BD = new SqlConnection(cadena);
            }
            catch (Exception e)
            {
                e.ToString();
            }
        }

        //METODOS
        //CRUD
        public void Crear(VideojuegoEN videojuegoEN)
        {
            Conectar();

            string orden = "insert into videojuego values (";
            orden += videojuegoEN.Id;
            orden += ", '";
            orden += videojuegoEN.Nombre;
            orden += ", '";
            orden += videojuegoEN.Precio;
            orden += ", '";
            orden += videojuegoEN.CantidadStock;
            orden += ", '";
            orden += videojuegoEN.EdadMinima;
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

       
        public void Actualizar(VideojuegoEN videojuegoEN)
        {
            Conectar();

            string orden = "update videojuego set nombre = '" + videojuegoEN.Nombre;
            orden += "', precio = " + videojuegoEN.Precio.ToString();
            orden += "', cantidadstock = " + videojuegoEN.CantidadStock.ToString();
            orden += "', edadminima = " + videojuegoEN.EdadMinima.ToString();
            orden += "' where id = " + videojuegoEN.Id.ToString() + ";";

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
            BorrarVideojuego(p.ToString());
        }
        public void BorrarVideojuego(string id)
        {
            Conectar();

            string orden = "delete from videojuego where id = " + id + ")";

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

       
        public VideojuegoEN Mostrar(int id)
        {
            ProductoEN producto = new VideojuegoEN();
            CAD_Producto.Cargar(id, producto.TipoProducto, out producto);
            VideojuegoEN consola = (VideojuegoEN)producto;

            Conectar();

            string orden = "select * from videojuego where id = " + id + ";";

            try
            {
                SqlCommand conectar = new SqlCommand(orden, BD);
                SqlDataReader reader = conectar.ExecuteReader();

                if (reader.Read())
                {
                    consola.Nombre = (string)(reader["nombre"]);
                    consola.Precio = (double)(reader["precio"]);
                    consola.CantidadStock = (int)(reader["cantidadstock"]);
                    consola.CantidadStock = (int)(reader["edadminima"]);
                }
                else throw new Exception("No es un videojuego");

                reader.Close();
            }
            catch (Exception e)
            {
                consola = new VideojuegoEN();
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
