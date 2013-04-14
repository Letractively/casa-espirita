using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using DataAccess;

namespace BusinessLayer
{
    public class VendaItensBL
    {
        public bool InserirBL(VendaItens venIt)
        {
            /*criar as regras de negocio*/
            VendaItensDA venItDA = new VendaItensDA();

            return venItDA.InserirDA(venIt);
        }

        public bool EditarBL(VendaItens ntE)
        {
            /*criar as regras de negocio*/
            VendaItensDA venItDA = new VendaItensDA();

            return venItDA.EditarDA(ntE);
        }

        public bool ExcluirBL(VendaItens venIt)
        {
            /*criar as regras de negocio*/
            VendaItensDA venItDA = new VendaItensDA();

            return venItDA.ExcluirDA(venIt);
        }

        public List<VendaItens> PesquisarBL()
        {
            /*criar as regras de negocio*/
            VendaItensDA venItDA = new VendaItensDA();

            return venItDA.PesquisarDA();
        }

        public List<VendaItens> PesquisarBL(int venIt)
        {
            VendaItensDA venItDA = new VendaItensDA();

            return venItDA.PesquisarDA(venIt);
        }
    }
}
