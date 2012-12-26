using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using DataAccess;

namespace BusinessLayer
{
    public class TurmasAlunosBL
    {
        public bool InserirBL(TurmasAlunos turAlu)
        {
            /*criar as regras de negocio*/
            TurmasAlunosDA turmasAlunosDA = new TurmasAlunosDA();

            return turmasAlunosDA.InserirDA(turAlu);
        }

        public bool EditarBL(TurmasAlunos turAlu)
        {
            /*criar as regras de negocio*/
            TurmasAlunosDA turmasAlunosDA = new TurmasAlunosDA();

            return turmasAlunosDA.EditarDA(turAlu);
        }

        public bool ExcluirBL(TurmasAlunos turAlu)
        {
            /*criar as regras de negocio*/
             TurmasAlunosDA turmasAlunosDA = new TurmasAlunosDA();

            return turmasAlunosDA.ExcluirDA(turAlu);
        }

        public List<TurmasAlunos> PesquisarBL()
        {
            /*criar as regras de negocio*/
            TurmasAlunosDA turmasAlunosDA = new TurmasAlunosDA();

            return turmasAlunosDA.PesquisarDA();
        }
    }
}
