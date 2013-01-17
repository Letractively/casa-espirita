using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using DataAccess;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using InfrastructureSqlServer.Helpers;

namespace DataAccess
{
    public class CategoriasDA : BaseDA
    {
        public bool InserirDA(Categorias cat)
        {
            SqlParameter[] paramsToSP = new SqlParameter[2];

            paramsToSP[0] = new SqlParameter("@codigo", cat.Codigo);
            paramsToSP[1] = new SqlParameter("@descricao", cat.Descricao);

            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_insert_categorias", paramsToSP);

            return true;
        }

        public bool EditarDA(Categorias cat)
        {
            SqlParameter[] paramsToSP = new SqlParameter[3];

            paramsToSP[0] = new SqlParameter("@id", cat.Id);
            paramsToSP[1] = new SqlParameter("@codigo", cat.Codigo);
            paramsToSP[2] = new SqlParameter("@descricao", cat.Descricao);

            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_update_categorias", paramsToSP);

            return true;
        }

        public bool ExcluirDA(Categorias cat)
        {
            SqlParameter[] paramsToSP = new SqlParameter[1];

            paramsToSP[0] = new SqlParameter("@id", cat.Id);

            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_delete_categorias", paramsToSP);

            return true;
        }

        public List<Categorias> PesquisarDA()
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, @"SELECT * FROM CATEGORIAS ");

            List<Categorias> categorias = new List<Categorias>();

            while (dr.Read())
            {
                Categorias cat = new Categorias();
                cat.Id = int.Parse(dr["ID"].ToString());
                cat.Codigo = int.Parse(dr["CODIGO"].ToString());
                cat.Descricao = dr["DESCRICAO"].ToString();

                categorias.Add(cat);
            }
            return categorias;
        }

        public List<Categorias> PesquisarDA(int id_cat)
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, string.Format(@"SELECT * FROM CATEGORIAS WHERE ID = {0}",id_cat));

            List<Categorias> categorias = new List<Categorias>();

            while (dr.Read())
            {
                Categorias cat = new Categorias();
                cat.Id = int.Parse(dr["ID"].ToString());
                cat.Codigo = int.Parse(dr["CODIGO"].ToString());
                cat.Descricao = dr["DESCRICAO"].ToString();

                categorias.Add(cat);
            }
            return categorias;
        }

        public override List<Base> Pesquisar(string descricao, string tipo)
        {
            SqlDataReader dr;
            
            if (tipo == "C")
            {
                int codigo = 0;
                Int32.TryParse(descricao,out codigo);

                dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                       CommandType.Text, string.Format(@"SELECT * " +
                                                                                       " FROM CATEGORIAS WHERE CODIGO = '{0}'", codigo));
            }
            else
            {
                dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                      CommandType.Text, string.Format(@"SELECT * " +
                                                                                       " FROM CATEGORIAS WHERE DESCRICAO LIKE '%{0}%'", descricao));
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
