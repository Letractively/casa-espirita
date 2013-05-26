using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using DataAccess;
using System.Data;
using FG;


namespace BusinessLayer
{
    public class EmprestimoMovBL
    {
        Utils utils = new Utils();
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

        public DataSet PesquisarRelatorioBL(string pessoasCod, string obrasCod, string dataRetiradaIni, string dataRetiradaFim, string dataDevolucaoIni, string dataDevolucaoFim, string Status)
        {
            /*criar as regras de negocio*/
            EmprestimoMovDA varDA = new EmprestimoMovDA();

            return varDA.PesquisarRelatorioDA(pessoasCod, obrasCod, dataRetiradaIni, dataRetiradaFim, dataDevolucaoIni, dataDevolucaoFim, Status);
        }

        public DataSet PesquisarRelatorioBL(string pessoasCod,string obrasCod, string dataRetiradaIni, string dataRetiradaFim, string dataDevolucaoIni, string dataDevolucaoFim, string Status, string ordenacao)
        {
            /*criar as regras de negocio*/
            EmprestimoMovDA varDA = new EmprestimoMovDA();

            return varDA.PesquisarRelatorioDA(pessoasCod, obrasCod, dataRetiradaIni, dataRetiradaFim, dataDevolucaoIni, dataDevolucaoFim, Status, ordenacao);
        }

        public Int32 IdMovEmprestado(int emprestimoId)
        { 
            /*criar as regras de negocio*/
            EmprestimoMovDA varDA = new EmprestimoMovDA();

            return varDA.IdMovEmprestado(emprestimoId);        
        }

        public EmprestimoMov Carregar(int id)
        {
            /*criar as regras de negocio*/
            EmprestimoMovDA varDA = new EmprestimoMovDA();

            return varDA.Carregar(id);
        }

        public List<EmprestimoMov> PesquisarMovAtivosDA(int id_pessoa)
        {
            EmprestimoMovDA empMovDA = new EmprestimoMovDA();

            return empMovDA.PesquisarMovAtivosDA(id_pessoa);
        }

        public string RetornaSituacaoTitulo(Int32 id_emp)
        {
            string erro = null;
            ParametrosDA parDa = new ParametrosDA();
            EmprestimosDA empDA = new EmprestimosDA();

            //verifica quantidade máxima de renovação
            int maxRenovacao = utils.ComparaIntComZero(parDa.PesquisarValorDA(2, "B"));
            if (empDA.QtdRenovacoes(id_emp) > maxRenovacao)
            {
                erro = "Este título não pode ser mais renovado!";
                return erro;
            }

            return erro;
        }

        public string RenovarEmprestimoBL(EmprestimoMov empMov, int qtdeDias)
        {
            string erro = null;          
            EmprestimoMovDA empMovDA = new EmprestimoMovDA();
         
            erro = RetornaSituacaoTitulo(empMov.EmprestimoId != null ? (int)empMov.EmprestimoId : 0 );
              
            if (erro == string.Empty || erro == null)
                if (!empMovDA.RenovarEmprestimo(empMov, qtdeDias))
                    erro = "Não foi possível renovar o título";

            return erro;
        }
    }
}
