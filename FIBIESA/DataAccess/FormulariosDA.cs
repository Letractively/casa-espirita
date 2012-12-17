using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;

namespace DataAccess
{
    public class FormulariosDA
    {
        public bool InserirDA(Formularios form)
        {
            return true;
        }

        public bool EditarDA(Formularios form)
        {
            return true;
        }

        public bool ExcluirDA(Formularios form)
        {
            return true;
        }

        public List<Formularios> PesquisarDA()
        {
            List<Formularios> formularios = new List<Formularios>();
            return formularios;
        }
    }
}
