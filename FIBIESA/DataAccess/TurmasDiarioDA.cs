using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using InfrastructureSqlServer.Helpers;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using FG;

namespace DataAccess
{
    public class TurmasDiarioDA
    {
        Utils utils = new Utils();

        public Int32 InserirDA(TurmasDiario tur)
        {
            SqlParameter[] paramsToSP = new SqlParameter[3];

            paramsToSP[0] = new SqlParameter("@data", tur.Data);
            paramsToSP[1] = new SqlParameter("@obs", tur.Obs);
            paramsToSP[2] = new SqlParameter("@turmaId", tur.TurmaId);
          
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_insert_turmasDiario", paramsToSP);

                DataTable tabela = ds.Tables[0];

                int id = utils.ComparaIntComZero(tabela.Rows[0]["ID"].ToString());

                return id;
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public bool EditarDA(TurmasDiario tur)
        {
            SqlParameter[] paramsToSP = new SqlParameter[4];

            paramsToSP[0] = new SqlParameter("@data", tur.Id);
            paramsToSP[1] = new SqlParameter("@data", tur.Data);
            paramsToSP[2] = new SqlParameter("@obs", tur.Obs);
            paramsToSP[3] = new SqlParameter("@turmaId", tur.TurmaId);

            try
            {
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_update_turmasDiario", paramsToSP);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool ExcluirDA(TurmasDiario tur)
        {
            SqlParameter[] paramsToSP = new SqlParameter[1];

            paramsToSP[0] = new SqlParameter("@id", tur.Id);

            try
            {
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_delete_turmasDiario", paramsToSP);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public DataSet PesquisarDA(int id_tur, DateTime data)
        {
            StringBuilder v_query = new StringBuilder();

            v_query.Append(@"SELECT obs ");
            v_query.Append(@" FROM turmasDiario");
            v_query.Append(@" WHERE CONVERT(DATE,data,103) = CONVERT(DATE,'" + data + "',103)");
            v_query.Append(@"  AND turmaId = {0} ");


            DataSet ds = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                       CommandType.Text, string.Format(v_query.ToString(), id_tur));

            return ds;
        }
    }
}
