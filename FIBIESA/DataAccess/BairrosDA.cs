using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using InfrastructureSqlServer.Helpers;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using FG;


namespace DataAccess
{
    public class BairrosDA : BaseDA
    {
        Utils utils = new Utils();
        #region funcoes
        private List<Bairros> CarregarObjBairro(SqlDataReader dr)
        {
            List<Bairros> bairros = new List<Bairros>();

            while (dr.Read())
            {
                Bairros bai = new Bairros();
                bai.Id = int.Parse(dr["ID"].ToString());
                bai.Codigo = int.Parse(dr["CODIGO"].ToString());
                bai.Descricao = dr["DESCRICAO"].ToString();
                bai.CidadeId = utils.ComparaIntComNull(dr["CIDADEID"].ToString());

                if (bai.CidadeId != null)
                {
                    CidadesDA cidDA = new CidadesDA();
                    Cidades cid = new Cidades();
                    DataSet dsCid = cidDA.PesquisaDA(bai.CidadeId != null? utils.ComparaIntComZero(bai.CidadeId.ToString()) : 0);

                    if (dsCid.Tables[0].Rows.Count != 0)
                    {
                        cid.Id = (Int32)dsCid.Tables[0].Rows[0]["id"];
                        cid.Codigo = (Int32)dsCid.Tables[0].Rows[0]["codigo"];
                        cid.Descricao = (string)dsCid.Tables[0].Rows[0]["descricao"];
                        cid.EstadoId = (Int32)dsCid.Tables[0].Rows[0]["estadoid"];
                    }

                    bai.Cidade =  cid;    
                }

                bairros.Add(bai);
            }

            return bairros;
        }
        #endregion
        public bool InserirDA(Bairros bai)
        {
            SqlParameter[] paramsToSP = new SqlParameter[3];

            paramsToSP[0] = new SqlParameter("@codigo", bai.Codigo); 
            paramsToSP[1] = new SqlParameter("@descricao", bai.Descricao);
            paramsToSP[2] = new SqlParameter("@cidadeid", bai.CidadeId);

            try
            {
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_insert_bairros", paramsToSP);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public bool EditarDA(Bairros bai)
        {
            SqlParameter[] paramsToSP = new SqlParameter[4];

            paramsToSP[0] = new SqlParameter("@id", bai.Id);
            paramsToSP[1] = new SqlParameter("@codigo", bai.Codigo);
            paramsToSP[2] = new SqlParameter("@descricao", bai.Descricao);
            paramsToSP[3] = new SqlParameter("@cidadeid", bai.CidadeId);

            try
            {
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_update_bairros", paramsToSP);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool ExcluirDA(Bairros bai)
        {
            SqlParameter[] paramsToSP = new SqlParameter[1];

            paramsToSP[0] = new SqlParameter("@id", bai.Id);

            try
            {
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_delete_bairros", paramsToSP);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<Bairros> PesquisarDA()
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(), 
                                                                CommandType.Text, string.Format(@"SELECT * FROM BAIRROS "));

            List<Bairros> bairros = CarregarObjBairro(dr);
                        
            return bairros;    

        }

        public List<Bairros> PesquisarDA(int id_bai)
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                       CommandType.Text, string.Format(@"SELECT * " +
                                                                                       " FROM BAIRROS WHERE ID = {0}", id_bai));

            List<Bairros> bairros = CarregarObjBairro(dr);
                        
            return bairros;
        }

        public List<Bairros> PesquisarCidDA(int id_cid)
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                       CommandType.Text, string.Format(@"SELECT * " +
                                                                                       " FROM BAIRROS WHERE CIDADEID = {0}", id_cid));

            List<Bairros> bairros = CarregarObjBairro(dr);

            return bairros;
        }

        public List<Bairros> PesquisarDA(string campo, string valor)
        {
            string consulta;

            switch (campo.ToUpper())
            {
                case "CODIGO":
                    consulta = string.Format("SELECT * FROM BAIRROS WHERE CODIGO = {0}", utils.ComparaIntComZero(valor));
                    break;
                case "DESCRICAO":
                    consulta = string.Format("SELECT * FROM BAIRROS WHERE DESCRICAO  LIKE '%{0}%'", valor);
                    break;
                default:
                    consulta = "";
                    break;
            }

            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, consulta);

            List<Bairros> bairros = CarregarObjBairro(dr);

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
                bas.PesCodigo = dr["CODIGO"].ToString();
                bas.PesDescricao = dr["DESCRICAO"].ToString();

                ba.Add(bas);
            }
            return ba;
        }
                
    }
}
