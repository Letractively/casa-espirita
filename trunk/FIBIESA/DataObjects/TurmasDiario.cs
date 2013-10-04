using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataObjects
{
    public class TurmasDiario
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _obs;
        public string Obs
        {
            get { return _obs; }
            set { _obs = value; }
        }

        private DateTime _data;
        public DateTime Data
        {
            get { return _data; }
            set { _data = value; }
        }

        private int _turmaId;
        public int TurmaId
        {
            get { return _turmaId; }
            set { _turmaId = value; }
        }
    }
}
