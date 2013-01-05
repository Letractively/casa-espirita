using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using System.Data;
using System.Data.SqlClient;
using InfrastructureSqlServer.Helpers;
using System.Configuration;

namespace DataAccess
{
    public class EstadosDA
    {
        public bool InserirDA(Estados est)
        {
            SqlParameter[] paramsToSP = new SqlParameter[2];

            paramsToSP[0] = new SqlParameter("@uf",est.Uf);
            paramsToSP[1] = new SqlParameter("@descricao", est.Descricao);

            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_insert_estados", paramsToSP);
    
            return true;
        }

        public bool EditarDA(Estados est)
        {
            SqlParameter[] paramsToSP = new SqlParameter[3];

            paramsToSP[0] = new SqlParameter("@id", est.Id);
            paramsToSP[1] = new SqlParameter("@uf", est.Uf);
            paramsToSP[2] = new SqlParameter("@descricao", est.Descricao);

            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_update_estados", paramsToSP);

            return true;
        }

        public bool ExcluirDA(Estados est)
        {
            SqlParameter[] paramsToSP = new SqlParameter[1];

            paramsToSP[0] = new SqlParameter("@id", est.Id);

            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_delete_estados", paramsToSP);

            return true;
        }

        public List<Estados> PesquisarDA()
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.Text, " select * from estados ");
                       
            List<Estados> estados = new List<Estados>();

            while (dr.Read())
            {
                Estados est = new Estados();
                est.Id = int.Parse(dr["ID"].ToString());
                est.Uf = dr["UF"].ToString();
                est.Descricao = dr["DESCRICAO"].ToString();
                                
                estados.Add(est);
            }
            return estados;
        }
    }
}
