using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using DataAccess;

namespace DataAccess
{
    public class CategoriasDA
    {
        public bool InserirDA(Categorias cat)
        {
            return true;
        }

        public bool EditarDA(Categorias cat)
        {
            return true;
        }

        public bool ExcluirDA(Categorias cat)
        {
            return true;
        }

        public List<Categorias> PesquisarDA()
        {
            List<Categorias> categorias = new List<Categorias>();
            return categorias;
        }
    }
}
