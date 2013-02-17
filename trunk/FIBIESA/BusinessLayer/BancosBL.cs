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

        public override List<Base> Pesquisar(string codDes, string tipo)
        {
            BancosDA banDA = new BancosDA();

            return banDA.Pesquisar(codDes, tipo);
        }
    }
}
