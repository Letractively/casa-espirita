using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using InfrastructureSqlServer.Helpers;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


namespace DataAccess
{
    public class TurmasDA : BaseDA
    {
        public bool InserirDA(Turmas tur)
        {
            SqlParameter[] paramsToSP = new SqlParameter[5];

            paramsToSP[0] = new SqlParameter("@codigo", tur.Codigo);
            paramsToSP[1] = new SqlParameter("@descricao", tur.Descricao);
            paramsToSP[2] = new SqlParameter("@cursoId", tur.CursoId);
            paramsToSP[3] = new SqlParameter("@dataInicial", tur.DataInicial);
            paramsToSP[4] = new SqlParameter("@dataFinal", tur.DataFinal);

            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_insert_turmas", paramsToSP);

            return true;
        }

        public bool EditarDA(Turmas tur)
        {
            SqlParameter[] paramsToSP = new SqlParameter[6];

            paramsToSP[0] = new SqlParameter("@id", tur.Id);
            paramsToSP[1] = new SqlParameter("@codigo", tur.Codigo);
            paramsToSP[2] = new SqlParameter("@descricao", tur.Descricao);
            paramsToSP[2] = new SqlParameter("@cursoId", tur.CursoId);
            paramsToSP[3] = new SqlParameter("@dataInicial", tur.DataInicial);
            paramsToSP[4] = new SqlParameter("@dataFinal", tur.DataFinal);

            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_update_turmas", paramsToSP);

            return true;
        }

        public bool ExcluirDA(Turmas tur)
        {
            SqlParameter[] paramsToSP = new SqlParameter[1];

            paramsToSP[0] = new SqlParameter("@id", tur.Id);

            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_delete_turmas", paramsToSP);

            return true;
        }

        public List<Turmas> PesquisarDA()
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, string.Format(@"SELECT * FROM TURMAS "));

            List<Turmas> turmas = new List<Turmas>();

            while (dr.Read())
            {
                Turmas tur = new Turmas();
                tur.Id = int.Parse(dr["ID"].ToString());
                tur.Codigo = int.Parse(dr["CODIGO"].ToString());
                tur.Descricao = dr["DESCRICAO"].ToString();
                tur.CursoId = int.Parse(dr["CURSOID"].ToString());
                tur.DataInicial = DateTime.Parse(dr["DATAINICIAL"].ToString());
                tur.DataFinal = DateTime.Parse(dr["DESCRICAO"].ToString());

                turmas.Add(tur);
            }
            return turmas;

        }

        public List<Turmas> PesquisarDA(int id_tur)
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                       CommandType.Text, string.Format(@"SELECT * " +
                                                                                       " FROM TURMAS WHERE ID = {0}", id_tur));

            List<Turmas> turmas = new List<Turmas>();

            while (dr.Read())
            {
                Turmas tur = new Turmas();
                tur.Id = int.Parse(dr["ID"].ToString());
                tur.Codigo = int.Parse(dr["CODIGO"].ToString());
                tur.Descricao = dr["DESCRICAO"].ToString();
                tur.CursoId = int.Parse(dr["CURSOID"].ToString());
                tur.DataInicial = DateTime.Parse(dr["DESCRICAO"].ToString());
                tur.DataFinal = DateTime.Parse(dr["DESCRICAO"].ToString());

                turmas.Add(tur);
            }
            return turmas;
        }

        public override List<Base> Pesquisar(string descricao, string tipo)
        {
            SqlDataReader dr;

            if (tipo == "C")
            {
                int codigo = 0;
                Int32.TryParse(descricao, out codigo);

                dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                       CommandType.Text, string.Format(@"SELECT * " +
                                                                                       " FROM TURMAS WHERE CODIGO = '{0}'", codigo));
            }
            else
            {
                dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                      CommandType.Text, string.Format(@"SELECT * " +
                                                                                       " FROM TURMAS WHERE DESCRICAO LIKE '%{0}%'", descricao));
            }

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
