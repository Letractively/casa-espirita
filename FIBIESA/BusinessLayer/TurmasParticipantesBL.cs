using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using DataAccess;

namespace BusinessLayer
{
    public class TurmasParticipantesBL
    {
        public bool InserirBL(TurmasParticipantes turAlu)
        {
            
            TurmasParticipantesDA tParDA = new TurmasParticipantesDA();

            return tParDA.InserirDA(turAlu);
        }

        public bool EditarBL(TurmasParticipantes turAlu)
        {

            TurmasParticipantesDA tParDA = new TurmasParticipantesDA();

            return tParDA.EditarDA(turAlu);
        }

        public bool ExcluirBL(TurmasParticipantes turAlu)
        {

            TurmasParticipantesDA tParDA = new TurmasParticipantesDA();

            return tParDA.ExcluirDA(turAlu);
        }

        public List<TurmasParticipantes> PesquisarBL()
        {

            TurmasParticipantesDA tParDA = new TurmasParticipantesDA();

            return tParDA.PesquisarDA();
        }

        public List<TurmasParticipantes> PesquisarBL(int id_turma)
        {

            TurmasParticipantesDA tParDA = new TurmasParticipantesDA();

            return tParDA.PesquisarDA(id_turma);
        }
    }
}
