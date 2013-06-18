using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using FG;
using System.Data;
using System.Data.SqlClient;
using InfrastructureSqlServer.Helpers;
using System.Configuration;

namespace DataAccess
{
    public class VendaItensDA
    {
        Utils utils = new Utils();
        #region funcoes
        private List<VendaItens> CarregarObjVendaItem(SqlDataReader dr)
        {
            List<VendaItens> vendaItens = new List<VendaItens>();

            while (dr.Read())
            {
                VendaItens venItEi = new VendaItens();
                venItEi.Id = int.Parse(dr["ID"].ToString());
                venItEi.VendaId = int.Parse(dr["VENDAID"].ToString());
                venItEi.Valor = utils.ComparaDecimalComZero(dr["VALOR"].ToString());
                venItEi.Quantidade = utils.ComparaIntComZero(dr["QUANTIDADE"].ToString());
                venItEi.ItemEstoqueId = utils.ComparaIntComZero(dr["ITEMESTOQUEID"].ToString());
                venItEi.Situacao = dr["SITUACAO"].ToString();
                venItEi.Desconto = utils.ComparaDecimalComZero(dr["DESCONTO"].ToString());

                Obras obra = new Obras();

                obra.Codigo = int.Parse(dr["CODIGO"].ToString());
                obra.Titulo = dr["TITULO"].ToString();

                venItEi.Obras = obra;

                vendaItens.Add(venItEi);
            }

            return vendaItens;
        }

        #endregion

        public bool InserirDA(VendaItens venItEi, int usuarioID)
        {
            SqlParameter[] paramsToSP = new SqlParameter[7];

            paramsToSP[0] = new SqlParameter("@vendaid", venItEi.VendaId);
            paramsToSP[1] = new SqlParameter("@valor", venItEi.Valor);
            paramsToSP[2] = new SqlParameter("@quantidade", venItEi.Quantidade);
            paramsToSP[3] = new SqlParameter("@itemestoqueid", venItEi.ItemEstoqueId);
            paramsToSP[4] = new SqlParameter("@desconto", venItEi.Desconto);
            paramsToSP[5] = new SqlParameter("@situacao", venItEi.Situacao);
            paramsToSP[6] = new SqlParameter("@usuarioId", usuarioID);

            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                    CommandType.StoredProcedure, "stp_insert_VendaItens", paramsToSP);

                DataTable tabela = ds.Tables[0];

                string resultado = tabela.Rows[0][0].ToString();

                if (resultado == "true")
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool EditarDA(VendaItens venItEi)
        {
            SqlParameter[] paramsToSP = new SqlParameter[7];

            paramsToSP[0] = new SqlParameter("@id", venItEi.Id);
            paramsToSP[1] = new SqlParameter("@vendaid", venItEi.VendaId);
            paramsToSP[2] = new SqlParameter("@valor", venItEi.Valor);
            paramsToSP[3] = new SqlParameter("@quantidade", venItEi.Quantidade);
            paramsToSP[4] = new SqlParameter("@itemestoqueid", venItEi.ItemEstoqueId);
            paramsToSP[5] = new SqlParameter("@desconto", venItEi.Desconto);
            paramsToSP[6] = new SqlParameter("@situacao", venItEi.Situacao);

            try
            {
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_update_VendaItens", paramsToSP);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool ExcluirDA(VendaItens venItEi)
        {
            SqlParameter[] paramsToSP = new SqlParameter[1];

            paramsToSP[0] = new SqlParameter("@id", venItEi.Id);

            try
            {
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_delete_vendaItens", paramsToSP);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool CancelarVendaItemDA(int id_ven, int id_venIt)
        {
            SqlParameter[] paramsToSP = new SqlParameter[2];

            paramsToSP[0] = new SqlParameter("@vendaItemId", id_venIt);
            paramsToSP[1] = new SqlParameter("@vendaId", id_ven);

            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                      CommandType.StoredProcedure, "stp_CANCELAR_VENDA_ITEM", paramsToSP);

                DataTable tabela = ds.Tables[0];

                string resultado = tabela.Rows[0][0].ToString();

                if (resultado == "true")
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<VendaItens> PesquisarDA()
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, string.Format(@"SELECT VI.*, O.CODIGO, O.TITULO " +
                                                                                                 " FROM VENDAITENS VI" +
                                                                                                 "     ,ITENSESTOQUE IE " +
                                                                                                 "     ,OBRAS O " +
                                                                                                 " WHERE VI.ITEMESTOQUEID = IE.ID " +
                                                                                                 "   AND IE.OBRAID = O.ID "));


            List<VendaItens> vendaItens = CarregarObjVendaItem(dr);

            return vendaItens;

        }

        public List<VendaItens> PesquisarDA(int id_venItEi)
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                       CommandType.Text, string.Format(@"SELECT VI.*, O.CODIGO, O.TITULO " +
                                                                                       " FROM VENDAITENS VI" +
                                                                                       "     ,ITENSESTOQUE IE " +
                                                                                       "     ,OBRAS O " +
                                                                                       " WHERE VI.ITEMESTOQUEID = IE.ID " +
                                                                                       "   AND IE.OBRAID = O.ID " +
                                                                                       "   AND VI.VENDAID = {0} ", id_venItEi));

            List<VendaItens> vendaItens = CarregarObjVendaItem(dr);

            return vendaItens;
        }

