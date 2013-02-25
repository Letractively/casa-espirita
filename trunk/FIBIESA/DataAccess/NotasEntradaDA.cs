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
    public class NotasEntradaDA
    {
        Utils utils = new Utils();

        #region funcoes
        private List<NotasEntrada> CarregarObjNotaEntrada(SqlDataReader dr)
        {
            List<NotasEntrada> NotasEntrada = new List<NotasEntrada>();

            while (dr.Read())
            {
                NotasEntrada ntE = new NotasEntrada();
                ntE.Id = int.Parse(dr["ID"].ToString());
                ntE.Numero = int.Parse(dr["NUMERO"].ToString());
                ntE.Serie = short.Parse(dr["SERIE"].ToString());
                ntE.Data = Convert.ToDateTime(dr["DATA"].ToString());

                NotasEntrada.Add(ntE);
            }

            return NotasEntrada;
        }

        #endregion

        public int InserirDA(NotasEntrada ntE)
        {
            SqlParameter[] paramsToSP = new SqlParameter[3];

            paramsToSP[0] = new SqlParameter("@numero", ntE.Numero);
            paramsToSP[1] = new SqlParameter("@serie", ntE.Serie);
            paramsToSP[2] = new SqlParameter("@data", ntE.Data);

            DataSet ds = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_insert_notaEntrada", paramsToSP);
                       
            DataTable tabela = ds.Tables[0];

            int id = utils.ComparaIntComZero(tabela.Rows[0]["ID"].ToString());

            return id;
        }

        public bool EditarDA(NotasEntrada ntE)
        {
            SqlParameter[] paramsToSP = new SqlParameter[4];

            paramsToSP[0] = new SqlParameter("@id", ntE.Id);
            paramsToSP[1] = new SqlParameter("@numero", ntE.Numero);
            paramsToSP[2] = new SqlParameter("@serie", ntE.Serie);
            paramsToSP[3] = new SqlParameter("@data", ntE.Data);

            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_update_notaEntrada", paramsToSP);

            return true;
        }

        public bool ExcluirDA(NotasEntrada ntE)
        {
            SqlParameter[] paramsToSP = new SqlParameter[1];

            paramsToSP[0] = new SqlParameter("@id", ntE.Id);

            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_delete_notaEntrada", paramsToSP);

            return true;
        }

        public List<NotasEntrada> PesquisarDA()
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, string.Format(@"SELECT * FROM NOTAENTRADA "));

            List<NotasEntrada> NotasEntrada = CarregarObjNotaEntrada(dr);
                       
            return NotasEntrada;

        }

        public List<NotasEntrada> PesquisarDA(int id_ntE)
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                       CommandType.Text, string.Format(@"SELECT * " +
                                                                                       " FROM NOTAENTRADA WHERE ID = {0}", id_ntE));

            List<NotasEntrada> NotasEntrada = CarregarObjNotaEntrada(dr);
                
            return NotasEntrada;
        }
              
    }
}
