using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using DataAccess;

namespace BusinessLayer
{
    public class TiposDeAutoresBL : BaseBL
    {
        private bool IsValid(TiposDeAutores instancia)
        {
            bool valido;
            valido = instancia.Descricao.Length <= 40;

            return valido;
        }

        public bool InserirBL(TiposDeAutores instancia)
        {
            if (IsValid(instancia))
            {
                TiposDeAutoresDA varDA = new TiposDeAutoresDA();

                return varDA.InserirDA(instancia);
            }
            else
                return false;
        }

        public bool EditarBL(TiposDeAutores instancia)
        {
            if (instancia.Id > 0 && IsValid(instancia))
            {
                TiposDeAutoresDA varDA = new TiposDeAutoresDA();

                return varDA.EditarDA(instancia);
            }
            else
                return false;
        }

        public bool ExcluirBL(TiposDeAutores instancia)
        {
            if (instancia.Id > 0)
            {
                TiposDeAutoresDA varDA = new TiposDeAutoresDA();

                return varDA.ExcluirDA(instancia);
            }
            else
                return false;
        }

        public List<TiposDeAutores> PesquisarBL()
        {
            /*criar as regras de negocio*/
            TiposDeAutoresDA TiposDeAutoresDA = new TiposDeAutoresDA();

            return TiposDeAutoresDA.PesquisarDA();
        }

        public List<TiposDeAutores> PesquisarBL(int bai)
        {
            TiposDeAutoresDA TiposDeAutoresDA = new TiposDeAutoresDA();

            return TiposDeAutoresDA.PesquisarDA(bai);
        }

        public List<TiposDeAutores> PesquisarBL(string campo, string valor)
        {
            TiposDeAutoresDA TiposDeAutoresDA = new TiposDeAutoresDA();

            return TiposDeAutoresDA.PesquisarDA(campo, valor);
        }

        public List<TiposDeAutores> PesquisarBuscaBL(string valor)
        {
            /*criar as regras de negocio*/
            TiposDeAutoresDA tiposDeAutoresDA = new TiposDeAutoresDA();

            return tiposDeAutoresDA.PesquisarBuscaDA(valor);
        }

        public override List<Base> Pesquisar(string codDes)
        {
            TiposDeAutoresDA baiDA = new TiposDeAutoresDA();

            return baiDA.Pesquisar(codDes);
        }
    }
}
