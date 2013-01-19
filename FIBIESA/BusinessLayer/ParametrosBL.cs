using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using DataObjects;

namespace BusinessLayer
{
    public class ParametrosBL
    {
        public bool InserirBL(Parametros par)
        {
            /*criar as regras de negocio*/
            ParametrosDA parametrosDA = new ParametrosDA();

            return parametrosDA.InserirDA(par);
        }

        public bool EditarBL(Parametros par)
        {
            /*criar as regras de negocio*/
            ParametrosDA parametrosDA = new ParametrosDA();

            return parametrosDA.EditarDA(par);
        }

        public bool ExcluirBL(Parametros par)
        {
            /*criar as regras de negocio*/
            ParametrosDA parametrosDA = new ParametrosDA();

            return parametrosDA.ExcluirDA(par);
        }

        public List<Parametros> PesquisarBL()
        {
            /*criar as regras de negocio*/
            ParametrosDA parametrosDA = new ParametrosDA();

            return parametrosDA.PesquisarDA();
        }

        public List<Parametros> PesquisarBL(int id_par)
        {
            ParametrosDA parametrosDA = new ParametrosDA();

            return parametrosDA.PesquisarDA(id_par);
        }

        public List<Parametros> PesquisarBL(int codigo, string modulo)
        {
            ParametrosDA parametrosDA = new ParametrosDA();

            return parametrosDA.PesquisarDA(codigo, modulo);
        }
    }
}
