using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using DataAccess;

namespace BusinessLayer
{
    public class TiposObrasBL
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
            TiposObrasDA varDA = new TiposObrasDA();

            return varDA.PesquisarDA();
        }
    }
}
