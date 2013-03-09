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
    public class ChamadasDA
    {
        #region funcoes
        private List<Chamadas> CarregarObjChamada(SqlDataReader dr)
        {
            List<Chamadas> chamadas = new List<Chamadas>();

            while (dr.Read())
            {
                Chamadas cha = new Chamadas();
                cha.Id = int.Parse(dr["ID"].ToString());
                cha.TurmaParticipanteId = int.Parse(dr["TURMAPARTICIPANTEID"].ToString());
                cha.Presenca = Convert.ToBoolean(dr["PRESENCA"].ToString());
                cha.Data = Convert.ToDateTime(dr["DATA"].ToString());
                
                chamadas.Add(cha);
            }
            return chamadas;
        }
        #endregion
        public bool InserirDA(Chamadas cha)
        {
            SqlParameter[] paramsToSP = new SqlParameter[3];

            paramsToSP[0] = new SqlParameter("@turmaparticipanteid", cha.TurmaParticipanteId);
            paramsToSP[1] = new SqlParameter("@presenca", cha.Presenca);
            paramsToSP[2] = new SqlParameter("@data", cha.Data);

            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_insert_Chamadas", paramsToSP);

            return true;
        }

        public bool EditarDA(Chamadas cha)
        {
            SqlParameter[] paramsToSP = new SqlParameter[4];

            paramsToSP[0] = new SqlParameter("@id", cha.Id);
            paramsToSP[1] = new SqlParameter("@turmaparticipanteid", cha.TurmaParticipanteId);
            paramsToSP[2] = new SqlParameter("@presenca", cha.Presenca);
            paramsToSP[3] = new SqlParameter("@data", cha.Data);

            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_update_Chamadas", paramsToSP);

            return true;
        }

        public bool ExcluirDA(Chamadas cha)
        {
            SqlParameter[] paramsToSP = new SqlParameter[1];

            paramsToSP[0] = new SqlParameter("@id", cha.Id);

            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_delete_Chamadas", paramsToSP);

            return true;
        }

        public List<Chamadas> PesquisarDA()
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, string.Format(@"SELECT * FROM CHAMADAS "));

            List<Chamadas> Chamadas = CarregarObjChamada(dr);
           
            return Chamadas;
        }

        public List<Chamadas> PesquisarDA(int id_tPar, DateTime data)
        {
            
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                       CommandType.Text, string.Format(@"SELECT * " +
                                                                                       " FROM CHAMADAS " +
                                                                                       " WHERE TURMAPARTICIPANTEID = {0}" +
                                                                                       "   AND DATA = '{1}'", id_tPar,data.ToString("MM/dd/yyyy")));

            List<Chamadas> Chamadas = CarregarObjChamada(dr);
        
            return Chamadas;
        }

        public List<Chamadas> PesquisarDA(int id_tur, int id_eve)
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                       CommandType.Text, string.Format(@"SELECT * " +
                                                                                       " FROM TURMAS T " +
                                                                                       "     ,TURMASPARTICIPANTES TP " +
                                                                                       "     ,CHAMADAS C "+
                                                                                       " WHERE T.ID = TP.TURMASID "+
                                                                                       "   AND TP.ID = C.TURMAPARTICIPANTEID "+
                                                                                       "   AND T.ID = {0} " +
                                                                                       "   AND T.EVENTOID = {1}",id_tur,id_eve));
                                                                                      


            List<Chamadas> Chamadas = CarregarObjChamada(dr);
        
            return Chamadas;
        }      
       
    }
}
