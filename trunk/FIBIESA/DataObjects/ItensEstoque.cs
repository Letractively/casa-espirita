using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataObjects
{
    public class ItensEstoque
    {
        private Int32 _id;
        public Int32 Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private bool _status;
        public bool Status
        {
            get { return _status; }
            set { _status = value; }
        }
        
        private Int32 _exemplarid;
        public Int32 ExemplarId
        {
            get { return _exemplarid; }
            set { _exemplarid = value; }
        }

        private bool _controlaestoque;
        public bool ControlaEstoque
        {
            get { return _controlaestoque; }
            set { _controlaestoque = value; }
        }
        

        private string _qtdminima;
        public string QtdMinima
        {
            get { return _qtdminima; }
            set { _qtdminima = value; }
        }
    
    }
}
