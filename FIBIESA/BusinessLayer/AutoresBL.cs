using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using DataAccess;

namespace BusinessLayer
{
    public class AutoresBL
    {
        private bool IsValid(Autores aut)
        {
            bool valido;
            valido = aut.Descricao.Length <= 70;

            return valido;
        }

        public bool InserirBL(Autores aut)
        {
            if (IsValid(aut))
            {
                AutoresDA autoresDA = new AutoresDA();

                return autoresDA.InserirDA(aut);
            }
            else
                return false;
        }

        public bool EditarBL(Autores aut)
        {
            if (aut.Id > 0 && IsValid(aut))
            {
                AutoresDA autoresDA = new AutoresDA();

                return autoresDA.EditarDA(aut);
            }
            else
                return false;
        }

        public bool ExcluirBL(Autores aut)
        {
            if (aut.Id > 0)
            {
                AutoresDA autoresDA = new AutoresDA();

                return autoresDA.ExcluirDA(aut);
            }
            else
                return false;
        }

        public List<Autores> PesquisarBL()
        {
            /*criar as regras de negocio*/
            AutoresDA autoresDA = new AutoresDA();

            return autoresDA.PesquisarDA();
        }

        public List<Autores> PesquisarBL(int aut)
        {
            AutoresDA autoresDA = new AutoresDA();

            return autoresDA.PesquisarDA(aut);
        }

        public List<Autores> PesquisarBuscaBL(string valor)
        {
            /*criar as regras de negocio*/
            AutoresDA autoresDA = new AutoresDA();

            return autoresDA.PesquisarBuscaDA(valor);
        }

        public List<Autores> PesquisarBL(string campo, string valor)
        {
            AutoresDA autoresDA = new AutoresDA();

            return autoresDA.PesquisarDA(campo, valor);
        }

      
    }
}
