using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using InfrastructureSqlServer.Helpers;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


namespace DataAccess
{
    public class BairrosDA
    {
        public bool InserirDA(Bairros bai)
        {
            SqlParameter[] paramsToSP = new SqlParameter[2];

            paramsToSP[0] = new SqlParameter("@codigo", bai.Codigo); 
            paramsToSP[1] = new SqlParameter("@descricao", bai.Descricao);       
            
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_insert_bairros", paramsToSP);
                           
            return true;
        }

        public bool EditarDA(Bairros bai)
        {
            SqlParameter[] paramsToSP = new SqlParameter[3];

            paramsToSP[0] = new SqlParameter("@id", bai.Id);
            paramsToSP[1] = new SqlParameter("@codigo", bai.Codigo);
            paramsToSP[2] = new SqlParameter("@descricao", bai.Descricao);

            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_update_bairros", paramsToSP);

            return true;
        }

        public bool ExcluirDA(Bairros bai)
        {
            SqlParameter[] paramsToSP = new SqlParameter[1];

            paramsToSP[0] = new SqlParameter("@id", bai.Id);

            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_delete_bairros", paramsToSP); 

            return true;
        }

        public List<Bairros> PesquisarDA()
        {
            List<Bairros> bairros = new List<Bairros>();
            return bairros;
        }
    }
}
