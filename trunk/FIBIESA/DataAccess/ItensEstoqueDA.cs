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
    public class ItensEstoqueDA
    {
        Utils utils = new Utils();
        #region funcoes
        private List<ItensEstoque> CarregarObjItemEstoque(SqlDataReader dr)
        {
            List<ItensEstoque> itensEstoque = new List<ItensEstoque>();

            while (dr.Read())
            {
                ItensEstoque itEst = new ItensEstoque();
                itEst.Id = int.Parse(dr["ID"].ToString());
                itEst.Status = bool.Parse(dr["STATUS"].ToString());
                itEst.ControlaEstoque = bool.Parse(dr["CONTROLAESTOQUE"].ToString());
                itEst.QtdMinima = utils.ComparaIntComZero(dr["QTDMINIMA"].ToString());
                itEst.ObraId = utils.ComparaIntComZero(dr["OBRAID"].ToString());
                itEst.VlrCusto = utils.ComparaDecimalComZero(dr["VLRCUSTO"].ToString());
                itEst.VlrVenda = utils.ComparaDecimalComZero(dr["VLRVENDA"].ToString());
                itEst.Data = Convert.ToDateTime(dr["DATA"].ToString());

                ObrasDA obDA = new ObrasDA();
                DataSet dsOb = obDA.PesquisarDA(itEst.ObraId);
                Obras obras = new Obras();

                if (dsOb.Tables[0].Rows.Count != 0)
                {
                    obras.Id = (Int32)dsOb.Tables[0].Rows[0]["id"];
                    obras.Codigo = (Int32)dsOb.Tables[0].Rows[0]["codigo"];
                    obras.Titulo = (string)dsOb.Tables[0].Rows[0]["titulo"];

                    itEst.Obra = obras;
                }

                MovimentosEstoqueDA movEsDA = new MovimentosEstoqueDA();
                itEst.QtdEstoque = movEsDA.PesquisarTotalMovimentosDA(itEst.Id, "");

                itensEstoque.Add(itEst);
            }

            return itensEstoque;
        }
        #endregion

        public bool InserirDA(ItensEstoque itEst)
        {
            SqlParameter[] paramsToSP = new SqlParameter[7];

            paramsToSP[0] = new SqlParameter("@status", itEst.Status);
            paramsToSP[1] = new SqlParameter("@controlaestoque", itEst.ControlaEstoque);
            paramsToSP[2] = new SqlParameter("@qtdminima", itEst.QtdMinima);
            paramsToSP[3] = new SqlParameter("@obraid", itEst.ObraId);
            paramsToSP[4] = new SqlParameter("@vlrcusto", itEst.VlrCusto);
            paramsToSP[5] = new SqlParameter("@vlrvenda", itEst.VlrVenda);
            paramsToSP[6] = new SqlParameter("@data", itEst.Data);

            
            try
            {
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_insert_ItensEstoque", paramsToSP);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool EditarDA(ItensEstoque itEst)
        {
            SqlParameter[] paramsToSP = new SqlParameter[8];

            paramsToSP[0] = new SqlParameter("@id", itEst.Id);
            paramsToSP[1] = new SqlParameter("@status", itEst.Status);
            paramsToSP[2] = new SqlParameter("@controlaestoque", itEst.ControlaEstoque);
            paramsToSP[3] = new SqlParameter("@qtdminima", itEst.QtdMinima);
            paramsToSP[4] = new SqlParameter("@obraid", itEst.ObraId);
            paramsToSP[5] = new SqlParameter("@vlrcusto", itEst.VlrCusto);
            paramsToSP[6] = new SqlParameter("@vlrvenda", itEst.VlrVenda);
            paramsToSP[7] = new SqlParameter("@data", itEst.Data);

            try
            {
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_update_ItensEstoque", paramsToSP);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool ExcluirDA(ItensEstoque itEst)
        {
            SqlParameter[] paramsToSP = new SqlParameter[1];

            paramsToSP[0] = new SqlParameter("@id", itEst.Id);

            try
            {
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_delete_ItensEstoque", paramsToSP);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<ItensEstoque> PesquisarDA()
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, string.Format(@"SELECT * FROM ITENSESTOQUE "));

            List<ItensEstoque> itensEstoque = CarregarObjItemEstoque(dr);

            return itensEstoque; 
        }

        public List<ItensEstoque> PesquisarDA(int status)
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, string.Format(@"SELECT * " +
                                                                                                 " FROM ITENSESTOQUE " +
                                                                                                 " WHERE STATUS = {0} ",status));
                                                                                               


            List<ItensEstoque> itensEstoque = CarregarObjItemEstoque(dr);

            return itensEstoque;
        }

        public List<ItensEstoque> PesquisarMovObraDA(Int32 id_obra)
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, string.Format(@"SELECT * " +
                                                                                                 " FROM ITENSESTOQUE " +
                                                                                                 " WHERE OBRAID = {0} " , id_obra)); 
                                                                                                 

            List<ItensEstoque> itensEstoque = CarregarObjItemEstoque(dr);

            return itensEstoque;
        }

        public List<ItensEstoque> PesquisarBuscaDA(string valor)
        {
            StringBuilder consulta = new StringBuilder(@"SELECT * FROM ITENSESTOQUE IE, OBRAS O WHERE IE.OBRAID = O.ID ");

            if (valor != "" && valor != null)
                consulta.Append(string.Format(" AND ( O.CODIGO = {0} OR O.TITULO LIKE '%{1}%') AND IE.STATUS = 1 ", utils.ComparaIntComZero(valor), valor));

            consulta.Append(" ORDER BY O.CODIGO ");

            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, consulta.ToString());

            List<ItensEstoque> itensEstoque = CarregarObjItemEstoque(dr);

            return itensEstoque;  
            
        }

        public List<ItensEstoque> PesquisarDA(string campo, string valor, int status)
        {
            StringBuilder consulta = new StringBuilder("SELECT * FROM ITENSESTOQUE IE, OBRAS O ");

            switch (campo.ToUpper())
            {
                case "CODIGO":
                    consulta.Append(string.Format("WHERE IE.OBRAID = O.ID AND O.CODIGO = {0} AND IE.STATUS = {1}", utils.ComparaIntComZero(valor), status));
                    break;
                case "TITULO":
                    consulta.Append(string.Format("WHERE IE.OBRAID = O.ID AND O.TITULO LIKE '%{0}%' AND IE.STATUS = {1}", valor, status));
                    break;
                default:
                    break;
            }

            SqlDataReader dr = SqlHelper.ExecuteReader(
                ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                CommandType.Text, consulta.ToString());

            return CarregarObjItemEstoque(dr);
        }

        public DataSet PesquisarItensEstoqueDA(int id_movEst)
        {
            DataSet ds = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                       CommandType.Text, string.Format(@"SELECT ITEST.ID, ITEST.CONTROLAESTOQUE, ITEST.QTDMINIMA " +
                                                                                        "       ,ITEST.STATUS, ITEST.EXEMPLARID, MEST.VALOR " +
                                                                                        "       ,MEST.QUANTIDADE, OB.CODIGO, OB.TITULO " +
                                                                                        " FROM ITENSESTOQUE ITEST " +
                                                                                        "    , MOVIMENTOSESTOQUE MEST " +
                                                                                        "    , EXEMPLARES EXE " +
                                                                                        "    , OBRAS OB " +
                                                                                        " WHERE ITEST.ID = MEST.ITEMESTOQUEID " +
                                                                                        "   AND ITEST.EXEMPLARID = EXE.ID " +
                                                                                        "   AND OB.ID = EXE.OBRAID " +
                                                                                        "   AND MEST.ID = {0} ",id_movEst));

                 
            return ds;
        }
    }
}
