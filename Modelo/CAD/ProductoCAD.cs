using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using Modelo.EN;
using Modelo.Conexion;

namespace Modelo.CAD
{
    public class ProductoCAD : IProductoCAD
    {
       //Atributos
        private SqlConnection BD;
        private Conectar conectar;



        public ProductoCAD()
        {
            conectar = new Conectar();
            BD = conectar.Conexion;
        }

        //Metodos
        //CRUD
        public void Crear(ProductoEN productoEN)
        {
            Conectar();

            string orden = "insert into articulo values (";
            orden += productoEN.Id;
            orden += ", '";
            orden += productoEN.Nombre.ToString();
            orden += "', ";
            orden += productoEN.Precio;
            orden += ", '";
            orden += productoEN.CantidadStock;
            orden += "', ";
            orden += productoEN.Descuento;
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

       
        public void Actualizar(ProductoEN productoEn)
        {
            Conectar();

            string orden = "update producto set nombre = '" + productoEn.Nombre;
            orden += "', precio = " + productoEn.Precio;
            orden += ", cantidadstock = '" + productoEn.CantidadStock;
            orden += ", descuento = '" + productoEn.Descuento;
            orden += "' where id = " + productoEn.Id + ";";

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
            BorrarProducto(p.ToString());
        }
        public void BorrarProducto(string codigo)
        {
            Conectar();

            string orden = "delete from producto where id = " + codigo + ")";

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

        public ProductoEN Mostrar(int p)
        {
            ProductoEN producto = (new ConsolaCAD()).Mostrar(p);

            
            if (producto.Id != p) producto = (new PerifericoCAD()).Mostrar(p);
            if (producto.Id != p) producto = (new VideojuegoCAD()).Mostrar(p);
            

            return producto;

        }

        
        public void Cargar(int cod, string tipo, out ProductoEN producto)
        {
            switch (tipo)
            {
                case "consola": producto = new ConsolaEN(); break;
                case "periferico": producto = new PerifericoEn(); break;
                default: producto = new VideojuegoEN(); break;
            }

            Conectar();

            string orden = "select * from producto where id = " + cod.ToString() + ";";

            try
            {
                SqlCommand comando = new SqlCommand(orden, BD);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    producto.Id = (int)(reader["id"]);
                    producto.Nombre = reader["nombre"].ToString();
                    producto.Precio = (double)(reader["precio"]);
                    producto.CantidadStock = (int)reader["cantidadstock"];
                    producto.Descuento = (bool)(reader["descuento"]);
                }
                reader.Close();
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

        //Metodos para conectar y desconectar de la bbdd
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
