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

        private Int32 _turmaAlunoid;
        public Int32 TurmaAlunoId
        {
            get { return _turmaAlunoid; }
            set { _turmaAlunoid = value; }
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
