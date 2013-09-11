using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using DataAccess;
using System.Data;

namespace BusinessLayer
{
    public class TurmasParticipantesBL
    {        

        public bool InserirBL(TurmasParticipantes turAlu)
        {

            TurmasBL turBL = new TurmasBL();
            DataSet dsTur = turBL.PesquisarBL(turAlu.TurmaId);

            List<TurmasParticipantes> ltur = PesquisarBL(turAlu.TurmaId);
            if (dsTur.Tables[0].Rows.Count != 0)
            {
                if (ltur.Count >= Convert.ToInt32(dsTur.Tables[0].Rows[0]["nromax"].ToString()))
                {                    
                    return false;
                }
            }

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

        public List<TurmasParticipantes> PesquisarBL(int id_turma, string nm_participante)
        {

            TurmasParticipantesDA tParDA = new TurmasParticipantesDA();

            return tParDA.PesquisarDA(id_turma, nm_participante);
        }

        public DataSet PesquisarParticipantesNotInTurmaBL(int id_turma, string nm_Participante)
        {

            TurmasParticipantesDA tParDA = new TurmasParticipantesDA();

            return tParDA.PesquisarParticipantesNotInTurmaDA(id_turma, nm_Participante);
        }
        
    }
}
