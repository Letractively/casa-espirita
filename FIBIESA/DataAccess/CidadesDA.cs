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
            return true;
        }

        public bool ExcluirDA(Cidades cid)
        {
            return true;
        }

        public List<Cidades> PesquisarDA()
        {
            List<Cidades> cidades = new List<Cidades>();
            return cidades;
        }
    }
}
