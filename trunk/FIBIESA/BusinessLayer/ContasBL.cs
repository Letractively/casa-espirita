using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using DataAccess;

namespace BusinessLayer
{
    public class ContasBL : BaseBL
    {
        public bool InserirBL(Contas con)
        {
            /*criar as regras de negocio*/
            ContasDA conDA = new ContasDA();

            return conDA.InserirDA(con);
        }

        public bool EditarBL(Contas con)
        {
            /*criar as regras de negocio*/
            ContasDA conDA = new ContasDA();

            return conDA.EditarDA(con);
        }

        public bool ExcluirBL(Contas con)
        {
            /*criar as regras de negocio*/
            ContasDA conDA = new ContasDA();

            return conDA.ExcluirDA(con);
        }

        public List<Contas> PesquisarBL()
        {
            /*criar as regras de negocio*/
            ContasDA conDA = new ContasDA();

            return conDA.PesquisarDA();
        }

        public List<Contas> PesquisarBL(int con)
        {
            ContasDA conDA = new ContasDA();

            return conDA.PesquisarDA(con);
        }

        public override List<Base> Pesquisar(string codDes, string tipo)
        {
            ContasDA conDA = new ContasDA();

            return conDA.Pesquisar(codDes, tipo);
        }
    }
}
