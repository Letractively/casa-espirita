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
    public class NotasEntradaItensDA
    {
        Utils utils = new Utils();
        #region funcoes
        private List<NotasEntradaItens> CarregarObjNotaEntrada(SqlDataReader dr)
        {
            List<NotasEntradaItens> NotasEntradaItens = new List<NotasEntradaItens>();

            while (dr.Read())
            {
                NotasEntradaItens ntEi = new NotasEntradaItens();
                ntEi.Id = int.Parse(dr["ID"].ToString());
                ntEi.NotaEntradaId = int.Parse(dr["NOTAENTRADAID"].ToString());
                ntEi.Valor = utils.ComparaDecimalComZero(dr["VALOR"].ToString());
                ntEi.Quantidade = utils.ComparaIntComZero(dr["QUANTIDADE"].ToString());
                ntEi.ItemEstoqueId = utils.ComparaIntComZero(dr["ITEMESTOQUEID"].ToString());
                
                Obras obra = new Obras();
                obra.Codigo = utils.ComparaIntComZero(dr["CODIGO"].ToString());
                obra.Titulo = dr["TITULO"].ToString();
                ntEi.Obra = obra;

                NotasEntradaItens.Add(ntEi);
            }

            return NotasEntradaItens;
        }

        #endregion

        public bool InserirDA(NotasEntradaItens ntEi)
        {
            SqlParameter[] paramsToSP = new SqlParameter[4];

            paramsToSP[0] = new SqlParameter("@notaentradaid", ntEi.NotaEntradaId);
            paramsToSP[1] = new SqlParameter("@valor", ntEi.Valor);
            paramsToSP[2] = new SqlParameter("@quantidade", ntEi.Quantidade);
            paramsToSP[3] = new SqlParameter("@itemestoqueid", ntEi.ItemEstoqueId);

            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_insert_NotaEntradaItens", paramsToSP);

            return true;
        }

        public bool EditarDA(NotasEntradaItens ntEi)
        {
            SqlParameter[] paramsToSP = new SqlParameter[5];

            paramsToSP[0] = new SqlParameter("@id", ntEi.Id);
            paramsToSP[1] = new SqlParameter("@notaentradaid", ntEi.NotaEntradaId);
            paramsToSP[2] = new SqlParameter("@valor", ntEi.Valor);
            paramsToSP[3] = new SqlParameter("@quantidade", ntEi.Quantidade);
            paramsToSP[4] = new SqlParameter("@itemestoqueid", ntEi.ItemEstoqueId);

            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_update_NotaEntradaItens", paramsToSP);

            return true;
        }

        public bool ExcluirDA(NotasEntradaItens ntEi)
        {
            SqlParameter[] paramsToSP = new SqlParameter[1];

            paramsToSP[0] = new SqlParameter("@id", ntEi.Id);

            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_delete_NotaEntradaItens", paramsToSP);

            return true;
        }

        public List<NotasEntradaItens> PesquisarDA()
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, string.Format(@"SELECT NI.*, O.CODIGO, O.TITULO " +
                                                                                                 " FROM NOTAENTRADAITENS NI" +
                                                                                                 "     ,ITENSESTOQUE IE " +
                                                                                                 "     ,OBRAS O " +
                                                                                                 " WHERE NI.ITEMESTOQUEID = IE.ID " +
                                                                                                 "   AND IE.OBRAID = O.ID "));
                                                                                                

            List<NotasEntradaItens> NotasEntradaItens = CarregarObjNotaEntrada(dr);

            return NotasEntradaItens;

        }

        public List<NotasEntradaItens> PesquisarDA(int id_ntEi)
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                       CommandType.Text, string.Format(@"SELECT NI.*, O.CODIGO, O.TITULO " +
                                                                                       " FROM NOTAENTRADAITENS NI" +
                                                                                       "     ,ITENSESTOQUE IE " +
                                                                                       "     ,OBRAS O " +
                                                                                       " WHERE NI.ITEMESTOQUEID = IE.ID " +
                                                                                       "   AND IE.OBRAID = O.ID " +
                                                                                       "   AND NI.ID = {0} ", id_ntEi));

            List<NotasEntradaItens> NotasEntradaItens = CarregarObjNotaEntrada(dr);

            return NotasEntradaItens;
        }
    }
}
