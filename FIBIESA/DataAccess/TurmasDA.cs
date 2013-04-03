using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using InfrastructureSqlServer.Helpers;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using FG;

namespace DataAccess
{
    public class TurmasDA : BaseDA
    {
        Utils utils = new Utils();

        #region funcoes
        private List<Turmas> CarregarObjTurmas(SqlDataReader dr)
        {
            List<Turmas> turmas = new List<Turmas>();
            PessoasDA pesDA = new PessoasDA();
            EventosDA eveDA = new EventosDA();

            while (dr.Read())
            {
                Turmas tur = new Turmas();
                tur.Id = int.Parse(dr["id"].ToString());
                tur.Codigo = int.Parse(dr["codigo"].ToString());
                tur.Descricao = dr["descricao"].ToString();
                tur.EventoId = int.Parse(dr["eventoid"].ToString());
                tur.DataInicial = Convert.ToDateTime(dr["dtini"].ToString());
                tur.DataFinal = Convert.ToDateTime(dr["dtfim"].ToString());
                tur.Nromax = utils.ComparaIntComZero(dr["nromax"].ToString());
                tur.HoraIni = utils.ComparaDataComNull(dr["horaini"].ToString());
                tur.HoraFim = utils.ComparaDataComNull(dr["horafim"].ToString());
                tur.Sala = dr["sala"].ToString();
                tur.DiaSemana = dr["diasemana"].ToString();
                tur.PessoaId = utils.ComparaIntComNull(dr["pessoaid"].ToString());

                int id = 0;

                if (tur.PessoaId != null)
                {
                    id = Convert.ToInt32(tur.PessoaId);
                    List<Pessoas> pes = pesDA.PesquisarDA(id);
                    Pessoas pessoa = new Pessoas();

                    foreach (Pessoas ltPes in pes)
                    {
                        pessoa.Id = ltPes.Id;
                        pessoa.Codigo = ltPes.Codigo;
                        pessoa.Nome = ltPes.Nome;
                    }

                    tur.Pessoa = pessoa;
                }
                
                id = Convert.ToInt32(tur.EventoId);
                List<Eventos> eve = eveDA.PesquisarDA(id);
                Eventos eventos = new Eventos();

                foreach (Eventos ltEve in eve)
                {
                    eventos.Id = ltEve.Id;
                    eventos.Codigo = ltEve.Codigo;
                    eventos.Descricao = ltEve.Descricao;
                }

                tur.Evento = eventos;


                turmas.Add(tur);
            }
            return turmas;
        }

        private Int32 RetornaMaxCodigo()
        {
            Int32 codigo = 1;
            DataSet ds = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                          CommandType.Text, string.Format(@" SELECT ISNULL(MAX(CODIGO),0) + 1 as COD FROM TURMAS "));

            if (ds.Tables[0].Rows.Count != 0)
                codigo = utils.ComparaIntComZero(ds.Tables[0].Rows[0]["COD"].ToString());

