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
    public class AutoresDA
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

        public List<Autores> PesquisarDA()
        {
            List<Autores> instancia = new List<Autores>();
            return instancia;
        }
    }
}
