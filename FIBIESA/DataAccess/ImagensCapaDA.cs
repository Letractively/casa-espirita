using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;

namespace DataAccess
{
    public class ImagensCapaDA
    {
        public bool InserirDA(ImagensCapa instancia)
        {
            return true;
        }

        public bool EditarDA(ImagensCapa instancia)
        {
            return true;
        }

        public bool ExcluirDA(ImagensCapa instancia)
        {
            return true;
        }

        public List<ImagensCapa> PesquisarDA()
        {
            List<ImagensCapa> instancia = new List<ImagensCapa>();
            return instancia;
        }
    }
}
