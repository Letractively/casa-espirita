using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using InfrastructureSqlServer.Helpers;

namespace DataAccess
{
    public class FormulariosDA
    {
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
                                              
                formularios.Add(formu);
            }

            return formularios;
        }
        #endregion
        public bool InserirDA(Formularios formu)
        {
            SqlParameter[] paramsToSP = new SqlParameter[4];

            paramsToSP[0] = new SqlParameter("@codigo", formu.Codigo);
            paramsToSP[1] = new SqlParameter("@descricao", formu.Descricao);
            paramsToSP[2] = new SqlParameter("@nome", formu.Nome);
            paramsToSP[3] = new SqlParameter("@tipo", formu.Tipo);

            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_insert_formularios", paramsToSP);

            return true;
        }

        public bool EditarDA(Formularios formu)
        {
            SqlParameter[] paramsToSP = new SqlParameter[5];

            paramsToSP[0] = new SqlParameter("@id", formu.Id);
            paramsToSP[1] = new SqlParameter("@codigo", formu.Codigo);
            paramsToSP[2] = new SqlParameter("@descricao", formu.Descricao);
            paramsToSP[3] = new SqlParameter("@nome", formu.Nome);
            paramsToSP[4] = new SqlParameter("@tipo", formu.Tipo);

            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_update_formularios", paramsToSP);

            return true;
        }

        public bool ExcluirDA(Formularios form)
        {
            SqlParameter[] paramsToSP = new SqlParameter[1];

            paramsToSP[0] = new SqlParameter("@id", form.Id);

            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_delete_formularios", paramsToSP);

            return true;
        }

        public List<Formularios> PesquisarDA()
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, @"SELECT * FROM FORMULARIOS ");

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
    }
}
