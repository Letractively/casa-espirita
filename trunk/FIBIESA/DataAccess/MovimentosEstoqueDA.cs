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
                movEst.VendaId = utils.ComparaIntComNull(dr["VENDAID"].ToString());
                movEst.UsuarioId = utils.ComparaIntComZero(dr["USUARIOID"].ToString());
                movEst.Valor = utils.ComparaDecimalComZero(dr["VALOR"].ToString());
                movEst.ItemEstoqueId = int.Parse(dr["ITEMESTOQUEID"].ToString());
                movEst.Quantidade = utils.ComparaIntComZero(dr["QUANTIDADE"].ToString());
                movEst.NotaEntradaId = utils.ComparaIntComNull(dr["NOTAENTRADAID"].ToString());
                movEst.Tipo = dr["TIPO"].ToString();
                movEst.Data = Convert.ToDateTime(dr["DATA"].ToString());
                movEstoque.Add(movEst);

                if (movEst.VendaId != null)
                {
                    VendasDA vendasDA = new VendasDA();
                    List<Vendas> ven = vendasDA.PesquisarDA(movEst.VendaId != null ? (int)movEst.VendaId : 0);
                    Vendas vendas = new Vendas();

                    foreach (Vendas ltVen in ven)
                       vendas.Numero = ltVen.Numero;

                    movEst.Vendas = vendas;
                }
                
                UsuariosDA usuariosDA = new UsuariosDA();
                List<Usuarios> usu = usuariosDA.PesquisarDA(movEst.UsuarioId);
                Usuarios usuarios = new Usuarios();

                foreach (Usuarios ltUsu in usu)
                {
                    usuarios.Nome = ltUsu.Nome;
                }

                movEst.Usuarios = usuarios;
                
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
            }

            return movEstoque;
        }
        #endregion

        public bool InserirDA(MovimentosEstoque movEst)
        {
            SqlParameter[] paramsToSP = new SqlParameter[7];

            paramsToSP[0] = new SqlParameter("@vendaid", movEst.VendaId);
            paramsToSP[1] = new SqlParameter("@usuarioid", movEst.UsuarioId);
            paramsToSP[2] = new SqlParameter("@itemestoqueid", movEst.ItemEstoqueId);
            paramsToSP[3] = new SqlParameter("@quantidade", movEst.Quantidade);
            paramsToSP[4] = new SqlParameter("@notaentradaid", movEst.NotaEntradaId);
            paramsToSP[5] = new SqlParameter("@tipo", movEst.Tipo);
            paramsToSP[6] = new SqlParameter("@data", movEst.Data);

           // try
            //{
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_insert_MovimentosEstoque", paramsToSP);

                return true;
            //}
           // catch (Exception e)
            //{
             //   return false;
           // }
        }

        public bool EditarDA(MovimentosEstoque movEst)
        {
            SqlParameter[] paramsToSP = new SqlParameter[8];

            paramsToSP[0] = new SqlParameter("@id", movEst.Id);
            paramsToSP[1] = new SqlParameter("@vendaid", movEst.VendaId);
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
                                                                CommandType.Text, string.Format(@" SELECT * FROM MOVIMENTOSESTOQUE " +
                                                                                                 " WHERE ITEMESTOQUEID = '{0}'", id_ItEst));


            List<MovimentosEstoque> movEstoque = CarregarObjMovimentoEstoque(dr);

            return movEstoque;
        }

        public List<MovimentosEstoque> PesquisarDA(int item_id, DateTime? data)
        {
            string consulta = "";

            if (item_id != null && data != null )
            {
                consulta = string.Format(@"SELECT * " +
                                          " FROM MOVIMENTOSESTOQUE M " +
                                          "     ,ITENSESTOQUE IE " +                                             
                                          " WHERE M.ITEMESTOQUEID = IE.ID " +
                                          "   AND IE.ID = {0} " +
                                          "   AND M.DATA = '{1}' " , item_id, data != null? Convert.ToDateTime(data).ToString("MM/dd/yyyy") : "");                   
            }
            else if (item_id != null)
            {
                consulta = string.Format(@"SELECT * " +
                                         " FROM MOVIMENTOSESTOQUE M " +
                                         "     ,ITENSESTOQUE IE " +
                                         " WHERE M.ITEMESTOQUEID = IE.ID " +
                                         "   AND IE.ID = {0} ", item_id);                                                     
            }


            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, consulta);
                                  

            List<MovimentosEstoque> movEstoque = CarregarObjMovimentoEstoque(dr);

            return movEstoque;
        }

        public Int32 PesquisarTotalMovimentosDA(Int32 id_ItEst)
        {
            Int32 total = 0;
            DataSet ds = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                          CommandType.Text, string.Format(@" SELECT SUM(ME.QUANTIDADE) " +
                                                                                           " - (SELECT SUM(M.QUANTIDADE) FROM MOVIMENTOSESTOQUE M WHERE M.ITEMESTOQUEID = {0} AND M.TIPO ='S') TOTAL " +
                                                                                           "         FROM MOVIMENTOSESTOQUE ME " + 
                                                                                           "         WHERE ME.ITEMESTOQUEID = {0} " +
                                                                                           "         AND ME.TIPO = 'E' ",id_ItEst)); 




            if (ds.Tables[0].Rows.Count != 0)
               total = utils.ComparaIntComZero(ds.Tables[0].Rows[0]["TOTAL"].ToString());
                       
            return total;
 
        }
    }
}
