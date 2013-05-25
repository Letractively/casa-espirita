using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using System.Data;
using System.Data.SqlClient;
using InfrastructureSqlServer.Helpers;
using System.Configuration;
using FG;

namespace DataAccess
{
    public class EventosDA : BaseDA
    {
        Utils utils = new Utils();

        #region funcoes
        private List<Eventos> CarregarObjEventos(SqlDataReader dr)
        {
            List<Eventos> eventos = new List<Eventos>();

            while (dr.Read())
            {
                Eventos eve = new Eventos();
                eve.Id = int.Parse(dr["ID"].ToString());
                eve.Codigo = int.Parse(dr["CODIGO"].ToString());
                eve.Descricao = dr["DESCRICAO"].ToString();
                eve.DtInicio = Convert.ToDateTime(dr["DTINICIO"].ToString());
                eve.DtFim = Convert.ToDateTime(dr["DTFIM"].ToString());                

                eventos.Add(eve);
            }
            return eventos;
        }

        private Int32 RetornaMaxCodigo()
        {
            Int32 codigo = 1;
            DataSet ds = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                          CommandType.Text, string.Format(@" SELECT ISNULL(MAX(CODIGO),0) + 1 as COD FROM EVENTOS "));

            if (ds.Tables[0].Rows.Count != 0)
                codigo = utils.ComparaIntComZero(ds.Tables[0].Rows[0]["COD"].ToString());

            return codigo;

        }
        #endregion
        public bool InserirDA(Eventos eve)
        {
            SqlParameter[] paramsToSP = new SqlParameter[4];

            paramsToSP[0] = new SqlParameter("@codigo", RetornaMaxCodigo());
            paramsToSP[1] = new SqlParameter("@descricao", eve.Descricao);
            paramsToSP[2] = new SqlParameter("@dtinicio", eve.DtInicio);
            paramsToSP[3] = new SqlParameter("@dtfim", eve.DtFim);

            try
            {
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_insert_eventos", paramsToSP);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool EditarDA(Eventos eve)
        {
            SqlParameter[] paramsToSP = new SqlParameter[5];

            paramsToSP[0] = new SqlParameter("@id", eve.Id);
            paramsToSP[1] = new SqlParameter("@codigo", eve.Codigo);
            paramsToSP[2] = new SqlParameter("@descricao", eve.Descricao);
            paramsToSP[3] = new SqlParameter("@dtinicio", eve.DtInicio);
            paramsToSP[4] = new SqlParameter("@dtfim", eve.DtFim);

            try
            {
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_update_eventos", paramsToSP);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public bool ExcluirDA(Eventos eve)
        {
            SqlParameter[] paramsToSP = new SqlParameter[1];

            paramsToSP[0] = new SqlParameter("@id", eve.Id);

            try
            {
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_delete_eventos", paramsToSP);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public List<Eventos> PesquisarDA()
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, string.Format(@"SELECT * FROM EVENTOS "));

            List<Eventos> eventos = CarregarObjEventos(dr);
                        
            return eventos;

        }

        public List<Eventos> PesquisarDA(int id_cur)
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                       CommandType.Text, string.Format(@"SELECT * " +
                                                                                       " FROM EVENTOS WHERE ID = {0}", id_cur));

            List<Eventos> eventos = CarregarObjEventos(dr);

            return eventos;
                      
        }

        public List<Eventos> PesquisarDA(string campo, string valor)
        {
            string consulta;

            switch (campo.ToUpper())
            {
                case "CODIGO":
                    consulta = string.Format("SELECT * FROM EVENTOS WHERE CODIGO = {0}", utils.ComparaIntComZero(valor));
                    break;
                case "DESCRICAO":
                    consulta = string.Format("SELECT * FROM EVENTOS WHERE DESCRICAO  LIKE '%{0}%'", valor);
                    break;
                default:
                    consulta = "";
                    break;
            }

            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, consulta);

            List<Eventos> eventos = CarregarObjEventos(dr);

            return eventos;
        }

        public List<Eventos> PesquisarBuscaDA(string valor)
        {
            StringBuilder consulta = new StringBuilder(@"SELECT * FROM EVENTOS ");

            if (valor != "")
                consulta.Append(string.Format(" WHERE CODIGO = {0} OR  DESCRICAO  LIKE '%{1}%'", utils.ComparaIntComZero(valor), valor));

            consulta.Append(" ORDER BY CODIGO ");

            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, consulta.ToString());

            List<Eventos> eventos = CarregarObjEventos(dr);

            return eventos;
        }

        public override List<Base> Pesquisar(string descricao)
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                      CommandType.Text, string.Format(@"SELECT * " +
                                                                                       " FROM EVENTOS WHERE CODIGO = '{0}' OR DESCRICAO LIKE '%{1}%'",utils.ComparaIntComZero(descricao), descricao));
            
            List<Base> ba = new List<Base>();

            while (dr.Read())
            {
                Base bas = new Base();
                bas.PesId1 = int.Parse(dr["ID"].ToString());
                bas.PesDescricao = dr["DESCRICAO"].ToString();

                ba.Add(bas);
            }
            return ba;
        }

        public List<Base> PesquisarEventos(string codigos)
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                      CommandType.Text, string.Format(@"SELECT * " +
                                                                                       " FROM EVENTOS WHERE CODIGO IN ({0})", codigos));

            List<Base> ba = new List<Base>();

            while (dr.Read())
            {
                Base bas = new Base();
                bas.PesId1 = int.Parse(dr["ID"].ToString());
                bas.PesDescricao = dr["DESCRICAO"].ToString();

                ba.Add(bas);
            }
            return ba;
        }

        public DataSet PesquisarDataSet(string codDes, string dataIni, string dataIniF, string dataFim, string dataFimF)
        {
            StringBuilder sqlQuery = new StringBuilder();
            sqlQuery.Append(@"SELECT codigo " +
                                    ",descricao " +
                                    ",dtInicio " +
                                    ",dtfIM " +
                                " FROM EVENTOS WHERE 1 = 1 ");
            
            if (codDes != string.Empty)
                sqlQuery.Append(@" AND codigo IN (" + codDes + ")");
            

            if ((dataIni != string.Empty) && (dataIniF != string.Empty))
                sqlQuery.Append(@" AND dtInicio BETWEEN CONVERT(DATETIME,'" + dataIni + "',103) AND CONVERT(DATETIME,'" + dataIniF + "',103)");
            
            if ((dataFim != string.Empty) && (dataFimF != string.Empty))
                sqlQuery.Append(@" AND dtfIM BETWEEN CONVERT(DATETIME,'" + dataFim + "',103) AND CONVERT(DATETIME,'" + dataFimF + "',103)");
            

            DataSet ds = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                      CommandType.Text, sqlQuery.ToString());

            
            return ds;
        }

    }
    
}
