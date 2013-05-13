using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using DataAccess;
using System.Data;

namespace BusinessLayer
{
    public class ItensEstoqueBL : BaseBL
    {
        public bool InserirBL(ItensEstoque id_itEst)
        {
            /*criar as regras de negocio*/
            ItensEstoqueDA itenEstoqueDA = new ItensEstoqueDA();

            return itenEstoqueDA.InserirDA(id_itEst);
        }

        public bool EditarBL(ItensEstoque id_itEst)
        {
            /*criar as regras de negocio*/
            ItensEstoqueDA itensEstoqueDA = new ItensEstoqueDA();

            return itensEstoqueDA.EditarDA(id_itEst);
        }

        public bool ExcluirBL(ItensEstoque id_itEst)
        {
            /*criar as regras de negocio*/
            ItensEstoqueDA ItensEstoqueDA = new ItensEstoqueDA();

            return ItensEstoqueDA.ExcluirDA(id_itEst);
        }

        public List<ItensEstoque> PesquisarBL()
        {
            /*criar as regras de negocio*/
            ItensEstoqueDA itensEstoqueDA = new ItensEstoqueDA();

            return itensEstoqueDA.PesquisarDA();
        }

        public List<ItensEstoque> PesquisarBL(int status)
        {
            /*criar as regras de negocio*/
            ItensEstoqueDA itensEstoqueDA = new ItensEstoqueDA();

            return itensEstoqueDA.PesquisarDA(status);
        }
                       
        public List<ItensEstoque> PesquisarMovObraBL(Int32 id_obra)
        {
            /*criar as regras de negocio*/
            ItensEstoqueDA itensEstoqueDA = new ItensEstoqueDA();

            return itensEstoqueDA.PesquisarMovObraDA(id_obra);
        }

        public List<ItensEstoque> PesquisarBL(string campo, string valor, int status)
        {
            /*criar as regras de negocio*/
            ItensEstoqueDA itensEstoqueDA = new ItensEstoqueDA();

            return itensEstoqueDA.PesquisarDA(campo, valor, status);
        }

        public List<ItensEstoque> PesquisarBL(string campo, string valor)
        {
            /*criar as regras de negocio*/
            ItensEstoqueDA itensEstoqueDA = new ItensEstoqueDA();

            return itensEstoqueDA.PesquisarDA(campo,valor);
        }

        public List<ItensEstoque> PesquisarIemBL(int itEst_id)
        {
            /*criar as regras de negocio*/
            ItensEstoqueDA itensEstoqueDA = new ItensEstoqueDA();

            return itensEstoqueDA.PesquisarIemDA(itEst_id);
        }

        public List<ItensEstoque> PesquisarBuscaBL(string valor)
        {
            /*criar as regras de negocio*/
            ItensEstoqueDA itensEstoqueDA = new ItensEstoqueDA();

            return itensEstoqueDA.PesquisarBuscaDA(valor);

        }

        public DataSet PesquisarItensEstoqueBL(int id_movEst)
        {
            ItensEstoqueDA itEstDA = new ItensEstoqueDA();

            return itEstDA.PesquisarItensEstoqueDA(id_movEst);
        }
    }
}
