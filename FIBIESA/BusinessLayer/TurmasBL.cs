using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using DataAccess;

namespace BusinessLayer
{
    public class TurmasBL
    {
        public bool InserirBL(Turmas tur)
        {
            /*criar as regras de negocio*/
            TurmasDA turmasDA = new TurmasDA();

            return turmasDA.InserirDA(tur);
        }

        public bool EditarBL(Turmas tur)
        {
            /*criar as regras de negocio*/
            TurmasDA turmasDA = new TurmasDA();

            return turmasDA.EditarDA(tur);
        }

        public bool ExcluirBL(Turmas tur)
        {
            /*criar as regras de negocio*/
             TurmasDA turmasDA = new TurmasDA();

            return turmasDA.ExcluirDA(tur);
        }

        public List<Turmas> PesquisarBL()
        {
            /*criar as regras de negocio*/
            TurmasDA turmasDA = new TurmasDA();

            return turmasDA.PesquisarDA();
        }
    }
}
