using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using BusinessLayer;
using DataObjects;

namespace BusinessLayer
{
    public class BancosInstrucoesBL
    {
        private bool IsValid(BancosInstrucoes ban)
        {
            bool valido;
            valido = ban.Descricao.Length <= 70;
            valido = valido && ban.Codigo.Length <= 2 && ban.Bancoid > 0;

            return valido;
        }

        public bool InserirBL(BancosInstrucoes ban)
        {
            if (IsValid(ban))
            {
                BancosInstrucoesDA bancosDA = new BancosInstrucoesDA();

                return bancosDA.InserirDA(ban);
            }
            else
                return false;
        }

        public bool EditarBL(BancosInstrucoes ban)
        {
            if (ban.Id > 0 && IsValid(ban))
            {
                BancosInstrucoesDA bancosDA = new BancosInstrucoesDA();

                return bancosDA.EditarDA(ban);
            }
            else
                return false;
        }

        public bool ExcluirBL(BancosInstrucoes ban)
        {
            if (ban.Id > 0)
            {
                BancosInstrucoesDA bancosDA = new BancosInstrucoesDA();

                return bancosDA.ExcluirDA(ban);
            }
            else
                return false;
        }

        public List<BancosInstrucoes> PesquisarBL()
        {
            /*criar as regras de negocio*/
            BancosInstrucoesDA bancosDA = new BancosInstrucoesDA();

            return bancosDA.PesquisarDA();
        }

        public List<BancosInstrucoes> PesquisarBL(int ban)
        {
            BancosInstrucoesDA bancosDA = new BancosInstrucoesDA();

            return bancosDA.PesquisarDA(ban);
        }

        public List<BancosInstrucoes > PesquisarBuscaBL(string valor)
        {
            /*criar as regras de negocio*/
            BancosInstrucoesDA bancosDA = new BancosInstrucoesDA();

            return bancosDA.PesquisarBuscaDA(valor);
        }        
    }
}
