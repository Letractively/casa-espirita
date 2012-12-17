using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using DataAccess;

namespace BusinessLayer
{
    public class CidadesBL
    {
        public bool InserirBL(Cidades cid)
        {
            /*criar as regras de negocio*/
            CidadesDA cidadesDA = new CidadesDA();

            return cidadesDA.InserirDA(cid);
        }

        public bool EditarBL(Cidades cid)
        {
            /*criar as regras de negocio*/
            CidadesDA cidadesDA = new CidadesDA();

            return cidadesDA.EditarDA(cid);
        }

        public bool ExcluirBL(Cidades cid)
        {
            /*criar as regras de negocio*/
            CidadesDA cidadesDA = new CidadesDA();

            return cidadesDA.ExcluirDA(cid);
        }

        public List<Cidades> PesquisarBL()
        {
            /*criar as regras de negocio*/
            CidadesDA cidadesDA = new CidadesDA();

            return cidadesDA.PesquisarDA();
        }
    }
}
