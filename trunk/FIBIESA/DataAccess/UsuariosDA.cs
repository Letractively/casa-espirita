using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using DataObjects;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using InfrastructureSqlServer.Helpers;

namespace DataAccess
{
    public class UsuariosDA
    {
        public bool InserirDA(Usuarios usu)
        {
            SqlParameter[] paramsToSP = new SqlParameter[11];

            paramsToSP[0] = new SqlParameter("@login", usu.Login);
            paramsToSP[1] = new SqlParameter("@senha", usu.Senha);
            paramsToSP[2] = new SqlParameter("@nome", usu.Nome);
            paramsToSP[3] = new SqlParameter("@status", usu.Status);
            paramsToSP[4] = new SqlParameter("@dtinicio", usu.DtInicio);
            paramsToSP[5] = new SqlParameter("@dtfim", usu.DtFim);
            paramsToSP[6] = new SqlParameter("@tipo", usu.Tipo);
            paramsToSP[7] = new SqlParameter("@email", usu.Email);
            paramsToSP[8] = new SqlParameter("@pessoaid", usu.PessoaId);
            paramsToSP[9] = new SqlParameter("@nrtentlogin", usu.NrTentLogin);
            paramsToSP[10] = new SqlParameter("@dhtentlogin", usu.DhTentLogin);

            //SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "", paramsToSP);

            return true;
        }

        public bool EditarDA(Usuarios usu)
        {
            SqlParameter[] paramsToSP = new SqlParameter[12];

            paramsToSP[0] = new SqlParameter("@id", usu.Id);
            paramsToSP[1] = new SqlParameter("@login", usu.Login);
            paramsToSP[2] = new SqlParameter("@senha", usu.Senha);
            paramsToSP[3] = new SqlParameter("@nome", usu.Nome);
            paramsToSP[4] = new SqlParameter("@status", usu.Status);
            paramsToSP[5] = new SqlParameter("@dtinicio", usu.DtInicio);
            paramsToSP[6] = new SqlParameter("@dtfim", usu.DtFim);
            paramsToSP[7] = new SqlParameter("@tipo", usu.Tipo);
            paramsToSP[8] = new SqlParameter("@email", usu.Email);
            paramsToSP[9] = new SqlParameter("@pessoaid", usu.PessoaId);
            paramsToSP[10] = new SqlParameter("@nrtentlogin", usu.NrTentLogin);
            paramsToSP[11] = new SqlParameter("@dhtentlogin", usu.DhTentLogin);

            //SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "", paramsToSP);

            return true;
        }

        public bool ExcluirDA(Usuarios usu)
        {
            SqlParameter[] paramsToSP = new SqlParameter[1];

            paramsToSP[0] = new SqlParameter("@id", usu.Id);

           // SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "", paramsToSP);

            return true;
        }

        public List<Usuarios> PesquisarDA()
        {
            List<Usuarios> usuarios = new List<Usuarios>();
            return usuarios;
        }
    }
}
