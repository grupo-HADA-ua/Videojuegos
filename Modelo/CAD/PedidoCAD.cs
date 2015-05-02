﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Modelo.EN;


namespace Modelo.CAD
{
    class PedidoCAD : IPedidoCAD
    {
        private SqlConnection BD; /*Cambiar string por el tipo de dato de las bbdd*/
        private string s;

        //Constructor
        public PedidoCAD(string bbdd = "")
        {
            if (bbdd == "") s = ConfigurationManager.ConnectionStrings["BD"].ToString();
            else s = bbdd;

            try
            {
                BD = new SqlConnection(s);
            }
            catch (Exception e)
            {
                e.ToString();
            }
        }

        //Metodo para crear un pedido en la bbdd
        public void Crear(PedidoEN pedidoEN)
        {
            try
            {
                if (BD.State != System.Data.ConnectionState.Open) BD.Open();


                string com = "insert into pedido values (";
                com += pedidoEN.Id + ", ";
                com += "'" + pedidoEN.IdCliente + "', ";
                com += "'" + pedidoEN.Lineas + "', ";
                com += "'" + pedidoEN.Fecha.ToString() + "', ";
                com += "'" + pedidoEN.Confirmado + "', ";
                com += "'" + pedidoEN.Enviado + ");";

                SqlCommand comand = new SqlCommand(com, BD);
                comand.ExecuteNonQuery();

                Guardar(pedidoEN);
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


        protected void Cargar(ref PedidoEN ped)
        {
            try
            {
                if (BD.State != System.Data.ConnectionState.Open) BD.Open();

                string com = "select * from lineapedido where id = " + ped.Id;
                SqlDataReader reader = (new SqlCommand(com, BD)).ExecuteReader();

                
                int num;
                

                while (reader.Read())
                {
                    
                    num = (int)reader["cantidad"];

                   
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

        private void Guardar(PedidoEN pedido)
        {
            try
            {
                if (BD.State != System.Data.ConnectionState.Open) BD.Open();

                string com = "DELETE FROM LineaPedido WHERE id = " + pedido.Id;

                SqlCommand comand = new SqlCommand(com, BD);
                comand.ExecuteNonQuery();
                //Revisar!!!
                for (int i = 0; i < 5; i++)
                {
                    com = "INSERT INTO LineaPedido VALUES (" + pedido.Id + ", ";
                    com += pedido.Lineas[i].Producto + ");";

                    comand.CommandText = com;
                    comand.ExecuteNonQuery();
                }
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

        //Modulo que actualiza el pedido
        public void Actualizar(PedidoEN pedido)
        {
            try
            {
                if (BD.State != System.Data.ConnectionState.Open) BD.Open();
                string com = "update pedido set ";
                com += "idcliente = '" + pedido.IdCliente + "', ";
                com += "fecha = " + (pedido.Fecha.ToString()) + "', ";
                com += "confirmado = "; if (pedido.Confirmado) com += "1, "; else com += "0, ";
                com += "enviado = "; if (pedido.Enviado) com += "1"; else com += "0";
                com += "where id = " + pedido.Id + ";";

                SqlCommand comand = new SqlCommand(com, BD);
                comand.ExecuteNonQuery();

                Guardar(pedido);
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


        public PedidoEN Mostrar(int p)
        {
            PedidoEN pedido = new PedidoEN();

            try
            {
                if (BD.State != System.Data.ConnectionState.Open) BD.Open();
                string com = "select * from pedido where id = " + p;

                SqlDataReader reader = (new SqlCommand(com, BD)).ExecuteReader();

                if (reader.Read())
                {
                    pedido.Id = (int)reader["id"];
                   // pedido.IdCliente = (new ClienteCAD(s)).leercliente(reader["idcliente"].ToString());
                    pedido.Fecha = reader["fecha"].ToString();

                    //Los pedidos confirmados no se dejan editar
                    bool auxConf = bool.Parse(reader["confirmado"].ToString());
                    pedido.Enviado = bool.Parse(reader["servido"].ToString());

                    reader.Close();

                    Cargar(ref pedido);

                    pedido.Confirmado = auxConf;
                }

                if (!reader.IsClosed) reader.Close();
            }
            catch (Exception e)
            {
                e.ToString();
            }
            finally
            {
                BD.Close();
            }

            return pedido;
        }

        //Metodo que borra un pedido de la bbdd
        public void Borrar(int p)
        {
            try
            {
                if (BD.State != System.Data.ConnectionState.Open) BD.Open();
                string com = "delete from pedido where id = " + p;

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

        //Devolvemos todos los pedidos existentes en la base de datos
        public List<PedidoEN> getAllPedidos()
        {
            List<PedidoEN> pedidos = new List<PedidoEN>();
            List<int> ids = new List<int>();

            try
            {
                if (BD.State != System.Data.ConnectionState.Open) BD.Open();
                string com = "select id from pedido";
                SqlCommand comand = new SqlCommand(com, BD);
                SqlDataReader reader = comand.ExecuteReader();

                while (reader.Read())
                {
                    ids.Add((int)reader["id"]);
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

            foreach (int i in ids)
                pedidos.Add(Mostrar(i));

            return pedidos;
        }

        public DataSet getAllPedidosInDataSet()
        {
            DataSet set = new DataSet();

            try
            {
                string com = "select enviado, confirmado,pedido.id, idcliente, cantidad ";
                com += "from pedido, lineapedido where pedido.id=lineapedido.id ";
                com += "order by enviado, confirmado desc, pedido.id;";

                SqlDataAdapter adapter = new SqlDataAdapter(com, BD);

                adapter.Fill(set, "AllPedidos");
            }
            catch (Exception e)
            {
                e.ToString();
            }

            return set;
        }
        public PedidoEN getCarrito(string user)
        {
            PedidoEN pedido = new PedidoEN();

            try
            {
                if (BD.State != System.Data.ConnectionState.Open) BD.Open();
                string com = "select * from pedido where idcliente = '" + user + "' AND confirmado = 0;";

                SqlDataReader reader = (new SqlCommand(com, BD)).ExecuteReader();

                if (reader.Read())
                {
                    pedido.Id = (int)reader["id"];
                    //pedido.IdCliente = (new ClienteCAD(s)).leercliente(reader["id"].ToString());

                    pedido.Enviado = bool.Parse(reader["enviado"].ToString());

                    reader.Close();

                    Cargar(ref pedido);
                }

                if (!reader.IsClosed) reader.Close();
            }
            catch (Exception e)
            {
                e.ToString();
            }
            finally
            {
                BD.Close();
            }

            if (pedido.Id == -1) return newCarrito(user);

            return pedido;
        }


        private PedidoEN newCarrito(string user)
        {
            PedidoEN pedido = new PedidoEN();
           // pedido.IdCliente = (new ClienteCAD(s)).leercliente(user);
            pedido.Confirmado = pedido.Enviado = false;


            try
            {
                if (BD.State != System.Data.ConnectionState.Open) BD.Open();

                string com = "select max(id) as m from pedido";

                SqlDataReader reader = (new SqlCommand(com, BD)).ExecuteReader();

                if (reader.Read())
                {
                    pedido.Id = ((int)reader["m"]) + 1;
                   // pedido.Crear();
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

            return pedido;
        }
    }
}
