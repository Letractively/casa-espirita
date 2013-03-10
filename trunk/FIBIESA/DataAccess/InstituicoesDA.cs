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

        public bool InserirDA(Instituicoes ins)
        {
            SqlParameter[] paramsToSP = new SqlParameter[11];

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

            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_INSERT_instituicoes", paramsToSP);

            return true;
        }

        public bool EditarDA(Instituicoes ins)
        {
            SqlParameter[] paramsToSP = new SqlParameter[12];

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

            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_UPDATE_instituicoes", paramsToSP);

            return true;
        }

        public bool ExcluirDA(Instituicoes ins)
        {
            SqlParameter[] paramsToSP = new SqlParameter[1];

            paramsToSP[0] = new SqlParameter("@id", ins.Id);

            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_delete_instituicoes", paramsToSP);

            return true;
        }

        public List<Instituicoes> PesquisarDA()
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, string.Format(@"SELECT * FROM INSTITUICOES "));

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
               
    }
}
