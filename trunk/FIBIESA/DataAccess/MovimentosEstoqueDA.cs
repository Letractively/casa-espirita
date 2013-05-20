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
                movEst.NotaEntradaId = utils.ComparaIntComNull(dr["NOTAENTRADAID"].ToString());
                movEst.Tipo = dr["TIPO"].ToString();
                movEst.Data = Convert.ToDateTime(dr["DATA"].ToString());
                movEst.NumeroVenda = utils.ComparaIntComNull(dr["NUMERO"].ToString());

                Usuarios usuarios = new Usuarios();
                usuarios.Login = dr["LOGIN"].ToString();
                movEst.Usuarios = usuarios;

                Obras obras = new Obras();
                obras.Codigo = Int32.Parse(dr["CODIGO"].ToString());
                obras.Titulo = dr["TITULO"].ToString();

                movEst.Obras = obras;


                if (movEst.NotaEntradaId != null)
                {
                    NotasEntradaDA notaentradaDA = new NotasEntradaDA();
                    List<NotasEntrada> notaEnt = notaentradaDA.PesquisarDA(movEst.NotaEntradaId != null ? (int)movEst.NotaEntradaId : 0);
                    NotasEntrada notaEntrada = new NotasEntrada();

                    foreach (NotasEntrada ltNotE in notaEnt)
                    {
                        notaEntrada.Numero = ltNotE.Numero;
                        notaEntrada.Serie = ltNotE.Serie;
                    }

                    movEst.NotaEntrada = notaEntrada;
                }

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
            paramsToSP[4] = new SqlParameter("@notaentradaid", movEst.NotaEntradaId);
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
            paramsToSP[5] = new SqlParameter("@notaentradaid", movEst.NotaEntradaId);
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
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, string.Format(@" SELECT M.*,IE.VLRCUSTO, IE.VLRVENDA, O.CODIGO, O.TITULO, U.LOGIN, V.NUMERO   " +
                                                                                                 "   FROM MOVIMENTOSESTOQUE M  " +
                                                                                                 "        INNER JOIN ITENSESTOQUE IE ON IE.ID = M.ITEMESTOQUEID  " +
                                                                                                 "        INNER JOIN USUARIOS U ON U.ID = M.USUARIOID  " +
                                                                                                 "        INNER JOIN OBRAS O ON O.ID = IE.OBRAID  " +
                                                                                                 "        LEFT JOIN VENDAITENS VI ON VI.ID = M.VENDAITENSID  " +
                                                                                                 "        LEFT JOIN VENDAS V ON V.ID = VI.VENDAID  " +
                                                                                                 " WHERE M.ITEMESTOQUEID = '{0}'", id_ItEst));


            List<MovimentosEstoque> movEstoque = CarregarObjMovimentoEstoque(dr);

            return movEstoque;
        }

        public List<MovimentosEstoque> PesquisarDA(int item_id, DateTime? data)
        {
            string consulta = "";

            if (data != null)
            {
                consulta = string.Format(@" SELECT M.*,IE.VLRCUSTO, IE.VLRVENDA, O.CODIGO, O.TITULO, U.LOGIN, V.NUMERO   " +
                                          "   FROM MOVIMENTOSESTOQUE M  " +
                                          "        INNER JOIN ITENSESTOQUE IE ON IE.ID = M.ITEMESTOQUEID  " +
                                          "        INNER JOIN USUARIOS U ON U.ID = M.USUARIOID  " +
                                          "        INNER JOIN OBRAS O ON O.ID = IE.OBRAID  " +
                                          "        LEFT JOIN VENDAITENS VI ON VI.ID = M.VENDAITENSID  " +
                                          "        LEFT JOIN VENDAS V ON V.ID = VI.VENDAID  " +
                                          "  WHERE IE.ID = {0} " +
                                          "    AND M.DATA BETWEEN CONVERT(DATETIME,'{1} 00:00:00.001',103) AND CONVERT(DATETIME,'{1} 23:59:59.999',103) "
                                                                             , item_id, data != null ? Convert.ToDateTime(data).ToString("dd/MM/yyyy") : "");

            }
            else
            {
                consulta = string.Format(@" SELECT M.*,IE.VLRCUSTO, IE.VLRVENDA, O.CODIGO, O.TITULO, U.LOGIN, V.NUMERO   " +
                                          "   FROM MOVIMENTOSESTOQUE M  " +
                                          "        INNER JOIN ITENSESTOQUE IE ON IE.ID = M.ITEMESTOQUEID  " +
                                          "        INNER JOIN USUARIOS U ON U.ID = M.USUARIOID  " +
                                          "        INNER JOIN OBRAS O ON O.ID = IE.OBRAID  " +
                                          "        LEFT JOIN VENDAITENS VI ON VI.ID = M.VENDAITENSID  " +
                                          "        LEFT JOIN VENDAS V ON V.ID = VI.VENDAID  " +
                                          "  WHERE IE.ID = {0} ", item_id);

            }


            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, consulta);


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

        public DataSet PesquisarDataSetDA(MovimentosEstoque movestoque, string dtIni, string dtFim)
        {
            string consulta = "";


            consulta = " SELECT M.*,IE.VLRCUSTO, IE.VLRVENDA, O.CODIGO, O.TITULO, U.LOGIN, V.NUMERO   " +
                        "   FROM MOVIMENTOSESTOQUE M  " +
                        "        INNER JOIN ITENSESTOQUE IE ON IE.ID = M.ITEMESTOQUEID  " +
                        "        INNER JOIN USUARIOS U ON U.ID = M.USUARIOID  " +
                        "        INNER JOIN OBRAS O ON O.ID = IE.OBRAID  " +
                        "        LEFT JOIN VENDAITENS VI ON VI.ID = M.VENDAITENSID  " +
                        "        LEFT JOIN VENDAS V ON V.ID = VI.VENDAID  " +                        
                        "  WHERE 1 = 1 ";

            if(movestoque.UsuarioId != 0)
            {
                consulta += " AND m.usuarioid = " + movestoque.UsuarioId;
            }

            if (movestoque.ItemEstoqueId != 0)
            {
                consulta += " AND m.ITEMESTOQUEID = " + movestoque.ItemEstoqueId;
            }

            if (movestoque.Quantidade != 0)
            {
                consulta += " AND m.quantidade = " + movestoque.Quantidade;
            }

            if (movestoque.Tipo != string.Empty)
            {
                consulta += " AND m.tipo = " + movestoque.Tipo;
            }

            if ((dtIni != string.Empty) && (dtFim != string.Empty))
            {

                consulta += " AND M.data BETWEEN CONVERT(DATETIME,'" + dtIni + "',103) AND CONVERT(DATETIME,'" + dtFim + "',103)";
            }

            DataSet ds = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, consulta);

            return ds;
        }
    }
}
