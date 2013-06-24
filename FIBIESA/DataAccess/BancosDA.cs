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
                ban.Codigo = dr["CODIGO"].ToString();
                ban.Descricao = dr["DESCRICAO"].ToString();

                bancos.Add(ban);
            }

            return bancos;
        }
                
        #endregion

        public bool InserirDA(Bancos ban)
        {
            SqlParameter[] paramsToSP = new SqlParameter[2];

            paramsToSP[0] = new SqlParameter("@codigo", ban.Codigo.ToUpper());
            paramsToSP[1] = new SqlParameter("@descricao", ban.Descricao.ToUpper());

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
            paramsToSP[1] = new SqlParameter("@codigo", ban.Codigo.ToUpper());
            paramsToSP[2] = new SqlParameter("@descricao", ban.Descricao.ToUpper());

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

        public List<Bancos> PesquisarBuscaDA(string valor)
        {
            StringBuilder consulta = new StringBuilder(@"SELECT * FROM BANCOS ");

            if (valor != "" && valor != null)
                consulta.Append(string.Format(" WHERE CODIGO = {0} OR  DESCRICAO  LIKE '%{1}%'", utils.ComparaIntComZero(valor), valor));

            consulta.Append(" ORDER BY CODIGO ");

            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, consulta.ToString());

            List<Bancos> bancos = CarregarObjBanco(dr);

            return bancos;
        }

        public override List<Base> Pesquisar(string descricao)
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                      CommandType.Text, string.Format(@"SELECT * " +
                                                                                       " FROM BANCOS WHERE CODIGO = '{0}' OR DESCRICAO LIKE '%{1}%'",utils.ComparaIntComZero(descricao), descricao));
            
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

        public bool CodigoJaUtilizadoDA(Int32 codigo)
        {
            DataSet dsInst = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                       CommandType.Text, string.Format(@"SELECT 1 COD " +
                                                                                        "  FROM BANCOS " +
                                                                                        " WHERE CODIGO = {0} ", codigo));
            int cod = 0;

            if (dsInst.Tables[0].Rows.Count != 0)
                cod = (int)dsInst.Tables[0].Rows[0]["COD"];

            if (cod == 1)
                return true;
            else
                return false;

        }
    }
}
