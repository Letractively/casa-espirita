using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using DataAccess;
using System.Data;

namespace BusinessLayer
{
    public class BairrosBL : BaseBL
    {
        public bool InserirBL(Bairros bai)
        {
            /*criar as regras de negocio*/
            BairrosDA bairrosDA = new BairrosDA();

            return bairrosDA.InserirDA(bai);
        }

        public bool EditarBL(Bairros bai)
        {
            /*criar as regras de negocio*/
            BairrosDA bairrosDA = new BairrosDA();

            return bairrosDA.EditarDA(bai);
        }

        public bool ExcluirBL(Bairros bai)
        {
            /*criar as regras de negocio*/
             BairrosDA bairrosDA = new BairrosDA();

            return bairrosDA.ExcluirDA(bai);
        }

        public List<Bairros> PesquisarBL()
        {
            /*criar as regras de negocio*/
            BairrosDA bairrosDA = new BairrosDA();

            return bairrosDA.PesquisarDA();
        }

        public List<Bairros> PesquisarBL(int bai)
        {
            BairrosDA bairrosDA = new BairrosDA();

            return bairrosDA.PesquisarDA(bai);
        }

        public List<Bairros> PesquisarCidBL(int id_cid)
        {
            BairrosDA bairrosDA = new BairrosDA();

            return bairrosDA.PesquisarCidDA(id_cid);
        }

        public DataSet PesquisaBL(int id_bai)
        {
            BairrosDA bairrosDA = new BairrosDA();

            return bairrosDA.PesquisaDA(id_bai);
        }
        
        public List<Bairros> PesquisarBuscaBL(string valor)
        {
            /*criar as regras de negocio*/
            BairrosDA bairrosDA = new BairrosDA();

            return bairrosDA.PesquisarBuscaDA(valor);
        }

        public override List<Base> Pesquisar(string codDes)
        {
            BairrosDA baiDA = new BairrosDA();

            return baiDA.Pesquisar(codDes);
        }
       
    }
}
