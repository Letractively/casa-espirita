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
        #endregion
        public bool InserirDA(TiposDeAutores instancia)
        {
            SqlParameter[] paramsToSP = new SqlParameter[2];

            paramsToSP[0] = new SqlParameter("@codigo", instancia.Codigo);
            paramsToSP[1] = new SqlParameter("@descricao", instancia.Descricao);

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
            paramsToSP[2] = new SqlParameter("@descricao", instancia.Descricao);

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

        public override List<Base> Pesquisar(string descricao, string tipo)
        {
            SqlDataReader dr;

            if (tipo == "C")
            {
                int codigo = 0;
                Int32.TryParse(descricao, out codigo);

                dr = SqlHelper.ExecuteReader(
                    ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                    CommandType.Text, string.Format(@"SELECT * FROM TIPOSDEAUTORES WHERE CODIGO = '{0}'", codigo));
            }
            else
            {
                dr = SqlHelper.ExecuteReader(
                    ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                    CommandType.Text, string.Format(@"SELECT * FROM TIPOSDEAUTORES WHERE DESCRICAO LIKE '%{0}%'", descricao));
            }

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
