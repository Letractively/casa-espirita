using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using DataAccess;

namespace BusinessLayer
{
    public class PessoasBL : BaseBL
    {
        public int InserirBL(Pessoas pes)
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

        public List<Pessoas> PesquisarBL(int id_pes)
        {
            PessoasDA pessoasDA = new PessoasDA();

            return pessoasDA.PesquisarDA(id_pes);
        }

        public override List<Base> Pesquisar(string codDes, string tipo)
        {
            PessoasDA pesDA = new PessoasDA();

            return pesDA.Pesquisar(codDes, tipo);
        }
    }
}