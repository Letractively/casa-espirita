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
    public class ContasDA : BaseDA
    {
        Utils utils = new Utils();

        #region funcoes
        private List<Contas> CarregarObjContas(SqlDataReader dr)
        {
            List<Contas> Contas = new List<Contas>();
            AgenciasDA ageDA = new AgenciasDA();
           
            while (dr.Read())
            {
                Contas con = new Contas();
                con.Id = int.Parse(dr["ID"].ToString());
                con.Codigo = int.Parse(dr["CODIGO"].ToString());
                con.Descricao = dr["DESCRICAO"].ToString();
                con.AgenciaId = utils.ComparaIntComNull(dr["AGENCIAID"].ToString());
                con.Titular = dr["TITULAR"].ToString();
                con.Digito = dr["DIGITO"].ToString();

                int id = 0;

                if(con.AgenciaId != null)
                {
                    id = Convert.ToInt32(con.AgenciaId);
                    List<Agencias> agencias = ageDA.PesquisarDA(id);
                    Agencias age = new Agencias();

                    foreach (Agencias ltAge in agencias)
                    {
                        age.Codigo = ltAge.Codigo;
                        age.Descricao = ltAge.Descricao;
                        age.Id = ltAge.Id;
                    }

                    con.Agencia = age;
                }

                Contas.Add(con);
            }

            return Contas;
        }
        
        private Int32 RetornaMaxCodigo()
        {
            Int32 codigo = 1;
            DataSet ds = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                          CommandType.Text, string.Format(@" SELECT ISNULL(MAX(CODIGO),0) + 1 as COD FROM CONTAS "));

            if (ds.Tables[0].Rows.Count != 0)
                codigo = utils.ComparaIntComZero(ds.Tables[0].Rows[0]["COD"].ToString());

            return codigo;
        }

        #endregion
        public bool InserirDA(Contas con)
        {
            SqlParameter[] paramsToSP = new SqlParameter[5];

            paramsToSP[0] = new SqlParameter("@codigo", RetornaMaxCodigo());
            paramsToSP[1] = new SqlParameter("@descricao", con.Descricao);
            paramsToSP[2] = new SqlParameter("@digito", con.Digito);
            paramsToSP[3] = new SqlParameter("@agenciaid", con.AgenciaId);
            paramsToSP[4] = new SqlParameter("@titular", con.Titular);

            try
            {
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_insert_contas", paramsToSP);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool EditarDA(Contas con)
        {
            SqlParameter[] paramsToSP = new SqlParameter[6];

            paramsToSP[0] = new SqlParameter("@id", con.Id);
            paramsToSP[1] = new SqlParameter("@codigo", con.Codigo);
            paramsToSP[2] = new SqlParameter("@descricao", con.Descricao);
            paramsToSP[3] = new SqlParameter("@digito", con.Digito);
            paramsToSP[4] = new SqlParameter("@agenciaid", con.AgenciaId);
            paramsToSP[5] = new SqlParameter("@titular", con.Titular);

            try
            {
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_update_contas", paramsToSP);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public bool ExcluirDA(Contas con)
        {
            SqlParameter[] paramsToSP = new SqlParameter[1];

            paramsToSP[0] = new SqlParameter("@id", con.Id);

            try
            {
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_delete_Contas", paramsToSP);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<Contas> PesquisarDA()
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, string.Format(@"SELECT * FROM CONTAS "));

            List<Contas> Contas = CarregarObjContas(dr);
                       
            return Contas;

        }

        public List<Contas> PesquisarDA(int id_con)
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                       CommandType.Text, string.Format(@"SELECT * " +
                                                                                       " FROM CONTAS WHERE ID = {0}", id_con));

            List<Contas> Contas = CarregarObjContas(dr);
                      
            return Contas;
        }
                
        public List<Contas> PesquisarBuscaDA(string valor)
        {
            StringBuilder consulta = new StringBuilder(@"SELECT * FROM CONTAS ");

            if (valor != "" && valor != null)
                consulta.Append(string.Format(" WHERE CODIGO = {0} OR  DESCRICAO  LIKE '%{1}%'", utils.ComparaIntComZero(valor), valor));

            consulta.Append(" ORDER BY CODIGO ");

            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, consulta.ToString());

            List<Contas> contas = CarregarObjContas(dr);

            return contas;
        }

        public override List<Base> Pesquisar(string descricao)
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                      CommandType.Text, string.Format(@"SELECT * " +
                                                                                       " FROM CONTAS WHERE CODIGO = '{0}' OR DESCRICAO LIKE '%{1}%'",utils.ComparaIntComZero(descricao),  descricao));
            
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
