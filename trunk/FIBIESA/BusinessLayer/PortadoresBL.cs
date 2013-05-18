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
        private bool IsValid(Portadores por)
        {
            bool valido;
            valido = por.Descricao.Length <= 70;
           
            return valido;
        }

        public bool InserirBL(Portadores por)
        {
            if (IsValid(por))
            {
                PortadoresDA porDA = new PortadoresDA();

                return porDA.InserirDA(por);
            }
            else
                return false;
        }

        public bool EditarBL(Portadores por)
        {
            if (por.Id > 0 && IsValid(por))
            {
                PortadoresDA porDA = new PortadoresDA();

                return porDA.EditarDA(por);
            }
            else
                return false;
        }

        public bool ExcluirBL(Portadores por)
        {
            if (por.Id > 0)
            {
                PortadoresDA porDA = new PortadoresDA();

                return porDA.ExcluirDA(por);
            }
            else
                return false;
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

        public bool CodigoJaUtilizadoBL(Int32 codigo)
        {
            PortadoresDA porDA = new PortadoresDA();

            return porDA.CodigoJaUtilizadoDA(codigo);
        }
    }
}
