using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataObjects
{
    public class Exemplares
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private int _obraid;
        public int Obraid
        {
            get { return _obraid; }
            set { _obraid = value; }
        }

        private int _tombo;
        public int Tombo
        {
            get { return _tombo; }
            set { _tombo = value; }
        }

        private string _status; //1
        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }

    }
}
