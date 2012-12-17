using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;

namespace DataAccess
{
    public class TelefonesDA
    {
        public bool InserirDA(Telefones tel)
        {
            return true;
        }

        public bool EditarDA(Telefones tel)
        {
            return true;
        }

        public bool ExcluirDA(Telefones tel)
        {
            return true;
        }

        public List<Telefones> PesquisarDA()
        {
            List<Telefones> telefones = new List<Telefones>();
            return telefones;
        }
    }
}
