using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using DataObjects;

namespace BusinessLayer
{
    public class NotasEntradaBL
    {
        public int InserirBL(NotasEntrada ntE)
        {
            /*criar as regras de negocio*/
            NotasEntradaDA NotasEntradaDA = new NotasEntradaDA();

            return NotasEntradaDA.InserirDA(ntE);
        }

        public bool EditarBL(NotasEntrada ntE)
        {
            /*criar as regras de negocio*/
            NotasEntradaDA NotasEntradaDA = new NotasEntradaDA();

            return NotasEntradaDA.EditarDA(ntE);
        }

        public bool ExcluirBL(NotasEntrada ntE)
        {
            /*criar as regras de negocio*/
            NotasEntradaDA NotasEntradaDA = new NotasEntradaDA();

            return NotasEntradaDA.ExcluirDA(ntE);
        }

        public List<NotasEntrada> PesquisarBL()
        {
            /*criar as regras de negocio*/
            NotasEntradaDA NotasEntradaDA = new NotasEntradaDA();

            return NotasEntradaDA.PesquisarDA();
        }

        public List<NotasEntrada> PesquisarBL(int ntE)
        {
            NotasEntradaDA NotasEntradaDA = new NotasEntradaDA();

            return NotasEntradaDA.PesquisarDA(ntE);
        }
                
    }
}
