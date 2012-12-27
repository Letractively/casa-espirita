using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using DataAccess;

namespace BusinessLayer
{
    public class OrigensBL
    {
        public bool InserirBL(Origens instancia)
        {
            /*criar as regras de negocio*/
            OrigensDA varDA = new OrigensDA();

            return varDA.InserirDA(instancia);
        }

        public bool EditarBL(Origens instancia)
        {
            /*criar as regras de negocio*/
            OrigensDA varDA = new OrigensDA();

            return varDA.EditarDA(instancia);
        }

        public bool ExcluirBL(Origens instancia)
        {
            /*criar as regras de negocio*/
            OrigensDA varDA = new OrigensDA();

            return varDA.ExcluirDA(instancia);
        }

        public List<Origens> PesquisarBL()
        {
            /*criar as regras de negocio*/
            OrigensDA varDA = new OrigensDA();

            return varDA.PesquisarDA();
        }

    }
}
