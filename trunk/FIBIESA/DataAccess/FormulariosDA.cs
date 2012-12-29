using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using InfrastructureSqlServer.Helpers;

namespace DataAccess
{
    public class FormulariosDA
    {
        public bool InserirDA(Formularios form)
        {
            SqlParameter[] paramsToSP = new SqlParameter[2];

            paramsToSP[0] = new SqlParameter("@codigo", form.Codigo);
            paramsToSP[1] = new SqlParameter("@descricao", form.Descricao);

            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_insert_formularios", paramsToSP);

            return true;
        }

        public bool EditarDA(Formularios form)
        {
            SqlParameter[] paramsToSP = new SqlParameter[3];

            paramsToSP[0] = new SqlParameter("@id", form.Id);
            paramsToSP[1] = new SqlParameter("@codigo", form.Codigo);
            paramsToSP[2] = new SqlParameter("@descricao", form.Descricao);

            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_update_formularios", paramsToSP);

            return true;
        }

        public bool ExcluirDA(Formularios form)
        {
            SqlParameter[] paramsToSP = new SqlParameter[1];

            paramsToSP[0] = new SqlParameter("@id", form.Id);

            // SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "", paramsToSP);

            return true;
        }

        public List<Formularios> PesquisarDA()
        {
            List<Formularios> formularios = new List<Formularios>();
            return formularios;
        }
    }
}
