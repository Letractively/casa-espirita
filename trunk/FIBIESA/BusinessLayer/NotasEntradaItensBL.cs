using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using DataAccess;

namespace BusinessLayer
{
    public class NotasEntradaItensBL
    {
        public bool InserirBL(NotasEntradaItens ntE)
        {
            /*criar as regras de negocio*/
            NotasEntradaItensDA ntEiDA = new NotasEntradaItensDA();

            return ntEiDA.InserirDA(ntE);
        }

        public bool EditarBL(NotasEntradaItens ntE)
        {
            /*criar as regras de negocio*/
            NotasEntradaItensDA ntEiDA = new NotasEntradaItensDA();

            return ntEiDA.EditarDA(ntE);
        }

        public bool ExcluirBL(NotasEntradaItens ntE)
        {
            /*criar as regras de negocio*/
            NotasEntradaItensDA ntEiDA = new NotasEntradaItensDA();

            return ntEiDA.ExcluirDA(ntE);
        }

        public List<NotasEntradaItens> PesquisarBL()
        {
            /*criar as regras de negocio*/
            NotasEntradaItensDA ntEiDA = new NotasEntradaItensDA();

            return ntEiDA.PesquisarDA();
        }

        public List<NotasEntradaItens> PesquisarBL(int ntE)
        {
            NotasEntradaItensDA ntEiDA = new NotasEntradaItensDA();

            return ntEiDA.PesquisarDA(ntE);
        }
    }
}

