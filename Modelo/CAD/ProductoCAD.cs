﻿using Modelo.Conexion;
using Modelo.EN;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Modelo.CAD
{
    public class ProductoCAD : IProductoCAD
    {
        private SqlConnection conexion;
        private string s;

        public void Crear(ProductoEN p)
        {
            conexion = (new Conectar()).Conexion;
            //TODO
        }

        public ProductoEN Obtener(int id)
        {
            //TODO
            return null;
        }

        public virtual IList<ProductoEN> ObtenerTodos()
        {
            //TODO
            return null;
        }

        public void Actualizar(ProductoEN p)
        {
            //TODO
        }

        public void Borrar(ProductoEN p)
        {
            //TODO
        }

    }
}
