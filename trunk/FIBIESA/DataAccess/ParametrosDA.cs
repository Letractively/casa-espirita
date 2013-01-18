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
    public class ParametrosDA
    {
        public bool InserirDA(Parametros par)
        {
            SqlParameter[] paramsToSP = new SqlParameter[4];

            paramsToSP[0] = new SqlParameter("@codigo", par.Codigo);
            paramsToSP[1] = new SqlParameter("@descricao", par.Descricao);
            paramsToSP[2] = new SqlParameter("@valor", par.Valor);
            paramsToSP[3] = new SqlParameter("@modulo", par.Modulo);

            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_insert_parametros", paramsToSP);

            return true;
        }

        public bool EditarDA(Parametros par)
        {
            SqlParameter[] paramsToSP = new SqlParameter[5];

            paramsToSP[0] = new SqlParameter("@id", par.Id);
            paramsToSP[1] = new SqlParameter("@codigo", par.Codigo);
            paramsToSP[2] = new SqlParameter("@descricao", par.Descricao);
            paramsToSP[3] = new SqlParameter("@valor", par.Valor);
            paramsToSP[4] = new SqlParameter("@modulo", par.Modulo);

            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_update_parametros", paramsToSP);

            return true;
        }

        public bool ExcluirDA(Parametros par)
        {
            SqlParameter[] paramsToSP = new SqlParameter[1];

            paramsToSP[0] = new SqlParameter("@id", par.Id);

            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_delete_parametros", paramsToSP);

            return true;
        }

        public List<Parametros> PesquisarDA()
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, @"SELECT * FROM PARAMETROS ");

            List<Parametros> parametros = new List<Parametros>();

            while (dr.Read())
            {
                Parametros par = new Parametros();
                par.Id = int.Parse(dr["ID"].ToString());
                par.Descricao = dr["DESCRICAO"].ToString();
                par.Valor = dr["VALOR"].ToString();
                par.Modulo = dr["MODULO"].ToString();

                parametros.Add(par);
            }
            return parametros;
        }

        public List<Parametros> PesquisarDA(int id_par)
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, string.Format(@"SELECT * FROM PARAMETROS WHERE ID = {0}",id_par));

            List<Parametros> parametros = new List<Parametros>();

            while (dr.Read())
            {
                Parametros par = new Parametros();
                par.Id = int.Parse(dr["ID"].ToString());
                par.Descricao = dr["DESCRICAO"].ToString();
                par.Valor = dr["VALOR"].ToString();
                par.Modulo = dr["MODULO"].ToString();

                parametros.Add(par);
            }
            return parametros;
        }

        public List<Parametros> PesquisarDA(string descricao)
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, string.Format(@"SELECT * FROM PARAMETROS WHERE DESCRICAO = '{0}'", descricao.Trim()));

            List<Parametros> parametros = new List<Parametros>();

            while (dr.Read())
            {
                Parametros par = new Parametros();
                par.Id = int.Parse(dr["ID"].ToString());
                par.Descricao = dr["DESCRICAO"].ToString();
                par.Valor = dr["VALOR"].ToString();               

                parametros.Add(par);
            }
            return parametros;
        }
    }
}
