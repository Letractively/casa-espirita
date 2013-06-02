using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using DataAccess;

namespace BusinessLayer
{
    public class OrigensBL : BaseBL
    {
        private bool IsValid(Origens instancia)
        {
            bool valido;
            valido = instancia.Descricao.Length <= 40;

            return valido;
        }

        public bool InserirBL(Origens instancia)
        {
            if (IsValid(instancia))
            {
                OrigensDA varDA = new OrigensDA();

                return varDA.InserirDA(instancia);
            }
            else
                return false;
        }

        public bool EditarBL(Origens instancia)
        {
            if (instancia.Id > 0 && IsValid(instancia))
            {
                OrigensDA varDA = new OrigensDA();

                return varDA.EditarDA(instancia);
            }
            else
                return false;
        }

        public bool ExcluirBL(Origens instancia)
        {
            if (instancia.Id > 0)
            {
                OrigensDA varDA = new OrigensDA();

                return varDA.ExcluirDA(instancia);
            }
            else
                return false;                
        }

        public List<Origens> PesquisarBL()
        {
            /*criar as regras de negocio*/
            OrigensDA origensDA = new OrigensDA();

            return origensDA.PesquisarDA();
        }

        public List<Origens> PesquisarBL(int bai)
        {
            OrigensDA origensDA = new OrigensDA();

            return origensDA.PesquisarDA(bai);
        }

        public List<Origens> PesquisarBL(string campo, string valor)
        {
            OrigensDA origensDA = new OrigensDA();

            return origensDA.PesquisarDA(campo, valor);
        }

        public List<Origens> PesquisarBuscaBL(string valor)
        {
            /*criar as regras de negocio*/
            OrigensDA origensDA = new OrigensDA();

            return origensDA.PesquisarBuscaDA(valor);
        }

        public override List<Base> Pesquisar(string codDes)
        {
            OrigensDA origensDA = new OrigensDA();

            return origensDA.Pesquisar(codDes);
        }

    }
}
