using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using DataAccess;

namespace BusinessLayer
{
    public class TiposObrasBL : BaseBL
    {
        private bool IsValid(TiposObras instancia)
        {
            bool valido;
            valido = instancia.Descricao.Length <= 40 && instancia.QtdDias > 0;

            return valido;
        }

        public bool InserirBL(TiposObras instancia)
        {
            if (IsValid(instancia))
            {
                TiposObrasDA varDA = new TiposObrasDA();

                return varDA.InserirDA(instancia);
            }
            else
                return false;
        }

        public bool EditarBL(TiposObras instancia)
        {
            if (instancia.Id > 0 && IsValid(instancia))
            {
                TiposObrasDA varDA = new TiposObrasDA();

                return varDA.EditarDA(instancia);
            }
            else
                return false;
        }

        public bool ExcluirBL(TiposObras instancia)
        {
            if (instancia.Id > 0)
            {
                TiposObrasDA varDA = new TiposObrasDA();

                return varDA.ExcluirDA(instancia);
            }
            else
                return false;
        }

        public List<TiposObras> PesquisarBL()
        {
            /*criar as regras de negocio*/
            TiposObrasDA tiposObrasDA = new TiposObrasDA();

            return tiposObrasDA.PesquisarDA();
        }

        public List<TiposObras> PesquisarBL(int bai)
        {
            TiposObrasDA tiposObrasDA = new TiposObrasDA();

            return tiposObrasDA.PesquisarDA(bai);
        }

        public List<TiposObras> PesquisarBL(string campo, string valor)
        {
            TiposObrasDA tiposObrasDA = new TiposObrasDA();

            return tiposObrasDA.PesquisarDA(campo, valor);
        }

        public List<TiposObras> PesquisarBuscaBL(string valor)
        {
            /*criar as regras de negocio*/
            TiposObrasDA tiposObrasDA = new TiposObrasDA();

            return tiposObrasDA.PesquisarBuscaDA(valor);
        }

        public override List<Base> Pesquisar(string codDes)
        {
            TiposObrasDA tiposObrasDA = new TiposObrasDA();

            return tiposObrasDA.Pesquisar(codDes);
        }

    }
}
