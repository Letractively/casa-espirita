using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FG;
using DataObjects;
using System.Data.SqlClient;
using InfrastructureSqlServer.Helpers;
using System.Configuration;
using System.Data;

namespace DataAccess
{
    public class BancosInstrucoesDA : BaseDA
    {
        Utils utils = new Utils();

        #region funcoes
        private List<BancosInstrucoes> CarregarObjBancoInstrucoes(SqlDataReader dr)
        {
            List<BancosInstrucoes> bancosInstrucoes = new List<BancosInstrucoes>();
            BancosDA banDA = new BancosDA();
            Int32 id;

            while (dr.Read())
            {
                BancosInstrucoes banInst = new BancosInstrucoes();
                banInst.Id = int.Parse(dr["ID"].ToString());
                banInst.Codigo = int.Parse(dr["CODIGO"].ToString());
                banInst.Descricao = dr["DESCRICAO"].ToString();
                banInst.Nrdias = Boolean.Parse(dr["NRDIAS"].ToString());
                banInst.Bancoid = int.Parse(dr["BANCOID"].ToString());

                if (banInst.Bancoid > 0)
                {
                    id = Convert.ToInt32(banInst.Bancoid);
                    List<Bancos> bancos = banDA.PesquisarDA(id);
                    Bancos ban = new Bancos();
                    foreach (Bancos ltBan in bancos)
                    {
                        ban.Codigo = ltBan.Codigo;
                        ban.Descricao = ltBan.Descricao;
                    }

                    banInst.Bancos = ban;
                }

                bancosInstrucoes.Add(banInst);
            }

            return bancosInstrucoes;
        }

        #endregion

        public bool InserirDA(BancosInstrucoes ban)
        {
            SqlParameter[] paramsToSP = new SqlParameter[4];

            paramsToSP[0] = new SqlParameter("@codigo", ban.Codigo);
            paramsToSP[1] = new SqlParameter("@descricao", ban.Descricao.ToUpper());
            paramsToSP[2] = new SqlParameter("@nrdias", ban.Nrdias);
            paramsToSP[3] = new SqlParameter("@bancoid", ban.Bancoid);


            try
            {
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_insert_bancosInstrucoes", paramsToSP);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool EditarDA(BancosInstrucoes ban)
        {
            SqlParameter[] paramsToSP = new SqlParameter[5];

            paramsToSP[0] = new SqlParameter("@id", ban.Id);
            paramsToSP[1] = new SqlParameter("@codigo", ban.Codigo);
            paramsToSP[2] = new SqlParameter("@descricao", ban.Descricao.ToUpper());
            paramsToSP[3] = new SqlParameter("@nrdias", ban.Nrdias);
            paramsToSP[4] = new SqlParameter("@bancoid", ban.Bancoid);

            try
            {
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_update_bancosInstrucoes", paramsToSP);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool ExcluirDA(BancosInstrucoes ban)
        {
            SqlParameter[] paramsToSP = new SqlParameter[1];

            paramsToSP[0] = new SqlParameter("@id", ban.Id);

            try
            {
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_delete_bancosInstrucoes", paramsToSP);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<BancosInstrucoes> PesquisarDA()
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, string.Format(@"SELECT * FROM BANCOSINSTRUCOES ORDER BY CODIGO "));

            List<BancosInstrucoes> bancos = CarregarObjBancoInstrucoes(dr);

            return bancos;

        }

        public List<BancosInstrucoes> PesquisarDA(int id_ban)
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                       CommandType.Text, string.Format(@"SELECT * " +
                                                                                       " FROM BANCOSINSTRUCOES WHERE ID = {0}", id_ban));

            List<BancosInstrucoes> bancos = CarregarObjBancoInstrucoes(dr);

            return bancos;
        }

        public List<BancosInstrucoes> PesquisarBuscaDA(string valor)
        {
            StringBuilder consulta = new StringBuilder(@"SELECT * FROM BANCOSINSTRUCOES ");

            if (valor != "" && valor != null)
                consulta.Append(string.Format(" WHERE CODIGO = {0} OR  DESCRICAO  LIKE '%{1}%'", utils.ComparaIntComZero(valor), valor));

            consulta.Append(" ORDER BY CODIGO ");

            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, consulta.ToString());

            List<BancosInstrucoes> bancos = CarregarObjBancoInstrucoes(dr);

            return bancos;
        }

    }
}
