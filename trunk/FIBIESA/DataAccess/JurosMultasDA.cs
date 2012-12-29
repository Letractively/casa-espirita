using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;

namespace DataAccess
{
    public class JurosMultasDA
    {
        public bool InserirDA(JurosMultas jurosmu)
        {
            return true;
        }

        public bool EditarDA(JurosMultas jurosmu)
        {
            return true;
        }

        public bool ExcluirDA(JurosMultas jurosmu)
        {
            return true;
        }

        public List<JurosMultas> PesquisarDA()
        {
            List<JurosMultas> itensEstoque = new List<JurosMultas>();
            return JurosMultas;
        }
    }
}
