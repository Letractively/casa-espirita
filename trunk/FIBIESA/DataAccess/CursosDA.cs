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
    public class CursosDA : BaseDA
    {
        public bool InserirDA(Cursos cur)
        {
            SqlParameter[] paramsToSP = new SqlParameter[2];

            paramsToSP[0] = new SqlParameter("@codigo", cur.Codigo);
            paramsToSP[1] = new SqlParameter("@descricao", cur.Descricao);

            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_insert_cursos", paramsToSP);

            return true;
        }

        public bool EditarDA(Cursos cur)
        {
            SqlParameter[] paramsToSP = new SqlParameter[3];

            paramsToSP[0] = new SqlParameter("@id", cur.Id);
            paramsToSP[1] = new SqlParameter("@codigo", cur.Codigo);
            paramsToSP[2] = new SqlParameter("@descricao", cur.Descricao);

            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_update_cursos", paramsToSP);

            return true;
        }

        public bool ExcluirDA(Cursos cur)
        {
            SqlParameter[] paramsToSP = new SqlParameter[1];

            paramsToSP[0] = new SqlParameter("@id", cur.Id);

            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_delete_cursos", paramsToSP);

            return true;
        }

        public List<Cursos> PesquisarDA()
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, string.Format(@"SELECT * FROM CURSOS "));

            List<Cursos> cursos = new List<Cursos>();

            while (dr.Read())
            {
                Cursos cur = new Cursos();
                cur.Id = int.Parse(dr["ID"].ToString());
                cur.Codigo = int.Parse(dr["CODIGO"].ToString());
                cur.Descricao = dr["DESCRICAO"].ToString();

                cursos.Add(cur);
            }
            return cursos;

        }

        public List<Cursos> PesquisarDA(int id_cur)
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                       CommandType.Text, string.Format(@"SELECT * " +
                                                                                       " FROM CURSOS WHERE ID = {0}", id_cur));

            List<Cursos> cursos = new List<Cursos>();

            while (dr.Read())
            {
                Cursos cur = new Cursos();
                cur.Id = int.Parse(dr["ID"].ToString());
                cur.Codigo = int.Parse(dr["CODIGO"].ToString());
                cur.Descricao = dr["DESCRICAO"].ToString();

                cursos.Add(cur);
            }
            return cursos;
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
                                                                                       " FROM CURSOS WHERE CODIGO = '{0}'", codigo));
            }
            else
            {
                dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                      CommandType.Text, string.Format(@"SELECT * " +
                                                                                       " FROM CURSOS WHERE DESCRICAO LIKE '%{0}%'", descricao));
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
