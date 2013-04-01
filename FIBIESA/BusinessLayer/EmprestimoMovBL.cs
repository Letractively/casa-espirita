using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using DataAccess;
using System.Data;


namespace BusinessLayer
{
    class EmprestimoMovBL
    {

        public bool InserirBL(EmprestimoMov instancia)
        {
            /*criar as regras de negocio*/
            EmprestimoMovDA varDA = new EmprestimoMovDA();

            return varDA.InserirDA(instancia);
        }

        public bool EditarBL(EmprestimoMov instancia)
        {
            /*criar as regras de negocio*/
            EmprestimoMovDA varDA = new EmprestimoMovDA();

            return varDA.EditarDA(instancia);
        }

        public bool ExcluirBL(EmprestimoMov instancia)
        {
            /*criar as regras de negocio*/
            EmprestimoMovDA varDA = new EmprestimoMovDA();

            return varDA.ExcluirDA(instancia);
        }

    }
}
