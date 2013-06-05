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
    public class MovimentosEstoqueDA
    {
        Utils utils = new Utils();

        #region funcoes
        private List<MovimentosEstoque> CarregarObjMovimentoEstoque(SqlDataReader dr)
        {
            List<MovimentosEstoque> movEstoque = new List<MovimentosEstoque>();

            while (dr.Read())
            {
                MovimentosEstoque movEst = new MovimentosEstoque();
                movEst.Id = int.Parse(dr["ID"].ToString());
                movEst.VendaItensId = utils.ComparaIntComNull(dr["VENDAITENSID"].ToString());
                movEst.UsuarioId = utils.ComparaIntComZero(dr["USUARIOID"].ToString());
                movEst.VlrVenda = utils.ComparaDecimalComZero(dr["VLRVENDA"].ToString());
                movEst.VlrCusto = utils.ComparaDecimalComZero(dr["VLRCUSTO"].ToString());
                movEst.ItemEstoqueId = int.Parse(dr["ITEMESTOQUEID"].ToString());
                movEst.Quantidade = utils.ComparaIntComZero(dr["QUANTIDADE"].ToString());
                movEst.NotaEntradaId = utils.ComparaIntComNull(dr["NOTAENTRADAITENSID"].ToString());
                movEst.Tipo = dr["TIPO"].ToString();
                movEst.Data = Convert.ToDateTime(dr["DATA"].ToString());
                movEst.NumeroVenda = utils.ComparaIntComNull(dr["NUMERO"].ToString());
                movEst.Numnota = utils.ComparaIntComNull(dr["NUMNOTA"].ToString());
                movEst.Serie = utils.ComparaShortComNull(dr["SERIE"].ToString());


                Usuarios usuarios = new Usuarios();
                usuarios.Login = dr["LOGIN"].ToString();
                movEst.Usuarios = usuarios;

                Obras obras = new Obras();
                obras.Codigo = Int32.Parse(dr["CODIGO"].ToString());
                obras.Titulo = dr["TITULO"].ToString();

                movEst.Obras = obras;
                
                movEstoque.Add(movEst);
            }

            return movEstoque;
        }
        #endregion

        public bool InserirDA(MovimentosEstoque movEst)
        {
            SqlParameter[] paramsToSP = new SqlParameter[7];

            paramsToSP[0] = new SqlParameter("@vendaItensId", movEst.VendaItensId);
            paramsToSP[1] = new SqlParameter("@usuarioid", movEst.UsuarioId);
            paramsToSP[2] = new SqlParameter("@itemestoqueid", movEst.ItemEstoqueId);
            paramsToSP[3] = new SqlParameter("@quantidade", movEst.Quantidade);
            paramsToSP[4] = new SqlParameter("@notaentradaitensid", movEst.NotaEntradaId);
            paramsToSP[5] = new SqlParameter("@tipo", movEst.Tipo);
            paramsToSP[6] = new SqlParameter("@data", movEst.Data);

            try
            {
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_insert_MovimentosEstoque", paramsToSP);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool EditarDA(MovimentosEstoque movEst)
        {
            SqlParameter[] paramsToSP = new SqlParameter[8];

            paramsToSP[0] = new SqlParameter("@id", movEst.Id);
            paramsToSP[1] = new SqlParameter("@vendaItensid", movEst.VendaItensId);
            paramsToSP[2] = new SqlParameter("@usuarioid", movEst.UsuarioId);
            paramsToSP[3] = new SqlParameter("@itemestoqueid", movEst.ItemEstoqueId);
            paramsToSP[4] = new SqlParameter("@quantidade", movEst.Quantidade);
            paramsToSP[5] = new SqlParameter("@notaentradaitensid", movEst.NotaEntradaId);
            paramsToSP[6] = new SqlParameter("@tipo", movEst.Tipo);
            paramsToSP[7] = new SqlParameter("@data", movEst.Data);

            try
            {
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_update_MovimentosEstoque", paramsToSP);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool ExcluirDA(MovimentosEstoque movEst)
        {
            SqlParameter[] paramsToSP = new SqlParameter[1];

            paramsToSP[0] = new SqlParameter("@id", movEst.Id);

            try
            {
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_delete_MovimentosEstoque", paramsToSP);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<MovimentosEstoque> PesquisarDA()
        {
            List<MovimentosEstoque> movimentosEstoque = new List<MovimentosEstoque>();
            return movimentosEstoque;
        }

        public List<MovimentosEstoque> PesquisarDA(Int32 id_ItEst)
        {
            StringBuilder v_consulta = new StringBuilder();

            v_consulta.Append(@"  SELECT M.*,IE.VLRCUSTO, IE.VLRVENDA, O.CODIGO, O.TITULO ");
            v_consulta.Append(@"        ,U.LOGIN, V.NUMERO, N.NUMERO NUMNOTA , N.SERIE ");
            v_consulta.Append(@"   FROM MOVIMENTOSESTOQUE M  ");
            v_consulta.Append(@"        INNER JOIN ITENSESTOQUE IE ON IE.ID = M.ITEMESTOQUEID  ");
            v_consulta.Append(@"        INNER JOIN USUARIOS U ON U.ID = M.USUARIOID  ");
            v_consulta.Append(@"        INNER JOIN OBRAS O ON O.ID = IE.OBRAID  ");
            v_consulta.Append(@"        LEFT JOIN VENDAITENS VI ON VI.ID = M.VENDAITENSID  ");
            v_consulta.Append(@"        LEFT JOIN VENDAS V ON V.ID = VI.VENDAID  ");
            v_consulta.Append(@"        LEFT JOIN NOTAENTRADAITENS NI ON NI.ID = M.NOTAENTRADAITENSID ");
            v_consulta.Append(@"        LEFT JOIN NOTAENTRADA N ON N.ID = NI.NOTAENTRADAID ");
            v_consulta.Append(@"   WHERE M.ITEMESTOQUEID = {0} ");

            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, string.Format(v_consulta.ToString(), id_ItEst));


            List<MovimentosEstoque> movEstoque = CarregarObjMovimentoEstoque(dr);

            return movEstoque;
        }

        public List<MovimentosEstoque> PesquisarDA(int item_id, DateTime? data)
        {
            StringBuilder v_consulta = new StringBuilder();

            v_consulta.Append(@"  SELECT M.*,IE.VLRCUSTO, IE.VLRVENDA, O.CODIGO, O.TITULO ");
            v_consulta.Append(@"        ,U.LOGIN, V.NUMERO, N.NUMERO NUMNOTA , N.SERIE ");
            v_consulta.Append(@"   FROM MOVIMENTOSESTOQUE M  ");
            v_consulta.Append(@"        INNER JOIN ITENSESTOQUE IE ON IE.ID = M.ITEMESTOQUEID  "); 
            v_consulta.Append(@"        INNER JOIN USUARIOS U ON U.ID = M.USUARIOID  "); 
            v_consulta.Append(@"        INNER JOIN OBRAS O ON O.ID = IE.OBRAID  ");
            v_consulta.Append(@"        LEFT JOIN VENDAITENS VI ON VI.ID = M.VENDAITENSID  ");
            v_consulta.Append(@"        LEFT JOIN VENDAS V ON V.ID = VI.VENDAID  ");
            v_consulta.Append(@"        LEFT JOIN NOTAENTRADAITENS NI ON NI.ID = M.NOTAENTRADAITENSID ");
            v_consulta.Append(@"        LEFT JOIN NOTAENTRADA N ON N.ID = NI.NOTAENTRADAID ");
            v_consulta.Append(@"   WHERE IE.ID = {0} ");

            if (data != null)
                v_consulta.Append(@"    AND M.DATA BETWEEN CONVERT(DATE,'{1}',103) AND CONVERT(DATE,'{1}',103) ");
            
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, string.Format(v_consulta.ToString(), item_id
                                                                ,data != null ? Convert.ToDateTime(data).ToString("dd/MM/yyyy") : ""));


            List<MovimentosEstoque> movEstoque = CarregarObjMovimentoEstoque(dr);

            return movEstoque;
        }

        public Int32 PesquisarTotalMovimentosDA(Int32 id_ItEst, string data)
        {
            Int32 total = 0;
            string consulta;

            if (data == "")
            {
                consulta = string.Format(@" SELECT SUM(ME.QUANTIDADE) " +
                                          " - (SELECT ISNULL(SUM(M.QUANTIDADE),0) FROM MOVIMENTOSESTOQUE M WHERE M.ITEMESTOQUEID = {0} AND M.TIPO ='S') TOTAL " +
                                          "         FROM MOVIMENTOSESTOQUE ME " +
                                          "         WHERE ME.ITEMESTOQUEID = {0} " +
                                          "         AND ME.TIPO = 'E' ", id_ItEst);
            }
            else
            {
                consulta = string.Format(@" SELECT SUM(ME.QUANTIDADE) " +
                                          " - (SELECT ISNULL(SUM(M.QUANTIDADE),0) FROM MOVIMENTOSESTOQUE M WHERE M.ITEMESTOQUEID = {0} " +
                                          "    AND M.TIPO ='S' AND M.DATA <= CONVERT(DATETIME,'{1}',101)) TOTAL " +
                                          "         FROM MOVIMENTOSESTOQUE ME " +
                                          "         WHERE ME.ITEMESTOQUEID = {0} " +
                                          "           AND ME.TIPO = 'E' " +
                                          "           AND ME.DATA BETWEEN CONVERT(DATETIME,'{1} 00:00:00.001',103) AND CONVERT(DATETIME,'{1} 23:59:59.999',103) "
                                                                             , id_ItEst, data != null ? Convert.ToDateTime(data).ToString("dd/MM/yyyy") : "");


            }


            DataSet ds = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                          CommandType.Text, consulta);




            if (ds.Tables[0].Rows.Count != 0)
                total = utils.ComparaIntComZero(ds.Tables[0].Rows[0]["TOTAL"].ToString());

            return total;

        }

        public DataSet PesquisarDataSetDA(MovimentosEstoque movestoque, string coditens, string codUsuarios, string dtIni, string dtFim)
        {
            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append(@" SELECT M.*,IE.VLRCUSTO, IE.VLRVENDA, O.CODIGO, O.TITULO, U.LOGIN, V.NUMERO   " +
                        "   FROM MOVIMENTOSESTOQUE M  " +
                        "        INNER JOIN ITENSESTOQUE IE ON IE.ID = M.ITEMESTOQUEID  " +
                        "        INNER JOIN USUARIOS U ON U.ID = M.USUARIOID  " +
                        "        INNER JOIN OBRAS O ON O.ID = IE.OBRAID  " +
                        "        LEFT JOIN VENDAITENS VI ON VI.ID = M.VENDAITENSID  " +
                        "        LEFT JOIN VENDAS V ON V.ID = VI.VENDAID  " +                        
                        "  WHERE 1 = 1 ");

            if(codUsuarios != string.Empty)            
                sqlQuery.Append(@" AND m.usuarioid IN (" + codUsuarios + ")");            

            if (coditens != string.Empty)            
                sqlQuery.Append(@" AND O.CODIGO IN (" + coditens + ")");            

            if (movestoque.Quantidade != 0)            
                sqlQuery.Append(@" AND m.quantidade = " + movestoque.Quantidade);            

            if (movestoque.Tipo != null)            
                sqlQuery.Append(@" AND m.tipo = '" + movestoque.Tipo +"'");            

            if ((dtIni != string.Empty) && (dtFim != string.Empty))
                sqlQuery.Append(@" AND M.data BETWEEN CONVERT(DATETIME,'" + dtIni + "',103) AND CONVERT(DATETIME,'" + dtFim + "',103)");            

            DataSet ds = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, sqlQuery.ToString());

            return ds;
        }
    }
}
