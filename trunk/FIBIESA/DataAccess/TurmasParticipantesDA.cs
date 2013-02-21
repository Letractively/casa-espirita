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
                TurmasDA turDA = new TurmasDA();

                turP.Id = int.Parse(dr["ID"].ToString());
                turP.PessoaId = int.Parse(dr["PESSOAID"].ToString());
                turP.TurmaId = int.Parse(dr["TURMASID"].ToString());
                
                List<Pessoas> pes = pesDA.PesquisarDA(turP.PessoaId);
                Pessoas pessoas = new Pessoas();

                foreach (Pessoas ltPes in pes)
                {
                    pessoas.Id = ltPes.Id;
                    pessoas.Codigo = ltPes.Codigo;
                    pessoas.Nome = ltPes.Nome;

                    turP.Pessoa = pessoas;
                }

                List<Turmas> tur = turDA.PesquisarDA(turP.PessoaId);
                Turmas turmas = new Turmas();

                foreach (Turmas ltTur in tur)
                {
                    turmas.Id = ltTur.Id;
                    turmas.Codigo = ltTur.Codigo;
                    turmas.Descricao = ltTur.Descricao;

                    turP.Turma = turmas;
                }

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

            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_insert_turmasParticipantes", paramsToSP);

            return true;
        }

        public bool EditarDA(TurmasParticipantes turP)
        {
            SqlParameter[] paramsToSP = new SqlParameter[3];

            paramsToSP[0] = new SqlParameter("@id", turP.Id);
            paramsToSP[1] = new SqlParameter("@pessoaid", turP.PessoaId);
            paramsToSP[2] = new SqlParameter("@turmasid", turP.TurmaId);

            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_update_turmasParticipantes", paramsToSP);

            return true;
        }

        public bool ExcluirDA(TurmasParticipantes turP)
        {
            SqlParameter[] paramsToSP = new SqlParameter[1];

            paramsToSP[0] = new SqlParameter("@id", turP.Id);

            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_delete_turmasParticipantes", paramsToSP);

            return true;
        }

        public List<TurmasParticipantes> PesquisarDA()
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, string.Format(@"SELECT * FROM TURMASPARTICIPANTES "));

            List<TurmasParticipantes> turmasParticipantes = CarregarObjTurmasParticipantes(dr);

            return turmasParticipantes;

        }

        public List<TurmasParticipantes> PesquisarDA(int id_turma)
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                       CommandType.Text, string.Format(@"SELECT * " +
                                                                                       " FROM TURMASPARTICIPANTES WHERE TURMASID = {0}", id_turma));

            List<TurmasParticipantes> turmasParticipantes = CarregarObjTurmasParticipantes(dr);

            return turmasParticipantes;
        }
    }
}
