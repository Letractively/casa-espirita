using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataObjects;
using InfrastructureSqlServer.Helpers;
using System.Configuration;
using FG;

namespace DataAccess
{
    public class InstituicoesDA : BaseDA
    {
        Utils utils = new Utils();

        #region funcoes
        private List<Instituicoes> CarregarObjInstituicoes(SqlDataReader dr)
        {
            List<Instituicoes> instituicoes = new List<Instituicoes>();

            while (dr.Read())
            {
                Instituicoes ins = new Instituicoes();
                ins.Id = int.Parse(dr["ID"].ToString());
                ins.Codigo = int.Parse(dr["CODIGO"].ToString());
                ins.Razao = dr["RAZAO"].ToString();
                ins.NomeFantasia = dr["NOMEFANTASIA"].ToString();
                ins.Email = dr["EMAIL"].ToString();
                ins.Cnpj = dr["CNPJ"].ToString();
                ins.CidadeId = utils.ComparaIntComNull(dr["CIDADEID"].ToString());
                ins.Cep = dr["CEP"].ToString();
                ins.BairroId = utils.ComparaIntComNull(dr["BAIRROID"].ToString());
                ins.Endereco = dr["ENDERECO"].ToString();
                ins.Numero = dr["NUMERO"].ToString();
                ins.Complemento = dr["COMPLEMENTO"].ToString();
                ins.DDD = dr["DDD"].ToString();
                ins.telefone = dr["telefone"].ToString();
                ins.Ranking = utils.ComparaIntComZero(dr["ranking"].ToString());

                CidadesDA cidDA = new CidadesDA();
                Cidades cid = new Cidades();
                DataSet dsCid = cidDA.PesquisaDA(ins.CidadeId != null ? Convert.ToInt32(ins.CidadeId.ToString()) : 0);

                if (dsCid.Tables[0].Rows.Count != 0)
                {
                    cid.Id = (Int32)dsCid.Tables[0].Rows[0]["id"];
                    cid.Codigo = (Int32)dsCid.Tables[0].Rows[0]["codigo"];
                    cid.Descricao = (string)dsCid.Tables[0].Rows[0]["descricao"];
                    cid.EstadoId = (Int32)dsCid.Tables[0].Rows[0]["estadoid"];
                }

                ins.Cidades = cid;
                
                InstituicoesLogoDA insLDA = new InstituicoesLogoDA();

                List<InstituicoesLogo> instituicoesLogo = insLDA.PesquisarDA(ins.Id);
                InstituicoesLogo insL = new InstituicoesLogo();

                foreach (InstituicoesLogo ltInsL in instituicoesLogo)
                {
                    insL.Id = ltInsL.Id;
                    insL.InstituicoesId = ltInsL.InstituicoesId;
                    insL.Imagem = ltInsL.Imagem;

                    ins.InstituicaoLogo = insL;
                }
                                
                instituicoes.Add(ins);
            }
            return instituicoes;
        }
        #endregion

