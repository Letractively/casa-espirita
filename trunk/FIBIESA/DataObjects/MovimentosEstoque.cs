using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataObjects
{
    public class MovimentosEstoque
    {
        private Int32 _id;
        public Int32 Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private Int32 _vendaid;
        public Int32 VendaId
        {
            get { return _vendaid; }
            set { _vendaid = value; }
        }

        private Int32 _usuarioid;
        public Int32 UsuarioId
        {
            get { return _usuarioid; }
            set { _usuarioid = value; }
        }

        private float _valor;
        public float Valor
        {
            get { return _valor; }
            set { _valor = value; }
        }

        private Int32 _itemestoqueid;
        public Int32 ItemEstoqueId
        {
            get { return _itemestoqueid; }
            set { _itemestoqueid = value; }
        }

        private Int32 _quantidade;
        public Int32 Quantidade
        {
            get { return _quantidade; }
            set { _quantidade = value; }
        }

        private Int32 _notaentradaid;
        public Int32 NotaEntradaId
        {
            get { return _notaentradaid; }
            set { _notaentradaid = value; }
        }
    
    }
}
