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
using FG;

namespace DataAccess
{
    public class UsuariosDA
    {
        Utils utils = new Utils();

        #region funcoes
        private List<Usuarios> CarregarObjUsuario(SqlDataReader dr)
        {
            List<Usuarios> usuarios = new List<Usuarios>();
            
            while (dr.Read())
            {
                Usuarios usu = new Usuarios();
                Categorias cat = new Categorias();
                Pessoas pes = new Pessoas();

                usu.Id = int.Parse(dr["ID"].ToString());
                usu.Login = dr["LOGIN"].ToString();
                usu.Senha =null;
                usu.Nome = dr["NOME"].ToString();
                usu.Status = dr["STATUS"].ToString();
                usu.DtInicio = Convert.ToDateTime(dr["DTINICIO"].ToString());
                usu.DtFim = Convert.ToDateTime(dr["DTFIM"].ToString());
                usu.Tipo = dr["TIPO"].ToString();
                usu.Email = dr["EMAIL"].ToString();
                usu.PessoaId = utils.ComparaIntComNull(dr["PESSOAID"].ToString());
                usu.NrTentLogin = utils.ComparaIntComNull(dr["NRTENTLOGIN"].ToString());
                usu.DhTentLogin = utils.ComparaDataComNull(dr["DHTENTLOGIN"].ToString());
                usu.CategoriaId = utils.ComparaIntComZero(dr["CATEGORIAID"].ToString());

                cat.Id = int.Parse(dr["CATEGORIAID"].ToString());
                cat.Codigo = int.Parse(dr["CODCAT"].ToString());
                cat.Descricao = dr["DESCAT"].ToString();

                usu.Categoria = cat;

                if (utils.ComparaIntComZero(dr["PESSOAID"].ToString()) > 0)
                {
                    pes.Id = int.Parse(dr["PESSOAID"].ToString());
                    pes.Codigo = int.Parse(dr["PESCOD"].ToString());
                    pes.Nome = dr["PESNOME"].ToString();
                    usu.Pessoa = pes;
                }
                
                usuarios.Add(usu);
            }

            return usuarios;        
        }
                
        #endregion

