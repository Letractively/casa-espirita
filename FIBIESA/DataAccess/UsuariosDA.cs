using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using DataObjects;

namespace DataAccess
{
    public class UsuariosDA
    {
        public bool InserirDA(Usuarios usu)
        {
            return true;
        }

        public bool EditarDA(Usuarios usu)
        {
            return true;
        }

        public bool ExcluirDA(Usuarios usu)
        {
            return true;
        }

        public List<Usuarios> PesquisarDA()
        {
            List<Usuarios> usuarios = new List<Usuarios>();
            return usuarios;
        }
    }
}
