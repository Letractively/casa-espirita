using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using System.Data.SqlClient;
using InfrastructureSqlServer.Helpers;
using System.Configuration;
using System.Data;
using FG;

namespace DataAccess
{
    public class VendasDA
    {
        Utils utils = new Utils();

        #region funcoes
        private List<Vendas> CarregarObjVenda(SqlDataReader dr)
        {
            List<Vendas> vendas = new List<Vendas>();

            while (dr.Read())
            {
                Vendas ven = new Vendas();
                ven.Id = int.Parse(dr["ID"].ToString());
                ven.Numero = utils.ComparaIntComZero(dr["NUMERO"].ToString());
                ven.PessoaId = utils.ComparaIntComZero(dr["PESSOAID"].ToString());
                ven.UsuarioId = utils.ComparaIntComZero(dr["USUARIOID"].ToString());
                ven.Data = Convert.ToDateTime(dr["DATA"].ToString());
                ven.Situacao = dr["SITUACAO"].ToString();
                
                vendas.Add(ven);
            }

            return vendas;
        }
        #endregion

        public bool InserirDA(Vendas ven)
        {
            SqlParameter[] paramsToSP = new SqlParameter[5];

            paramsToSP[0] = new SqlParameter("@numero", ven.Numero);
            paramsToSP[1] = new SqlParameter("@pessoaid", ven.PessoaId);
            paramsToSP[2] = new SqlParameter("@usuarioid", ven.UsuarioId);
            paramsToSP[3] = new SqlParameter("@data", ven.Data);
            paramsToSP[4] = new SqlParameter("@situacao", ven.Situacao);

            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_insert_vendas", paramsToSP);

            return true;
        }

        public bool EditarDA(Vendas ven)
        {
            SqlParameter[] paramsToSP = new SqlParameter[6];

            paramsToSP[0] = new SqlParameter("@id", ven.Id);
            paramsToSP[1] = new SqlParameter("@numero", ven.Numero);
            paramsToSP[2] = new SqlParameter("@pessoaid", ven.PessoaId);
            paramsToSP[3] = new SqlParameter("@usuarioid", ven.UsuarioId);
            paramsToSP[4] = new SqlParameter("@data", ven.Data);
            paramsToSP[5] = new SqlParameter("@situacao", ven.Situacao);

            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_update_vendas", paramsToSP);

            return true;
        }

        public bool ExcluirDA(Vendas ven)
        {
            SqlParameter[] paramsToSP = new SqlParameter[1];

            paramsToSP[0] = new SqlParameter("@id", ven.Id);

            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_delete_vendas", paramsToSP);

            return true;
        }

        public List<Vendas> PesquisarDA()
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, string.Format(@"SELECT * FROM VENDAS "));

            List<Vendas> vendas = CarregarObjVenda(dr);
                        
            return vendas;

        }

        public List<Vendas> PesquisarDA(int id_ven)
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                       CommandType.Text, string.Format(@"SELECT * " +
                                                                                       " FROM VENDAS WHERE ID = {0}", id_ven));

            List<Vendas> vendas = CarregarObjVenda(dr);

            return vendas;
        }
               
    }
}
