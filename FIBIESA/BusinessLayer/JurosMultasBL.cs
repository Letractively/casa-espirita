using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using DataAccess;

namespace BusinessLayer
{
    public class JurosMultasBL
    {
        public bool InserirBL(JurosMultas jurosmu)
        {
            /*criar as regras de negocio*/
            JurosMultasDA jurosmultasDA = new JurosMultasDA();

            return jurosmultasDA.InserirDA(jurosmu);
        }

        public bool EditarBL(JurosMultas jurosmu)
        {
            /*criar as regras de negocio*/
            JurosMultasDA jurosmultasDA = new JurosMultasDA();

            return jurosmultasDA.EditarDA(jurosmu);
        }

        public bool ExcluirBL(JurosMultas jurosmu)
        {
            /*criar as regras de negocio*/
            JurosMultasDA jurosmultasDA = new JurosMultasDA();

            return jurosmultasDA.ExcluirDA(jurosmu);
        }

        public List<JurosMultas> PesquisarBL()
        {
            /*criar as regras de negocio*/
            JurosMultasDA jurosmultasDA = new JurosMultasDA();

            return jurosmultasDA.PesquisarDA();
        }

        public List<JurosMultas> PesquisarBL(int id_jm)
        {
            /*criar as regras de negocio*/
            JurosMultasDA jurosmultasDA = new JurosMultasDA();

            return jurosmultasDA.PesquisarDA(id_jm);
        }
    }
}
