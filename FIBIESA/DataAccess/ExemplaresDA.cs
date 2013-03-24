using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using FG;
using System.Data.SqlClient;
using InfrastructureSqlServer.Helpers;
using System.Configuration;
using System.Data;


namespace DataAccess
{
    public class ExemplaresDA : BaseDA
    {
        
        Utils utils = new Utils();
        #region funcoes
        private List<Exemplares> CarregarObjExemplares(SqlDataReader dr)
        {
            List<Exemplares> tipoObra = new List<Exemplares>();

            while (dr.Read())
            {
                Exemplares tipo = new Exemplares();
                tipo.Id = int.Parse(dr["ID"].ToString());
                tipo.Obraid = int.Parse(dr["OBRAID"].ToString());
                tipo.Tombo = int.Parse(dr["TOMBO"].ToString());
                tipo.Status = dr["STATUS"].ToString();

                ObrasDA obDA = new ObrasDA();
                List<Obras> ob = obDA.PesquisarDA(tipo.Obraid);
                Obras obras = new Obras();

                foreach (Obras ltObr in ob)
                {
                    obras.Id = ltObr.Id;
                    obras.Codigo = ltObr.Codigo;
                    obras.Titulo = ltObr.Titulo;

                    tipo.Obras = obras;
                }

                tipoObra.Add(tipo);
            }

            return tipoObra;
        }
        #endregion

        public bool InserirDA(Exemplares instancia)
        {
            SqlParameter[] paramsToSP = new SqlParameter[3];

            paramsToSP[0] = new SqlParameter("@obraid", instancia.Obraid);
            paramsToSP[1] = new SqlParameter("@status", instancia.Status);
            paramsToSP[2] = new SqlParameter("@tombo", instancia.Tombo);

            try
            {
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                           CommandType.StoredProcedure, "stp_insert_tiposObras", paramsToSP);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public bool EditarDA(Exemplares instancia)
        {
            SqlParameter[] paramsToSP = new SqlParameter[4];

            paramsToSP[0] = new SqlParameter("@id", instancia.Id);
            paramsToSP[1] = new SqlParameter("@obraid", instancia.Obraid);
            paramsToSP[2] = new SqlParameter("@status", instancia.Status);
            paramsToSP[3] = new SqlParameter("@tombo", instancia.Tombo);

            try
            {
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                            CommandType.StoredProcedure, "stp_update_tiposObras", paramsToSP);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool ExcluirDA(Exemplares instancia)
        {
            SqlParameter[] paramsToSP = new SqlParameter[1];

            paramsToSP[0] = new SqlParameter("@id", instancia.Id);

            try
            {
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                            CommandType.StoredProcedure, "stp_delete_tiposObras", paramsToSP);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public List<Exemplares> PesquisarDA()
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(
                ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                CommandType.Text, string.Format(@"SELECT * FROM EXEMPLARES "));
            return CarregarObjExemplares(dr);
        }

        public List<Exemplares> PesquisarDA(int id)
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(
                ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                CommandType.Text, string.Format(@"SELECT * FROM EXEMPLARES  WHERE ID = {0}", id));
            return CarregarObjExemplares(dr);
        }

        public List<Exemplares> PesquisarDA(string campo, string valor)
        {
            StringBuilder consulta = new StringBuilder("SELECT * FROM EXEMPLARES ");

            switch (campo.ToUpper())
            {
                case "CODIGO":
                    consulta.Append(string.Format("WHERE CODIGO = {0}", utils.ComparaIntComZero(valor)));
                    break;
                case "DESCRICAO":
                    consulta.Append(string.Format("WHERE DESCRICAO  LIKE '%{0}%'", valor));
                    break;
                default:
                    break;
            }

            SqlDataReader dr = SqlHelper.ExecuteReader(
                ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                CommandType.Text, consulta.ToString());

            return CarregarObjExemplares(dr);
        }

        public override List<Base> Pesquisar(string descricao, string tipo)
        {
            SqlDataReader dr;

            if (tipo == "C")
            {
                int codigo = 0;
                Int32.TryParse(descricao, out codigo);

                dr = SqlHelper.ExecuteReader(
                    ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                    CommandType.Text, string.Format(@"SELECT * FROM EXEMPLARES WHERE CODIGO = '{0}'", codigo));
            }
            else
            {
                dr = SqlHelper.ExecuteReader(
                    ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                    CommandType.Text, string.Format(@"SELECT * FROM EXEMPLARES WHERE DESCRICAO LIKE '%{0}%'", descricao));
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