        public Int32 InserirDA(Instituicoes ins)
        {
            SqlParameter[] paramsToSP = new SqlParameter[14];

            paramsToSP[0] = new SqlParameter("@codigo", ins.Codigo);
            paramsToSP[1] = new SqlParameter("@razao", ins.Razao);
            paramsToSP[2] = new SqlParameter("@nomefantasia", ins.NomeFantasia);
            paramsToSP[3] = new SqlParameter("@email", ins.Email);
            paramsToSP[4] = new SqlParameter("@cnpj", ins.Cnpj);
            paramsToSP[5] = new SqlParameter("@cidadeid", ins.CidadeId);
            paramsToSP[6] = new SqlParameter("@cep", ins.Cep);
            paramsToSP[7] = new SqlParameter("@bairroid", ins.BairroId);
            paramsToSP[8] = new SqlParameter("@endereco", ins.Endereco);
            paramsToSP[9] = new SqlParameter("@numero", ins.Numero);
            paramsToSP[10] = new SqlParameter("@complemento", ins.Complemento);
            paramsToSP[11] = new SqlParameter("@DDD", ins.DDD);
            paramsToSP[12] = new SqlParameter("@telefone", ins.telefone);
            paramsToSP[13] = new SqlParameter("@ranking", ins.Ranking);

            try
            {                
                DataSet ds = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_INSERT_instituicoes", paramsToSP);

                DataTable tabela = ds.Tables[0];

                int id = utils.ComparaIntComZero(tabela.Rows[0]["ID"].ToString());

                return id;
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public bool EditarDA(Instituicoes ins)
        {
            SqlParameter[] paramsToSP = new SqlParameter[15];

            paramsToSP[0] = new SqlParameter("@id", ins.Id);
            paramsToSP[1] = new SqlParameter("@codigo", ins.Codigo);
            paramsToSP[2] = new SqlParameter("@razao", ins.Razao);
            paramsToSP[3] = new SqlParameter("@nomeFantasia", ins.NomeFantasia);
            paramsToSP[4] = new SqlParameter("@email", ins.Email);
            paramsToSP[5] = new SqlParameter("@cnpj", ins.Cnpj);
            paramsToSP[6] = new SqlParameter("@cidadeid", ins.CidadeId);
            paramsToSP[7] = new SqlParameter("@cep", ins.Cep);
            paramsToSP[8] = new SqlParameter("@bairroid", ins.BairroId);
            paramsToSP[9] = new SqlParameter("@endereco", ins.Endereco);
            paramsToSP[10] = new SqlParameter("@numero", ins.Numero);
            paramsToSP[11] = new SqlParameter("@complemento", ins.Complemento);
            paramsToSP[12] = new SqlParameter("@DDD", ins.DDD);
            paramsToSP[13] = new SqlParameter("@telefone", ins.telefone);
            paramsToSP[14] = new SqlParameter("@ranking", ins.Ranking);

            try
            {
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_UPDATE_instituicoes", paramsToSP);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool ExcluirDA(Instituicoes ins)
        {
            SqlParameter[] paramsToSP = new SqlParameter[1];

            paramsToSP[0] = new SqlParameter("@id", ins.Id);

            try
            {
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_delete_instituicoes", paramsToSP);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public List<Instituicoes> PesquisarDA(bool instPrincipal)
        {
            StringBuilder v_consulta = new StringBuilder();

            v_consulta.Append(@"SELECT * FROM INSTITUICOES ");

            if (instPrincipal)
                v_consulta.Append(@" WHERE RANKING = (SELECT MIN(RANKING) FROM INSTITUICOES)");

            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, v_consulta.ToString());

            List<Instituicoes> instituicoes = CarregarObjInstituicoes(dr);

            return instituicoes;
        }
               
        public List<Instituicoes> PesquisarDA(string campo, string valor)
        {
            string consulta;

            switch (campo.ToUpper())
            {
                case "CODIGO":
                    consulta = string.Format("SELECT * FROM INSTITUICOES WHERE CODIGO = {0}", utils.ComparaIntComZero(valor));
                    break;
                case "RAZAO":
                    consulta = string.Format("SELECT * FROM INSTITUICOES WHERE RAZAO  LIKE '%{0}%'", valor);
                    break;
                default:
                    consulta = "";
                    break;
            }

            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, consulta);

            List<Instituicoes> instituicoes = CarregarObjInstituicoes(dr);

            return instituicoes;
        }

        public List<Instituicoes> PesquisarDA(int id_ins)
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                       CommandType.Text, string.Format(@"SELECT * " +
                                                                                       " FROM INSTITUICOES WHERE ID = {0}", id_ins));

            List<Instituicoes> instituicoes = CarregarObjInstituicoes(dr);

            return instituicoes;
        }

        public DataSet PesquisarDsDA()
        {
            DataSet instituicoes = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                       CommandType.Text, string.Format(@"SELECT [id] " +
                                                                                        "      ,[codigo] " +
                                                                                        "      ,[razao] " +
                                                                                        "      ,[nomefantasia] " +
                                                                                        "      ,[email] " +
                                                                                        "      ,[cnpj] " +
                                                                                        "      ,[cidadeid] " +
                                                                                        "      ,[cep] " +
                                                                                        "      ,[bairroid] " +
                                                                                        "      ,[endereco] " +
                                                                                        "      ,[numero] " +
                                                                                        "      ,[complemento] " +
                                                                                        "      ,[DDD] " +
                                                                                        "      ,[telefone] " +
                                                                                        "  FROM [dbo].[Instituicoes]"));

            
            return instituicoes;
        }

        public List<Instituicoes> PesquisarBuscaDA(string valor)
        {
            StringBuilder consulta = new StringBuilder(@"SELECT * FROM INSTITUICOES ");

            if (valor != "")
                consulta.Append(string.Format(" WHERE CODIGO = {0} OR  RAZAO  LIKE '%{1}%'", utils.ComparaIntComZero(valor), valor));

            consulta.Append(" ORDER BY CODIGO ");

            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, consulta.ToString());

            List<Instituicoes> instituicoes = CarregarObjInstituicoes(dr);

            return instituicoes;
        }

        public bool CodigoJaUtilizadoDA(Int32 codigo)
        {
            DataSet dsInst = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                       CommandType.Text, string.Format(@"SELECT 1 COD "+                                                                                        
                                                                                        "  FROM INSTITUICOES " +
                                                                                        " WHERE CODIGO = {0} ",codigo));
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
