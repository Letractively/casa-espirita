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
        public bool InserirBL(Origens instancia)
        {
            /*criar as regras de negocio*/
            OrigensDA varDA = new OrigensDA();

            return varDA.InserirDA(instancia);
        }

        public bool EditarBL(Origens instancia)
        {
            /*criar as regras de negocio*/
            OrigensDA varDA = new OrigensDA();

            return varDA.EditarDA(instancia);
        }

        public bool ExcluirBL(Origens instancia)
        {
            /*criar as regras de negocio*/
            OrigensDA varDA = new OrigensDA();

            return varDA.ExcluirDA(instancia);
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
