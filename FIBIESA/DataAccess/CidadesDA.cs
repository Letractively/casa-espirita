using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;

namespace DataAccess
{
    public class CidadesDA
    {
        public bool InserirDA(Cidades cid)
        {
            return true;
        }

        public bool EditarDA(Cidades cid)
        {
            return true;
        }

        public bool ExcluirDA(Cidades cid)
        {
            return true;
        }

        public List<Cidades> PesquisarDA()
        {
            List<Cidades> cidades = new List<Cidades>();
            return cidades;
        }
    }
}
