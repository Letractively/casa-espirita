using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using InfrastructureSqlServer.Helpers;
using FG;

namespace DataAccess
{
    public class CidadesDA : BaseDA
    {
        Utils utils = new Utils();
        #region funcoes
        private List<Cidades> CarregarObjCidade(SqlDataReader dr)
        {
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

        private Int32 RetornaMaxCodigo()
        {
            Int32 codigo = 1;
            DataSet ds = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                          CommandType.Text, string.Format(@" SELECT ISNULL(MAX(CODIGO),0) + 1 as COD FROM CIDADES "));

            if (ds.Tables[0].Rows.Count != 0)
                codigo = utils.ComparaIntComZero(ds.Tables[0].Rows[0]["COD"].ToString());

            return codigo;
        }
        #endregion

        public bool InserirDA(Cidades cid)
        {
            SqlParameter[] paramsToSP = new SqlParameter[3];

            paramsToSP[0] = new SqlParameter("@codigo", RetornaMaxCodigo());
            paramsToSP[1] = new SqlParameter("@descricao", cid.Descricao);
            paramsToSP[2] = new SqlParameter("@estadoId", cid.EstadoId);

            try
            {
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_insert_cidades", paramsToSP);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public bool EditarDA(Cidades cid)
        {
            SqlParameter[] paramsToSP = new SqlParameter[4];

            paramsToSP[0] = new SqlParameter("@id", cid.Id);
            paramsToSP[1] = new SqlParameter("@codigo", cid.Codigo);
            paramsToSP[2] = new SqlParameter("@descricao", cid.Descricao);
            paramsToSP[3] = new SqlParameter("@estadoId", cid.EstadoId);

            try
            {
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_update_cidades", paramsToSP);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool ExcluirDA(Cidades cid)
        {
            SqlParameter[] paramsToSP = new SqlParameter[1];

            paramsToSP[0] = new SqlParameter("@id", cid.Id);

            try
            {
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_delete_cidades", paramsToSP);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<Cidades> PesquisarDA()
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                               CommandType.Text, @"SELECT * FROM CIDADES ORDER BY CODIGO ");

            List<Cidades> cidades = CarregarObjCidade(dr);

            return cidades;
        }

        public DataSet PesquisaDA(int id_cid)
        {
            DataSet ds = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                              CommandType.Text, string.Format( @"SELECT * FROM CIDADES WHERE ID = {0}", id_cid));

            return ds;

        }

        public List<Cidades> PesquisaCidUfDA(int id_uf)
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                              CommandType.Text, string.Format(@"SELECT * FROM CIDADES WHERE ESTADOID = {0}", id_uf));

            List<Cidades> cidades = CarregarObjCidade(dr);

            return cidades;

        }

        public List<Cidades> PesquisarBuscaDA(string valor)
        {
            StringBuilder consulta = new StringBuilder(@"SELECT * FROM CIDADES ");

            if (valor != "")
                consulta.Append(string.Format(" WHERE CODIGO = {0} OR  DESCRICAO  LIKE '%{1}%'", utils.ComparaIntComZero(valor), valor));

            consulta.Append(" ORDER BY CODIGO ");

            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, consulta.ToString());

            List<Cidades> cidades = CarregarObjCidade(dr);

            return cidades;
        }

        public override List<Base> Pesquisar(string descricao)
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                      CommandType.Text, string.Format(@"SELECT * " +
                                                                                       " FROM CIDADES WHERE CODIGO = '{0}' OR DESCRICAO LIKE '%{1}%'",utils.ComparaIntComZero(descricao), descricao));
            
            List<Base> ba = new List<Base>();

            while (dr.Read())
            {
                Base bas = new Base();
                bas.PesId1 = int.Parse(dr["ID"].ToString());
                bas.PesCodigo = dr["CODIGO"].ToString();
                bas.PesDescricao = dr["DESCRICAO"].ToString();

                ba.Add(bas);
            }
            return ba;
        }    
    }
}
