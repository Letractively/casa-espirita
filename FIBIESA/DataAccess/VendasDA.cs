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
            PessoasDA pesDA = new PessoasDA();
            UsuariosDA usuDA = new UsuariosDA();

            while (dr.Read())
            {
                Vendas ven = new Vendas();
                ven.Id = int.Parse(dr["ID"].ToString());
                ven.Numero = utils.ComparaIntComZero(dr["NUMERO"].ToString());
                ven.PessoaId = utils.ComparaIntComZero(dr["PESSOAID"].ToString());
                ven.UsuarioId = utils.ComparaIntComZero(dr["USUARIOID"].ToString());
                ven.Data = Convert.ToDateTime(dr["DATA"].ToString());
                ven.Situacao = dr["SITUACAO"].ToString();

                
                List<Pessoas> pes = pesDA.PesquisarDA(ven.PessoaId);
                Pessoas pessoa = new Pessoas();

                foreach (Pessoas ltPes in pes)
                {
                    pessoa.Id = ltPes.Id;
                    pessoa.Codigo = ltPes.Codigo;
                    pessoa.Nome = ltPes.Nome;
                }

                ven.Pessoas = pessoa;

                List<Usuarios> usu = usuDA.PesquisarDA(ven.UsuarioId);
                Usuarios usuarios = new Usuarios();

                foreach (Usuarios ltUsu in usu)
                {
                    usuarios.Id = ltUsu.Id;
                    usuarios.Login = ltUsu.Login;
                    usuarios.Nome = ltUsu.Nome;
                }

                ven.Usuarios = usuarios;                
                
                vendas.Add(ven);
            }

            return vendas;
        }

        private Int32 RetornaMaxNumero()
        {
            Int32 codigo = 1;
            DataSet ds = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                          CommandType.Text, string.Format(@" SELECT ISNULL(MAX(NUMERO),0) + 1 as COD FROM VENDAS "));

            if (ds.Tables[0].Rows.Count != 0)
                codigo = utils.ComparaIntComZero(ds.Tables[0].Rows[0]["COD"].ToString());

            return codigo;
        }

        #endregion

        public Int32 InserirDA(Vendas ven)
        {
            SqlParameter[] paramsToSP = new SqlParameter[5];

            paramsToSP[0] = new SqlParameter("@numero", RetornaMaxNumero());
            paramsToSP[1] = new SqlParameter("@pessoaid", ven.PessoaId);
            paramsToSP[2] = new SqlParameter("@usuarioid", ven.UsuarioId);
            paramsToSP[3] = new SqlParameter("@data", ven.Data);
            paramsToSP[4] = new SqlParameter("@situacao", ven.Situacao);

            try
            {

                DataSet ds = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_insert_vendas", paramsToSP);

                DataTable tabela = ds.Tables[0];

                int id = utils.ComparaIntComZero(tabela.Rows[0]["ID"].ToString());

                return id;
            }
            catch (Exception e)
            {
                return 0;
            }
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

            try
            {
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_update_vendas", paramsToSP);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool ExcluirDA(Vendas ven)
        {
            SqlParameter[] paramsToSP = new SqlParameter[1];

            paramsToSP[0] = new SqlParameter("@id", ven.Id);

            try
            {
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_delete_vendas", paramsToSP);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<Vendas> PesquisarDA()
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, string.Format(@"SELECT * FROM VENDAS "));

            List<Vendas> vendas = CarregarObjVenda(dr);
                        
            return vendas;

        }

        public bool CancelarVendaDA(int id_ven)
        {
            SqlParameter[] paramsToSP = new SqlParameter[1];

            paramsToSP[0] = new SqlParameter("@vendaId", id_ven);

            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                      CommandType.StoredProcedure, "stp_CANCELAR_VENDA", paramsToSP);

                DataTable tabela = ds.Tables[0];

                string resultado = tabela.Rows[0][0].ToString();

                if (resultado == "true")
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<Vendas> PesquisarDA(int id_ven)
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                       CommandType.Text, string.Format(@"SELECT * " +
                                                                                       " FROM VENDAS WHERE ID = {0}", id_ven));

            List<Vendas> vendas = CarregarObjVenda(dr);

            return vendas;
        }

        public List<Vendas> PesquisarBuscaDA(string valor)
        {
            StringBuilder consulta = new StringBuilder(@"SELECT * " +
                                                        "   FROM VENDAS V " +
                                                        "      , PESSOAS P " +
                                                        "      , USUARIOS U " +
                                                        "  WHERE V.PESSOAID = P.ID " +
                                                        "    AND V.USUARIOID = U.ID ");
                                                                

            if (valor != "" && valor != null)
                consulta.Append(string.Format(" AND ( V.NUMERO = {0} OR P.NOME LIKE '%{1}%' OR P.NOMEFANTASIA LIKE '%{1}%' OR U.NOME LIKE '%{1}%' ) "
                                                                                                      , utils.ComparaIntComZero(valor), valor));

            consulta.Append(" ORDER BY V.NUMERO ");

            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, consulta.ToString());

            List<Vendas> vendas = CarregarObjVenda(dr);

            return vendas;

        }
        
        public DataSet PesquisarDADataSet(int id_ven)
        {
            DataSet ds = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                       CommandType.Text, string.Format(@"SELECT  id " +
                                                                                            ",numero " +
                                                                                            ",PessoaId " +
                                                                                            ",pessoa " +
                                                                                            ",cpfCnpj " +
                                                                                            ",usuarioId " +
                                                                                            ",usuario " +
                                                                                            ",data " +
                                                                                            ",situacao " +                                                                                       
                                                                                       " FROM dbo.VIEW_vendas WHERE ID = {0}", id_ven));            
            return ds;
        }
         
               
    }
}