            return codigo;

        }
        #endregion
        public bool InserirDA(Turmas tur)
        {
            SqlParameter[] paramsToSP = new SqlParameter[11];

            paramsToSP[0] = new SqlParameter("@codigo", RetornaMaxCodigo());
            paramsToSP[1] = new SqlParameter("@descricao", tur.Descricao);
            paramsToSP[2] = new SqlParameter("@eventoid", tur.EventoId);
            paramsToSP[3] = new SqlParameter("@dtini", tur.DataInicial);
            paramsToSP[4] = new SqlParameter("@dtfim", tur.DataFinal);
            paramsToSP[5] = new SqlParameter("@nromax", tur.Nromax);
            paramsToSP[6] = new SqlParameter("@sala", tur.Sala);
            paramsToSP[7] = new SqlParameter("@horaini", tur.HoraIni);
            paramsToSP[8] = new SqlParameter("@horafim", tur.HoraFim);
            paramsToSP[9] = new SqlParameter("@diasemana", tur.DiaSemana);
            paramsToSP[10] = new SqlParameter("@pessoaid", tur.PessoaId);


            try
            {
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_insert_turmas", paramsToSP);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public bool EditarDA(Turmas tur)
        {
            SqlParameter[] paramsToSP = new SqlParameter[12];

            paramsToSP[0] = new SqlParameter("@id", tur.Id);
            paramsToSP[1] = new SqlParameter("@codigo", tur.Codigo);
            paramsToSP[2] = new SqlParameter("@descricao", tur.Descricao);
            paramsToSP[3] = new SqlParameter("@eventoid", tur.EventoId);
            paramsToSP[4] = new SqlParameter("@dtini", tur.DataInicial);
            paramsToSP[5] = new SqlParameter("@dtfim", tur.DataFinal);
            paramsToSP[6] = new SqlParameter("@nromax", tur.Nromax);
            paramsToSP[7] = new SqlParameter("@sala", tur.Sala);
            paramsToSP[8] = new SqlParameter("@horaini", tur.HoraIni);
            paramsToSP[9] = new SqlParameter("@horafim", tur.HoraFim);
            paramsToSP[10] = new SqlParameter("@diasemana", tur.DiaSemana);
            paramsToSP[11] = new SqlParameter("@pessoaid", tur.PessoaId);

            try
            {
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_update_turmas", paramsToSP);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool ExcluirDA(Turmas tur)
        {
            SqlParameter[] paramsToSP = new SqlParameter[1];

            paramsToSP[0] = new SqlParameter("@id", tur.Id);

            try
            {
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_delete_turmas", paramsToSP);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<Turmas> PesquisarDA()
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, string.Format(@"SELECT * FROM TURMAS "));

            List<Turmas> turmas = CarregarObjTurmas(dr);

            return turmas;

        }

        public List<Turmas> PesquisarDA(int id_tur)
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                       CommandType.Text, string.Format(@"SELECT * " +
                                                                                       " FROM TURMAS WHERE ID = {0}", id_tur));
            List<Turmas> turmas = CarregarObjTurmas(dr);

            return turmas;
        }

        public List<Turmas> PesquisarEveDA(int id_eve)
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                       CommandType.Text, string.Format(@"SELECT * " +
                                                                                       " FROM TURMAS WHERE EVENTOID = {0}", id_eve));

            List<Turmas> turmas = CarregarObjTurmas(dr);

            return turmas;
        }

        public List<Turmas> PesquisarDA(int id_tur, int id_eve)
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                       CommandType.Text, string.Format(@"SELECT * " +
                                                                                       " FROM TURMAS " +
                                                                                       " WHERE ID = {0} " +
                                                                                       " AND EVENTOID = {1}", id_tur, id_eve));

            List<Turmas> turmas = CarregarObjTurmas(dr);

            return turmas;
        }

        public List<Turmas> PesquisarDA(string campo, string valor)
        {
            string consulta;

            switch (campo.ToUpper())
            {
                case "CODIGO":
                    consulta = string.Format("SELECT * FROM TURMAS WHERE CODIGO = {0}", utils.ComparaIntComZero(valor));
                    break;
                case "DESCRICAO":
                    consulta = string.Format("SELECT * FROM TURMAS WHERE DESCRICAO  LIKE '%{0}%'", valor);
                    break;
                default:
                    consulta = "";
                    break;
            }

            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, consulta);

            List<Turmas> turmas = CarregarObjTurmas(dr);

            return turmas;
        }

        public List<Turmas> PesquisarBuscaDA(string valor)
        {
            StringBuilder consulta = new StringBuilder(@"SELECT * FROM TURMAS ");

            if (valor != "")
                consulta.Append(string.Format(" WHERE CODIGO = {0} OR  DESCRICAO  LIKE '%{1}%'", utils.ComparaIntComZero(valor), valor));

            consulta.Append(" ORDER BY CODIGO ");

            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, consulta.ToString());

            List<Turmas> turmas = CarregarObjTurmas(dr);

            return turmas;
        }
        
        public override List<Base> Pesquisar(string descricao)
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                      CommandType.Text, string.Format(@"SELECT * " +
                                                                                       " FROM TURMAS WHERE CODIGO = '{0}' OR DESCRICAO LIKE '%{1}%'",utils.ComparaIntComZero(descricao), descricao));
            
            List<Base> ba = new List<Base>();

            while (dr.Read())
            {
                Base bas = new Base();
                bas.PesId1 = int.Parse(dr["ID"].ToString());
                bas.PesDescricao = dr["DESCRICAO"].ToString();

                ba.Add(bas);
            }
            return ba;
        }

    }
}
