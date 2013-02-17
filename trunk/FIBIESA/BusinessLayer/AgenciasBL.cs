using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using DataAccess;

namespace BusinessLayer
{
    public class AgenciasBL : BaseBL
    {
        public bool InserirBL(Agencias age)
        {
            /*criar as regras de negocio*/
            AgenciasDA ageDA = new AgenciasDA();

            return ageDA.InserirDA(age);
        }

        public bool EditarBL(Agencias age)
        {
            /*criar as regras de negocio*/
            AgenciasDA ageDA = new AgenciasDA();

            return ageDA.EditarDA(age);
        }

        public bool ExcluirBL(Agencias age)
        {
            /*criar as regras de negocio*/
            AgenciasDA ageDA = new AgenciasDA();

            return ageDA.ExcluirDA(age);
        }

        public List<Agencias> PesquisarBL()
        {
            /*criar as regras de negocio*/
            AgenciasDA ageDA = new AgenciasDA();

            return ageDA.PesquisarDA();
        }

        public List<Agencias> PesquisarBL(int bai)
        {
            AgenciasDA ageDA = new AgenciasDA();

            return ageDA.PesquisarDA(bai);
        }

        public override List<Base> Pesquisar(string codDes, string tipo)
        {
            AgenciasDA ageDA = new AgenciasDA();

            return ageDA.Pesquisar(codDes, tipo);
        }
    }
}
