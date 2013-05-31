using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using DataAccess;
using System.Data;

namespace BusinessLayer
{
    public class ChamadasBL
    {
        public bool InserirBL(Chamadas cha)
        {
            
            ChamadasDA chaDA = new ChamadasDA();
                        
            return chaDA.InserirDA(cha);
        }

        public bool EditarBL(Chamadas cha)
        {

            ChamadasDA chaDA = new ChamadasDA();

            return chaDA.EditarDA(cha);
        }

        public bool ExcluirBL(Chamadas cha)
        {

            ChamadasDA chaDA = new ChamadasDA();

            return chaDA.ExcluirDA(cha);
        }

        public List<Chamadas> PesquisarBL()
        {

            ChamadasDA chaDA = new ChamadasDA();

            return chaDA.PesquisarDA();
        }

        public List<Chamadas> PesquisarBL(int id_tPar, DateTime data)
        {

            ChamadasDA chaDA = new ChamadasDA();

            return chaDA.PesquisarDA(id_tPar, data);
        }

        public List<Chamadas> PesquisarBL(int id_tur, int id_eve)
        {

            ChamadasDA chaDA = new ChamadasDA();

            return chaDA.PesquisarDA(id_tur, id_eve);
        }

        public DataSet PesquisarAnosChamada()
        {

            ChamadasDA chaDA = new ChamadasDA();

            return chaDA.PesquisarAnosChamadaDA();
        }

        public DataSet PesquisarDataSet(string mes, string ano, int turmaId, string alunosCod, int preenchido)
        {
            ChamadasDA chaDA = new ChamadasDA();

            return chaDA.PesquisarDataSetDA(mes, ano, turmaId, alunosCod, preenchido);
        }
               
    }
}
