﻿using Modelo.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Configuration;

using System.Data;
namespace Modelo.CAD
{
    interface IClienteCAD
    {
        void Crear(ClienteEN c);
        ClienteEN Obtener(ClienteEN c);
        IList<ClienteEN> ObtenerTodos();
        void Actualizar(ClienteEN c);
        void Borrar(ClienteEN c);
        bool Existe(ClienteEN c);
        void BorrarTodos();
        bool LoginCorrecto(ClienteEN c);
    }
}
