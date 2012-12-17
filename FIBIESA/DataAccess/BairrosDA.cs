using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;

namespace DataAccess
{
    public class BairrosDA
    {
        public bool InserirDA(Bairros bai)
        {
            return true;
        }

        public bool EditarDA(Bairros bai)
        {
            return true;
        }

        public bool ExcluirDA(Bairros pes)
        {
            return true;
        }

        public List<Bairros> PesquisarDA()
        {
            List<Bairros> bairros = new List<Bairros>();
            return bairros;
        }
    }
}
