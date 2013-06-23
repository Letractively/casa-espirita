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

            try
            {
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_insert_permissoes", paramsToSP);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
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

            try
            {
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_update_permissoes", paramsToSP);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool ExcluirDA(Permissoes per)
        {
            SqlParameter[] paramsToSP = new SqlParameter[1];

            paramsToSP[0] = new SqlParameter("@id", per.Id);

            try
            {
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_delete_Permissoes", paramsToSP);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
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

        public DataSet PesquisarPermissoesDA(int id_cat)
        {

            DataSet ds = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, string.Format(@"SELECT CASE FMOD.MO " +
                                                                                                "  WHEN 'F' THEN 'A' " +
                                                                                                "  WHEN 'B' THEN 'B' " + 
                                                                                                "  WHEN 'E' THEN 'C' " +
                                                                                                "  WHEN 'V' THEN 'D' " +
                                                                                                "  WHEN 'G' THEN 'E' " +
                                                                                                "  WHEN 'C' THEN 'F' " +
                                                                                                "  ELSE ' ' END AS MO " +
                                                                                                " , CASE FMOD.M " +
                                                                                                "      WHEN 'F' THEN 'Financeiro' " +
                                                                                                "      WHEN 'B' THEN 'Biblioteca'  " +
                                                                                                "      WHEN 'E' THEN 'Estoque'  " +
                                                                                                "      WHEN 'V' THEN 'Evento' " +
                                                                                                "      WHEN 'G' THEN 'Geral' " +
                                                                                                "      WHEN 'C' THEN 'Configuração'" +
                                                                                                "      ELSE ' ' END AS DESMODULO " +
                                                                                                " FROM(SELECT distinct F.MODULO MO,  F.MODULO M " +
                                                                                                "        FROM PERMISSOES PER " +
                                                                                                "            ,FORMULARIOS F  " +
                                                                                                "       WHERE PER.FORMULARIOID = F.ID   " +
                                                                                                "         AND PER.CONSULTAR = 1   " +
                                                                                                "         AND PER.CATEGORIAID = {0}   " +
                                                                                                "         AND F.TIPO = 'V') FMOD  " +
                                                                                                "  ORDER BY MO " +
                                                                                                "; " +
                                                                                                @"SELECT F.DESCRICAO "+
                                                                                                 "      ,F.NOME " +
                                                                                                 "      ,F.TIPO " +
                                                                                                 "      ,CASE F.MODULO " +
                                                                                                 "       WHEN 'F' THEN 'Financeiro'" +
                                                                                                 "       WHEN 'B' THEN 'Biblioteca'" +
                                                                                                 "       WHEN 'E' THEN 'Estoque'" +
                                                                                                 "       WHEN 'V' THEN 'Evento'" +
                                                                                                 "       WHEN 'G' THEN 'Geral'" +
                                                                                                 "       WHEN 'C' THEN 'Configuração'" +
                                                                                                 "       ELSE ' ' END AS DESMODULO" +
                                                                                                 " FROM PERMISSOES PER " +
                                                                                                 "     ,FORMULARIOS F " +
                                                                                                 " WHERE PER.FORMULARIOID = F.ID " +
                                                                                                 " AND PER.CONSULTAR = 1 " +
                                                                                                 " AND PER.CATEGORIAID = {0} " +
                                                                                                 " AND F.TIPO = 'V' "+
                                                                                                 " ORDER BY F.ID ", id_cat));
            
          return ds;
        }

        public DataSet PesquisarModulosDA(int id_cat)
        {
            
            DataSet ds = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                               CommandType.Text, string.Format(@"SELECT CASE FMOD.M " +
                                                                                                "      WHEN 'F' THEN 'Financeiro' " +
                                                                                                "      WHEN 'B' THEN 'Biblioteca'  " +
                                                                                                "      WHEN 'E' THEN 'Estoque'  " +
                                                                                                "      WHEN 'V' THEN 'Evento' " +
                                                                                                "      WHEN 'G' THEN 'Geral' " +
                                                                                                "      WHEN 'C' THEN 'Configuração'" +
                                                                                                "      ELSE ' ' END AS DESMODULO " +
                                                                                                " FROM(SELECT distinct F.MODULO m " +
                                                                                                "        FROM PERMISSOES PER " +
                                                                                                "            ,FORMULARIOS F  " +
                                                                                                "       WHERE PER.FORMULARIOID = F.ID   " +
                                                                                                "         AND PER.CONSULTAR = 1   " +
                                                                                                "         AND PER.CATEGORIAID = {0}   " +
                                                                                                "         AND F.TIPO = 'V') FMOD ", id_cat));


            return ds;
                     

        }                
    }
}
