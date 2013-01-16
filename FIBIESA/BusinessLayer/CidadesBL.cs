using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using DataAccess;

namespace BusinessLayer
{
    public class CidadesBL : BaseBL
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

        public List<Cidades> PesquisarBL(int id_cid)
        {
            CidadesDA cidadesDA = new CidadesDA();

            return cidadesDA.PesquisaDA(id_cid);
        }

        public override List<Base> Pesquisar(string codDes, string tipo)
        {
            CidadesDA cidDA = new CidadesDA();

            return cidDA.Pesquisar(codDes, tipo);
        }
    }
}
