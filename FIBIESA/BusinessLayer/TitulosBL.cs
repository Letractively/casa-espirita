using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using DataAccess;

namespace BusinessLayer
{
    public class TitulosBL : BaseBL
    {
        public bool InserirBL(Titulos tit)
        {
            TitulosDA titDA = new TitulosDA();
            return titDA.InserirDA(tit);
        }

        public bool EditarBL(Titulos tit)
        {
            TitulosDA titDA = new TitulosDA();
            return titDA.EditarDA(tit);
        }

        public bool ExcluirBL(Titulos tit)
        {
            TitulosDA titDA = new TitulosDA();
            return titDA.ExcluirDA(tit);
        }

        public List<Titulos> PesquisarBL()
        {
            TitulosDA titDA = new TitulosDA();
            return titDA.PesquisarDA();
        }

        public List<Titulos> PesquisarBL(int tit)
        {
            TitulosDA titDA = new TitulosDA();
            return titDA.PesquisarDA(tit);
        }

        public List<Titulos> PesquisarBuscaBL(string valor)
        {
            TitulosDA titDA = new TitulosDA();
            return titDA.PesquisarBuscaDA(valor);
        }

        public override List<Base> Pesquisar(string codDes)
        {
            TitulosDA titDA = new TitulosDA();

            return titDA.Pesquisar(codDes);
        }

    }

}
