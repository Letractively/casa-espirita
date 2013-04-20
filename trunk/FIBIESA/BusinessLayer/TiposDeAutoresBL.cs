using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using DataAccess;

namespace BusinessLayer
{
    public class TiposDeAutoresBL : BaseBL
    {
        public bool InserirBL(TiposDeAutores instancia)
        {
            /*criar as regras de negocio*/
            TiposDeAutoresDA varDA = new TiposDeAutoresDA();

            return varDA.InserirDA(instancia);
        }

        public bool EditarBL(TiposDeAutores instancia)
        {
            /*criar as regras de negocio*/
            TiposDeAutoresDA varDA = new TiposDeAutoresDA();

            return varDA.EditarDA(instancia);
        }

        public bool ExcluirBL(TiposDeAutores instancia)
        {
            /*criar as regras de negocio*/
            TiposDeAutoresDA varDA = new TiposDeAutoresDA();

            return varDA.ExcluirDA(instancia);
        }

        public List<TiposDeAutores> PesquisarBL()
        {
            /*criar as regras de negocio*/
            TiposDeAutoresDA TiposDeAutoresDA = new TiposDeAutoresDA();

            return TiposDeAutoresDA.PesquisarDA();
        }

        public List<TiposDeAutores> PesquisarBL(int bai)
        {
            TiposDeAutoresDA TiposDeAutoresDA = new TiposDeAutoresDA();

            return TiposDeAutoresDA.PesquisarDA(bai);
        }

        public List<TiposDeAutores> PesquisarBL(string campo, string valor)
        {
            TiposDeAutoresDA TiposDeAutoresDA = new TiposDeAutoresDA();

            return TiposDeAutoresDA.PesquisarDA(campo, valor);
        }

        public List<TiposDeAutores> PesquisarBuscaBL(string valor)
        {
            /*criar as regras de negocio*/
            TiposDeAutoresDA tiposDeAutoresDA = new TiposDeAutoresDA();

            return tiposDeAutoresDA.PesquisarBuscaDA(valor);
        }

        public override List<Base> Pesquisar(string codDes)
        {
            TiposDeAutoresDA baiDA = new TiposDeAutoresDA();

            return baiDA.Pesquisar(codDes);
        }
    }
}
