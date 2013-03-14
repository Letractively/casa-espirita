using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FG;
using DataObjects;
using System.Data;
using System.Data.SqlClient;
using InfrastructureSqlServer.Helpers;
using System.Configuration;

namespace DataAccess
{
    public class ObrasAutoresDA
    {
        Utils utils = new Utils();
        #region funcoes
        private List<ObrasAutores> CarregarObjObrasAutores(SqlDataReader dr)
        {
            List<ObrasAutores> ObrasAutores = new List<ObrasAutores>();

            while (dr.Read())
            {
                ObrasAutores obAt = new ObrasAutores();
                obAt.Id = utils.ComparaIntComZero(dr["ID"].ToString());
                obAt.ObraId = utils.ComparaIntComZero(dr["OBRAID"].ToString());
                obAt.AutoresId = utils.ComparaIntComZero(dr["AUTORESID"].ToString());

                ObrasAutores.Add(obAt);
            }

            return ObrasAutores;
        }
        #endregion

        public bool InserirDA(ObrasAutores obAt)
        {
            SqlParameter[] paramsToSP = new SqlParameter[2];

            paramsToSP[0] = new SqlParameter("@obraid", obAt.ObraId);
            paramsToSP[1] = new SqlParameter("@autoresid", obAt.AutoresId);

            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_insert_obrasAutores", paramsToSP);

            return true;
        }

        public bool EditarDA(ObrasAutores obAt)
        {
            SqlParameter[] paramsToSP = new SqlParameter[3];

            paramsToSP[0] = new SqlParameter("@id", obAt.Id);
            paramsToSP[1] = new SqlParameter("@obraid", obAt.ObraId);
            paramsToSP[2] = new SqlParameter("@autoresid", obAt.AutoresId);

            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_update_obrasAutores", paramsToSP);

            return true;
        }

        public bool ExcluirDA(ObrasAutores obAt)
        {
            SqlParameter[] paramsToSP = new SqlParameter[1];

            paramsToSP[0] = new SqlParameter("@id", obAt.Id);

            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_delete_obrasAutores", paramsToSP);

            return true;
        }

        public List<ObrasAutores> PesquisarDA()
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, string.Format(@"SELECT * FROM OBRASAUTORES "));

            List<ObrasAutores> ObrasAutores = CarregarObjObrasAutores(dr);

            return ObrasAutores;

        }

        public List<ObrasAutores> PesquisarDA(int id_obAt)
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                       CommandType.Text, string.Format(@"SELECT * " +
                                                                                       " FROM OBRASAUTORES WHERE ID = {0}", id_obAt));

            List<ObrasAutores> ObrasAutores = CarregarObjObrasAutores(dr);

            return ObrasAutores;
        }
                      
    }
}
