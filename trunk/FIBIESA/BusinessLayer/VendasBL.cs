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
        public Int32 InserirBL(Vendas ven)
        {
            /*criar as regras de negocio*/
            VendasDA vendasDA = new VendasDA();

            return vendasDA.InserirDA(ven);
        }

        public bool EditarBL(Vendas ven)
        {
            /*criar as regras de negocio*/
            VendasDA vendasDA = new VendasDA();

            return vendasDA.EditarDA(ven);
        }

        public bool ExcluirBL(Vendas ven)
        {
            /*criar as regras de negocio*/
            VendasDA vendasDA = new VendasDA();

            return vendasDA.ExcluirDA(ven);
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
    }
    
}
