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

        public List<Agencias> PesquisarBL(int age)
        {
            AgenciasDA ageDA = new AgenciasDA();

            return ageDA.PesquisarDA(age);
        }

        public List<Agencias> PesquisarBanDA(int id_ban)
        {
            AgenciasDA ageDA = new AgenciasDA();

            return ageDA.PesquisarBanDA(id_ban); 
        }

        public List<Agencias> PesquisarBL(string campo, string valor)
        {
            AgenciasDA agenciaDA = new AgenciasDA();

            return agenciaDA.PesquisarDA(campo, valor);
        }

        public override List<Base> Pesquisar(string codDes)
        {
            AgenciasDA ageDA = new AgenciasDA();

            return ageDA.Pesquisar(codDes);
        }
    }
}
