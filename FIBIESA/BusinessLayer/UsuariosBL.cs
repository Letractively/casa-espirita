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
            valido = usu.Nome.Length <= 70 && usu.Email.Length <= 100 && usu.Status.Length <= 1 && usu.Senha.Length <= 100;
            valido = valido && usu.CategoriaId > 0;
            valido = valido && usu.DtFim != null && usu.DtInicio != null && usu.Senha != null && usu.Login != null && usu.Status != null;                        
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
            if (usu.Id > 0 && IsValid(usu))
            {
                UsuariosDA pessoasDA = new UsuariosDA();

                return pessoasDA.EditarDA(usu);
            }
            else
                return false;
        }

        public bool ExcluirBL(Usuarios usu)
        {
            if (usu.Id > 0)
            {
                UsuariosDA pessoasDA = new UsuariosDA();

                return pessoasDA.ExcluirDA(usu);
            }
            else
                return false;
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

        public List<Usuarios> PesquisarBuscaBL(string valor)
        {
            UsuariosDA usuariosDA = new UsuariosDA();

            return usuariosDA.PesquisarBuscaDA(valor); 
        }

        public List<Usuarios> PesquisarBL(string login, string senha, DateTime data)
        {
            UsuariosDA usuariosDA = new UsuariosDA();

            return usuariosDA.PesquisarDA(login, senha, data);
        }
                
    }
}
