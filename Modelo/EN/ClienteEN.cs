using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo.EN
{
    public class ClienteEN
    {
        private int id;
        public int Id { get { return id; } set { id = value; } }

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

        public ClienteEN(int id, string nombre, string email, string password, string direccion)
        {
            inicializar(id, nombre, email, password, direccion);
        }

        public ClienteEN(ClienteEN c)
        {
            inicializar(c.Id, c.Nombre, c.Email, c.Password, c.Direccion);
        }

        private void inicializar(int id, string nombre, string email, string password, string direccion)
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
    }
}
