using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using DataAccess;
using System.Data;

namespace BusinessLayer
{
    public class EmprestimosBL
    {
        public bool InserirBL(Emprestimos instancia)
        {
            /*criar as regras de negocio*/
            EmprestimosDA varDA = new EmprestimosDA();

            return varDA.InserirDA(instancia);
        }

        public bool EditarBL(Emprestimos instancia)
        {
            /*criar as regras de negocio*/
            EmprestimosDA varDA = new EmprestimosDA();

            return varDA.EditarDA(instancia);
        }

        public bool ExcluirBL(Emprestimos instancia)
        {
            /*criar as regras de negocio*/
            EmprestimosDA varDA = new EmprestimosDA();

            return varDA.ExcluirDA(instancia);
        }

        public List<Emprestimos> PesquisarBL()
        {
            /*criar as regras de negocio*/
            EmprestimosDA varDA = new EmprestimosDA();

            return varDA.PesquisarDA();
        }

        //public DataSet  PesquisarRelatorioBL()
        //{
        //    /*criar as regras de negocio*/
        //    EmprestimosDA varDA = new EmprestimosDA();

        //    return varDA.PesquisarDA();
        //}
    }
}
