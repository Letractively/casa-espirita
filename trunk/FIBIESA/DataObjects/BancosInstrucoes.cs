using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataObjects
{
    public class BancosInstrucoes
    {
        private Int32 _id;
        public Int32 Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private Int32 _codigo;
        public Int32 Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        private string _descricao;
        public string Descricao
        {
            get { return _descricao; }
            set { _descricao = value; }
        }

        private Boolean _nrdias;
        public Boolean Nrdias
        {
            get { return _nrdias; }
            set { _nrdias = value; }
        }

        private Int32 _bancoid;
        public Int32 Bancoid
        {
            get { return _bancoid; }
            set { _bancoid = value; }
        }

        private Bancos _bancos;
        public Bancos Bancos
        {
            get { return _bancos; }
            set { _bancos = value; }
        }

    }
}
