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
        #endregion

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

        public List<Cidades> PesquisaDA(string campo, string valor)
        {
            string consulta;

            switch (campo.ToUpper())
            {
                case "CODIGO":
                    consulta = string.Format("SELECT * FROM CIDADES WHERE CODIGO = {0}", utils.ComparaIntComZero(valor));
                    break;
                case "DESCRICAO":
                    consulta = string.Format("SELECT * FROM CIDADES WHERE DESCRICAO  LIKE '%{0}%'", valor);
                    break;
                default:
                    consulta = "";
                    break;
            }

            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, consulta);

            List<Cidades> cidades = CarregarObjCidade(dr);

            return cidades;

        }

        public override List<Base> Pesquisar(string descricao, string tipo)
        {
            SqlDataReader dr;
            int codigo;

            if (tipo == "C")
            {
                Int32.TryParse(descricao, out codigo);
                dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                       CommandType.Text, string.Format(@"SELECT * " +
                                                                                       " FROM CIDADES WHERE CODIGO = '{0}'", codigo));
            }
            else
            {
                dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                      CommandType.Text, string.Format(@"SELECT * " +
                                                                                       " FROM CIDADES WHERE DESCRICAO LIKE '%{0}%'", descricao));
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
