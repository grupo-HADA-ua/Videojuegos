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

        public ClienteEN()
        {
        }

        public ClienteEN(int id, string nombre, string email, string password)
        {
            inicializar(id, nombre, email, password);
        }

        public ClienteEN(ClienteEN c)
        {
            inicializar(c.Id, c.Nombre, c.Email, c.Password);
        }

        private void inicializar(int id, string nombre, string email, string password)
        {
            Id = id;
            Nombre = nombre;
            Email = email;
            Password = password;
        }
    }
}
