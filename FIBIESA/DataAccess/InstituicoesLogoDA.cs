using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using System.Data;
using System.Data.SqlClient;
using InfrastructureSqlServer.Helpers;
using System.Configuration;

namespace DataAccess
{
    public class InstituicoesLogoDA
    {
        #region funcoes
        private List<InstituicoesLogo> CarregarObjInstituicoes(SqlDataReader dr)
        {
            List<InstituicoesLogo> instituicoesLogo = new List<InstituicoesLogo>();

            while (dr.Read())
            {
                InstituicoesLogo insL = new InstituicoesLogo();
                insL.Id = int.Parse(dr["ID"].ToString());
                insL.InstituicoesId = int.Parse(dr["INSTITUICOESID"].ToString());
                insL.Extensao = dr["EXTENSAO"].ToString();
                insL.Imagem = (byte[])dr["IMAGEM"];
                //.Imagem = dr["IMAGEM"].ToString();
                
                instituicoesLogo.Add(insL);
            }
            return instituicoesLogo;
        }
        #endregion

        public bool InserirDA(InstituicoesLogo insL)
        {
            SqlParameter[] paramsToSP = new SqlParameter[3];

            paramsToSP[0] = new SqlParameter("@instituicoesid", insL.InstituicoesId);
            paramsToSP[1] = new SqlParameter("@imagem", insL.Imagem);
            paramsToSP[2] = new SqlParameter("@extensao", insL.Extensao);

            try
            {
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_insert_instituicoeslogo", paramsToSP);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool EditarDA(InstituicoesLogo insL)
        {
            SqlParameter[] paramsToSP = new SqlParameter[4];

            paramsToSP[0] = new SqlParameter("@id", insL.Id);
            paramsToSP[1] = new SqlParameter("@instituicoesid", insL.InstituicoesId);
            paramsToSP[2] = new SqlParameter("@imagem", insL.Imagem);
            paramsToSP[3] = new SqlParameter("@extensao", insL.Extensao);

            try
            {
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_UPDATE_instituicoeslogo", paramsToSP);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool ExcluirDA(InstituicoesLogo insL)
        {
            SqlParameter[] paramsToSP = new SqlParameter[1];

            paramsToSP[0] = new SqlParameter("@id", insL.Id);

            try
            {
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_delete_instituicoeslogo", paramsToSP);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<InstituicoesLogo> PesquisarDA()
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, string.Format(@"SELECT * FROM INSTITUICOESLOGO "));

            List<InstituicoesLogo> instituicoesLogo = CarregarObjInstituicoes(dr);

            return instituicoesLogo;

        }

        public DataSet PesquisarDsDA()
        {
            DataSet lDs = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, string.Format(@"SELECT id " +
                                                                                                 "   ,instituicoesid " +
                                                                                                 "   ,imagem " +
                                                                                                 "   ,extensao  " +
                                                                                                 " FROM INSTITUICOESLOGO "));

            return lDs;

        }

        public List<InstituicoesLogo> PesquisarDA(int id_insL)
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                       CommandType.Text, string.Format(@"SELECT * " +
                                                                                       " FROM INSTITUICOESLOGO WHERE ID = {0}", id_insL));

            List<InstituicoesLogo> instituicoesLogo = CarregarObjInstituicoes(dr);

            return instituicoesLogo;
        }
    }
}
