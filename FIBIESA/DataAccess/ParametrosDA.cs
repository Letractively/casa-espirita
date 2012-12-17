using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;

namespace DataAccess
{
    public class ParametrosDA
    {
        public bool InserirDA(Parametros par)
        {
            return true;
        }

        public bool EditarDA(Parametros par)
        {
            return true;
        }

        public bool ExcluirDA(Parametros par)
        {
            return true;
        }

        public List<Parametros> PesquisarDA()
        {
            List<Parametros> parametros = new List<Parametros>();
            return parametros;
        }
    }
}
