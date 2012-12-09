using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using DataAccess;

namespace BusinessLayer
{
    public class PessoasBL
    {
        public bool InserirBL(Pessoas pes)
        {
            /*criar as regras de negocio*/
            PessoasDA pessoasDA = new PessoasDA();

            return pessoasDA.InserirDA(pes);
        }

        public bool EditarBL(Pessoas pes)
        {
            /*criar as regras de negocio*/
            PessoasDA pessoasDA = new PessoasDA();
            
            return pessoasDA.EditarDA(pes);
        }

        public bool ExcluirBL(Pessoas pes)
        {
            /*criar as regras de negocio*/
            PessoasDA pessoasDA = new PessoasDA();
            
            return pessoasDA.ExcluirDA(pes);
        }

        public List<Pessoas> PesquisarBL()
        {
            /*criar as regras de negocio*/
            PessoasDA pessoasDA = new PessoasDA();

            return pessoasDA.PesquisarDA();
        }
    }
}