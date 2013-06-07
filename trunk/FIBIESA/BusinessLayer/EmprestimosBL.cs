using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using DataAccess;
using System.Data;

namespace BusinessLayer
{
    public class EmprestimosBL : BaseBL
    {
        public Int32 InserirBL(Emprestimos instancia)
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

        public List<Emprestimos> PesquisarBL(int bai)
        {
            EmprestimosDA varDA = new EmprestimosDA();

            return varDA.PesquisarDA(bai);
        }

        public List<Emprestimos> PesquisarBL(string campo, string valor)
        {
            EmprestimosDA varDA = new EmprestimosDA();

            return varDA.PesquisarDA(campo, valor);
        }

        public EmprestimoMov CarregaEmpNaoDevolvido(int id_emprestimo)
        {
            EmprestimosDA varDA = new EmprestimosDA();

            return varDA.CarregaEmpNaoDevolvido(id_emprestimo);
        }

        public bool LivrosAtrasados(int pessoaId, DateTime hoje)
        { 
            //criar as regras de negocio
            EmprestimosDA varDA = new EmprestimosDA();

            return varDA.LivrosAtrasados(pessoaId, hoje);
        }

        public int QuantosLivrosEmprestados(int pessoaId)
        {
            //criar as regras de negocio
            EmprestimosDA varDA = new EmprestimosDA();

            return varDA.QuantosLivrosEmprestados(pessoaId);
        }

        public Int32 QtdRenovacoes(int emprestimoId)
        { 
            //criar as regras de negocio
            EmprestimosDA varDA = new EmprestimosDA();

            return varDA.QtdRenovacoes(emprestimoId);        
        }

        public DataTable BuscaHistorico(int pessoaId)
        {
                        //criar as regras de negocio
            EmprestimosDA varDA = new EmprestimosDA();

            return varDA.BuscaHistorico(pessoaId);
        }

        //public List<Emprestimos> PesquisarBuscaBL(string valor)
        public List<ViewEmprestimos> PesquisarBuscaBL(string valor)
        {
            //criar as regras de negocio
            EmprestimosDA varDA = new EmprestimosDA();

            return varDA.PesquisarBuscaBL(valor);
        }
        
        public override List<Base> Pesquisar(string codDes)
        {
            EmprestimosDA varDA = new EmprestimosDA();

            return varDA.Pesquisar(codDes);
        }

        public DataSet PesquisarDataSet(int empId)
        {
            EmprestimosDA varDA = new EmprestimosDA();

            return varDA.PesquisarDataSetDA(empId);
        }

        
    }
}
