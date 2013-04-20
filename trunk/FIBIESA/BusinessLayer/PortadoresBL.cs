using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using DataAccess;

namespace BusinessLayer
{
    public class PortadoresBL : BaseBL
    {
        public bool InserirBL(Portadores por)
        {
            /*criar as regras de negocio*/
            PortadoresDA porDA = new PortadoresDA();

            return porDA.InserirDA(por);
        }

        public bool EditarBL(Portadores por)
        {
            /*criar as regras de negocio*/
            PortadoresDA porDA = new PortadoresDA();

            return porDA.EditarDA(por);
        }

        public bool ExcluirBL(Portadores por)
        {
            /*criar as regras de negocio*/
            PortadoresDA porDA = new PortadoresDA();

            return porDA.ExcluirDA(por);
        }

        public List<Portadores> PesquisarBL()
        {
            /*criar as regras de negocio*/
            PortadoresDA porDA = new PortadoresDA();

            return porDA.PesquisarDA();
        }

        public List<Portadores> PesquisarBL(int por)
        {
            PortadoresDA porDA = new PortadoresDA();

            return porDA.PesquisarDA(por);
        }
                
        public List<Portadores> PesquisarBuscaBL(string valor)
        {
            /*criar as regras de negocio*/
            PortadoresDA portadoresDA = new PortadoresDA();

            return portadoresDA.PesquisarBuscaDA(valor);
        }

        public override List<Base> Pesquisar(string codDes)
        {
            PortadoresDA porDA = new PortadoresDA();

            return porDA.Pesquisar(codDes);
        }
    }
}
