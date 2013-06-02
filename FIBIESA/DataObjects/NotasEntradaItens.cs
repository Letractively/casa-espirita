using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataObjects
{
    public class NotasEntradaItens
    {
        private Int32 _id;
        public Int32 Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private Int32 _notaEntradaId;
        public Int32 NotaEntradaId
        {
            get { return _notaEntradaId; }
            set { _notaEntradaId = value; }
        }

        private Decimal _valor;
        public Decimal Valor
        {
            get { return _valor; }
            set { _valor = value; }
        }

        private Int32 _quantidade;
        public Int32 Quantidade
        {
            get { return _quantidade; }
            set { _quantidade = value; }
        }

        private Int32 _itemEstoqueId;
        public Int32 ItemEstoqueId
        {
            get { return _itemEstoqueId; }
            set { _itemEstoqueId = value; }
        }

        private Obras _obra;
        public Obras Obra
        {
            get { return _obra; }
            set { _obra = value; }
        }

        private Int32 _usuarioId;
        public Int32 UsuarioId
        {
            get { return _usuarioId; }
            set { _usuarioId = value; }
        }

        
    }
}
