using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using DataAccess;

namespace BusinessLayer
{
    public class UsuariosBL
    {
        private bool IsValid(Usuarios usu)
        {
            bool valido;
            valido = usu.Senha != null;            
            return valido;
        }

        public bool InserirBL(Usuarios usu)
        {
            if (IsValid(usu))
            {              
                UsuariosDA pessoasDA = new UsuariosDA();

                return pessoasDA.InserirDA(usu);
            }
            return false;
        }

        public bool EditarBL(Usuarios usu)
        {
            /*criar as regras de negocio*/
            UsuariosDA pessoasDA = new UsuariosDA();

            return pessoasDA.EditarDA(usu);
        }

        public bool ExcluirBL(Usuarios usu)
        {
            /*criar as regras de negocio*/
            UsuariosDA pessoasDA = new UsuariosDA();

            return pessoasDA.ExcluirDA(usu);
        }

        public List<Usuarios> PesquisarBL()
        {
            /*criar as regras de negocio*/
            UsuariosDA usuariosDA = new UsuariosDA();

            return usuariosDA.PesquisarDA();
        }

        public List<Usuarios> PesquisarBL(int id_usu)
        {
            UsuariosDA usuariosDA = new UsuariosDA();

            return usuariosDA.PesquisarDA(id_usu);
        }

        public List<Usuarios> PesquisarBL(string campo, string valor)
        {
            UsuariosDA usuariosDA = new UsuariosDA();

            return usuariosDA.PesquisarDA(campo, valor);
        }

        public List<Usuarios> PesquisarBL(string login, string senha, DateTime data)
        {
            UsuariosDA usuariosDA = new UsuariosDA();

            return usuariosDA.PesquisarDA(login, senha, data);
        }
       
    }
}
