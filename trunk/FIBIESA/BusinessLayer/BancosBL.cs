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
        private bool IsValid(Bancos ban)
        {
            bool valido;
            valido = ban.Descricao.Length <= 70;
                                  
            return valido;
        }

        public bool InserirBL(Bancos ban)
        {
            if (IsValid(ban))
            {
                BancosDA bancosDA = new BancosDA();

                return bancosDA.InserirDA(ban);
            }
            else
                return false;
        }

        public bool EditarBL(Bancos ban)
        {
            if (ban.Id > 0 && IsValid(ban))
            {
                BancosDA bancosDA = new BancosDA();

                return bancosDA.EditarDA(ban);
            }
            else
                return false;
        }

        public bool ExcluirBL(Bancos ban)
        {
            if (ban.Id > 0)
            {
                BancosDA bancosDA = new BancosDA();

                return bancosDA.ExcluirDA(ban);
            }
            else
                return false;
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
