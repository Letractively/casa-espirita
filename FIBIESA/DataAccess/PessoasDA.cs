using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;

namespace DataAccess
{
    public class PessoasDA
    {
        public bool InserirDA(Pessoas pes)
        {
            return true;
        }

        public bool EditarDA(Pessoas pes)
        {
            return true;
        }

        public bool ExcluirDA(Pessoas pes)
        {
            return true;
        }

        public List<Pessoas> PesquisarDA()
        {
            List<Pessoas> pessoas = new List<Pessoas>();
            return pessoas; 
        }
    }
}
