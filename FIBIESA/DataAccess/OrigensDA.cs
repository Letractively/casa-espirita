using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;

namespace DataAccess
{
    public class OrigensDA
    {
        public bool InserirDA(Origens instancia)
        {
            return true;
        }

        public bool EditarDA(Origens instancia)
        {
            return true;
        }

        public bool ExcluirDA(Origens instancia)
        {
            return true;
        }

        public List<Origens> PesquisarDA()
        {
            List<Origens> instancia = new List<Origens>();
            return instancia;
        }
    }
}
