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
                if (dr["DATAPREVISTAEMPRESTIMO"].ToString() != string.Empty)
                    emprestim.DtPrevistaDevolucao = Convert.ToDateTime(dr["DATAPREVISTAEMPRESTIMO"].ToString());
                emprestim.Titulo = dr["TITULO"].ToString();
                emprestim.Nome = dr["NOME"].ToString();
                emprestim.NomeFantasia = dr["NOMEFANTASIA"].ToString();
                emprestim.Status = dr["STATUS"].ToString();
                emprestim.Tombo = 123;//utils.ComparaIntComZero(dr["TOMBO"].ToString());
                emprestim.Codigo = 1;//utils.ComparaIntComZero(dr["CODIGO"].ToString());

                emprestimos.Add(emprestim);
            }

            return emprestimos;
        }
        private int LerParametro(int codigo, string modulo)
        {
            ParametrosDA parDA = new ParametrosDA();
            DataSet dsPar = parDA.PesquisarDA(codigo, modulo);
            int valor = -1;

            if (dsPar.Tables[0].Rows.Count != 0)
                valor = utils.ComparaIntComZero(dsPar.Tables[0].Rows[0]["VALOR"].ToString());

            return valor;
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

            try
            {
                return (SqlHelper.ExecuteNonQuery(
                    ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                    CommandType.StoredProcedure, "stp_update_emprestimos", paramsToSP) > 0);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool ExcluirDA(Emprestimos instancia)
        {
            SqlParameter[] paramsToSP = new SqlParameter[1];

            paramsToSP[0] = new SqlParameter("@id", instancia.Id);

            try
            {
                return (SqlHelper.ExecuteNonQuery(
                    ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                    CommandType.StoredProcedure, "stp_delete_emprestimos", paramsToSP) > 0);
            }
            catch (Exception e)
            {
                return false;
            }
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
                string.Format(consulta.ToString(), id_emprestimo));
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

        /// <summary>
        /// Retorna uma lista com todos os empréstimos ativos (não devolvidos) da pessoa.
        /// </summary>
        /// <param name="pessoaId"></param>
        /// <returns></returns>
        public DataTable BuscaHistorico(int pessoaId)
        {
            StringBuilder consulta = new StringBuilder();
            consulta.Append(@" SELECT EX.TOMBO, OB.CODIGO, OB.TITULO,  MOV.DATAEMPRESTIMO, MOV.DATAPREVISTAEMPRESTIMO,");
            consulta.Append(@" MOV.EMPRESTIMOID, EM.EXEMPLARID,  EM.PESSOAID,");
            consulta.Append(@" CASE WHEN (DATAPREVISTAEMPRESTIMO <= CAST (GETDATE() AS DATE))");
            consulta.Append(@" THEN 'Atrasado' ELSE 'Emprestado' END AS SITUACAO");
            consulta.Append(@" FROM EMPRESTIMOMOV MOV");
            consulta.Append(@" INNER JOIN EMPRESTIMOS EM ON EM.ID = MOV.EMPRESTIMOID");
            consulta.Append(@" INNER JOIN EXEMPLARES EX ON EX.ID = EM.EXEMPLARID");
            consulta.Append(@" INNER JOIN OBRAS OB ON OB.ID = EX.OBRAID");
            consulta.Append(@" WHERE MOV.DATADEVOLUCAO IS NULL AND PESSOAID = " + pessoaId.ToString());

            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, consulta.ToString());

            DataTable dt = new DataTable();
            DataColumn coluna1 = new DataColumn("TOMBO", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("CODIGO", Type.GetType("System.Int32"));
            DataColumn coluna3 = new DataColumn("TITULO", Type.GetType("System.String"));
            DataColumn coluna4 = new DataColumn("DATAEMPRESTIMO", Type.GetType("System.DateTime"));
            DataColumn coluna5 = new DataColumn("DATAPREVISTAEMPRESTIMO", Type.GetType("System.DateTime"));
            DataColumn coluna6 = new DataColumn("EMPRESTIMOID", Type.GetType("System.Int32"));
            DataColumn coluna7 = new DataColumn("EXEMPLARID", Type.GetType("System.Int32"));
            DataColumn coluna8 = new DataColumn("PESSOAID", Type.GetType("System.Int32"));
            DataColumn coluna9 = new DataColumn("SITUACAO", Type.GetType("System.String"));

            dt.Columns.Add(coluna1);
            dt.Columns.Add(coluna2);
            dt.Columns.Add(coluna3);
            dt.Columns.Add(coluna4);
            dt.Columns.Add(coluna5);
            dt.Columns.Add(coluna6);
            dt.Columns.Add(coluna7);
            dt.Columns.Add(coluna8);
            dt.Columns.Add(coluna9);

            while (dr.Read())
            {
                DataRow linha = dt.NewRow();

                linha["TOMBO"] = int.Parse(dr["TOMBO"].ToString());
                linha["CODIGO"] = int.Parse(dr["CODIGO"].ToString());
                linha["TITULO"] = dr["TITULO"].ToString();
                linha["DATAEMPRESTIMO"] = Convert.ToDateTime(dr["DATAEMPRESTIMO"].ToString());
                linha["DATAPREVISTAEMPRESTIMO"] = Convert.ToDateTime(dr["DATAPREVISTAEMPRESTIMO"].ToString());
                linha["EMPRESTIMOID"] = int.Parse(dr["EMPRESTIMOID"].ToString());
                linha["EXEMPLARID"] = int.Parse(dr["EXEMPLARID"].ToString());
                linha["PESSOAID"] = int.Parse(dr["PESSOAID"].ToString());
                linha["SITUACAO"] = dr["SITUACAO"].ToString();

                dt.Rows.Add(linha);
            }

            return dt;
        }

        public List<ViewEmprestimos> PesquisarBuscaBL(string valor)
        {
            StringBuilder consulta = new StringBuilder(@"SELECT * FROM view_emprestimos ");

            if (valor != "" && valor != null)
                consulta.Append(string.Format(" WHERE tombo LIKE '%{1}%' OR titulo LIKE '%{1}%' OR nome LIKE '%{1}%' OR nomeFantasia LIKE '%{1}%'", utils.ComparaIntComZero(valor), valor));

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

        public DataSet PesquisarDataSetDA(int empId)
        {
            SqlParameter[] paramsToSP = new SqlParameter[1];

            paramsToSP[0] = new SqlParameter("@id", empId);
            
            DataSet ds = SqlHelper.ExecuteDataset(
                ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                CommandType.StoredProcedure, "stp_CONSULTA_emprestimo", paramsToSP);
            return ds;
        }

        public bool VerificaQtdeMaximaEmprestimo(int id_pessoa)
        {
            StringBuilder v_erro = new StringBuilder();
            StringBuilder v_query = new StringBuilder();
            
            //verifica quantidade minima inicial para emprestimos
            v_query.Clear();

            int minQtdDias = this.LerParametro(3, "B");
            int minEmp = this.LerParametro(4, "B");
            int maxExemp = this.LerParametro(1, "B");
            int qtdEmprestados = this.QuantosLivrosEmprestados(id_pessoa);

            v_query.Append(@"SELECT DATEDIFF ( DAY , CONVERT(DATE,P.DTCADASTRO,103), CONVERT(DATE,GETDATE(),103)) AS QTDE ");
            v_query.Append(@"  FROM PESSOAS P ");
            v_query.Append(@" WHERE P.ID = " + id_pessoa.ToString());

            DataSet dsEmp = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, v_query.ToString());
            int v_qtd;

            if (dsEmp.Tables[0].Rows.Count != 0)
            {
                v_qtd = (Int32)dsEmp.Tables[0].Rows[0]["QTDE"];

                if (minQtdDias >= v_qtd && qtdEmprestados >= minEmp)
                    return false;
            }

            //Quantidade máxima de exemplares emprestado           
            if (qtdEmprestados >= maxExemp)
                return false;

            return true;

        }

    }
}
