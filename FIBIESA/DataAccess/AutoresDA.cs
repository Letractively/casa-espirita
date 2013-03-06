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
    public class AutoresDA : BaseDA
    {
        Utils utils = new Utils();

        #region funcoes
        private List<Autores> CarregarObjAutores(SqlDataReader dr)
        {
            List<Autores> autor = new List<Autores>();

            while (dr.Read())
            {
                Autores aut = new Autores();
                aut.Id = int.Parse(dr["ID"].ToString());
                aut.Codigo = int.Parse(dr["CODIGO"].ToString());
                aut.Descricao = dr["DESCRICAO"].ToString();
                aut.TipoId = int.Parse(dr["TIPOID"].ToString());

                autor.Add(aut);
            }

            return autor;
        }
        #endregion

        public bool InserirDA(Autores instancia)
        {
            SqlParameter[] paramsToSP = new SqlParameter[3];

            paramsToSP[0] = new SqlParameter("@codigo", instancia.Codigo);
            paramsToSP[1] = new SqlParameter("@descricao", instancia.Descricao);
            paramsToSP[2] = new SqlParameter("@tipoId", instancia.TipoId);

            int i = SqlHelper.ExecuteNonQuery(
                ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                CommandType.StoredProcedure, "stp_insert_autores", paramsToSP);
            return (i > 0); 
        }

        public bool EditarDA(Autores instancia)
        {
            SqlParameter[] paramsToSP = new SqlParameter[4];

            paramsToSP[0] = new SqlParameter("@id", instancia.Id);
            paramsToSP[1] = new SqlParameter("@codigo", instancia.Codigo);
            paramsToSP[2] = new SqlParameter("@descricao", instancia.Descricao);
            paramsToSP[3] = new SqlParameter("@tipoId", instancia.TipoId);

            return (SqlHelper.ExecuteNonQuery(
                ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                CommandType.StoredProcedure, "stp_update_autores", paramsToSP) > 0);
        }

        public bool ExcluirDA(Autores instancia)
        {
            SqlParameter[] paramsToSP = new SqlParameter[1];

            paramsToSP[0] = new SqlParameter("@id", instancia.Id);

            return (SqlHelper.ExecuteNonQuery(
                ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                CommandType.StoredProcedure, "stp_delete_Autores", paramsToSP) > 0);
        }

        public List<Autores> PesquisarDA()
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(
                ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                CommandType.Text, string.Format(@"SELECT * FROM AUTORES "));
            return CarregarObjAutores(dr);
        }

        public List<Autores> PesquisarDA(int id)
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(
                ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                CommandType.Text, string.Format(@"SELECT * FROM AUTORES  WHERE ID = {0}", id));
            return CarregarObjAutores(dr);
        }

        public List<Autores> PesquisarDA(string campo, string valor)
        {
            StringBuilder consulta = new StringBuilder("SELECT * FROM AUTORES ");

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

            return CarregarObjAutores(dr);
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
                    CommandType.Text, string.Format(@"SELECT * FROM AUTORES WHERE CODIGO = '{0}'", codigo));
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
