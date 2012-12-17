using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;

namespace DataAccess
{
    public class EstadosDA
    {
        public bool InserirDA(Estados est)
        {
            return true;
        }

        public bool EditarDA(Estados est)
        {
            return true;
        }

        public bool ExcluirDA(Estados est)
        {
            return true;
        }

        public List<Estados> PesquisarDA()
        {
            List<Estados> estados = new List<Estados>();
            return estados;
        }
    }
}
