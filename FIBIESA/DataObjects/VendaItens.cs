using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataObjects
{
    public class VendaItens
    {
        private Int32 _id;
        public Int32 Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private Int32 _vendaId;
        public Int32 VendaId
        {
            get { return _vendaId; }
            set { _vendaId = value; }
        }

        private Int32 _quantidade;
        public Int32 Quantidade
        {
            get { return _quantidade; }
            set { _quantidade = value; }
        }

        private Decimal _valor;
        public Decimal Valor
        {
            get { return _valor; }
            set { _valor = value; }
        }

        private Decimal _desconto;
        public Decimal Desconto
        {
            get { return _desconto; }
            set { _desconto = value; }
        }

        private string _situacao;
        public string Situacao
        {
            get { return _situacao; }
            set { _situacao = value; }
        }

        private Int32 _itemEstoqueId;
        public Int32 ItemEstoqueId
        {
            get { return _itemEstoqueId; }
            set { _itemEstoqueId = value; }
        }

        private Obras _obras;
        public Obras Obras
        {
            get { return _obras; }
            set { _obras = value; }
        }
        
        
    }
}
