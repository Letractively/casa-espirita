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
    public class PermissoesDA
    {
        public bool InserirDA(Permissoes per)
        {
            SqlParameter[] paramsToSP = new SqlParameter[6];

            paramsToSP[0] = new SqlParameter("@codigo", per.Codigo);
            paramsToSP[1] = new SqlParameter("@consultar", per.Consultar);
            paramsToSP[2] = new SqlParameter("@inserir", per.Inserir);
            paramsToSP[3] = new SqlParameter("@editar", per.Editar);
            paramsToSP[4] = new SqlParameter("@excluir", per.Excluir);
            paramsToSP[5] = new SqlParameter("@formularioid", per.FormularioId);

           // SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "", paramsToSP);

            return true;
        }

        public bool EditarDA(Permissoes per)
        {
            SqlParameter[] paramsToSP = new SqlParameter[7];

            paramsToSP[0] = new SqlParameter("@id", per.Id);
            paramsToSP[1] = new SqlParameter("@codigo", per.Codigo);
            paramsToSP[2] = new SqlParameter("@consultar", per.Consultar);
            paramsToSP[3] = new SqlParameter("@inserir", per.Inserir);
            paramsToSP[4] = new SqlParameter("@editar", per.Editar);
            paramsToSP[5] = new SqlParameter("@excluir", per.Excluir);
            paramsToSP[6] = new SqlParameter("@formularioid", per.FormularioId);

            // SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "", paramsToSP);

            return true;
        }

        public bool ExcluirDA(Permissoes per)
        {
            SqlParameter[] paramsToSP = new SqlParameter[1];

            paramsToSP[0] = new SqlParameter("@id", per.Id);

            // SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "", paramsToSP);

            return true;
        }

        public List<Permissoes> PesquisarDA()
        {
            List<Permissoes> permissoes = new List<Permissoes>();
            return permissoes;
        }
    }
}
