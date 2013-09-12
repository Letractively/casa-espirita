using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using InfrastructureSqlServer.Helpers;


namespace DataAccess
{
    public class TurmasParticipantesDA
    {
        #region funcoes
        private List<TurmasParticipantes> CarregarObjTurmasParticipantes(SqlDataReader dr)
        {
            List<TurmasParticipantes> turmasParticipantes = new List<TurmasParticipantes>();

            while (dr.Read())
            {
                TurmasParticipantes turP = new TurmasParticipantes();
                PessoasDA pesDA = new PessoasDA();
                Turmas turmas = new Turmas();
                Pessoas pessoas = new Pessoas();

                turP.Id = int.Parse(dr["ID"].ToString());
                turP.PessoaId = int.Parse(dr["PESSOAID"].ToString());
                turP.TurmaId = int.Parse(dr["TURMASID"].ToString());
                
                //turmas
                turmas.Id =int.Parse(dr["ID_TUR"].ToString());
                turmas.Descricao = dr["DESCRICAO"].ToString();
                turP.Turma = turmas;
                
                //pessoas
                pessoas.Id = int.Parse(dr["ID_PES"].ToString());
                pessoas.Codigo = int.Parse(dr["P_COD"].ToString());
                pessoas.Nome = dr["NOME"].ToString();

                turP.Pessoa = pessoas;
                                
                turmasParticipantes.Add(turP);
            }
            return turmasParticipantes;
        }      

        #endregion
        public bool InserirDA(TurmasParticipantes turP)
        {
            SqlParameter[] paramsToSP = new SqlParameter[2];

            paramsToSP[0] = new SqlParameter("@pessoaid", turP.PessoaId);
            paramsToSP[1] = new SqlParameter("@turmasid", turP.TurmaId);

            try
            {
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_insert_turmasParticipantes", paramsToSP);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool EditarDA(TurmasParticipantes turP)
        {
            SqlParameter[] paramsToSP = new SqlParameter[3];

            paramsToSP[0] = new SqlParameter("@id", turP.Id);
            paramsToSP[1] = new SqlParameter("@pessoaid", turP.PessoaId);
            paramsToSP[2] = new SqlParameter("@turmasid", turP.TurmaId);

            try
            {
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_update_turmasParticipantes", paramsToSP);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool ExcluirDA(TurmasParticipantes turP)
        {
            SqlParameter[] paramsToSP = new SqlParameter[1];

            paramsToSP[0] = new SqlParameter("@id", turP.Id);

            try
            {
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_delete_turmasParticipantes", paramsToSP);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public List<TurmasParticipantes> PesquisarDA()
        {
            StringBuilder v_query = new StringBuilder();
            v_query.Append(@"SELECT TP.*, T.ID ID_TUR, T.DESCRICAO ");
            v_query.Append(@"       ,P.CODIGO P_COD,P.ID ID_PES, P.NOME ");
            v_query.Append(@"  FROM TURMASPARTICIPANTES TP ");
            v_query.Append(@"      ,TURMAS T ");
            v_query.Append(@"      ,PESSOAS P ");
            v_query.Append(@" WHERE T.ID = TP.TURMASID ");
            v_query.Append(@"   AND TP.PESSOAID = P.ID ");
         
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, string.Format(v_query.ToString()));

            List<TurmasParticipantes> turmasParticipantes = CarregarObjTurmasParticipantes(dr);

            return turmasParticipantes;

        }

        public List<TurmasParticipantes> PesquisarDA(int id_turma)
        {
            StringBuilder v_query = new StringBuilder();
            v_query.Append(@"SELECT TP.*, T.ID ID_TUR, T.DESCRICAO ");
            v_query.Append(@"       ,P.CODIGO P_COD,P.ID ID_PES, P.NOME ");
            v_query.Append(@"  FROM TURMASPARTICIPANTES TP ");
            v_query.Append(@"      ,TURMAS T ");
            v_query.Append(@"      ,PESSOAS P ");
            v_query.Append(@" WHERE T.ID = TP.TURMASID ");
            v_query.Append(@"   AND TP.PESSOAID = P.ID ");
            v_query.Append(@"   AND TP.TURMASID = {0}");                                                                                       
            
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                       CommandType.Text, string.Format(v_query.ToString(), id_turma));

            List<TurmasParticipantes> turmasParticipantes = CarregarObjTurmasParticipantes(dr);

            return turmasParticipantes;
        }

        public List<TurmasParticipantes> PesquisarDA(int id_turma, string nm_participante)
        {
            StringBuilder v_query = new StringBuilder();
            v_query.Append(@"SELECT TP.*, T.ID ID_TUR, T.DESCRICAO ");
            v_query.Append(@"       ,P.CODIGO P_COD,P.ID ID_PES, P.NOME ");
            v_query.Append(@"  FROM TURMASPARTICIPANTES TP ");
            v_query.Append(@"      ,TURMAS T ");
            v_query.Append(@"      ,PESSOAS P ");
            v_query.Append(@" WHERE T.ID = TP.TURMASID ");
            v_query.Append(@"   AND TP.PESSOAID = P.ID ");
            v_query.Append(@"   AND TP.TURMASID = {0}");
            if (nm_participante != string.Empty)
                v_query.Append(@"   AND P.NOME LIKE '%{1}%'  ");

            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                       CommandType.Text, string.Format(v_query.ToString(), id_turma, nm_participante));

            List<TurmasParticipantes> turmasParticipantes = CarregarObjTurmasParticipantes(dr);

            return turmasParticipantes;
        }

        public DataSet PesquisarParticipantesNotInTurmaDA(int id_turma, string nm_participante)
        {
            StringBuilder v_query = new StringBuilder();
            v_query.Append(@"SELECT  P.CODIGO P_COD,P.ID ID_PES, P.NOME   ");
            v_query.Append(@"   FROM PESSOAS P WHERE P.ID NOT IN ");
            v_query.Append(@"   (SELECT TP.pessoaid FROM TURMASPARTICIPANTES TP WHERE TP.TURMASID = {0}) ");
            if(nm_participante != string.Empty)
                v_query.Append(@"   AND P.NOME LIKE '%{1}%'  ");

            DataSet ds = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                       CommandType.Text, string.Format(v_query.ToString(), id_turma,nm_participante));
            
            return ds;
        }
    }
}
