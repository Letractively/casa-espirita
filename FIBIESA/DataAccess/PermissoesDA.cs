using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;

namespace DataAccess
{
    public class PermissoesDA
    {
        public bool InserirDA(Permissoes per)
        {
            return true;
        }

        public bool EditarDA(Permissoes per)
        {
            return true;
        }

        public bool ExcluirDA(Permissoes per)
        {
            return true;
        }

        public List<Permissoes> PesquisarDA()
        {
            List<Permissoes> permissoes = new List<Permissoes>();
            return permissoes;
        }
    }
}
