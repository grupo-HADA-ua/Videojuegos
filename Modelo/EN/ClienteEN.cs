﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo.CAD;

namespace Modelo.EN
{
    public class ClienteEN
    {
        private IClienteCAD cad = new ClienteCAD();

        private string id;
        public string Id { get { return id; } set { id = value; } }

        private string nombre;
        public string Nombre { get { return nombre; } set { nombre = value; } }

        private string email;
        public string Email { get { return email; } set { email = value; } }

        private string password;
        public string Password { get { return password; } set { password = value; } }

        private string direccion;
        public string Direccion { get { return direccion; } set { direccion = value; } }

        public ClienteEN()
        {
        }

        public ClienteEN(string id, string nombre, string email, string password, string direccion)
        {
            inicializar(id, nombre, email, password, direccion);
        }

        public ClienteEN(string nombre, string email, string password, string direccion)
        {
            Nombre = nombre;
            Email = email;
            Password = password;
            Direccion = direccion;
        }

        public ClienteEN(ClienteEN c)
        {
            inicializar(c.Id, c.Nombre, c.Email, c.Password, c.Direccion);
        }

        private void inicializar(string id, string nombre, string email, string password, string direccion)
        {
            Id = id;
            Nombre = nombre;
            Email = email;
            Password = password;
            Direccion = direccion;
        }

        public override bool Equals(Object obj)
        {
            if (!(obj is ClienteEN)) return false;

            ClienteEN p = (ClienteEN)obj;
            return id == p.id & nombre == p.nombre & email == p.email & password == p.password & direccion == p.direccion;
        }

        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 37 + Email.GetHashCode();
            return hash;
        }

        public void Guardar()
        {
            cad.Crear(this);
        }

        public ClienteEN Obtener()
        {
            return cad.Obtener(this);

        }

        public bool LoginCorrecto()
        {
            return cad.LoginCorrecto(this);
        }

        public IList<ClienteEN> ObtenerTodos()
        {
            return cad.ObtenerTodos();
        }

        public void Actualizar()
        {
            cad.Actualizar(this);
        }

        public void Borrar()
        {
            cad.Borrar(this);
        }

        public void BorrarTodos()
        {
            cad.BorrarTodos();
        }

        public bool Existe()
        {
            return cad.Existe(this);
        }
         
    }
}