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

        public DataSet PesquisarRelatorioDA(Emprestimos instancia, string dataRetiradaIni, string dataRetiradaFim, string dataDevolucaoIni, string dataDevolucaoFim, string Status)
        {
            DataSet lDs;
            try
            {
                string sqlQuery = "SELECT " +
                                  "    descricao " +
                                  "    ,Associado " +
                                  "    ,renovacoes " +
                                  "    ,dataRetirada " +
                                  "    ,dataDevolucao " +
                                  "    ,pessoaid " +
                                  "    ,exemplarid " +
                                  "    ,status " +
                                  "FROM dbo.VIEW_REL_EMPRESTIMO " +
                                  " WHERE 1 = 1 ";
                if (instancia.PessoaId != 0)
                {

                    sqlQuery += " AND pessoaid = " + instancia.PessoaId;
                }

                if (instancia.ExemplarId != 0)
                {

                    sqlQuery += " AND exemplarid = " + instancia.ExemplarId;
                }

                if ((dataRetiradaIni != string.Empty) && (dataRetiradaFim != string.Empty))
                {

                    sqlQuery += " AND dataRetirada BETWEEN CONVERT(DATETIME,'" + dataRetiradaIni + "',103) AND CONVERT(DATETIME,'" + dataRetiradaFim + "',103)";
                }

                if ((dataDevolucaoIni != string.Empty) && (dataDevolucaoFim != string.Empty))
                {

                    sqlQuery += " AND dataDevolucao BETWEEN CONVERT(DATETIME,'" + dataDevolucaoIni + "',103) AND CONVERT(DATETIME,'" + dataDevolucaoFim + "',103)";
                }

                if (Status != string.Empty)
                {

                    sqlQuery += " AND Status = " + Status;
                }

                lDs = SqlHelper.ExecuteDataset(
                    ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                    CommandType.Text, sqlQuery);
                return lDs;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

    }
}
