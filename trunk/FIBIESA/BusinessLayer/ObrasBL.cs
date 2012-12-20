using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using DataAccess;

namespace BusinessLayer
{
    public class ObrasBL
    {
        public bool InserirBL(Obras instancia)
        {
            /*criar as regras de negocio*/
            ObrasDA varDA = new ObrasDA();

            return varDA.InserirDA(instancia);
        }

        public bool EditarBL(Obras instancia)
        {
            /*criar as regras de negocio*/
            ObrasDA varDA = new ObrasDA();

            return varDA.EditarDA(instancia);
        }

        public bool ExcluirBL(Obras instancia)
        {
            /*criar as regras de negocio*/
            ObrasDA varDA = new ObrasDA();

            return varDA.ExcluirDA(instancia);
        }

        public List<Obras> PesquisarBL()
        {
            /*criar as regras de negocio*/
            ObrasDA varDA = new ObrasDA();

            return varDA.PesquisarDA();
        }
    }
}
