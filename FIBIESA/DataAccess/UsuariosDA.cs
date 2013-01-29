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
                usu.Id = int.Parse(dr["ID"].ToString());
                usu.Login = dr["LOGIN"].ToString();
                usu.Senha = dr["SENHA"].ToString();
                usu.Nome = dr["NOME"].ToString();
                usu.Status = dr["STATUS"].ToString();
                usu.DtInicio = utils.ComparaDataComNull(dr["DTINICIO"].ToString());
                usu.DtFim = utils.ComparaDataComNull(dr["DTFIM"].ToString());
                usu.Tipo = dr["TIPO"].ToString();
                usu.Email = dr["EMAIL"].ToString();
                usu.PessoaId = utils.ComparaIntComNull(dr["PESSOAID"].ToString());
                usu.NrTentLogin = utils.ComparaIntComNull(dr["NRTENTLOGIN"].ToString());
                usu.DhTentLogin = utils.ComparaDataComNull(dr["DHTENTLOGIN"].ToString());
                usu.CategoriaId = utils.ComparaIntComZero(dr["CATEGORIAID"].ToString());

                CategoriasDA catDA = new CategoriasDA();
                
                List<Categorias> categorias = catDA.PesquisarDA(usu.CategoriaId);
                Categorias cat = new Categorias();

                foreach (Categorias ltcat in categorias)
                {                    
                    cat.Id = ltcat.Id;
                    cat.Codigo = ltcat.Codigo;
                    cat.Descricao = ltcat.Descricao;                    
                }

                usu.Categoria = cat;

                usuarios.Add(usu);
            }

            return usuarios;        
        }
        #endregion

        public bool InserirDA(Usuarios usu)
        {
            SqlParameter[] paramsToSP = new SqlParameter[11];

            paramsToSP[0] = new SqlParameter("@login", usu.Login);
            paramsToSP[1] = new SqlParameter("@senha", usu.Senha);
            paramsToSP[2] = new SqlParameter("@nome", usu.Nome);
            paramsToSP[3] = new SqlParameter("@status", usu.Status);
            paramsToSP[4] = new SqlParameter("@dtinicio", usu.DtInicio);
            paramsToSP[5] = new SqlParameter("@dtfim", usu.DtFim);
            paramsToSP[6] = new SqlParameter("@tipo", usu.Tipo);
            paramsToSP[7] = new SqlParameter("@email", usu.Email);
            paramsToSP[8] = new SqlParameter("@pessoaid", usu.PessoaId);
            paramsToSP[9] = new SqlParameter("@nrtentlogin", usu.NrTentLogin);
            paramsToSP[10] = new SqlParameter("@dhtentlogin", usu.DhTentLogin);
            //paramsToSP[11] = new SqlParameter("@categoriaid", usu.CategoriaId);

            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_insert_usuarios", paramsToSP);

            return true;
        }

        public bool EditarDA(Usuarios usu)
        {
            SqlParameter[] paramsToSP = new SqlParameter[12];

            paramsToSP[0] = new SqlParameter("@id", usu.Id);
            paramsToSP[1] = new SqlParameter("@login", usu.Login);
            paramsToSP[2] = new SqlParameter("@senha", usu.Senha);
            paramsToSP[3] = new SqlParameter("@nome", usu.Nome);
            paramsToSP[4] = new SqlParameter("@status", usu.Status);
            paramsToSP[5] = new SqlParameter("@dtinicio", usu.DtInicio);
            paramsToSP[6] = new SqlParameter("@dtfim", usu.DtFim);
            paramsToSP[7] = new SqlParameter("@tipo", usu.Tipo);
            paramsToSP[8] = new SqlParameter("@email", usu.Email);
            paramsToSP[9] = new SqlParameter("@pessoaid", usu.PessoaId);
            paramsToSP[10] = new SqlParameter("@nrtentlogin", usu.NrTentLogin);
            paramsToSP[11] = new SqlParameter("@dhtentlogin", usu.DhTentLogin);
            //paramsToSP[12] = new SqlParameter("@categoriaid", usu.CategoriaId);

            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_update_usuarios", paramsToSP);

            return true;
        }

        public bool ExcluirDA(Usuarios usu)
        {
            SqlParameter[] paramsToSP = new SqlParameter[1];

            paramsToSP[0] = new SqlParameter("@id", usu.Id);

            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_delete_usuarios", paramsToSP);

            return true;
        }

        public List<Usuarios> PesquisarDA()
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, @"SELECT * FROM USUARIOS ");

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

        public List<Usuarios> PesquisarDA(string login, string senha)
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, string.Format(@"SELECT * FROM USUARIOS WHERE LOGIN = '{0}' AND SENHA = '{1}' " +
                                                                                                 " AND STATUS = 'A' ", login, senha));

            //string.Format(@"SELECT * FROM USUARIOS WHERE LOGIN = '{0}' AND SENHA = '{1}' " +
            //" AND STATUS = 'A' AND GETDATE() BETWEEN DTINICIO AND DTFIM ", login, senha));

            List<Usuarios> usuarios = CarregarObjUsuario(dr); 

            return usuarios;
        }
    }
}
