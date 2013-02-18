using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using System.Data;
using System.Data.SqlClient;
using InfrastructureSqlServer.Helpers;
using System.Configuration;

namespace DataAccess
{
    public class EventosDA : BaseDA
    {
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
        #endregion
        public bool InserirDA(Eventos eve)
        {
            SqlParameter[] paramsToSP = new SqlParameter[4];

            paramsToSP[0] = new SqlParameter("@codigo", eve.Codigo);
            paramsToSP[1] = new SqlParameter("@descricao", eve.Descricao);
            paramsToSP[2] = new SqlParameter("@dtinicio", eve.DtInicio);
            paramsToSP[3] = new SqlParameter("@dtfim", eve.DtFim);

            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_insert_eventos", paramsToSP);

            return true;
        }

        public bool EditarDA(Eventos eve)
        {
            SqlParameter[] paramsToSP = new SqlParameter[5];

            paramsToSP[0] = new SqlParameter("@id", eve.Id);
            paramsToSP[1] = new SqlParameter("@codigo", eve.Codigo);
            paramsToSP[2] = new SqlParameter("@descricao", eve.Descricao);
            paramsToSP[3] = new SqlParameter("@dtinicio", eve.DtInicio);
            paramsToSP[4] = new SqlParameter("@dtfim", eve.DtFim);

            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_update_eventos", paramsToSP);

            return true;
        }

        public bool ExcluirDA(Eventos eve)
        {
            SqlParameter[] paramsToSP = new SqlParameter[1];

            paramsToSP[0] = new SqlParameter("@id", eve.Id);

            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_delete_eventos", paramsToSP);

            return true;
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

        public override List<Base> Pesquisar(string descricao, string tipo)
        {
            SqlDataReader dr;

            if (tipo == "C")
            {
                int codigo = 0;
                Int32.TryParse(descricao, out codigo);

                dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                       CommandType.Text, string.Format(@"SELECT * " +
                                                                                       " FROM EVENTOS WHERE CODIGO = '{0}'", codigo));
            }
            else
            {
                dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                      CommandType.Text, string.Format(@"SELECT * " +
                                                                                       " FROM EVENTOS WHERE DESCRICAO LIKE '%{0}%'", descricao));
            }

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

    }
    
}
