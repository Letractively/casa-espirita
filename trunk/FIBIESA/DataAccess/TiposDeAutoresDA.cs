using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using System.Data.SqlClient;
using FG;
using InfrastructureSqlServer.Helpers;
using System.Configuration;
using System.Data;

namespace DataAccess
{
    public class TiposDeAutoresDA : BaseDA
    {
        Utils utils = new Utils();
        #region funcoes
        private List<TiposDeAutores> CarregarObjTiposAu(SqlDataReader dr)
        {
            List<TiposDeAutores> tipoAutor = new List<TiposDeAutores>();

            while (dr.Read())
            {
                TiposDeAutores tipo = new TiposDeAutores();
                tipo.Id = int.Parse(dr["ID"].ToString());
                tipo.Codigo = int.Parse(dr["CODIGO"].ToString());
                tipo.Descricao = dr["DESCRICAO"].ToString();

                tipoAutor.Add(tipo);
            }

            return tipoAutor;
        }

        private Int32 RetornaMaxCodigo()
        {
            Int32 codigo = 1;
            DataSet ds = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                          CommandType.Text, string.Format(@" SELECT ISNULL(MAX(CODIGO),0) + 1 as COD FROM TIPOSDEAUTORES "));

            if (ds.Tables[0].Rows.Count != 0)
                codigo = utils.ComparaIntComZero(ds.Tables[0].Rows[0]["COD"].ToString());

            return codigo;
        }

        #endregion
        public bool InserirDA(TiposDeAutores instancia)
        {
            SqlParameter[] paramsToSP = new SqlParameter[2];

            paramsToSP[0] = new SqlParameter("@codigo", RetornaMaxCodigo());
            paramsToSP[1] = new SqlParameter("@descricao", instancia.Descricao.ToUpper());

            try
            {
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                            CommandType.StoredProcedure, "stp_insert_tiposdeAutores", paramsToSP);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool EditarDA(TiposDeAutores instancia)
        {
            SqlParameter[] paramsToSP = new SqlParameter[3];

            paramsToSP[0] = new SqlParameter("@id", instancia.Id);
            paramsToSP[1] = new SqlParameter("@codigo", instancia.Codigo);
            paramsToSP[2] = new SqlParameter("@descricao", instancia.Descricao.ToUpper());

            try
            {
                SqlHelper.ExecuteNonQuery(
                    ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                    CommandType.StoredProcedure, "stp_update_tiposdeAutores", paramsToSP);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool ExcluirDA(TiposDeAutores instancia)
        {
            SqlParameter[] paramsToSP = new SqlParameter[1];

            paramsToSP[0] = new SqlParameter("@id", instancia.Id);

            try
            {
                SqlHelper.ExecuteNonQuery(
                    ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                    CommandType.StoredProcedure, "stp_delete_tiposdeAutores", paramsToSP);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<TiposDeAutores> PesquisarDA()
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(
                ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                CommandType.Text, string.Format(@"SELECT * FROM TIPOSDEAUTORES "));
            return CarregarObjTiposAu(dr);
        }

        public List<TiposDeAutores> PesquisarDA(int id)
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(
                ConfigurationManager.ConnectionStrings["conexao"].ToString(), 
                CommandType.Text, string.Format(@"SELECT * FROM TIPOSDEAUTORES  WHERE ID = {0}", id));
            return CarregarObjTiposAu(dr);
        }

        public List<TiposDeAutores> PesquisarDA(string campo, string valor)
        {
            StringBuilder consulta = new StringBuilder("SELECT * FROM TIPOSDEAUTORES ORDER BY CODIGO ");

            switch (campo.ToUpper())
            {
                case "CODIGO":
                    consulta.Append(string.Format("WHERE CODIGO = {0}", utils.ComparaIntComZero(valor)));
                    break;
                case "DESCRICAO":
                    consulta.Append(string.Format("WHERE DESCRICAO  LIKE '%{0}%'", valor));
                    break;
                default:
                    break;
            }

            SqlDataReader dr = SqlHelper.ExecuteReader(
                ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                CommandType.Text, consulta.ToString());

            return CarregarObjTiposAu(dr);
        }

        public List<TiposDeAutores> PesquisarBuscaDA(string valor)
        {
            StringBuilder consulta = new StringBuilder(@"SELECT * FROM TIPOSDEAUTORES ");

            if (valor != "" && valor != null)
                consulta.Append(string.Format(" WHERE CODIGO = {0} OR  DESCRICAO  LIKE '%{1}%'", utils.ComparaIntComZero(valor), valor));

            consulta.Append(" ORDER BY CODIGO ");

            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, consulta.ToString());

            List<TiposDeAutores> tipoAutor = CarregarObjTiposAu(dr);

            return tipoAutor;
        }

        public override List<Base> Pesquisar(string descricao)
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(
                    ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                    CommandType.Text, string.Format(@"SELECT * FROM TIPOSDEAUTORES WHERE CODIGO = '{0}' OR DESCRICAO LIKE '%{0}%'",utils.ComparaIntComZero(descricao), descricao));
            
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
