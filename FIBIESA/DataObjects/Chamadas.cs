using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataObjects
{
    public class Chamadas
    {
        private Int32 _id;
        public Int32 Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private Int32 _turmaParticipanteId;
        public Int32 TurmaParticipanteId
        {
            get { return _turmaParticipanteId; }
            set { _turmaParticipanteId = value; }
        }

        private Boolean _presenca;
        public Boolean Presenca
        {
            get { return _presenca; }
            set { _presenca = value; }
        }
        
        private DateTime _data;
        public DateTime Data
        {
            get { return _data; }
            set { _data = value; }
        }
    }
}
