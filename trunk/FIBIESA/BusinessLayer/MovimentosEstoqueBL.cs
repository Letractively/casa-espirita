using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using DataAccess;

namespace BusinessLayer
{
    public class MovimentosEstoqueBL
    {
        public bool InserirBL(MovimentosEstoque movEst)
        {
            /*criar as regras de negocio*/
            MovimentosEstoqueDA MovimentosEstoqueDA = new MovimentosEstoqueDA();

            return MovimentosEstoqueDA.InserirDA(movEst);
        }

        public bool EditarBL(MovimentosEstoque movEst)
        {
            /*criar as regras de negocio*/
            MovimentosEstoqueDA MovimentosEstoqueDA = new MovimentosEstoqueDA();

            return MovimentosEstoqueDA.EditarDA(movEst);
        }

        public bool ExcluirBL(MovimentosEstoque movEst)
        {
            /*criar as regras de negocio*/
            MovimentosEstoqueDA MovimentosEstoqueDA = new MovimentosEstoqueDA();

            return MovimentosEstoqueDA.ExcluirDA(movEst);
        }

        public List<MovimentosEstoque> PesquisarBL()
        {
            /*criar as regras de negocio*/
            MovimentosEstoqueDA movimentosestoqueDA = new MovimentosEstoqueDA();

            return movimentosestoqueDA.PesquisarDA();
        }
    }
}
