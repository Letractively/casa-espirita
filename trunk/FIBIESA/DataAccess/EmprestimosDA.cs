using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using FG;
using System.Data.SqlClient;
using InfrastructureSqlServer.Helpers;
using System.Configuration;
using System.Data;

namespace DataAccess
{
    public class EmprestimosDA : BaseDA
    {
        Utils utils = new Utils();
        #region funcoes
        private List<Emprestimos> CarregarObjEmprestimos(SqlDataReader dr)
        {
            List<Emprestimos> emprestimos = new List<Emprestimos>();

            while (dr.Read())
            {
                Emprestimos emprestim = new Emprestimos();
                emprestim.Id = int.Parse(dr["ID"].ToString());
                emprestim.ExemplarId = int.Parse(dr["EXEMPLARID"].ToString());
                emprestim.PessoaId = int.Parse(dr["PESSOAID"].ToString());

                emprestimos.Add(emprestim);
            }

            return emprestimos;
        }
        #endregion

        public bool InserirDA(Emprestimos instancia)
        {
            SqlParameter[] paramsToSP = new SqlParameter[2];

            paramsToSP[0] = new SqlParameter("@codigo", instancia.ExemplarId);
            paramsToSP[1] = new SqlParameter("@descricao", instancia.PessoaId);

            return (SqlHelper.ExecuteNonQuery(
                ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                CommandType.StoredProcedure, "stp_insert_emprestimos", paramsToSP) > 0);
        }

        public bool EditarDA(Emprestimos instancia)
        {
            SqlParameter[] paramsToSP = new SqlParameter[3];

            paramsToSP[0] = new SqlParameter("@id", instancia.Id);
            paramsToSP[1] = new SqlParameter("@codigo", instancia.ExemplarId);
            paramsToSP[2] = new SqlParameter("@descricao", instancia.PessoaId);

            return (SqlHelper.ExecuteNonQuery(
                ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                CommandType.StoredProcedure, "stp_update_emprestimos", paramsToSP) > 0);
        }

        public bool ExcluirDA(Emprestimos instancia)
        {
            SqlParameter[] paramsToSP = new SqlParameter[1];

            paramsToSP[0] = new SqlParameter("@id", instancia.Id);

            return (SqlHelper.ExecuteNonQuery(
                ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                CommandType.StoredProcedure, "stp_delete_emprestimos", paramsToSP) > 0);
        }

        public List<Emprestimos> PesquisarDA()
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(
                ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                CommandType.Text, string.Format(@"SELECT * FROM emprestimos "));
            return CarregarObjEmprestimos(dr);
        }

        public List<Emprestimos> PesquisarDA(int id)
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(
                ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                CommandType.Text, string.Format(@"SELECT * FROM emprestimos  WHERE ID = {0}", id));
            return CarregarObjEmprestimos(dr);
        }

        public List<Emprestimos> PesquisarDA(string campo, string valor)
        {
            StringBuilder consulta = new StringBuilder("SELECT * FROM emprestimos ");

            switch (campo.ToUpper())
            {
                case "CODIGO":
                    consulta.Append(string.Format("WHERE CODIGO = {0}", utils.ComparaIntComZero(valor)));
                    break;
                case "DESCRICAO":
                    consulta.Append(string.Format("WHERE DESCRICAO  LIKE '%{0}%'", valor));
                    break;
                default:
                    break;
            }

            SqlDataReader dr = SqlHelper.ExecuteReader(
                ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                CommandType.Text, consulta.ToString());

            return CarregarObjEmprestimos(dr);
        }

        public override List<Base> Pesquisar(string descricao, string tipo)
        {
            SqlDataReader dr;

            if (tipo == "C")
            {
                int codigo = 0;
                Int32.TryParse(descricao, out codigo);

                dr = SqlHelper.ExecuteReader(
                    ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                    CommandType.Text, string.Format(@"SELECT * FROM emprestimos WHERE CODIGO = '{0}'", codigo));
            }
            else
            {
                dr = SqlHelper.ExecuteReader(
                    ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                    CommandType.Text, string.Format(@"SELECT * FROM emprestimos WHERE DESCRICAO LIKE '%{0}%'", descricao));
            }

            List<Base> ba = new List<Base>();

            while (dr.Read())
            {
                Base bas = new Base();
                bas.PesId1 = int.Parse(dr["ID"].ToString());
                bas.PesCodigo = dr["CODIGO"].ToString();
                bas.PesDescricao = dr["DESCRICAO"].ToString();

                ba.Add(bas);
            }
            return ba;
        }

    }
}
