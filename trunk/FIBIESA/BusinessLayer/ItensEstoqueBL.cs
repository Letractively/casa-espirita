using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using DataAccess;

namespace BusinessLayer
{
    public class ItensEstoqueBL
    {
        public bool InserirBL(ItensEstoque itenes)
        {
            /*criar as regras de negocio*/
            ItensEstoqueDA itenEstoqueDA = new ItensEstoqueDA();

            return itenEstoqueDA.InserirDA(itenes);
        }

        public bool EditarBL(ItensEstoque itenes)
        {
            /*criar as regras de negocio*/
            ItensEstoqueDA itensEstoqueDA = new ItensEstoqueDA();

            return itensEstoqueDA.EditarDA(itenes);
        }

        public bool ExcluirBL(ItensEstoque itenes)
        {
            /*criar as regras de negocio*/
            ItensEstoqueDA ItensEstoqueDA = new ItensEstoqueDA();

            return ItensEstoqueDA.ExcluirDA(itenes);
        }

        public List<ItensEstoque> PesquisarBL()
        {
            /*criar as regras de negocio*/
            ItensEstoqueDA itensEstoqueDA = new ItensEstoqueDA();

            return itensEstoqueDA.PesquisarDA();
        }
    }
}
