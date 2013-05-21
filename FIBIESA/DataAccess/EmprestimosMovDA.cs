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
    public class EmprestimosMovDA : BaseDA
    {
        Utils utils = new Utils();
        #region funcoes
        private List<EmprestimosMov> CarregarObjEmpMov(SqlDataReader dr)
        {
            List<EmprestimosMov> empMov = new List<EmprestimosMov>();

            while (dr.Read())
            {
                EmprestimosMov instanciaLoop = new EmprestimosMov();
                instanciaLoop.Id = int.Parse(dr["ID"].ToString());
                instanciaLoop.EmprestimoId = int.Parse(dr["EMPRESTIMOID"].ToString());
                instanciaLoop.DataEmprestimo = Convert.ToDateTime(dr["DATAEMPRESTIMO"].ToString());
                instanciaLoop.DataDevolucao = Convert.ToDateTime(dr["DATADEVOLUCAO"].ToString());
                instanciaLoop.DataPrevistaEmprestimo = Convert.ToDateTime(dr["DATAPREVISTAEMPRESTIMO"].ToString());

                empMov.Add(instanciaLoop);
            }

            return empMov;
        }
        #endregion

        public bool InserirDA(EmprestimosMov instancia)
        {
            SqlParameter[] paramsToSP = new SqlParameter[4];

            paramsToSP[0] = new SqlParameter("@emprestimoid", instancia.EmprestimoId);
            paramsToSP[1] = new SqlParameter("@datadevolucao", instancia.DataDevolucao);
            paramsToSP[2] = new SqlParameter("@dataemprestimo", instancia.DataEmprestimo);
            paramsToSP[3] = new SqlParameter("@dataprevistaemprestimo", instancia.DataPrevistaEmprestimo);

            return (SqlHelper.ExecuteNonQuery(
                ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                CommandType.StoredProcedure, "stp_insert_emprestimoMov", paramsToSP) > 0);
        }

        public bool EditarDA(EmprestimosMov instancia)
        {
            SqlParameter[] paramsToSP = new SqlParameter[5];

            paramsToSP[0] = new SqlParameter("@id", instancia.Id);
            paramsToSP[1] = new SqlParameter("@emprestimoid", instancia.EmprestimoId);
            paramsToSP[2] = new SqlParameter("@datadevolucao", instancia.DataDevolucao);
            paramsToSP[3] = new SqlParameter("@dataemprestimo", instancia.DataEmprestimo);
            paramsToSP[4] = new SqlParameter("@dataprevistaemprestimo", instancia.DataPrevistaEmprestimo);

            return (SqlHelper.ExecuteNonQuery(
                ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                CommandType.StoredProcedure, "stp_update_emprestimoMov", paramsToSP) > 0);
        }

        public bool ExcluirDA(EmprestimosMov instancia)
        {
            SqlParameter[] paramsToSP = new SqlParameter[1];

            paramsToSP[0] = new SqlParameter("@id", instancia.Id);

            return (SqlHelper.ExecuteNonQuery(
                ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                CommandType.StoredProcedure, "stp_delete_emprestimoMov", paramsToSP) > 0);
        }

        public List<EmprestimosMov> PesquisarDA()
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(
                ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                CommandType.Text, string.Format(@"SELECT * FROM EMPRESTIMOMOV "));
            return CarregarObjEmpMov(dr);
        }

        public List<EmprestimosMov> PesquisarDA(int id)
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(
                ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                CommandType.Text, string.Format(@"SELECT * FROM EMPRESTIMOMOV  WHERE ID = {0}", id));
            return CarregarObjEmpMov(dr);
        }

        public List<EmprestimosMov> PesquisarDA(string campo, string valor)
        {
            StringBuilder consulta = new StringBuilder("SELECT * FROM EMPRESTIMOMOV ");

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

            return CarregarObjEmpMov(dr);
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
                    CommandType.Text, string.Format(@"SELECT * FROM EMPRESTIMOMOV WHERE CODIGO = '{0}'", codigo));
            }
            else
            {
                dr = SqlHelper.ExecuteReader(
                    ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                    CommandType.Text, string.Format(@"SELECT * FROM EMPRESTIMOMOV WHERE DESCRICAO LIKE '%{0}%'", descricao));
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
