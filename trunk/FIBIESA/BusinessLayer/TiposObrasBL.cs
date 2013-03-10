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
        public bool InserirBL(TiposObras instancia)
        {
            /*criar as regras de negocio*/
            TiposObrasDA varDA = new TiposObrasDA();

            return varDA.InserirDA(instancia);
        }

        public bool EditarBL(TiposObras instancia)
        {
            /*criar as regras de negocio*/
            TiposObrasDA varDA = new TiposObrasDA();

            return varDA.EditarDA(instancia);
        }

        public bool ExcluirBL(TiposObras instancia)
        {
            /*criar as regras de negocio*/
            TiposObrasDA varDA = new TiposObrasDA();

            return varDA.ExcluirDA(instancia);
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

        public override List<Base> Pesquisar(string codDes, string tipo)
        {
            TiposObrasDA tiposObrasDA = new TiposObrasDA();

            return tiposObrasDA.Pesquisar(codDes, tipo);
        }

    }
}
