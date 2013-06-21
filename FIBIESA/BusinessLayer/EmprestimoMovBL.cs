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

        #region
        
        private string LerParametro(int codigo, string modulo)
        {
            ParametrosBL parBL = new ParametrosBL();
            string valor = parBL.PesquisarValorBL(codigo, modulo);

            return valor;
        }

        #endregion
        public bool InserirBL(EmprestimoMov instancia)
        {
            /*criar as regras de negocio*/
            EmprestimoMovDA varDA = new EmprestimoMovDA();

            return varDA.InserirDA(instancia);
        }

        public string EditarBL(EmprestimoMov instancia)
        {            
            EmprestimoMovDA varDA = new EmprestimoMovDA();

            if (varDA.EditarDA(instancia))
            {
                DateTime hoje = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                DateTime diaD = instancia.DataPrevistaEmprestimo ?? hoje;
                TimeSpan data = hoje - diaD;
                int diasAtraso = data.Days;

                if (utils.ComparaIntComZero(diasAtraso.ToString()) > 0)
                {
                    //cadastrar titulo da multa
                    decimal multa = utils.ComparaDecimalComZero(this.LerParametro(1, "F"));
                    Int32 tipoDocumento = utils.ComparaIntComZero(this.LerParametro(4, "F"));
                    Int32 portadorId = utils.ComparaIntComZero(this.LerParametro(5, "F"));

                    multa = multa * diasAtraso;
                    int prazo = utils.ComparaIntComZero(this.LerParametro(6, "F"));
                    prazo = (prazo < 1 ? 7 : prazo);                   
                    
                    TitulosBL titBL = new TitulosBL();
                    Titulos titulos = new Titulos();

                    titulos.Numero = titBL.RetornaNovoNumero();
                    titulos.Parcela = 1;
                    titulos.Pessoaid = instancia.PessoaId;
                    titulos.DataEmissao = hoje;                   
                    titulos.DataVencimento = hoje.AddDays(prazo);
                    titulos.Valor = multa;
                    titulos.TipoDocumentoId = tipoDocumento;
                    titulos.Portadorid = portadorId;
                    titulos.Tipo = "R";

                                                   
                    titulos.Obs = "Titulo gerado automaticamente, devido ao atraso de " + utils.ComparaIntComZero(diasAtraso.ToString())
                        + " dia(s) na devolução do exemplar " + instancia.Titulo;

                    if (titBL.InserirBL(titulos))
                        return "Exemplar devolvido com atraso. Foi gerado o título " + titulos.Numero + " no valor de R$" + titulos.Valor;
                                        
                }

                return "Devolução realizada com sucesso!";
            }
            else
                return "false";

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
            if (empDA.QtdRenovacoes(id_emp) >= maxRenovacao)
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
