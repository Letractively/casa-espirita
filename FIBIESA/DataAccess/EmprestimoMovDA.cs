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

    }
}
