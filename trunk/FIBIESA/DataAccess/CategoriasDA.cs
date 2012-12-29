using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using DataAccess;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using InfrastructureSqlServer.Helpers;

namespace DataAccess
{
    public class CategoriasDA
    {
        public bool InserirDA(Categorias cat)
        {
            SqlParameter[] paramsToSP = new SqlParameter[2];

            paramsToSP[0] = new SqlParameter("@codigo", cat.Codigo);
            paramsToSP[1] = new SqlParameter("@descricao", cat.Descricao);

            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_insert_categorias", paramsToSP);

            return true;
        }

        public bool EditarDA(Categorias cat)
        {
            SqlParameter[] paramsToSP = new SqlParameter[3];

            paramsToSP[0] = new SqlParameter("@id", cat.Id);
            paramsToSP[1] = new SqlParameter("@codigo", cat.Codigo);
            paramsToSP[2] = new SqlParameter("@descricao", cat.Descricao);

            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_update_categorias", paramsToSP);

            return true;
        }

        public bool ExcluirDA(Categorias cat)
        {
            SqlParameter[] paramsToSP = new SqlParameter[1];

            paramsToSP[0] = new SqlParameter("@id", cat.Id);

            // SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "", paramsToSP);

            return true;
        }

        public List<Categorias> PesquisarDA()
        {
            List<Categorias> categorias = new List<Categorias>();
            return categorias;
        }
    }
}
