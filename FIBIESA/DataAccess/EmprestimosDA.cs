using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using FG;
using System.Data.SqlClient;
using InfrastructureSqlServer.Helpers;
using System.Configuration;
using System.Data;

namespace DataAccess
{
    public class EmprestimosDA : BaseDA
    {
        Utils utils = new Utils();
        #region funcoes
        private List<Emprestimos> CarregarObjEmprestimos(SqlDataReader dr)
        {
            List<Emprestimos> emprestimos = new List<Emprestimos>();

            while (dr.Read())
            {
                Emprestimos emprestim = new Emprestimos();
                emprestim.Id = int.Parse(dr["ID"].ToString());
                emprestim.ExemplarId = int.Parse(dr["EXEMPLARID"].ToString());
                emprestim.PessoaId = int.Parse(dr["PESSOAID"].ToString());

                emprestimos.Add(emprestim);
            }

            return emprestimos;
        }

        private List<ViewEmprestimos> CarregarObjViewEmprestimos(SqlDataReader dr)
        {
            List<ViewEmprestimos> emprestimos = new List<ViewEmprestimos>();

            while (dr.Read())
            {
                ViewEmprestimos emprestim = new ViewEmprestimos();
                
                emprestim.Id = int.Parse(dr["ID"].ToString());
                emprestim.EmprestimoId = int.Parse(dr["EMPRESTIMOID"].ToString());
                emprestim.ExemplarId = int.Parse(dr["EXEMPLARID"].ToString());
                emprestim.PessoaId = int.Parse(dr["PESSOAID"].ToString());
                emprestim.Id = int.Parse(dr["ID"].ToString());
                emprestim.DtEmprestimo = Convert.ToDateTime(dr["DATAEMPRESTIMO"].ToString());
                emprestim.DtPrevistaDevolucao = Convert.ToDateTime(dr["DATAPREVISTAEMPRESTIMO"].ToString());
                emprestim.Titulo = dr["TITULO"].ToString();
                emprestim.Nome = dr["NOME"].ToString();
                emprestim.NomeFantasia = dr["NOMEFANTASIA"].ToString();
                emprestim.Status = dr["STATUS"].ToString();
                                
                emprestimos.Add(emprestim);
            }

            return emprestimos;
        }
        #endregion

        public Int32 InserirDA(Emprestimos instancia)
        {
            SqlParameter[] paramsToSP = new SqlParameter[2];

            paramsToSP[0] = new SqlParameter("@exemplarid", instancia.ExemplarId);
            paramsToSP[1] = new SqlParameter("@pessoaid", instancia.PessoaId);

            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                    CommandType.StoredProcedure, "stp_insert_emprestimos", paramsToSP);
                
                DataTable tabela = ds.Tables[0];

                int id = utils.ComparaIntComZero(tabela.Rows[0]["ID"].ToString());

                return id;
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public bool EditarDA(Emprestimos instancia)
        {
            SqlParameter[] paramsToSP = new SqlParameter[3];

            paramsToSP[0] = new SqlParameter("@id", instancia.Id);
            paramsToSP[1] = new SqlParameter("@exemplarid", instancia.ExemplarId);
            paramsToSP[2] = new SqlParameter("@pessoaid", instancia.PessoaId);

            return (SqlHelper.ExecuteNonQuery(
                ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                CommandType.StoredProcedure, "stp_update_emprestimos", paramsToSP) > 0);
        }

        public bool ExcluirDA(Emprestimos instancia)
        {
            SqlParameter[] paramsToSP = new SqlParameter[1];

            paramsToSP[0] = new SqlParameter("@id", instancia.Id);

            return (SqlHelper.ExecuteNonQuery(
                ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                CommandType.StoredProcedure, "stp_delete_emprestimos", paramsToSP) > 0);
        }

        public List<Emprestimos> PesquisarDA()
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(
                ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                CommandType.Text, string.Format(@"SELECT * FROM emprestimos "));
            return CarregarObjEmprestimos(dr);
        }

