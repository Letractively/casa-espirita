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
                obAt.TipoAutor = dr["TIPO"].ToString();
                obAt.Autor = dr["DESCRICAO"].ToString();
                obAt.CodAutor = utils.ComparaIntComZero(dr["CODIGO"].ToString());


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

            try
            {
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                            CommandType.StoredProcedure, "stp_insert_obrasAutores", paramsToSP);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            
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
            StringBuilder v_consulta = new StringBuilder();

            v_consulta.Append(@"SELECT OA.*, A.CODIGO, A.DESCRICAO, TA.DESCRICAO TIPO  ");
            v_consulta.Append(@"  FROM OBRASAUTORES OA ");
            v_consulta.Append(@"      ,AUTORES A ");
            v_consulta.Append(@"      ,TIPOSDEAUTORES TA ");
            v_consulta.Append(@"  WHERE OA.AUTORESID = A.ID ");
            v_consulta.Append(@"    AND A.TIPOID = TA.ID ");

            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, v_consulta.ToString());

            List<ObrasAutores> ObrasAutores = CarregarObjObrasAutores(dr);

            return ObrasAutores;

        }

        public List<ObrasAutores> PesquisarDA(int id_obra)
        {
            StringBuilder v_consulta = new StringBuilder();

            v_consulta.Append(@"SELECT OA.*, A.CODIGO, A.DESCRICAO, TA.DESCRICAO TIPO  ");
            v_consulta.Append(@"  FROM OBRASAUTORES OA ");           
            v_consulta.Append(@"      ,AUTORES A ");
            v_consulta.Append(@"      ,TIPOSDEAUTORES TA ");
            v_consulta.Append(@"  WHERE OA.AUTORESID = A.ID ");
            v_consulta.Append(@"    AND A.TIPOID = TA.ID " );
            v_consulta.Append(string.Format(@" AND OA.OBRAID = {0}", id_obra));
            

            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                       CommandType.Text, v_consulta.ToString());
                                                                                     

            List<ObrasAutores> ObrasAutores = CarregarObjObrasAutores(dr);

            return ObrasAutores;
        }
                      
    }
}
