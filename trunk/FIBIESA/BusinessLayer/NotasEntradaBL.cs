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
        private bool IsValid(NotasEntrada ntE)
        {
            bool valido;
            valido = ntE.Numero > 0 && ntE.Serie > 0; 
            valido = valido && ntE.Data != null;
            return valido;
        }

        public int InserirBL(NotasEntrada ntE)
        {
            if (IsValid(ntE))
            {
                NotasEntradaDA NotasEntradaDA = new NotasEntradaDA();

                return NotasEntradaDA.InserirDA(ntE);
            }
            else
                return 0;
        }

        public bool EditarBL(NotasEntrada ntE)
        {
            if (ntE.Id > 0 && IsValid(ntE))
            {
                NotasEntradaDA NotasEntradaDA = new NotasEntradaDA();

                return NotasEntradaDA.EditarDA(ntE);
            }
            else
                return false;
        }

        public bool ExcluirBL(NotasEntrada ntE)
        {
            if (ntE.Id > 0)
            {
                NotasEntradaDA NotasEntradaDA = new NotasEntradaDA();

                return NotasEntradaDA.ExcluirDA(ntE);
            }
            else
                return false;
        }

        public List<NotasEntrada> PesquisarBL()
        {
            /*criar as regras de negocio*/
            NotasEntradaDA NotasEntradaDA = new NotasEntradaDA();

            return NotasEntradaDA.PesquisarDA();
        }

        public List<NotasEntrada> PesquisarBL(string campo, string valor)
        {
            NotasEntradaDA notaEntDA = new NotasEntradaDA();

            return notaEntDA.PesquisarDA(campo, valor);
        }

        public List<NotasEntrada> PesquisarBL(int ntE)
        {
            NotasEntradaDA notasEntradaDA = new NotasEntradaDA();

            return notasEntradaDA.PesquisarDA(ntE);
        }

        public List<NotasEntrada> PesquisarBuscaBL(string valor)
        {
            NotasEntradaDA notasEntradaDA = new NotasEntradaDA();

            return notasEntradaDA.PesquisarBuscaDA(valor);
        }

        public bool CodigoJaUtilizadoBL(Int32 codigo)
        {
            NotasEntradaDA nteDA = new NotasEntradaDA();

            return nteDA.CodigoJaUtilizadoDA(codigo);
        }
    }
}
