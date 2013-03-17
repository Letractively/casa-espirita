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
    public class AgenciasDA : BaseDA
    {
        Utils utils = new Utils();
        #region funcoes
        private List<Agencias> CarregarObjAgencias(SqlDataReader dr)
        {
            List<Agencias> agencias = new List<Agencias>();
            CidadesDA cidDA = new CidadesDA();
            BairrosDA baiDA = new BairrosDA();
            BancosDA banDA = new BancosDA();

            while (dr.Read())
            {
                Agencias age = new Agencias();
                age.Id = int.Parse(dr["ID"].ToString());
                age.Codigo = int.Parse(dr["CODIGO"].ToString());
                age.Descricao = dr["DESCRICAO"].ToString();
                age.BairroId = utils.ComparaIntComNull(dr["BAIRROID"].ToString());
                age.Cep = dr["CEP"].ToString();
                age.Endereco = dr["ENDERECO"].ToString();
                age.Complemento = dr["COMPLEMENTO"].ToString();
                age.Ranking = utils.ComparaIntComZero(dr["RANKING"].ToString());
                age.CidadeId = utils.ComparaIntComNull(dr["CIDADEID"].ToString());
                age.BancoId = utils.ComparaIntComZero(dr["BANCOID"].ToString());

                int id = 0;
                DataSet dsCid = cidDA.PesquisaDA(age.CidadeId != null ? utils.ComparaIntComZero(age.CidadeId.ToString()) : 0);

                if (dsCid.Tables[0].Rows.Count != 0)
                {
                    Cidades cid = new Cidades();

                    cid.Id = (Int32)dsCid.Tables[0].Rows[0]["id"];
                    cid.Codigo = (Int32)dsCid.Tables[0].Rows[0]["codigo"];
                    cid.Descricao = (string)dsCid.Tables[0].Rows[0]["descricao"];

                    age.Cidade = cid;
                }

                if (age.BairroId != null)
                {
                    id = Convert.ToInt32(age.BairroId);
                    List<Bairros> bairros = baiDA.PesquisarDA(id);
                    Bairros bai = new Bairros();

                    foreach (Bairros ltBai in bairros)
                    {
                        bai.Codigo = ltBai.Codigo;
                        bai.Descricao = ltBai.Descricao;
                    }

                    age.Bairro = bai;
                }

                if (age.BancoId > 0)
                {
                    id = Convert.ToInt32(age.BancoId);
                    List<Bancos> bancos = banDA.PesquisarDA(id);
                    Bancos ban = new Bancos();
                    foreach (Bancos ltBan in bancos)
                    {
                        ban.Codigo = ltBan.Codigo;
                        ban.Descricao = ltBan.Descricao;
                    }

                    age.Banco = ban;
                }

                agencias.Add(age);
            }
            return agencias;
        }
        #endregion

        public bool InserirDA(Agencias age)
        {
            SqlParameter[] paramsToSP = new SqlParameter[9];

            paramsToSP[0] = new SqlParameter("@codigo", age.Codigo);
            paramsToSP[1] = new SqlParameter("@descricao", age.Descricao);
            paramsToSP[2] = new SqlParameter("@cep", age.Cep);
            paramsToSP[3] = new SqlParameter("@bairroid", age.BairroId);
            paramsToSP[4] = new SqlParameter("@endereco", age.Endereco);
            paramsToSP[5] = new SqlParameter("@complemento", age.Complemento);
            paramsToSP[6] = new SqlParameter("@cidadeid", age.CidadeId);
            paramsToSP[7] = new SqlParameter("@ranking", age.Ranking);
            paramsToSP[8] = new SqlParameter("@bancoid", age.BancoId);

            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_insert_agencias", paramsToSP);

            return true;
        }

        public bool EditarDA(Agencias age)
        {
            SqlParameter[] paramsToSP = new SqlParameter[10];

            paramsToSP[0] = new SqlParameter("@id", age.Id);
            paramsToSP[1] = new SqlParameter("@codigo", age.Codigo);
            paramsToSP[2] = new SqlParameter("@descricao", age.Descricao);
            paramsToSP[3] = new SqlParameter("@cep", age.Cep);
            paramsToSP[4] = new SqlParameter("@bairroid", age.BairroId);
            paramsToSP[5] = new SqlParameter("@endereco", age.Endereco);
            paramsToSP[6] = new SqlParameter("@complemento", age.Complemento);
            paramsToSP[7] = new SqlParameter("@cidadeid", age.CidadeId);
            paramsToSP[8] = new SqlParameter("@ranking", age.Ranking);
            paramsToSP[9] = new SqlParameter("@bancoid", age.BancoId);

            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_update_agencias", paramsToSP);

            return true;
        }

        public bool ExcluirDA(Agencias age)
        {
            SqlParameter[] paramsToSP = new SqlParameter[1];

            paramsToSP[0] = new SqlParameter("@id", age.Id);

            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_delete_agencias", paramsToSP);

            return true;
        }

        public List<Agencias> PesquisarDA()
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, string.Format(@"SELECT * FROM AGENCIAS ORDER BY CODIGO "));

            List<Agencias> agencias = CarregarObjAgencias(dr);

            return agencias;

        }

        public List<Agencias> PesquisarDA(int id_age)
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                       CommandType.Text, string.Format(@"SELECT * " +
                                                                                       " FROM AGENCIAS WHERE ID = {0}", id_age));

            List<Agencias> agencias = CarregarObjAgencias(dr);

            return agencias;
        }

        public List<Agencias> PesquisarDA(string campo, string valor)
        {
            string consulta;

            switch (campo.ToUpper())
            {
                case "CODIGO":
                    consulta = string.Format("SELECT * FROM AGENCIAS WHERE CODIGO = {0}", utils.ComparaIntComZero(valor));
                    break;
                case "DESCRICAO":
                    consulta = string.Format("SELECT * FROM AGENCIAS WHERE DESCRICAO  LIKE '%{0}%'", valor);
                    break;
                default:
                    consulta = "";
                    break;
            }

            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, consulta);

            List<Agencias> agencias = CarregarObjAgencias(dr);

            return agencias;
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
                                                                                       " FROM  WHERE CODIGO = '{0}'", codigo));
            }
            else
            {
                dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                      CommandType.Text, string.Format(@"SELECT * " +
                                                                                       " FROM AGENCIAS WHERE DESCRICAO LIKE '%{0}%'", descricao));
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
