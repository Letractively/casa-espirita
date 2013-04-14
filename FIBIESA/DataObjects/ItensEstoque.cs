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

        private Int32 _obraId;
        public Int32 ObraId
        {
            get { return _obraId; }
            set { _obraId = value; }
        }

        private bool _controlaestoque;
        public bool ControlaEstoque
        {
            get { return _controlaestoque; }
            set { _controlaestoque = value; }
        }
        

        private Int32 _qtdminima;
        public Int32 QtdMinima
        {
            get { return _qtdminima; }
            set { _qtdminima = value; }
        }

        private DateTime _data;
        public DateTime Data
        {
            get { return _data; }
            set { _data = value; }
        }

        private Decimal _vlrCusto;
        public Decimal VlrCusto
        {
            get { return _vlrCusto; }
            set { _vlrCusto = value; }
        }

        private Decimal _vlrVenda;
        public Decimal VlrVenda
        {
            get { return _vlrVenda; }
            set { _vlrVenda = value; }
        }

        private Obras _obra;
        public Obras Obra
        {
            get { return _obra; }
            set { _obra = value; }
        }

        private Int32 _qtdEstoque;
        public Int32 QtdEstoque
        {
            get { return _qtdEstoque; }
            set { _qtdEstoque = value; }
        }
    
    }
}