        public bool InserirDA(Usuarios usu)
        {
            SqlParameter[] paramsToSP = new SqlParameter[12];

            paramsToSP[0] = new SqlParameter("@login", usu.Login);
            paramsToSP[1] = new SqlParameter("@senha", utils.Criptografar(usu.Senha));
            paramsToSP[2] = new SqlParameter("@nome", usu.Nome.ToUpper());
            paramsToSP[3] = new SqlParameter("@status", usu.Status);
            paramsToSP[4] = new SqlParameter("@dtinicio", usu.DtInicio);
            paramsToSP[5] = new SqlParameter("@dtfim", usu.DtFim);
            paramsToSP[6] = new SqlParameter("@tipo", usu.Tipo);
            paramsToSP[7] = new SqlParameter("@email", usu.Email);
            paramsToSP[8] = new SqlParameter("@pessoaid", usu.PessoaId);
            paramsToSP[9] = new SqlParameter("@nrtentlogin", usu.NrTentLogin);
            paramsToSP[10] = new SqlParameter("@dhtentlogin", usu.DhTentLogin);
            paramsToSP[11] = new SqlParameter("@categoriaid", usu.CategoriaId);

            try
            {
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_insert_usuarios", paramsToSP);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool EditarDA(Usuarios usu)
        {
            SqlParameter[] paramsToSP = new SqlParameter[13];

            paramsToSP[0] = new SqlParameter("@id", usu.Id);
            paramsToSP[1] = new SqlParameter("@login", usu.Login);
            string senha = utils.Criptografar(usu.Senha);
            if (senha == string.Empty)
                senha = null;
            paramsToSP[2] = new SqlParameter("@senha", senha);
            paramsToSP[3] = new SqlParameter("@nome", usu.Nome.ToUpper());
            paramsToSP[4] = new SqlParameter("@status", usu.Status);
            paramsToSP[5] = new SqlParameter("@dtinicio", usu.DtInicio);
            paramsToSP[6] = new SqlParameter("@dtfim", usu.DtFim);
            paramsToSP[7] = new SqlParameter("@tipo", usu.Tipo);
            paramsToSP[8] = new SqlParameter("@email", usu.Email);
            paramsToSP[9] = new SqlParameter("@pessoaid", usu.PessoaId);
            paramsToSP[10] = new SqlParameter("@nrtentlogin", usu.NrTentLogin);
            paramsToSP[11] = new SqlParameter("@dhtentlogin", usu.DhTentLogin);
            paramsToSP[12] = new SqlParameter("@categoriaid", usu.CategoriaId);

            try
            {
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_update_usuarios", paramsToSP);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public bool ExcluirDA(Usuarios usu)
        {
            SqlParameter[] paramsToSP = new SqlParameter[1];

            paramsToSP[0] = new SqlParameter("@id", usu.Id);

            try
            {
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_delete_usuarios", paramsToSP);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<Usuarios> PesquisarDA()
        {
            StringBuilder consulta = new StringBuilder(); 
            consulta.Append(@"SELECT U.*, C.CODIGO CODCAT, C.DESCRICAO DESCAT, P.CODIGO PESCOD, P.NOME PESNOME ");
            consulta.Append(@"  FROM USUARIOS U ");
            consulta.Append(@"  INNER JOIN CATEGORIAS C ON C.ID = U.CATEGORIAID ");
            consulta.Append(@"  LEFT JOIN  PESSOAS P ON P.ID = U.PESSOAID");
           
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, consulta.ToString());

            List<Usuarios> usuarios = CarregarObjUsuario(dr);
                       
            return usuarios;
        }

        public List<Usuarios> PesquisarDA(string campo, string valor)
        {
            StringBuilder consulta = new StringBuilder();
            consulta.Append(@"SELECT U.*, C.CODIGO CODCAT, C.DESCRICAO DESCAT, P.CODIGO PESCOD, P.NOME PESNOME ");
            consulta.Append(@"  FROM USUARIOS U ");
            consulta.Append(@"  INNER JOIN CATEGORIAS C ON C.ID = U.CATEGORIAID ");
            consulta.Append(@"  LEFT JOIN  PESSOAS P ON P.ID = U.PESSOAID");
            
            switch (campo.ToUpper())
            {
                case "NOME":
                    consulta.Append(@" WHERE P.NOME LIKE '%{0}%' ");
                    break;             
                default:
                    consulta.Clear();
                    break;
            }

            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                              CommandType.Text, string.Format(consulta.ToString(),valor));

            List<Usuarios> usuarios = CarregarObjUsuario(dr);

            return usuarios;
        }

        public List<Usuarios> PesquisarDA(int id_usu)
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text,string.Format(@"SELECT * FROM USUARIOS WHERE ID = {0}",id_usu));
            
            List<Usuarios> usuarios = CarregarObjUsuario(dr);             
            
            return usuarios;
        }

        public List<Usuarios> PesquisarBuscaDA(string valor)
        {
            StringBuilder consulta = new StringBuilder();
            consulta.Append(@"SELECT U.*, C.CODIGO CODCAT, C.DESCRICAO DESCAT, P.CODIGO PESCOD, P.NOME PESNOME ");
            consulta.Append(@"  FROM USUARIOS U ");
            consulta.Append(@"  INNER JOIN CATEGORIAS C ON C.ID = U.CATEGORIAID ");
            consulta.Append(@"  LEFT JOIN  PESSOAS P ON P.ID = U.PESSOAID");
            
            if (valor != "" && valor != null)
                consulta.Append(string.Format(" WHERE U.NOME  LIKE '%{0}%'", valor));

            consulta.Append(" ORDER BY U.NOME ");

            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, consulta.ToString());

            List<Usuarios> usuarios = CarregarObjUsuario(dr);

            return usuarios;
        }

        public List<Usuarios> PesquisarDA(string login, string senha, DateTime data)
        {
            StringBuilder consulta = new StringBuilder();
            consulta.Append(@"SELECT U.*, C.CODIGO CODCAT, C.DESCRICAO DESCAT, P.CODIGO PESCOD, P.NOME PESNOME ");
            consulta.Append(@"  FROM USUARIOS U ");
            consulta.Append(@" INNER JOIN CATEGORIAS C ON C.ID = U.CATEGORIAID ");
            consulta.Append(@"  LEFT JOIN  PESSOAS P ON P.ID = U.PESSOAID");
            consulta.Append(@" WHERE U.LOGIN = '{0}' ");
            consulta.Append(@"   AND U.SENHA = '{1}' ");
            consulta.Append(@"   AND U.STATUS = 'A' ");
            
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, string.Format(consulta.ToString(), login, utils.Criptografar(senha)));
           
            List<Usuarios> usuarios = CarregarObjUsuario(dr);
            
            return usuarios;
        }

        public DataSet PesquisarDAEmail(string email)
        {
            StringBuilder sqlQuery = new StringBuilder();
            sqlQuery.Append(@"SELECT email, login, senha, nome ");
            sqlQuery.Append(@" FROM usuarios  "); 
            sqlQuery.Append(@" WHERE email = '{0}'");
           
            DataSet ds = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                      CommandType.Text, string.Format(sqlQuery.ToString(),email));
            return ds;
        }
                
        // string.Format(@"SELECT * " +
        //" FROM TURMAS WHERE CODIGO = '{0}' OR DESCRICAO LIKE '%{1}%'",utils.ComparaIntComZero(descricao), descricao));
    }
}
