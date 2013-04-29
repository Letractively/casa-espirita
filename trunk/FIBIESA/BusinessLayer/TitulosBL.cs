﻿using System;
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

        public List<Titulos> PesquisarBL(int pes)
        {
            TitulosDA titDA = new TitulosDA();
            return titDA.PesquisarDA(pes);
        }

        public List<Titulos> PesquisarBL(string campo, string valor)
        {
            TitulosDA titulosDA = new TitulosDA();
            return titulosDA.PesquisarDA(campo, valor);
        }

        public override List<Base> Pesquisar(string tipo)
        {
            TitulosDA titDA = new TitulosDA();
            return titDA.Pesquisar(tipo);
        }

    }


}
