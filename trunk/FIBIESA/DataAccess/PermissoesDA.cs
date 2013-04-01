using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using InfrastructureSqlServer.Helpers;
using FG;

namespace DataAccess
{
    public class PermissoesDA
    {
        Utils utils = new Utils();
        #region funcoes
        private List<Permissoes> CarregarObjPermissao(SqlDataReader dr)
        {
            List<Permissoes> permissoes = new List<Permissoes>();

            while (dr.Read())
            {
                Permissoes per = new Permissoes();
                per.Id = int.Parse(dr["ID"].ToString());               
                per.Consultar = bool.Parse(dr["CONSULTAR"].ToString());                
                per.Editar = bool.Parse(dr["EDITAR"].ToString());
                per.Excluir = bool.Parse(dr["EXCLUIR"].ToString());
                per.Inserir = bool.Parse(dr["INSERIR"].ToString());
                per.FormularioId = int.Parse(dr["FORMULARIOID"].ToString());
                per.CategoriaId = int.Parse(dr["CATEGORIAID"].ToString());
                               
                permissoes.Add(per);
            }

            return permissoes;
        }
        #endregion
        public bool InserirDA(Permissoes per)
        {
            SqlParameter[] paramsToSP = new SqlParameter[6];

           
            paramsToSP[0] = new SqlParameter("@consultar", per.Consultar);
            paramsToSP[1] = new SqlParameter("@inserir", per.Inserir);
            paramsToSP[2] = new SqlParameter("@editar", per.Editar);
            paramsToSP[3] = new SqlParameter("@excluir", per.Excluir);
            paramsToSP[4] = new SqlParameter("@formularioid", per.FormularioId);
            paramsToSP[5] = new SqlParameter("@categoriaid", per.CategoriaId);

            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_insert_permissoes", paramsToSP);

            return true;
        }

        public bool EditarDA(Permissoes per)
        {
            SqlParameter[] paramsToSP = new SqlParameter[7];

            paramsToSP[0] = new SqlParameter("@id", per.Id);           
            paramsToSP[1] = new SqlParameter("@consultar", per.Consultar);
            paramsToSP[2] = new SqlParameter("@inserir", per.Inserir);
            paramsToSP[3] = new SqlParameter("@editar", per.Editar);
            paramsToSP[4] = new SqlParameter("@excluir", per.Excluir);
            paramsToSP[5] = new SqlParameter("@formularioid", per.FormularioId);
            paramsToSP[6] = new SqlParameter("@categoriaid", per.CategoriaId);

            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_update_permissoes", paramsToSP);

            return true;
        }

        public bool ExcluirDA(Permissoes per)
        {
            SqlParameter[] paramsToSP = new SqlParameter[1];

            paramsToSP[0] = new SqlParameter("@id", per.Id);

            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_delete_Permissoes", paramsToSP);

            return true;
        }

        public List<Permissoes> PesquisarDA()
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, @"SELECT * FROM PERMISSOES ");

            List<Permissoes> permissoes = CarregarObjPermissao(dr);
            
            return permissoes;
        }

        public List<Permissoes> PesquisarDA(int id_cat)
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, string.Format(@"SELECT PER.* " +
                                                                                                 " FROM PERMISSOES PER " +
                                                                                                 "     ,FORMULARIOS F " +
                                                                                                 " WHERE PER.FORMULARIOID = F.ID " +
                                                                                                 " AND PER.CATEGORIAID = {0} ", id_cat));

            List<Permissoes> permissoes = CarregarObjPermissao(dr);
            
            return permissoes;
        }

        public List<Permissoes> PesquisarDA(int id_categoria, int id_formulario)
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, string.Format(@"SELECT PER.* " + 
                                                                                                 " FROM PERMISSOES PER " +
                                                                                                 "     ,FORMULARIOS F " +                                                                                                 
                                                                                                 " WHERE PER.FORMULARIOID = F.ID " +
                                                                                                 " AND PER.CATEGORIAID = {0} " +
                                                                                                 " AND F.ID = {1} ", id_categoria, id_formulario));

            List<Permissoes> permissoes = CarregarObjPermissao(dr);
                        
            return permissoes;
        }

        public List<Permissoes> PesquisarDA(int id_categoria, string nome)
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, string.Format(@"SELECT PER.* " +
                                                                                                 " FROM PERMISSOES PER " +
                                                                                                 "     ,FORMULARIOS F " +
                                                                                                 " WHERE PER.FORMULARIOID = F.ID " +
                                                                                                 " AND PER.CATEGORIAID = {0} " +
                                                                                                 " AND F.NOME = '{1}' " +
                                                                                                 " AND PER.CONSULTAR = 1 ", id_categoria, nome));

            List<Permissoes> permissoes = CarregarObjPermissao(dr);
            

            return permissoes;
        }        
                
    }
}
