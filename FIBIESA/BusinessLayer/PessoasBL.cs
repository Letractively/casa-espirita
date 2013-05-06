using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using DataAccess;
using System.Data;

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

        public DataSet PesquisaBL(int id_pes)
        {
            PessoasDA pesDA = new PessoasDA();
            
            return pesDA.PesquisaDA(id_pes);
        }

        public List<Pessoas> PesquisarPorGeneroDA(int id_cat)
        {
            /*criar as regras de negocio*/
            PessoasDA pessoasDA = new PessoasDA();

            return pessoasDA.PesquisarPorGeneroDA(id_cat);
        }

        public List<Pessoas> PesquisarBL(int id_pes)
        {
            PessoasDA pessoasDA = new PessoasDA();

            return pessoasDA.PesquisarDA(id_pes);
        }

        public List<Pessoas> PesquisarBL(string campo, string valor)
        {
            PessoasDA pessoasDA = new PessoasDA();

            return pessoasDA.PesquisarDA(campo, valor);
        }

        public List<Pessoas> PesquisarBuscaBL(string valor)
        {
            /*criar as regras de negocio*/
            PessoasDA pessoasDA = new PessoasDA();

            return pessoasDA.PesquisarBuscaDA(valor);
        }

        public override List<Base> Pesquisar(string codDes)
        {
            PessoasDA pesDA = new PessoasDA();

            return pesDA.Pesquisar(codDes);
        }
    }
}