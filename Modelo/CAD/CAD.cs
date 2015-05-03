using Modelo.Conexion;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Modelo.CAD
{
    class CAD
    {
        Conectar conectar;
        SqlConnection conexion;

        public CAD()
        {
            conectar = new Conectar();
            conexion = conectar.Conexion;
        }
    }
}