        public List<Emprestimos> PesquisarDA(int id)
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(
                ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                CommandType.Text, string.Format(@"SELECT * FROM emprestimos  WHERE ID = {0}", id));
            return CarregarObjEmprestimos(dr);
        }

        public List<Emprestimos> PesquisarDA(string campo, string valor)
        {
            StringBuilder consulta = new StringBuilder("SELECT * FROM emprestimos ");

            switch (campo.ToUpper())
            {
                case "PESSOAID": //"CODIGO":
                    consulta.Append(string.Format("WHERE PESSOAID = {0}", utils.ComparaIntComZero(valor)));
                    break;
                case "EXEMPLARID": //"DESCRICAO":
                    consulta.Append(string.Format("WHERE EXEMPLARID = {0}", utils.ComparaIntComZero(valor)));
                    //consulta.Append(string.Format("WHERE DESCRICAO  LIKE '%{0}%'", valor));
                    break;
                default:
                    break;
            }

            SqlDataReader dr = SqlHelper.ExecuteReader(
                ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                CommandType.Text, consulta.ToString());

            return CarregarObjEmprestimos(dr);
        }

        public override List<Base> Pesquisar(string descricao)
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(
                    ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                    CommandType.Text, string.Format(@"SELECT * FROM emprestimos WHERE  CODIGO = '{0}' OR DESCRICAO LIKE '%{1}%'", utils.ComparaIntComZero(descricao), descricao));
            
            List<Base> ba = new List<Base>();

            while (dr.Read())
            {
                Base bas = new Base();
                bas.PesId1 = int.Parse(dr["ID"].ToString());
                bas.PesCodigo = dr["CODIGO"].ToString();
                bas.PesDescricao = dr["DESCRICAO"].ToString();

                ba.Add(bas);
            }
            return ba;
        }

        /// <summary>
        /// Carrega, da movimentacao de emprestimos, o emprestimo nao devolvido.
        /// </summary>
        /// <param name="id_emprestimo">Id do emprestimo (NÃO DO MOVIMENTACAO)</param>
        /// <returns>O Objeto EmprestimoMov da movimentacao nao devolvida, ou se nao existir, um objeto vazio com id == -1.</returns>
        public EmprestimoMov CarregaEmpNaoDevolvido(int id_emprestimo)
        {
            StringBuilder consulta = new StringBuilder(@"SELECT ID, EMPRESTIMOID, DATAEMPRESTIMO, DATAPREVISTAEMPRESTIMO FROM EMPRESTIMOMOV ");
            consulta.Append(@" WHERE EMPRESTIMOID = {0}");
            consulta.Append(@" AND DATADEVOLUCAO IS NULL ");

            SqlDataReader dr = SqlHelper.ExecuteReader(
                ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                CommandType.Text,
                string.Format(consulta.ToString(),id_emprestimo));
            EmprestimoMov volta = new EmprestimoMov();
            volta.Id = -1;
            if (dr.Read())
            {                
                volta.Id = int.Parse(dr["ID"].ToString());
                volta.EmprestimoId = int.Parse(dr["EMPRESTIMOID"].ToString());
                volta.DataEmprestimo = Convert.ToDateTime(dr["DATAEMPRESTIMO"].ToString());
                volta.DataPrevistaEmprestimo = Convert.ToDateTime(dr["DATAPREVISTAEMPRESTIMO"].ToString());
            }
            return volta;
        }

        /// <summary>
        /// Verifica se a pessoa tem livros atrasados até a data de hoje
        /// </summary>
        /// <param name="pessoaId">O Id da pessoa a analisar</param>
        /// <param name="Hoje">A data onde ainda não é considerado atraso.</param>
        /// <returns></returns>
        public bool LivrosAtrasados(int pessoaId, DateTime hoje)
        {
            StringBuilder consulta = new StringBuilder(@"SELECT COUNT(*) AS QTD FROM VIEW_EMPRESTIMOS WHERE PESSOAID = " + pessoaId.ToString());
            consulta.Append(@" AND DATAPREVISTAEMPRESTIMO >  '" + hoje.ToString("yyyy-MM-dd") + "'");
            int i = 0;
            string valor = SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                CommandType.Text, consulta.ToString()).ToString();

            Int32.TryParse(valor, out i);
            return (i > 0);
        }

        public int QuantosLivrosEmprestados(int pessoaId)
        {
            StringBuilder consulta = new StringBuilder(@"SELECT COUNT(*) AS QTD FROM VIEW_EMPRESTIMOS WHERE PESSOAID = " + pessoaId.ToString());
            int i = -1;
            string valor = SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                CommandType.Text, consulta.ToString()).ToString();

            Int32.TryParse(valor, out i);
            return i;
        }

        public Int32 QtdRenovacoes(int emprestimoId)
        {            
            StringBuilder consulta = new StringBuilder(@"SELECT COUNT(*) -1 AS QTD FROM EMPRESTIMOMOV WHERE EMPRESTIMOID = " + emprestimoId.ToString());
            int i = -1;
            string valor = SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                CommandType.Text, consulta.ToString()).ToString();

            if (Int32.TryParse(valor, out i))
            {
                if (i < 1)
                    i = 0; //se retornou 0, e fez a subtracao, tem -1 em i
            }
            return i;
        }

        public List<ViewEmprestimos> PesquisarBuscaBL(string valor)
        {
            StringBuilder consulta = new StringBuilder(@"SELECT * FROM view_emprestimos ");

            if (valor != "" && valor != null)
                consulta.Append(string.Format(" WHERE titulo LIKE '%{1}%' OR nome LIKE '%{1}%' OR nomeFantasia LIKE '%{1}%'", utils.ComparaIntComZero(valor), valor));

            consulta.Append(" ORDER BY DATAEMPRESTIMO ");

            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, consulta.ToString());

            List<ViewEmprestimos> listao = CarregarObjViewEmprestimos(dr);

            return listao;
        }



        //metodos do objeto viewEmprestimos

        public ViewEmprestimos CarregarViewEmprestimo(int id)
        {
            ViewEmprestimos ve = new ViewEmprestimos();

            SqlDataReader dr = SqlHelper.ExecuteReader(
                ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                CommandType.Text, string.Format(@"SELECT * FROM view_emprestimos  WHERE ID = {0}", id));
            
            dr.Read();

            ve.Id = id;
            ve.DtEmprestimo = Convert.ToDateTime(dr["DATAEMPRESTIMO"].ToString());
            ve.DtPrevistaDevolucao = Convert.ToDateTime(dr["DATAPREVISTAEMPRESTIMO"].ToString());
            ve.Titulo = dr["TITULO"].ToString();
            ve.Nome = dr["NOME"].ToString();
            ve.NomeFantasia = dr["NOMEFANTASIA"].ToString();
            ve.Status = dr["STATUS"].ToString();
            ve.ExemplarId = int.Parse(dr["EXEMPLARID"].ToString());
            ve.EmprestimoId = int.Parse(dr["EMPRESTIMOID"].ToString());
            ve.PessoaId = int.Parse(dr["PESSOAID"].ToString());

            return ve;

        }
    }
}
