using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataObjects
{
    public class Titulos : Base
    {
        private Int32 _id;
        public Int32 Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private Int32 _numero;
        public Int32 Numero
        {
            get { return _numero; }
            set { _numero = value; }
        }

        private Int32 _parcela;
        public Int32 Parcela
        {
            get { return _parcela; }
            set { _parcela = value; }
        }

        private Decimal _valor;
        public Decimal Valor
        {
            get { return _valor; }
            set { _valor = value; }
        }

        private Int32? _pessoaid;
        public Int32? Pessoaid
        {
            get { return _pessoaid; }
            set { _pessoaid = value; }
        }

        private Int32? _portadorid;
        public Int32? Portadorid
        {
            get { return _portadorid; }
            set { _portadorid = value; }
        }

        private DateTime _dataVencimento;
        public DateTime DataVencimento
        {
            get { return _dataVencimento; }
            set { _dataVencimento = value; }
        }

        private DateTime _dataEmissao;
        public DateTime DataEmissao
        {
            get { return _dataEmissao; }
            set { _dataEmissao = value; }
        }

        private Int32? _tipoDocumentoId;
        public Int32? TipoDocumentoId
        {
            get { return _tipoDocumentoId; }
            set { _tipoDocumentoId = value; }
        }

        private string _tipo;
        public string Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }
               
        private Portadores _portador;
        public Portadores Portador
        {
            get { return _portador; }
            set { _portador = value; }
        }

        private Pessoas _pessoas;
        public Pessoas Pessoas
        {
            get { return _pessoas; }
            set { _pessoas = value; }
        }

        private TiposDocumentos _tiposDocumentos;
        public TiposDocumentos TiposDocumentos
        {
            get { return _tiposDocumentos; }
            set { _tiposDocumentos = value; }
        }

        private DateTime? _dtPagamento;
        public DateTime? DtPagamento
        {
            get { return _dtPagamento; }
            set { _dtPagamento = value; }
        }

        private Decimal? _valorPago;
        public Decimal? ValorPago
        {
            get { return _valorPago; }
            set { _valorPago = value; }
        }

        private string _obs;
        public string Obs
        {
            get { return _obs; }
            set { _obs = value; }
        }
                    
    }
}
