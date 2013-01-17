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
    public class BairrosDA : BaseDA
    {
        public bool InserirDA(Bairros bai)
        {
            SqlParameter[] paramsToSP = new SqlParameter[2];

            paramsToSP[0] = new SqlParameter("@codigo", bai.Codigo); 
            paramsToSP[1] = new SqlParameter("@descricao", bai.Descricao);       
            
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_insert_bairros", paramsToSP);
                           
            return true;
        }

        public bool EditarDA(Bairros bai)
        {
            SqlParameter[] paramsToSP = new SqlParameter[3];

            paramsToSP[0] = new SqlParameter("@id", bai.Id);
            paramsToSP[1] = new SqlParameter("@codigo", bai.Codigo);
            paramsToSP[2] = new SqlParameter("@descricao", bai.Descricao);

            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_update_bairros", paramsToSP);

            return true;
        }

        public bool ExcluirDA(Bairros bai)
        {
            SqlParameter[] paramsToSP = new SqlParameter[1];

            paramsToSP[0] = new SqlParameter("@id", bai.Id);

            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_delete_bairros", paramsToSP); 

            return true;
        }

        public List<Bairros> PesquisarDA()
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(), 
                                                                CommandType.Text, string.Format(@"SELECT * FROM BAIRROS "));

            List<Bairros> bairros = new List<Bairros>();

            while (dr.Read())
            {
                Bairros bai = new Bairros();
                bai.Id = int.Parse(dr["ID"].ToString());
                bai.Codigo = int.Parse(dr["CODIGO"].ToString());
                bai.Descricao = dr["DESCRICAO"].ToString();

                bairros.Add(bai);
            }
            return bairros;
        }

        public List<Bairros> PesquisarDA(int id_bai)
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                       CommandType.Text, string.Format(@"SELECT * " +
                                                                                       " FROM BAIRROS WHERE ID = {0}", id_bai));

            List<Bairros> bairros = new List<Bairros>();

            while (dr.Read())
            {
                Bairros bai = new Bairros();
                bai.Id = int.Parse(dr["ID"].ToString());
                bai.Codigo = int.Parse(dr["CODIGO"].ToString());
                bai.Descricao = dr["DESCRICAO"].ToString();

                bairros.Add(bai);
            }
            return bairros;
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
                                                                                       " FROM BAIRROS WHERE CODIGO = '{0}'", codigo));
            }
            else
            {
                dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                      CommandType.Text, string.Format(@"SELECT * " +
                                                                                       " FROM BAIRROS WHERE DESCRICAO LIKE '%{0}%'", descricao));
            }

            List<Base> ba = new List<Base>();

            while (dr.Read())
            {
                Base bas = new Base();
                bas.PesId1 = int.Parse(dr["ID"].ToString());
                bas.PesCodigo = dr["UF"].ToString();
                bas.PesDescricao = dr["DESCRICAO"].ToString();

                ba.Add(bas);
            }
            return ba;
        }    
    }
}
