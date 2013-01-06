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
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                               CommandType.Text, @"SELECT * FROM CIDADES ");

            List<Cidades> cidades = new List<Cidades>();

            while (dr.Read())
            {
                Cidades cid = new Cidades();
                cid.Id = int.Parse(dr["ID"].ToString());
                cid.Codigo = int.Parse(dr["CODIGO"].ToString());
                cid.Descricao = dr["DESCRICAO"].ToString();
                cid.EstadoId = int.Parse(dr["ESTADOID"].ToString());

                cidades.Add(cid);
            }
            return cidades;
        }

        public List<Cidades> PesquisaDA(int id_cid)
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                              CommandType.Text, string.Format( @"SELECT * FROM CIDADES WHERE ID = {0}", id_cid));

            List<Cidades> cidades = new List<Cidades>();

            while (dr.Read())
            {
                Cidades cid = new Cidades();
                cid.Id = int.Parse(dr["ID"].ToString());
                cid.Codigo = int.Parse(dr["CODIGO"].ToString());
                cid.Descricao = dr["DESCRICAO"].ToString();
                cid.EstadoId = int.Parse(dr["ESTADOID"].ToString());
                    
                cidades.Add(cid);
            }

            return cidades;

        }
    }
}
