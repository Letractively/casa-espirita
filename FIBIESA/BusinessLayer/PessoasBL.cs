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

        public DataSet PesquisaDataSetDA(int id_pes)
        {
            
            PessoasDA pessoasDA = new PessoasDA();

            return pessoasDA.PesquisaDataSetDA(id_pes);
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

        public List<Pessoas> PesquisarParticTurmaBL(string valor, int tur_id)
        {
            /*criar as regras de negocio*/
            PessoasDA pessoasDA = new PessoasDA();

            return pessoasDA.PesquisarParticTurmaDA(valor, tur_id); 
        }

        public override List<Base> Pesquisar(string codDes)
        {
            PessoasDA pesDA = new PessoasDA();

            return pesDA.Pesquisar(codDes);
        }

        public int EstaDevendo(int id)
        {
            PessoasDA instancia = new PessoasDA();
            return instancia.EstaDevendo(id);
        }

        public string VerificaSituacaoPessoa(int id_pes, bool financeiro, bool biblioteca)
        {
            PessoasDA pesDA = new PessoasDA();
            EmprestimosDA empDA = new EmprestimosDA();
            StringBuilder situacao = new StringBuilder();

            situacao.Append(pesDA.VerificaSituacaoPessoa(id_pes, financeiro, biblioteca));
            if (!empDA.VerificaQtdeMaximaEmprestimo(id_pes))
                situacao.Append("O cliente já atingiu o limite máximo de empréstimos permitido!");

            return situacao.ToString();
        }

        /// <summary>
        /// pesquisa realizada com mais de um id 
        /// </summary>
        /// <param name="valor">Id das pessoas separado por virgula</param>
        /// <returns>Retorna um List<Base></returns>
        public List<Base> PesquisarPessoas(string codDes)
        {
            PessoasDA pesDA = new PessoasDA();

            return pesDA.PesquisarPessoas(codDes);
        }
    }
}