using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using DataAccess;

namespace BusinessLayer
{
    public class ReservasBL : BaseBL
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

        public List<Reservas> PesquisarBL(int bai)
        {
            ReservasDA varDA = new ReservasDA();

            return varDA.PesquisarDA(bai);
        }

        public List<Reservas> PesquisarCidBL(int id_cid)
        {
            BairrosDA varDA = new BairrosDA();
            return null;
            //return varDA.PesquisarCidDA(id_cid);
        }

        public List<Reservas> PesquisarBuscaBL(string valor)
        {
            /*criar as regras de negocio*/
            ReservasDA varDA = new ReservasDA();
            return null;

           // return varDA.PesquisarBuscaDA(valor);
        }

        public override List<Base> Pesquisar(string codDes)
        {
            ReservasDA varDA = new ReservasDA();

            return varDA.Pesquisar(codDes);
        }

    }
}
