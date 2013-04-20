using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using System.Data;
using System.Data.SqlClient;
using InfrastructureSqlServer.Helpers;
using System.Configuration;
using FG;

namespace DataAccess
{
    public class TiposDocumentosDA : BaseDA
    {
        Utils utils = new Utils();

        #region funcoes
        private List<TiposDocumentos> CarregarObjTiposDocumentos(SqlDataReader dr)
        {
            List<TiposDocumentos> tiposDocumentos = new List<TiposDocumentos>();

            while (dr.Read())
            {
                TiposDocumentos tdo = new TiposDocumentos();
                tdo.Id = int.Parse(dr["ID"].ToString());
                tdo.Codigo = int.Parse(dr["CODIGO"].ToString());
                tdo.Descricao = dr["DESCRICAO"].ToString();
                tdo.Aplicacao = dr["APLICACAO"].ToString();

                tiposDocumentos.Add(tdo);
            }
            return tiposDocumentos;
        }

        private Int32 RetornaMaxCodigo()
        {
            Int32 codigo = 1;
            DataSet ds = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                          CommandType.Text, string.Format(@" SELECT ISNULL(MAX(CODIGO),0) + 1 as COD FROM TIPOSDOCUMENTOS "));

            if (ds.Tables[0].Rows.Count != 0)
                codigo = utils.ComparaIntComZero(ds.Tables[0].Rows[0]["COD"].ToString());

            return codigo;
        }

        #endregion

        public bool InserirDA(TiposDocumentos tdo)
        {
            SqlParameter[] paramsToSP = new SqlParameter[3];

            paramsToSP[0] = new SqlParameter("@codigo", RetornaMaxCodigo());
            paramsToSP[1] = new SqlParameter("@descricao", tdo.Descricao);
            paramsToSP[2] = new SqlParameter("@aplicacao", tdo.Aplicacao);

            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_insert_tiposDocumentos", paramsToSP);

            return true;
        }

        public bool EditarDA(TiposDocumentos tdo)
        {
            SqlParameter[] paramsToSP = new SqlParameter[4];

            paramsToSP[0] = new SqlParameter("@id", tdo.Id);
            paramsToSP[1] = new SqlParameter("@codigo", tdo.Codigo);
            paramsToSP[2] = new SqlParameter("@descricao", tdo.Descricao);
            paramsToSP[3] = new SqlParameter("@aplicacao", tdo.Aplicacao);

            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_update_tiposDocumentos", paramsToSP);

            return true;
        }

        public bool ExcluirDA(TiposDocumentos tdo)
        {
            SqlParameter[] paramsToSP = new SqlParameter[1];

            paramsToSP[0] = new SqlParameter("@id", tdo.Id);

            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_delete_tiposDocumentos", paramsToSP);

            return true;
        }

        public List<TiposDocumentos> PesquisarDA()
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, string.Format(@"SELECT * FROM TIPOSDOCUMENTOS "));

            List<TiposDocumentos> tiposDocumentos = CarregarObjTiposDocumentos(dr);
                        
            return tiposDocumentos;

        }

        public List<TiposDocumentos> PesquisarDA(int id_tdo)
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                       CommandType.Text, string.Format(@"SELECT * " +
                                                                                       " FROM TIPOSDOCUMENTOS WHERE ID = {0}", id_tdo));

            List<TiposDocumentos> tiposDocumentos = CarregarObjTiposDocumentos(dr);

            return tiposDocumentos;
        }

        public List<TiposDocumentos> PesquisarDA(string campo, string valor)
        {
            string consulta;

            switch (campo.ToUpper())
            {
                case "CODIGO":
                    consulta = string.Format("SELECT * FROM TIPOSDOCUMENTOS WHERE  CODIGO = {0}", utils.ComparaIntComZero(valor));
                    break;
                case "DESCRICAO":
                    consulta = string.Format("SELECT * FROM TIPOSDOCUMENTOS WHERE DESCRICAO LIKE '%{0}%'", valor);
                    break;
                default:
                    consulta = "";
                    break;
            }

            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, consulta);

            List<TiposDocumentos> tiposDoc = CarregarObjTiposDocumentos(dr);

            return tiposDoc;
        }

        public List<TiposDocumentos> PesquisarBuscaDA(string valor)
        {
            StringBuilder consulta = new StringBuilder(@"SELECT * FROM TIPOSDOCUMENTOS ");

            if (valor != "" && valor != null)
                consulta.Append(string.Format(" WHERE CODIGO = {0} OR  DESCRICAO  LIKE '%{1}%'", utils.ComparaIntComZero(valor), valor));

            consulta.Append(" ORDER BY CODIGO ");

            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, consulta.ToString());

            List<TiposDocumentos> tipoDoc = CarregarObjTiposDocumentos(dr);

            return tipoDoc;
        }

        public override List<Base> Pesquisar(string descricao)
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                      CommandType.Text, string.Format(@"SELECT * " +
                                                                                       " FROM TIPOSDOCUMENTOS WHERE CODIGO = '{0}' OR DESCRICAO LIKE '%{0}%'",utils.ComparaIntComZero(descricao), descricao));
            
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
