using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using DataAccess;

namespace BusinessLayer
{
    public class TelefonesBL
    {
        public bool InserirBL(Telefones tel)
        {
            /*criar as regras de negocio*/
            TelefonesDA telefonesDA = new TelefonesDA();

            return telefonesDA.InserirDA(tel);
        }

        public bool EditarBL(Telefones tel)
        {
            /*criar as regras de negocio*/
            TelefonesDA telefonesDA = new TelefonesDA();

            return telefonesDA.EditarDA(tel);
        }

        public bool ExcluirBL(Telefones tel)
        {
            /*criar as regras de negocio*/
            TelefonesDA telefonesDA = new TelefonesDA();

            return telefonesDA.ExcluirDA(tel);
        }

        public bool ExcluirBL(int id_pes)
        {
            /*criar as regras de negocio*/
            TelefonesDA telefonesDA = new TelefonesDA();

            return telefonesDA.ExcluirDA(id_pes);
        }

        public List<Telefones> PesquisarBL()
        {
            /*criar as regras de negocio*/
            TelefonesDA telefonesDA = new TelefonesDA();

            return telefonesDA.PesquisarDA();
        }

        public List<Telefones> PesquisarBL(int id_pes)
        {
            TelefonesDA telefonesDA = new TelefonesDA();

            return telefonesDA.PesquisarDA(id_pes);
        }

        public int RetornarMaxCodigoBL()
        {
            TelefonesDA telDA = new TelefonesDA();

            return telDA.RetornarMaxCodigoDA();
        }
    }
}
