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

        private Int32? _vendaItensid;
        public Int32? VendaItensId
        {
            get { return _vendaItensid; }
            set { _vendaItensid = value; }
        }

        private Int32 _usuarioid;
        public Int32 UsuarioId
        {
            get { return _usuarioid; }
            set { _usuarioid = value; }
        }

        private decimal _valor;
        public decimal Valor
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

        private Int32? _notaentradaid;
        public Int32? NotaEntradaId
        {
            get { return _notaentradaid; }
            set { _notaentradaid = value; }
        }

        private string _tipo;
        public string Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }
                
        private Usuarios _usuarios;
        public Usuarios Usuarios
        {
            get { return _usuarios; }
            set { _usuarios = value; }
        }

        private NotasEntrada _notaEntrada;
        public NotasEntrada NotaEntrada
        {
            get { return _notaEntrada; }
            set { _notaEntrada = value; }
        }

        private DateTime _data;
        public DateTime Data
        {
            get { return _data; }
            set { _data = value; }
        }

        private Obras _obras;
        public Obras Obras
        {
            get { return _obras; }
            set { _obras = value; }
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

        private Int32? _numeroVenda;
        public Int32? NumeroVenda
        {
            get { return _numeroVenda; }
            set { _numeroVenda = value; }
        }
    
    }
}
