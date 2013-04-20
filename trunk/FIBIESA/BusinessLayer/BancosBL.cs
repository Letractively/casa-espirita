using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using DataAccess;

namespace BusinessLayer
{
    public class BancosBL : BaseBL
    {
        public bool InserirBL(Bancos ban)
        {
            /*criar as regras de negocio*/
            BancosDA bancosDA = new BancosDA();

            return bancosDA.InserirDA(ban);
        }

        public bool EditarBL(Bancos ban)
        {
            /*criar as regras de negocio*/
            BancosDA bancosDA = new BancosDA();

            return bancosDA.EditarDA(ban);
        }

        public bool ExcluirBL(Bancos ban)
        {
            /*criar as regras de negocio*/
            BancosDA bancosDA = new BancosDA();

            return bancosDA.ExcluirDA(ban);
        }

        public List<Bancos> PesquisarBL()
        {
            /*criar as regras de negocio*/
            BancosDA bancosDA = new BancosDA();

            return bancosDA.PesquisarDA();
        }

        public List<Bancos> PesquisarBL(int ban)
        {
            BancosDA bancosDA = new BancosDA();

            return bancosDA.PesquisarDA(ban);
        }
        
        public List<Bancos> PesquisarBuscaBL(string valor)
        {
            /*criar as regras de negocio*/
            BancosDA bancosDA = new BancosDA();

            return bancosDA.PesquisarBuscaDA(valor);
        }

        public override List<Base> Pesquisar(string codDes)
        {
            BancosDA banDA = new BancosDA();

            return banDA.Pesquisar(codDes);
        }
    }
}
