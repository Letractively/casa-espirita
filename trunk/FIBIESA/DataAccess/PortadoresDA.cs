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
            AgenciasDA ageDA = new AgenciasDA();
            BancosDA banDA = new BancosDA();
            ContasDA conDA = new ContasDA();

            while (dr.Read())
            {
                Portadores por = new Portadores();
                por.Id = int.Parse(dr["ID"].ToString());
                por.Codigo = int.Parse(dr["CODIGO"].ToString());
                por.Descricao = dr["DESCRICAO"].ToString();
                por.AgenciaId = utils.ComparaIntComNull(dr["AGENCIAID"].ToString());
                por.BancoId = utils.ComparaIntComNull(dr["BANCOID"].ToString());
                por.ContaId = utils.ComparaIntComNull(dr["CONTAID"].ToString());
                
                int Id = 0;
                
                if(por.AgenciaId != null )
                {
                    Id = Convert.ToInt32(por.AgenciaId);
                    List<Agencias> agencias = ageDA.PesquisarDA(Id);
                    Agencias age = new Agencias();

                    foreach (Agencias ltAge in agencias)
	                {
                        age.Codigo = ltAge.Codigo;
                        age.Descricao = ltAge.Descricao;		 
	                }

                    por.Agencia = age;
                }

                if (por.BancoId != null)
                {
                    Id = Convert.ToInt32(por.BancoId);
                    List<Bancos> bancos = banDA.PesquisarDA(Id);
                    Bancos ban = new Bancos();

                    foreach (Bancos ltBan in bancos)
                    {
                        ban.Codigo = ltBan.Codigo;
                        ban.Descricao = ltBan.Descricao;
                    }

                    por.Banco = ban;
                }

                if (por.ContaId != null)
                {
                    Id = Convert.ToInt32(por.ContaId);
                    List<Contas> contas = conDA.PesquisarDA(Id);
                    Contas con = new Contas();

                    foreach (Contas ltCon in contas)
                    {
                        con.Id = ltCon.Id;
                        con.Codigo = ltCon.Codigo;
                        con.Descricao = ltCon.Descricao;
                        con.Digito = ltCon.Digito;
                    }

                    por.Contas = con;
                }  

                portadores.Add(por);
            }
            return portadores;
        }

        private Int32 RetornaMaxCodigo()
        {
            Int32 codigo = 1;
            DataSet ds = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                          CommandType.Text, string.Format(@" SELECT ISNULL(MAX(CODIGO),0) + 1 as COD FROM PORTADORES "));

            if (ds.Tables[0].Rows.Count != 0)
                codigo = utils.ComparaIntComZero(ds.Tables[0].Rows[0]["COD"].ToString());

            return codigo;
        }
        #endregion
        public bool InserirDA(Portadores por)
        {
            SqlParameter[] paramsToSP = new SqlParameter[5];

            paramsToSP[0] = new SqlParameter("@codigo", RetornaMaxCodigo());
            paramsToSP[1] = new SqlParameter("@descricao", por.Descricao.ToUpper());
            paramsToSP[2] = new SqlParameter("@agenciaid", por.AgenciaId);
            paramsToSP[3] = new SqlParameter("@bancoid", por.BancoId);
            paramsToSP[4] = new SqlParameter("@contaid", por.ContaId);

            try
            {
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_insert_Portadores", paramsToSP);

                return true;
            }
            catch (Exception e)
            {
                return false;                    
            }
        }

        public bool EditarDA(Portadores por)
        {
            SqlParameter[] paramsToSP = new SqlParameter[6];

            paramsToSP[0] = new SqlParameter("@id", por.Id);
            paramsToSP[1] = new SqlParameter("@codigo", por.Codigo);
            paramsToSP[2] = new SqlParameter("@descricao", por.Descricao.ToUpper());
            paramsToSP[3] = new SqlParameter("@agenciaid", por.AgenciaId);
            paramsToSP[4] = new SqlParameter("@bancoid", por.BancoId);
            paramsToSP[5] = new SqlParameter("@contaid", por.ContaId);

            try
            {
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_update_Portadores", paramsToSP);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool ExcluirDA(Portadores por)
        {
            SqlParameter[] paramsToSP = new SqlParameter[1];

            paramsToSP[0] = new SqlParameter("@id", por.Id);

            try
            {
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_delete_Portadores", paramsToSP);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
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
               
        public List<Portadores> PesquisarBuscaDA(string valor)
        {
            StringBuilder consulta = new StringBuilder(@"SELECT * FROM PORTADORES ");

            if (valor != "" && valor != null)
                consulta.Append(string.Format(" WHERE CODIGO = {0} OR  DESCRICAO  LIKE '%{1}%'", utils.ComparaIntComZero(valor), valor));

            consulta.Append(" ORDER BY CODIGO ");

            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, consulta.ToString());

            List<Portadores> portadores = CarregarObjPortadores(dr);

            return portadores;
        }

        public override List<Base> Pesquisar(string descricao)
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                      CommandType.Text, string.Format(@"SELECT * " +
                                                                                       " FROM PORTADORES WHERE CODIGO = '{0}' OR DESCRICAO LIKE '%{1}%'", utils.ComparaIntComZero(descricao), descricao));
            
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

        public bool CodigoJaUtilizadoDA(Int32 codigo)
        {
            DataSet dsInst = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                       CommandType.Text, string.Format(@"SELECT 1 COD " +
                                                                                        "  FROM PORTADORES " +
                                                                                        " WHERE CODIGO = {0} ", codigo));
            int cod = 0;

            if (dsInst.Tables[0].Rows.Count != 0)
                cod = (int)dsInst.Tables[0].Rows[0]["COD"];

            if (cod == 1)
                return true;
            else
                return false;

        }
    }
}
