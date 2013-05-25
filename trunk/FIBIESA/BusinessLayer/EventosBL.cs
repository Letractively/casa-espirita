using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using DataAccess;
using System.Data;

namespace BusinessLayer
{
    public class EventosBL : BaseBL
    {
        public bool InserirBL(Eventos eve)
        {
            /*criar as regras de negocio*/
            EventosDA eveDA = new EventosDA();

            return eveDA.InserirDA(eve);
        }

        public bool EditarBL(Eventos eve)
        {
            /*criar as regras de negocio*/
            EventosDA eveDA = new EventosDA();

            return eveDA.EditarDA(eve);
        }

        public bool ExcluirBL(Eventos eve)
        {
            /*criar as regras de negocio*/
            EventosDA eveDA = new EventosDA();

            return eveDA.ExcluirDA(eve);
        }

        public List<Eventos> PesquisarBL()
        {
            /*criar as regras de negocio*/
            EventosDA eveDA = new EventosDA();

            return eveDA.PesquisarDA();
        }

        public List<Eventos> PesquisarBL(int eve)
        {
            EventosDA eveDA = new EventosDA();

            return eveDA.PesquisarDA(eve);
        }

        public List<Eventos> PesquisarBL(string campo, string valor)
        {
            EventosDA eveDA = new EventosDA();

            return eveDA.PesquisarDA(campo,valor);
        }

        public List<Eventos> PesquisarBuscaBL(string valor)
        {
            EventosDA eveDA = new EventosDA();

            return eveDA.PesquisarBuscaDA(valor);
        }

        public override List<Base> Pesquisar(string codDes)
        {
            EventosDA eveDA = new EventosDA();

            return eveDA.Pesquisar(codDes);
        }

        public List<Base> PesquisarEventos(string codDes)
        {
            EventosDA eveDA = new EventosDA();

            return eveDA.PesquisarEventos(codDes);
        }

        public DataSet PesquisarDataset(string codDes, string dataIni, string dataIniF, string dataFim, string dataFimF)
        {
            EventosDA eveDA = new EventosDA();

            return eveDA.PesquisarDataSet(codDes,dataIni,dataIniF,dataFim,dataFimF);
        }

    }
}
