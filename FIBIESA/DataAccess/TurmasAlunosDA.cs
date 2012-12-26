using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;

namespace DataAccess
{
    public class TurmasAlunosDA
    {
        public bool InserirDA(TurmasAlunos turAlu)
        {
            return true;
        }

        public bool EditarDA(TurmasAlunos turAlu)
        {
            return true;
        }

        public bool ExcluirDA(TurmasAlunos turAlu)
        {
            return true;
        }

        public List<TurmasAlunos> PesquisarDA()
        {
            List<TurmasAlunos> turmasAlunos = new List<TurmasAlunos>();
            return turmasAlunos;
        }
    }
}
