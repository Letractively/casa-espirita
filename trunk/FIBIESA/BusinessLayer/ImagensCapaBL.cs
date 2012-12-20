using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using DataAccess;

namespace BusinessLayer
{
    public class ImagensCapaBL
    {
        public bool InserirBL(ImagensCapa instancia)
        {
            /*criar as regras de negocio*/
            ImagensCapaDA varDA = new ImagensCapaDA();

            return varDA.InserirDA(instancia);
        }

        public bool EditarBL(ImagensCapa instancia)
        {
            /*criar as regras de negocio*/
            ImagensCapaDA varDA = new ImagensCapaDA();

            return varDA.EditarDA(instancia);
        }

        public bool ExcluirBL(ImagensCapa instancia)
        {
            /*criar as regras de negocio*/
            ImagensCapaDA varDA = new ImagensCapaDA();

            return varDA.ExcluirDA(instancia);
        }

        public List<ImagensCapa> PesquisarBL()
        {
            /*criar as regras de negocio*/
            ImagensCapaDA varDA = new ImagensCapaDA();

            return varDA.PesquisarDA();
        }
    }
}
