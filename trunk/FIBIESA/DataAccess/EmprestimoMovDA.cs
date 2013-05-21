using System;
using System.Collections.Generic;
using System.Text;
using DataObjects;
using FG;
using System.Data.SqlClient;
using InfrastructureSqlServer.Helpers;
using System.Configuration;
using System.Data;

namespace DataAccess
{
    public class EmprestimoMovDA
    {

        Utils utils = new Utils();

        #region funcoes
        private List<EmprestimoMov> CarregarObjEmpMov(SqlDataReader dr)
        {
            List<EmprestimoMov> emprestimoMov = new List<EmprestimoMov>();
            
            while (dr.Read())
            {
                EmprestimoMov empMov = new EmprestimoMov();
                empMov.Id = int.Parse(dr["ID"].ToString());
                empMov.EmprestimoId = int.Parse(dr["EMPRESTIMOID"].ToString());
                empMov.DataEmprestimo = Convert.ToDateTime(dr["DATAEMPRESTIMO"].ToString());
                empMov.DataDevolucao = utils.ComparaDataComNull(dr["DATADEVOLUCAO"].ToString());
                empMov.DataPrevistaEmprestimo = Convert.ToDateTime(dr["DATAPREVISTAEMPRESTIMO"].ToString());
                empMov.Situacao = dr["SITUACAO"].ToString();

                Exemplares exemplar = new Exemplares();
                exemplar.Id = int.Parse(dr["IDEXE"].ToString());
                exemplar.Tombo =  int.Parse(dr["TOMBO"].ToString());

                empMov.Exemplares = exemplar;

                Obras obras = new Obras();
                obras.Id = int.Parse(dr["IDOBRA"].ToString());
                obras.Codigo = int.Parse(dr["CODIGO"].ToString());
                obras.Titulo = dr["TITULO"].ToString();

                empMov.Obras = obras;
                
                emprestimoMov.Add(empMov);
            }

            return emprestimoMov;
        }
        #endregion

        public bool InserirDA(EmprestimoMov instancia)
        {
            SqlParameter[] paramsToSP = new SqlParameter[4];

            paramsToSP[0] = new SqlParameter("@emprestimoid", instancia.EmprestimoId);
            paramsToSP[1] = new SqlParameter("@dataemprestimo", instancia.DataEmprestimo);
            paramsToSP[2] = new SqlParameter("@datadevolucao", instancia.DataDevolucao);
            paramsToSP[3] = new SqlParameter("@dataprevistaemprestimo", instancia.DataPrevistaEmprestimo);
            

            return (SqlHelper.ExecuteNonQuery(
                ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                CommandType.StoredProcedure, "stp_insert_emprestimoMov", paramsToSP) > 0);
        }

        public bool EditarDA(EmprestimoMov instancia)
        {
            SqlParameter[] paramsToSP = new SqlParameter[5];

            paramsToSP[0] = new SqlParameter("@emprestimoid", instancia.EmprestimoId);
            paramsToSP[1] = new SqlParameter("@dataemprestimo", instancia.DataEmprestimo);
            paramsToSP[2] = new SqlParameter("@datadevolucao", instancia.DataDevolucao);
            paramsToSP[3] = new SqlParameter("@dataprevistaemprestimo", instancia.DataPrevistaEmprestimo);
            paramsToSP[4] = new SqlParameter("@id", instancia.Id);

            return (SqlHelper.ExecuteNonQuery(
                ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                CommandType.StoredProcedure, "stp_update_emprestimoMov", paramsToSP) > 0);
        }

        public bool ExcluirDA(EmprestimoMov instancia)
        {
            SqlParameter[] paramsToSP = new SqlParameter[1];

            paramsToSP[0] = new SqlParameter("@id", instancia.Id);

            return (SqlHelper.ExecuteNonQuery(
                ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                CommandType.StoredProcedure, "stp_delete_emprestimoMov", paramsToSP) > 0);
        }