        public DataSet PesquisarDADataSet(int id_venda)
        {
            DataSet ds = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                       CommandType.Text, string.Format(@"SELECT id " +
                                                                                            ",vendaId " +
                                                                                            ",quantidade " +
                                                                                            ",valor " +
                                                                                            ",desconto " +
                                                                                            ",situacao " +
                                                                                            ",itemEstoqueId " +
                                                                                            ",titulo " +
                                                                                       " FROM VIEW_vendasItens " +
                                                                                       " WHERE vendaId = {0} ", id_venda));


            return ds;
        }

        public DataSet PesquisarDARelDataSet(string pessoasCod, string itensCod, string dtIni, string dtFim, Boolean cancelados)
        {
            StringBuilder query = new StringBuilder();

            query.Append(@"SELECT  v.vendaId " +
                    "    ,v.quantidade " +
                    "    ,v.total " +
                    "    ,v.obraCodigo " +
                    "    ,v.titulo " +
                    "    ,v.PessoaId " +
                    "    ,v.Nome " +
                    "    ,v.data " +
                    "    ,situacao " +
                    "    ,numero " +
                    " FROM dbo.VIEW_vendasItens v " +
                    " WHERE 1 = 1 ");

            if (pessoasCod != string.Empty)
                query.Append(@" AND pessoaCodigo IN (" + pessoasCod + ")");

            if (itensCod != string.Empty)
                query.Append(@" AND obraCodigo IN (" + itensCod + ")");

            if ((dtIni != string.Empty) && (dtFim != string.Empty))
                query.Append(@" AND CONVERT(DATE,DATA,103) BETWEEN CONVERT(DATE,'" + dtIni + "',103) AND CONVERT(DATE,'" + dtFim + "',103)");

            if (!cancelados)
                query.Append(@" AND situacao = 'A' and vendasituacao = 'A' ");

            DataSet ds = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                       CommandType.Text, query.ToString());


            return ds;
        }

        public DataSet PesquisarDARelDataSet(string pessoasCod, string itensCod, string dtIni, string dtFim, Boolean cancelados , string ord)
        {
            StringBuilder query = new StringBuilder();

            query.Append(@"SELECT  v.obraCodigo " +
                    "    ,v.titulo " +
                    "    ,SUM(v.quantidade) as qtde " +
                    " FROM dbo.VIEW_vendasItens v " +
                    " WHERE 1 = 1 ");

            if (pessoasCod != string.Empty)
                query.Append(@" AND pessoaCodigo IN (" + pessoasCod + ")");

            if (itensCod != string.Empty)
                query.Append(@" AND obraCodigo IN (" + itensCod + ")");

            if ((dtIni != string.Empty) && (dtFim != string.Empty))
                query.Append(@" AND CONVERT(DATE,DATA,103) BETWEEN CONVERT(DATE,'" + dtIni + "',103) AND CONVERT(DATE,'" + dtFim + "',103)");

            if (!cancelados)
                query.Append(@" AND situacao = 'A' and vendasituacao = 'A' ");

            query.Append(@" GROUP BY v.obraCodigo,v.titulo ");
            if (ord != string.Empty)
                query.Append(@" ORDER BY qtde " + ord);

            DataSet ds = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                       CommandType.Text, query.ToString());


            return ds;
        }
    }
}
