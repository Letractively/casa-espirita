using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using DataAccess;

namespace BusinessLayer
{
    public class ObrasAutoresBL
    {
        public bool InserirBL(ObrasAutores obAt)
        {
            /*criar as regras de negocio*/
            ObrasAutoresDA obrasAutoresDA = new ObrasAutoresDA();

            return obrasAutoresDA.InserirDA(obAt);
        }

        public bool EditarBL(ObrasAutores obAt)
        {
            /*criar as regras de negocio*/
            ObrasAutoresDA obrasAutoresDA = new ObrasAutoresDA();

            return obrasAutoresDA.EditarDA(obAt);
        }

        public bool ExcluirBL(ObrasAutores obAt)
        {
            /*criar as regras de negocio*/
            ObrasAutoresDA obrasAutoresDADA = new ObrasAutoresDA();

            return obrasAutoresDADA.ExcluirDA(obAt);
        }

        public List<ObrasAutores> PesquisarBL()
        {
            /*criar as regras de negocio*/
            ObrasAutoresDA obrasAutoresDA = new ObrasAutoresDA();

            return obrasAutoresDA.PesquisarDA();
        }

        public List<ObrasAutores> PesquisarBL(int obAt)
        {
            ObrasAutoresDA ObrasAutoresDADA = new ObrasAutoresDA();

            return ObrasAutoresDADA.PesquisarDA(obAt);
        }

       

    }
}
