using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using DataAccess;

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

        public override List<Base> Pesquisar(string codDes, string tipo)
        {
            BairrosDA baiDA = new BairrosDA();

            return baiDA.Pesquisar(codDes, tipo);
        }
    }
}
