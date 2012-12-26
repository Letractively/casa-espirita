using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using DataAccess;

namespace BusinessLayer
{
    public class ChamadasBL
    {
        public bool InserirBL(Chamadas cha)
        {
            /*criar as regras de negocio*/
            ChamadasDA chamadasDA = new ChamadasDA();

            return chamadasDA.InserirDA(cha);
        }

        public bool EditarBL(Chamadas cha)
        {
            /*criar as regras de negocio*/
            ChamadasDA chamadasDA = new ChamadasDA();

            return chamadasDA.EditarDA(cha);
        }

        public bool ExcluirBL(Chamadas cha)
        {
            /*criar as regras de negocio*/
            ChamadasDA chamadasDA = new ChamadasDA();

            return chamadasDA.ExcluirDA(cha);
        }

        public List<Chamadas> PesquisarBL()
        {
            /*criar as regras de negocio*/
            ChamadasDA bairrosDA = new ChamadasDA();

            return chamadasDA.PesquisarDA();
        }
    }
}
