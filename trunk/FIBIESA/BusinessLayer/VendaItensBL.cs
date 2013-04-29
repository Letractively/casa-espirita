using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using DataAccess;
using System.Data;

namespace BusinessLayer
{
    public class VendaItensBL
    {
        private bool IsValid(VendaItens venIt)
        {
            bool valido;
            valido = venIt.Situacao.Trim() == "A";
            valido = valido && venIt.ItemEstoqueId > 0 && venIt.Quantidade > 0 && venIt.Valor > 0;
            return valido;
        }
        
        public Int32 InserirBL(VendaItens venIt)
        {
            if (IsValid(venIt))
            {
                VendaItensDA venItDA = new VendaItensDA();

                return venItDA.InserirDA(venIt);
            }
            return 0;
        }

        public bool EditarBL(VendaItens venIt)
        {
            if (venIt.Id > 0)
            {
                VendaItensDA venItDA = new VendaItensDA();

                return venItDA.EditarDA(venIt);
            }
            return false;
        }

        public bool ExcluirBL(VendaItens venIt)
        {
            if (venIt.Id > 0)
            {
                VendaItensDA venItDA = new VendaItensDA();

                return venItDA.ExcluirDA(venIt);
            }
            return false;
        }

        public bool CancelarVendaItemBL(int id_venIt)
        {
            if (id_venIt > 0)
            {
                VendaItensDA venItDA = new VendaItensDA();

                return venItDA.CancelarVendaItemDA(id_venIt);
            }
            return false;
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

        public DataSet PesquisarBLDataSet(int venda)
        {
            VendaItensDA venItDA = new VendaItensDA();

            return venItDA.PesquisarDADataSet(venda);
        }
    }
}
