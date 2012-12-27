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

            paramsToSP[0] = new SqlParameter("@codigo", SqlDbType.Int);
            paramsToSP[0].Value = bai.Codigo;

            paramsToSP[1] = new SqlParameter("@descricao", SqlDbType.Int);
            paramsToSP[1].Value = bai.Descricao;
            
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_insert_bairros", paramsToSP);
                           
            return true;
        }

        public bool EditarDA(Bairros bai)
        {
            return true;
        }

        public bool ExcluirDA(Bairros pes)
        {
            return true;
        }

        public List<Bairros> PesquisarDA()
        {
            List<Bairros> bairros = new List<Bairros>();
            return bairros;
        }
    }
}
