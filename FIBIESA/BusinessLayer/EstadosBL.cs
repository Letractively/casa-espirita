using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using DataAccess;

namespace BusinessLayer
{
    public class EstadosBL
    {
        public bool InserirBL(Estados est)
        {
            /*criar as regras de negocio*/
            EstadosDA estadosDA = new EstadosDA();

            return estadosDA.InserirDA(est);
        }

        public bool EditarBL(Estados est)
        {
            /*criar as regras de negocio*/
            EstadosDA estadosDA = new EstadosDA();

            return estadosDA.EditarDA(est);
        }

        public bool ExcluirBL(Estados est)
        {
            /*criar as regras de negocio*/
            EstadosDA estadosDA = new EstadosDA();

            return estadosDA.ExcluirDA(est);
        }

        public List<Estados> PesquisarBL()
        {
            /*criar as regras de negocio*/
            EstadosDA estadosDA = new EstadosDA();

            return estadosDA.PesquisarDA();
        }
    }
}
