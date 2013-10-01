using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataObjects
{
    public class SelecaoTitulos
    {
        private string _codTitulos;
        public string CodTitulos
        {
            get { return _codTitulos; }
            set { _codTitulos = value; }
        }

        private string _codAssociados;
        public string CodAssociados
        {
            get { return _codAssociados; }
            set { _codAssociados = value; }
        }

        private string _codPotadores;
        public string CodPotadores
        {
            get { return _codPotadores; }
            set { _codPotadores = value; }
        }

        private string _tipo;
        public string Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }

        private string _tipoDocumento;
        public string TipoDocumento
        {
            get { return _tipoDocumento; }
            set { _tipoDocumento = value; }
        }

        private Boolean _blAtrasados;
        public Boolean BlAtrasados
        {
            get { return _blAtrasados; }
            set { _blAtrasados = value; }
        }

        private string _dataEmissaoIni;
        public string DataEmissaoIni
        {
            get { return _dataEmissaoIni; }
            set { _dataEmissaoIni = value; }
        }

        private string _dataEmissaoFim;
        public string DataEmissaoFim
        {
            get { return _dataEmissaoFim; }
            set { _dataEmissaoFim = value; }
        }

        private string _dataVencimentoIni;
        public string DataVencimentoIni
        {
            get { return _dataVencimentoIni; }
            set { _dataVencimentoIni = value; }
        }

        private string _dataVencimentoFim;
        public string DataVencimentoFim
        {
            get { return _dataVencimentoFim; }
            set { _dataVencimentoFim = value; }
        }

        private string _dataPagamentoIni;
        public string DataPagamentoIni
        {
            get { return _dataPagamentoIni; }
            set { _dataPagamentoIni = value; }
        }

        private string _dataPagamentoFim;
        public string DataPagamentoFim
        {
            get { return _dataPagamentoFim; }
            set { _dataPagamentoFim = value; }
        }

        private string _portadorId;
        public string PortadorId
        {
            get { return _portadorId; }
            set { _portadorId = value; }
        }

    }
}
