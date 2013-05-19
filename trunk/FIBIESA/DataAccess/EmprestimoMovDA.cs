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

        public DataSet PesquisarRelatorioDA(Emprestimos instancia, string obraId, string dataRetiradaIni, string dataRetiradaFim, string dataDevolucaoIni, string dataDevolucaoFim, string Status)
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
                                  "    ,pessoaid " +
                                  "    ,exemplarid " +
                                  "    ,status " +
                                  "FROM dbo.VIEW_REL_EMPRESTIMO " +
                                  " WHERE 1 = 1 ");
                if (instancia.PessoaId != 0)
                    sqlQuery.Append(@" AND pessoaid = " + instancia.PessoaId);
                
                if (obraId != string.Empty)
                    sqlQuery.Append(@" AND obraid = " + obraId);
                
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

        public DataSet PesquisarRelatorioDA(Emprestimos instancia,string obraId, string dataRetiradaIni, string dataRetiradaFim, string dataDevolucaoIni, string dataDevolucaoFim, string Status, string retirados)
        {
            DataSet lDs;
            try
            {
                StringBuilder sqlQuery = new StringBuilder();
                sqlQuery.Append( @"SELECT " +
                                  "    descricao " +
                                  "    ,exemplarid " +
                                  "    ,COUNT(exemplarid) quantidade " +
                                  "FROM dbo.VIEW_REL_EMPRESTIMO " +
                                  " WHERE 1 = 1 ");
                if (instancia.PessoaId != 0)                                    
                    sqlQuery.Append( @" AND pessoaid = " + instancia.PessoaId);
                
                if (obraId != string.Empty)
                    sqlQuery.Append(@" AND obraid = " + obraId);
                

                if ((dataRetiradaIni != string.Empty) && (dataRetiradaFim != string.Empty))
                    sqlQuery.Append(@" AND dataRetirada BETWEEN CONVERT(DATETIME,'" + dataRetiradaIni + "',103) AND CONVERT(DATETIME,'" + dataRetiradaFim + "',103)");
                
                if ((dataDevolucaoIni != string.Empty) && (dataDevolucaoFim != string.Empty))
                    sqlQuery.Append(@" AND dataDevolucao BETWEEN CONVERT(DATETIME,'" + dataDevolucaoIni + "',103) AND CONVERT(DATETIME,'" + dataDevolucaoFim + "',103)");
                
                if (Status != string.Empty)
                    sqlQuery.Append(@" AND Status = '" + Status+ "'");
                
                sqlQuery.Append(@" GROUP BY exemplarid, descricao order by quantidade " + retirados);
                
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
    }
}
