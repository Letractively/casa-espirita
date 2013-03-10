using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using System.Data;
using System.Data.SqlClient;
using InfrastructureSqlServer.Helpers;
using System.Configuration;

namespace DataAccess
{
    public class ItensEstoqueDA
    {
        public bool InserirDA(ItensEstoque itenes)
        {
            return true;
        }

        public bool EditarDA(ItensEstoque itenes)
        {
            return true;
        }

        public bool ExcluirDA(ItensEstoque itenes)
        {
            return true;
        }

        public List<ItensEstoque> PesquisarDA()
        {
            List<ItensEstoque> itensEstoque = new List<ItensEstoque>();
            return itensEstoque;
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
