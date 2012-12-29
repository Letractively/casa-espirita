using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;

namespace DataAccess
{
    public class MovimentosEstoqueDA
    {
        public bool InserirDA(MovimentosEstoque movEst)
        {
            return true;
        }

        public bool EditarDA(MovimentosEstoque movEst)
        {
            return true;
        }

        public bool ExcluirDA(MovimentosEstoque movEst)
        {
            return true;
        }

        public List<MovimentosEstoque> PesquisarDA()
        {
            List<MovimentosEstoque> movimentosEstoque = new List<MovimentosEstoque>();
            return movimentosEstoque;
        }
    }
}