        public DataSet PesquisarRelatorioDA(string pessoasCod, string obrasCod, string dataRetiradaIni, string dataRetiradaFim, string dataDevolucaoIni, string dataDevolucaoFim, string Status)
        {
            DataSet lDs;
            try
            {
                StringBuilder sqlQuery = new StringBuilder();
                sqlQuery.Append(@"SELECT " +
                                  "    descricao " +
                                  "    ,Associado " +
                                  "    ,renovacoes " +
                                  "    ,dataRetirada " +
                                  "    ,dataDevolucao " +
                                  "    ,pessoaCodigo " +
                                  "    ,obrasCodigo " +
                                  "    ,status " +
                                  "FROM dbo.VIEW_REL_EMPRESTIMO " +
                                  " WHERE 1 = 1 ");
                if (pessoasCod != string.Empty)
                    sqlQuery.Append(@" AND pessoaCodigo IN (" + pessoasCod + ")");
                
                if (obrasCod != string.Empty)
                    sqlQuery.Append(@" AND obrasCodigo IN (" + obrasCod + ")");
                
                if ((dataRetiradaIni != string.Empty) && (dataRetiradaFim != string.Empty))
                    sqlQuery.Append(@" AND dataRetirada BETWEEN CONVERT(DATETIME,'" + dataRetiradaIni + "',103) AND CONVERT(DATETIME,'" + dataRetiradaFim + "',103)");
                
                if ((dataDevolucaoIni != string.Empty) && (dataDevolucaoFim != string.Empty))
                    sqlQuery.Append(@" AND dataDevolucao BETWEEN CONVERT(DATETIME,'" + dataDevolucaoIni + "',103) AND CONVERT(DATETIME,'" + dataDevolucaoFim + "',103)");
                
                if (Status != string.Empty)
                    sqlQuery.Append(@" AND Status = '" + Status +"'");
                
                lDs = SqlHelper.ExecuteDataset(
                    ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                    CommandType.Text, sqlQuery.ToString());
                return lDs;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public DataSet PesquisarRelatorioDA(string pessoasCod,string obrasCod, string dataRetiradaIni, string dataRetiradaFim, string dataDevolucaoIni, string dataDevolucaoFim, string Status, string retirados)
        {
            DataSet lDs;
            try
            {
                StringBuilder sqlQuery = new StringBuilder();
                sqlQuery.Append( @"SELECT " +
                                  "    descricao " +
                                  "    ,obrasCodigo " +
                                  "    ,COUNT(obrasCodigo) quantidade " +
                                  "FROM dbo.VIEW_REL_EMPRESTIMO " +
                                  " WHERE 1 = 1 ");
                if (pessoasCod != string.Empty)
                    sqlQuery.Append(@" AND pessoaCodigo in (" + pessoasCod + ")");
                
                if (obrasCod != string.Empty)
                    sqlQuery.Append(@" AND obrasCodigo in (" + obrasCod + ")");
                

                if ((dataRetiradaIni != string.Empty) && (dataRetiradaFim != string.Empty))
                    sqlQuery.Append(@" AND dataRetirada BETWEEN CONVERT(DATETIME,'" + dataRetiradaIni + "',103) AND CONVERT(DATETIME,'" + dataRetiradaFim + "',103)");
                
                if ((dataDevolucaoIni != string.Empty) && (dataDevolucaoFim != string.Empty))
                    sqlQuery.Append(@" AND dataDevolucao BETWEEN CONVERT(DATETIME,'" + dataDevolucaoIni + "',103) AND CONVERT(DATETIME,'" + dataDevolucaoFim + "',103)");
                
                if (Status != string.Empty)
                    sqlQuery.Append(@" AND Status = '" + Status+ "'");

                sqlQuery.Append(@" GROUP BY obrasCodigo, descricao order by quantidade " + retirados);
                
                lDs = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                    CommandType.Text,sqlQuery.ToString());
                return lDs;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public Int32 IdMovEmprestado(int emprestimoId)
        {
            StringBuilder consulta = new StringBuilder(@"SELECT ID FROM EMPRESTIMOMOV WHERE DATADEVOLUCAO IS NULL AND EMPRESTIMOID = " + emprestimoId.ToString());
            int i = -1;
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, consulta.ToString());
            if (dr.Read())            
                return int.Parse(dr["ID"].ToString());            
            else
                return -1;
        }

        public EmprestimoMov Carregar(int id)
        {
            EmprestimoMov volta = new EmprestimoMov();
            volta.Id = -1;

            StringBuilder consulta = new StringBuilder(@"SELECT * FROM EMPRESTIMOMOV WHERE ID = " + id.ToString());
            int i = -1;
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, consulta.ToString());
            if (dr.Read())
            {
                volta.Id = id;
                volta.EmprestimoId = int.Parse(dr["EMPRESTIMOID"].ToString());
                volta.DataDevolucao = DateTime.Parse(dr["DATADEVOLUCAO"].ToString());
                volta.DataEmprestimo = DateTime.Parse(dr["DATAEMPRESTIMO"].ToString());
                volta.DataPrevistaEmprestimo = DateTime.Parse(dr["DATAPREVISTAEMPRESTIMO"].ToString());
            }
            return volta;
        }

        public List<EmprestimoMov> PesquisarMovAtivosDA(int id_pessoa)
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                       CommandType.Text, string.Format(@"SELECT EM.*, O.ID IDOBRA, O.CODIGO, O.TITULO, " +
                                                                                       " EX.ID IDEXE, EX.TOMBO, " +
                                                                                       " CASE WHEN (DATAPREVISTAEMPRESTIMO <= CAST (GETDATE() AS DATE)) " +
                                                                                       " THEN 'Atrasado' ELSE 'Emprestado' END AS SITUACAO " +
                                                                                       " FROM EMPRESTIMOMOV EM " +
                                                                                       "     ,EMPRESTIMOS E " +
                                                                                       "     ,EXEMPLARES EX " +
                                                                                       "     ,OBRAS O " +
                                                                                       " WHERE EM.EMPRESTIMOID = E.ID " +
                                                                                       "   AND E.EXEMPLARID = EX.ID " +
                                                                                       "   AND EX.OBRAID = O.ID " +
                                                                                       "   AND EM.DATADEVOLUCAO IS NULL " +
                                                                                       "   AND E.PESSOAID = {0}", id_pessoa));

            List<EmprestimoMov> empMov = CarregarObjEmpMov(dr);

            return empMov;
        }
    }
}
