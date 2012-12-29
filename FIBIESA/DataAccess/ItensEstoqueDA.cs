using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;

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
    }
}
