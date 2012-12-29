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
    public class CidadesDA
    {
        public bool InserirDA(Cidades cid)
        {
            SqlParameter[] paramsToSP = new SqlParameter[3];

            paramsToSP[0] = new SqlParameter("@codigo", cid.Codigo);
            paramsToSP[1] = new SqlParameter("@descricao", cid.Descricao);
            paramsToSP[2] = new SqlParameter("@estadoId", cid.EstadoId);

            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_insert_cidades", paramsToSP);

            return true;
        }

        public bool EditarDA(Cidades cid)
        {
            SqlParameter[] paramsToSP = new SqlParameter[4];

            paramsToSP[0] = new SqlParameter("@id", cid.Id);
            paramsToSP[1] = new SqlParameter("@codigo", cid.Codigo);
            paramsToSP[2] = new SqlParameter("@descricao", cid.Descricao);
            paramsToSP[3] = new SqlParameter("@estadoId", cid.EstadoId);

            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_update_cidades", paramsToSP);

            return true;
        }

        public bool ExcluirDA(Cidades cid)
        {
            SqlParameter[] paramsToSP = new SqlParameter[1];

            paramsToSP[0] = new SqlParameter("@id", cid.Id);

            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_delete_cidades", paramsToSP);

            return true;
        }

        public List<Cidades> PesquisarDA()
        {
            List<Cidades> cidades = new List<Cidades>();
            return cidades;
        }
    }
}
