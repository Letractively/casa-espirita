using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using InfrastructureSqlServer.Helpers;

namespace DataAccess
{
    public class TelefonesDA
    {
        public bool InserirDA(Telefones tel)
        {
            SqlParameter[] paramsToSP = new SqlParameter[4];

            paramsToSP[0] = new SqlParameter("@descricao", tel.Descricao);
            paramsToSP[1] = new SqlParameter("@ddd", tel.Ddd);
            paramsToSP[2] = new SqlParameter("@numero", tel.Numero);
            paramsToSP[3] = new SqlParameter("@pessoaid", tel.PessoaId);

            //SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "", paramsToSP);

            return true;
        }

        public bool EditarDA(Telefones tel)
        {
            SqlParameter[] paramsToSP = new SqlParameter[5];

            paramsToSP[0] = new SqlParameter("@id", tel.Id);
            paramsToSP[1] = new SqlParameter("@descricao", tel.Descricao);
            paramsToSP[2] = new SqlParameter("@ddd", tel.Ddd);
            paramsToSP[3] = new SqlParameter("@numero", tel.Numero);
            paramsToSP[4] = new SqlParameter("@pessoaid", tel.PessoaId);

            //SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "", paramsToSP);

            return true;
        }

        public bool ExcluirDA(Telefones tel)
        {
            SqlParameter[] paramsToSP = new SqlParameter[1];

            paramsToSP[0] = new SqlParameter("@id", tel.Id);

            // SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "", paramsToSP);

            return true;
        }

        public List<Telefones> PesquisarDA()
        {
            List<Telefones> telefones = new List<Telefones>();
            return telefones;
        }
    }
}
