using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;

namespace DataAccess
{
    public class TiposDeAutoresDA
    {
        public bool InserirDA(TiposDeAutores instancia)
        {
            return true;
        }

        public bool EditarDA(TiposDeAutores instancia)
        {
            return true;
        }

        public bool ExcluirDA(TiposDeAutores instancia)
        {
            return true;
        }

        public List<TiposDeAutores> PesquisarDA()
        {
            List<TiposDeAutores> instancia = new List<TiposDeAutores>();
            return instancia;
        }
    }
}
