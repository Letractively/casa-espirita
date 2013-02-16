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
    public class PortadoresDA : BaseDA
    {
        Utils utils = new Utils();
        #region funcoes
        private List<Portadores> CarregarObjPortadores(SqlDataReader dr)
        {
            List<Portadores> portadores = new List<Portadores>();

            while (dr.Read())
            {
                Portadores por = new Portadores();
                por.Id = int.Parse(dr["ID"].ToString());
                por.Codigo = int.Parse(dr["CODIGO"].ToString());
                por.Descricao = dr["DESCRICAO"].ToString();
                por.AgenciaId = utils.ComparaIntComNull(dr["AGENCIAID"].ToString());
                por.BancoId = utils.ComparaIntComNull(dr["BANCOID"].ToString());

                portadores.Add(por);
            }
            return portadores;
        }
        #endregion
        public bool InserirDA(Portadores por)
        {
            SqlParameter[] paramsToSP = new SqlParameter[4];

            paramsToSP[0] = new SqlParameter("@codigo", por.Codigo);
            paramsToSP[1] = new SqlParameter("@descricao", por.Descricao);
            paramsToSP[2] = new SqlParameter("@agenciaid", por.AgenciaId);
            paramsToSP[3] = new SqlParameter("@bancoid", por.BancoId);

            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_insert_Portadores", paramsToSP);

            return true;
        }

        public bool EditarDA(Portadores por)
        {
            SqlParameter[] paramsToSP = new SqlParameter[5];

            paramsToSP[0] = new SqlParameter("@id", por.Id);
            paramsToSP[1] = new SqlParameter("@codigo", por.Codigo);
            paramsToSP[2] = new SqlParameter("@descricao", por.Descricao);
            paramsToSP[3] = new SqlParameter("@agenciaid", por.AgenciaId);
            paramsToSP[4] = new SqlParameter("@bancoid", por.BancoId);

            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_update_Portadores", paramsToSP);

            return true;
        }

        public bool ExcluirDA(Portadores por)
        {
            SqlParameter[] paramsToSP = new SqlParameter[1];

            paramsToSP[0] = new SqlParameter("@id", por.Id);

            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_delete_Portadores", paramsToSP);

            return true;
        }

        public List<Portadores> PesquisarDA()
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, string.Format(@"SELECT * FROM PORTADORES "));

            List<Portadores> portadores = CarregarObjPortadores(dr);
                        
            return portadores;

        }

        public List<Portadores> PesquisarDA(int id_por)
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                       CommandType.Text, string.Format(@"SELECT * " +
                                                                                       " FROM PORTADORES WHERE ID = {0}", id_por));

            List<Portadores> portadores = CarregarObjPortadores(dr);

            return portadores;
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
                                                                                       " FROM PORTADORES WHERE CODIGO = '{0}'", codigo));
            }
            else
            {
                dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                      CommandType.Text, string.Format(@"SELECT * " +
                                                                                       " FROM PORTADORES WHERE DESCRICAO LIKE '%{0}%'", descricao));
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
