using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using DataAccess;
using System.Data;

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

        public DataSet PesquisarBL(int id_cid)
        {
            CidadesDA cidadesDA = new CidadesDA();

            return cidadesDA.PesquisaDA(id_cid);
        }

        public List<Cidades> PesquisaCidUfDA(int id_uf)
        {
            CidadesDA cidadesDA = new CidadesDA();

            return cidadesDA.PesquisaCidUfDA(id_uf);
        }
               
        public List<Cidades> PesquisarBuscaBL(string valor)
        {
            /*criar as regras de negocio*/
            CidadesDA cidadesDA = new CidadesDA();

            return cidadesDA.PesquisarBuscaDA(valor);
        }

        public override List<Base> Pesquisar(string codDes)
        {
            CidadesDA cidDA = new CidadesDA();

            return cidDA.Pesquisar(codDes);
        }
    }
}
