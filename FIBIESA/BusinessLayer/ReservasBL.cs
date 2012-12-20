using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using DataAccess;

namespace BusinessLayer
{
    public class ReservasBL
    {
        public bool InserirBL(Reservas instancia)
        {
            /*criar as regras de negocio*/
            ReservasDA varDA = new ReservasDA();

            return varDA.InserirDA(instancia);
        }

        public bool EditarBL(Reservas instancia)
        {
            /*criar as regras de negocio*/
            ReservasDA varDA = new ReservasDA();

            return varDA.EditarDA(instancia);
        }

        public bool ExcluirBL(Reservas instancia)
        {
            /*criar as regras de negocio*/
            ReservasDA varDA = new ReservasDA();

            return varDA.ExcluirDA(instancia);
        }

        public List<Reservas> PesquisarBL()
        {
            /*criar as regras de negocio*/
            ReservasDA varDA = new ReservasDA();

            return varDA.PesquisarDA();
        }
    }
}
