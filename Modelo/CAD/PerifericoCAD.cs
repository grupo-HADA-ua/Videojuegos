﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using Modelo.EN;
using Modelo.Conexion;


namespace Modelo.CAD
{
    class PerifericoCAD : ProductoCAD
    {

        private ProductoCAD CAD_Producto;
        private SqlConnection BD;
        private Conectar conectar;



        public PerifericoCAD()
        {
            conectar = new Conectar();
            BD = conectar.Conexion;
        }

        //METODOS
        //CRUD
        public void Crear(PerifericoEn perifericoEN)
        {
            Conectar();

            string orden = "insert into periferico values (";
            orden += perifericoEN.Id;
            orden += ", '";
            orden += perifericoEN.Nombre;
            orden += ", '";
            orden += perifericoEN.Precio;
            orden += ", '";
            orden += perifericoEN.CantidadStock;
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

        
        public void Actualizar(PerifericoEn perifericoEN)
        {
            Conectar();

            string orden = "update periferico set nombre = '" + perifericoEN.Nombre;
            orden += "', precio = " + perifericoEN.Precio.ToString();
            orden += "', cantidadstock = " + perifericoEN.CantidadStock.ToString();
            orden += "' where id = " + perifericoEN.Id.ToString() + ";";

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

            string orden = "delete from periferico where id = " + id + ")";

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

        
        public PerifericoEn Mostrar(int id)
        {
            ProductoEN producto = new PerifericoEn();
            CAD_Producto.Cargar(id, producto.TipoProducto, out producto);
            PerifericoEn periferico = (PerifericoEn)producto;

            Conectar();

            string orden = "select * from periferico where id = " + id + ";";

            try
            {
                SqlCommand conectar = new SqlCommand(orden, BD);
                SqlDataReader reader = conectar.ExecuteReader();

                if (reader.Read())
                {
                    periferico.Nombre = (string)(reader["nombre"]);
                    periferico.Precio = (double)(reader["precio"]);
                    periferico.CantidadStock = (int)(reader["cantidadstock"]);
                }
                else throw new Exception("No es un periferico");

                reader.Close();
            }
            catch (Exception e)
            {
                periferico = new PerifericoEn();
                e.ToString();
            }

            return periferico;
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
