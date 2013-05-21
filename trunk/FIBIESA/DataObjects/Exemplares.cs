using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataObjects
{
    public class Exemplares : Base
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

        private string _status; 
        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }

        private Obras _obras;
        public Obras Obras
        {
            get { return _obras; }
            set { _obras = value; }
        }

        private string _codigoBarras;
        public string CodigoBarras
        {
            get { return _codigoBarras; }
            set { _codigoBarras = value; }
        }

        private int? _origemId;
        public int? OrigemId
        {
            get { return _origemId; }
            set { _origemId = value; }
        }

        private string _codBarras;
        public string CodBarras
        {
            get { return _codBarras; }
            set { _codBarras = value; }
        }
    }
}
