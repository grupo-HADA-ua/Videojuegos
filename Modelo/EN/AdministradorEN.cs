using Modelo.CAD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo.EN
{
    public class AdministradorEN
    {
        private AdministradorCAD _cad = new AdministradorCAD();

        public string Id { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }

        public AdministradorEN()
        {
        }

        public AdministradorEN(string id, string usuario, string password)
        {
            Inicializar(id, usuario, password);
        }

        public AdministradorEN(string usuario, string password)
        {
            Usuario = usuario;
            Password = password;
        }

        private void Inicializar(string id, string usuario, string password)
        {
            Id = id;
            Usuario = usuario;
            Password = password;
        }

        public void Guardar()
        {
            _cad.Crear(this);
        }

        public AdministradorEN Obtener()
        {
            return _cad.Obtener(this);
        }

        public void BorrarTodos()
        {
            _cad.BorrarTodos();
        }

        public bool LoginCorrecto()
        {
            return _cad.LoginCorrecto(this);
        }
    }
}
