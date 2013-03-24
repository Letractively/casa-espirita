using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using FG;
using System.Data.SqlClient;
using InfrastructureSqlServer.Helpers;
using System.Configuration;
using System.Data;

namespace DataAccess
{
    public class TiposObrasDA : BaseDA
    {
        Utils utils = new Utils();
        #region funcoes
        private List<TiposObras> CarregarObjTiposObra(SqlDataReader dr)
        {
            List<TiposObras> tipoObra = new List<TiposObras>();

            while (dr.Read())
            {
                TiposObras tipo = new TiposObras();
                tipo.Id = int.Parse(dr["ID"].ToString());
                tipo.Codigo = int.Parse(dr["CODIGO"].ToString());
                tipo.Descricao = dr["DESCRICAO"].ToString();
                tipo.QtdDias = int.Parse(dr["QTDDIAS"].ToString());

                tipoObra.Add(tipo);
            }

            return tipoObra;
        }
        #endregion

        public bool InserirDA(TiposObras instancia)
        {
            SqlParameter[] paramsToSP = new SqlParameter[3];

            paramsToSP[0] = new SqlParameter("@codigo", instancia.Codigo);
            paramsToSP[1] = new SqlParameter("@descricao", instancia.Descricao);
            paramsToSP[2] = new SqlParameter("@qtdDias", instancia.QtdDias);

            try
            {
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_insert_tiposObras", paramsToSP);
                
                return true;
            }
            catch (Exception e)
            {
                return false;
            }


        }

        public bool EditarDA(TiposObras instancia)
        {
            SqlParameter[] paramsToSP = new SqlParameter[4];

            paramsToSP[0] = new SqlParameter("@id", instancia.Id);
            paramsToSP[1] = new SqlParameter("@codigo", instancia.Codigo);
            paramsToSP[2] = new SqlParameter("@descricao", instancia.Descricao);
            paramsToSP[3] = new SqlParameter("@qtdDias", instancia.QtdDias);

            try
            {
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(),CommandType.StoredProcedure, "stp_update_tiposObras", paramsToSP);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool ExcluirDA(TiposObras instancia)
        {
            SqlParameter[] paramsToSP = new SqlParameter[1];

            paramsToSP[0] = new SqlParameter("@id", instancia.Id);

            try
            {
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_delete_tiposObras", paramsToSP);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<TiposObras> PesquisarDA()
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(
                ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                CommandType.Text, string.Format(@"SELECT * FROM TIPOSOBRAS ORDER BY CODIGO ")); 
            return CarregarObjTiposObra(dr);
        }

        public List<TiposObras> PesquisarDA(int id)
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(
                ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                CommandType.Text, string.Format(@"SELECT * FROM TIPOSOBRAS  WHERE ID = {0}", id));
            return CarregarObjTiposObra(dr);
        }

        public List<TiposObras> PesquisarDA(string campo, string valor)
        {
            StringBuilder consulta = new StringBuilder("SELECT * FROM TIPOSOBRAS ");

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

            return CarregarObjTiposObra(dr);
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
                    CommandType.Text, string.Format(@"SELECT * FROM TIPOSOBRAS WHERE CODIGO = '{0}'", codigo));
            }
            else
            {
                dr = SqlHelper.ExecuteReader(
                    ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                    CommandType.Text, string.Format(@"SELECT * FROM TIPOSOBRAS WHERE DESCRICAO LIKE '%{0}%'", descricao));
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
