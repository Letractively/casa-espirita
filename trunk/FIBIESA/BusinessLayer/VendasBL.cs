using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using DataAccess;
using System.Data;

namespace BusinessLayer
{
    public class VendasBL
    {
        private bool IsValid(Vendas ven)
        {
            bool valido;
            valido = ven.Situacao.Trim() == "A";
            valido = valido && ven.PessoaId > 0 && ven.UsuarioId > 0;          
            return valido;
        }

        public Int32 InserirBL(Vendas ven)
        {
            if (IsValid(ven))
            {
                VendasDA vendasDA = new VendasDA();

                return vendasDA.InserirDA(ven);
            }
            else
                return 0;
        }

        public bool EditarBL(Vendas ven)
        {
            if (ven.Id > 0 && IsValid(ven))
            {
                VendasDA vendasDA = new VendasDA();

                return vendasDA.EditarDA(ven);
            }
            return false;
        }

        public bool ExcluirBL(Vendas ven)
        {
            if (ven.Id > 0)
            {
                VendasDA vendasDA = new VendasDA();

                return vendasDA.ExcluirDA(ven);
            }
            return false;
        }

        public bool CancelarVendaBL(int id_ven)
        {
            VendasDA vendasDA = new VendasDA();

            return vendasDA.CancelarVendaDA(id_ven);
        }

        public List<Vendas> PesquisarBL()
        {
            /*criar as regras de negocio*/
            VendasDA vendasDA = new VendasDA();

            return vendasDA.PesquisarDA();
        }

        public List<Vendas> PesquisarBL(int ven)
        {
            VendasDA vendasDA = new VendasDA();

            return vendasDA.PesquisarDA(ven);
        }

        public DataSet PesquisarBLDataSet(int ven)
        {
            VendasDA vendasDA = new VendasDA();
                        
            return vendasDA.PesquisarDADataSet(ven);
        }

        public List<Vendas> PesquisarBuscaBL(string valor)
        {
            VendasDA vendasDA = new VendasDA();

            return vendasDA.PesquisarBuscaDA(valor);
        }
    }
    
}
