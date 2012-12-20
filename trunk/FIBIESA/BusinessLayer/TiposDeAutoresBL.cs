using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using DataAccess;

namespace BusinessLayer
{
    public class TiposDeAutoresBL
    {
        public bool InserirBL(TiposDeAutores instancia)
        {
            /*criar as regras de negocio*/
            TiposDeAutoresDA varDA = new TiposDeAutoresDA();

            return varDA.InserirDA(instancia);
        }

        public bool EditarBL(TiposDeAutores instancia)
        {
            /*criar as regras de negocio*/
            TiposDeAutoresDA varDA = new TiposDeAutoresDA();

            return varDA.EditarDA(instancia);
        }

        public bool ExcluirBL(TiposDeAutores instancia)
        {
            /*criar as regras de negocio*/
            TiposDeAutoresDA varDA = new TiposDeAutoresDA();

            return varDA.ExcluirDA(instancia);
        }

        public List<TiposDeAutores> PesquisarBL()
        {
            /*criar as regras de negocio*/
            TiposDeAutoresDA varDA = new TiposDeAutoresDA();

            return varDA.PesquisarDA();
        }
    }
}
