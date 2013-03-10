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
    public class JurosMultasDA
    {
        Utils utils = new Utils();
        #region funcoes
        private List<JurosMultas> CarregarObjJurosMultas(SqlDataReader dr)
        {
            List<JurosMultas> jurosMultas = new List<JurosMultas>();

            while (dr.Read())
            {
                JurosMultas jm = new JurosMultas();
                jm.Id = int.Parse(dr["ID"].ToString());
                jm.MesAno = Convert.ToDateTime(dr["MESANO"].ToString());
                jm.PercJurosDias = utils.ComparaDecimalComZero(dr["PERCJUROSDIA"].ToString());
                jm.PercJurosMes = utils.ComparaDecimalComZero(dr["PERCJUROSMES"].ToString());
                jm.PercMultaDias = utils.ComparaDecimalComZero(dr["PERCMULTADIA"].ToString());
                jm.PercMultaMes = utils.ComparaDecimalComZero(dr["PERCMULTAMES"].ToString());

                jurosMultas.Add(jm);
            }
            return jurosMultas;  
        }
        #endregion
        public bool InserirDA(JurosMultas jm)
        {
            SqlParameter[] paramsToSP = new SqlParameter[5];

            paramsToSP[0] = new SqlParameter("@mesano", jm.MesAno);
            paramsToSP[1] = new SqlParameter("@percjurosdia", jm.PercJurosDias);
            paramsToSP[2] = new SqlParameter("@percjurosmes", jm.PercJurosMes);
            paramsToSP[3] = new SqlParameter("@percmultadia", jm.PercMultaDias);
            paramsToSP[4] = new SqlParameter("@percmultames", jm.PercMultaMes);

            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_insert_jurosMultas", paramsToSP);

            return true;
        }

        public bool EditarDA(JurosMultas jm)
        {
            SqlParameter[] paramsToSP = new SqlParameter[6];

            paramsToSP[0] = new SqlParameter("@id", jm.Id);
            paramsToSP[1] = new SqlParameter("@mesano", jm.MesAno);
            paramsToSP[2] = new SqlParameter("@percjurosdia", jm.PercJurosDias);
            paramsToSP[3] = new SqlParameter("@percjurosmes", jm.PercJurosMes);
            paramsToSP[4] = new SqlParameter("@percmultadia", jm.PercMultaDias);
            paramsToSP[5] = new SqlParameter("@percmultames", jm.PercMultaMes);

            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_update_jurosMultas", paramsToSP);
                       
            return true; 
        }

        public bool ExcluirDA(JurosMultas jm)
        {
            SqlParameter[] paramsToSP = new SqlParameter[1];

            paramsToSP[0] = new SqlParameter("@id", jm.Id);

            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_delete_jurosMultas", paramsToSP);

            return true;
        }

        public List<JurosMultas> PesquisarDA()
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, string.Format(@"SELECT * FROM JUROSMULTAS "));

            List<JurosMultas> jurosMultas = CarregarObjJurosMultas(dr);

            return jurosMultas;    
        }

        public List<JurosMultas> PesquisarDA(int id_jm)
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                               CommandType.Text, string.Format(@"SELECT * FROM JUROSMULTAS WHERE ID = {0}",id_jm));

            List<JurosMultas> jurosMultas = CarregarObjJurosMultas(dr);

            return jurosMultas; 
        }

        public List<JurosMultas> PesquisarDA(string campo, string valor)
        {
            string consulta;

            switch (campo.ToUpper())
            {
                case "MESANO":
                    consulta = string.Format("SELECT * FROM JUROSMULTAS WHERE MESANO = '{0}'", valor != null? Convert.ToDateTime(valor).ToString("MM/dd/yyyy") : "");
                    break;                
                default:
                    consulta = "";
                    break;
            }

            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, consulta);

            List<JurosMultas> jurosMultas = CarregarObjJurosMultas(dr);

            return jurosMultas;
        }
    }
}
