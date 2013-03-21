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
    public class BancosDA : BaseDA
    {
        Utils utils = new Utils();

        #region funcoes
        private List<Bancos> CarregarObjBanco(SqlDataReader dr)
        {
            List<Bancos> bancos = new List<Bancos>();
            
            while (dr.Read())
            {
                Bancos ban = new Bancos();
                ban.Id = int.Parse(dr["ID"].ToString());
                ban.Codigo = int.Parse(dr["CODIGO"].ToString());
                ban.Descricao = dr["DESCRICAO"].ToString();

                bancos.Add(ban);
            }

            return bancos;
        }
        #endregion

        public bool InserirDA(Bancos ban)
        {
            SqlParameter[] paramsToSP = new SqlParameter[2];

            paramsToSP[0] = new SqlParameter("@codigo", ban.Codigo);
            paramsToSP[1] = new SqlParameter("@descricao", ban.Descricao);

            try
            {
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_insert_bancos", paramsToSP);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool EditarDA(Bancos ban)
        {
            SqlParameter[] paramsToSP = new SqlParameter[3];

            paramsToSP[0] = new SqlParameter("@id", ban.Id);
            paramsToSP[1] = new SqlParameter("@codigo", ban.Codigo);
            paramsToSP[2] = new SqlParameter("@descricao", ban.Descricao);

            try
            {
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_update_bancos", paramsToSP);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool ExcluirDA(Bancos ban)
        {
            SqlParameter[] paramsToSP = new SqlParameter[1];

            paramsToSP[0] = new SqlParameter("@id", ban.Id);

            try
            {
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_delete_bancos", paramsToSP);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<Bancos> PesquisarDA()
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, string.Format(@"SELECT * FROM BANCOS ORDER BY CODIGO "));

            List<Bancos> bancos = CarregarObjBanco(dr);
            
            return bancos;

        }

        public List<Bancos> PesquisarDA(int id_ban)
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                       CommandType.Text, string.Format(@"SELECT * " +
                                                                                       " FROM BANCOS WHERE ID = {0}", id_ban));

            List<Bancos> bancos = CarregarObjBanco(dr);
                   
            return bancos;
        }

        public List<Bancos> PesquisarDA(string campo, string valor)
        {
            string consulta;

            switch (campo.ToUpper())
            {
                case "CODIGO":
                    consulta = string.Format("SELECT * FROM BANCOS WHERE CODIGO = {0}", utils.ComparaIntComZero(valor));
                    break;
                case "DESCRICAO":
                    consulta = string.Format("SELECT * FROM BANCOS WHERE DESCRICAO  LIKE '%{0}%'", valor);
                    break;
                default:
                    consulta = "";
                    break;
            }

            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, consulta);

            List<Bancos> bancos = CarregarObjBanco(dr);

            return bancos;
        }

        public override List<Base> Pesquisar(string descricao, string tipo)
        {
            SqlDataReader dr;

            if (tipo == "C")
            {
                int codigo = 0;
                Int32.TryParse(descricao, out codigo);

                dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                       CommandType.Text, string.Format(@"SELECT * " +
                                                                                       " FROM BANCOS WHERE CODIGO = '{0}'", codigo));
            }
            else
            {
                dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                      CommandType.Text, string.Format(@"SELECT * " +
                                                                                       " FROM BANCOS WHERE DESCRICAO LIKE '%{0}%'", descricao));
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
