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
    public class FormulariosDA
    {
        Utils utils = new Utils();
        #region funcoes
        private List<Formularios> CarregarObjFormulario(SqlDataReader dr)
        {
            List<Formularios> formularios = new List<Formularios>();

            while (dr.Read())
            {
                Formularios formu = new Formularios();
                formu.Id = int.Parse(dr["ID"].ToString());
                formu.Codigo = int.Parse(dr["CODIGO"].ToString());
                formu.Descricao = dr["DESCRICAO"].ToString();
                formu.Nome = dr["NOME"].ToString();
                formu.Tipo = dr["TIPO"].ToString();
                formu.Modulo = dr["MODULO"].ToString();
                                              
                formularios.Add(formu);
            }

            return formularios;
        }

        private Int32 RetornaMaxCodigo()
        {
            Int32 codigo = 1;
            DataSet ds = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                          CommandType.Text, string.Format(@" SELECT ISNULL(MAX(CODIGO),0) + 1 as COD FROM FORMULARIOS ")); 
                                                                                           
            if (ds.Tables[0].Rows.Count != 0)
                codigo = utils.ComparaIntComZero(ds.Tables[0].Rows[0]["COD"].ToString());

            return codigo;
        }

        #endregion
        public bool InserirDA(Formularios formu)
        {
            SqlParameter[] paramsToSP = new SqlParameter[5];

            paramsToSP[0] = new SqlParameter("@codigo", RetornaMaxCodigo());
            paramsToSP[1] = new SqlParameter("@descricao", formu.Descricao);
            paramsToSP[2] = new SqlParameter("@nome", formu.Nome);
            paramsToSP[3] = new SqlParameter("@tipo", formu.Tipo);
            paramsToSP[4] = new SqlParameter("@modulo", formu.Modulo);

            try
            {
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_insert_formularios", paramsToSP);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool EditarDA(Formularios formu)
        {
            SqlParameter[] paramsToSP = new SqlParameter[6];

            paramsToSP[0] = new SqlParameter("@id", formu.Id);
            paramsToSP[1] = new SqlParameter("@codigo", formu.Codigo);
            paramsToSP[2] = new SqlParameter("@descricao", formu.Descricao);
            paramsToSP[3] = new SqlParameter("@nome", formu.Nome);
            paramsToSP[4] = new SqlParameter("@tipo", formu.Tipo);
            paramsToSP[5] = new SqlParameter("@modulo", formu.Modulo);

            try
            {
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_update_formularios", paramsToSP);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool ExcluirDA(Formularios form)
        {
            SqlParameter[] paramsToSP = new SqlParameter[1];

            paramsToSP[0] = new SqlParameter("@id", form.Id);

            try
            {
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_delete_formularios", paramsToSP);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<Formularios> PesquisarDA()
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, @"SELECT * FROM FORMULARIOS ORDER BY CODIGO ");

            List<Formularios> formularios = CarregarObjFormulario(dr);

            return formularios;
        }

        public List<Formularios> PesquisarDA(string modulo)
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, string.Format(@"SELECT * FROM FORMULARIOS WHERE MODULO = '{0}' ", modulo));

            List<Formularios> formularios = CarregarObjFormulario(dr);

            return formularios;
        }

        public List<Formularios> PesquisarDA(int id_for)
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, string.Format(@"SELECT * FROM FORMULARIOS WHERE ID = {0}", id_for));

            List<Formularios> formularios = CarregarObjFormulario(dr);

            return formularios;
        }

        public List<Formularios> PesquisarBuscaDA(string valor)
        {
            StringBuilder consulta = new StringBuilder(@"SELECT * FROM FORMULARIOS ");

            if (valor != "")
                consulta.Append(string.Format(" WHERE CODIGO = {0} OR  DESCRICAO  LIKE '%{1}%'", utils.ComparaIntComZero(valor), valor));

            consulta.Append(" ORDER BY CODIGO ");
            
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, consulta.ToString());

            List<Formularios> formularios = CarregarObjFormulario(dr);

            return formularios;                        
        }
    }
}
