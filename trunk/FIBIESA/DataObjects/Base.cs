using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataObjects
{
    public class Base
    {
        private int _pesId;
        public int PesId1
        {
            get { return _pesId; }
            set { _pesId = value; }
        }

        private string _pesCodigo;
        public string PesCodigo
        {
          get { return _pesCodigo; }
          set { _pesCodigo = value; }
        }

        private string _pesDescricao;
        public string PesDescricao
        {
            get { return _pesDescricao; }
            set { _pesDescricao = value; }
        }
    }
}
