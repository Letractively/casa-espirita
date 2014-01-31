using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataObjects
{
    public class Loglogradouro
    {
        private int _log_nu;
        private string _ufe_sg;
        private int _loc_nu;
        private int _bai_nu_ini;
        private int _bai_nu_fim;
        private string _log_no;
        private string _log_complemento;
        private string _cep;
        private string _tlo_tx;
        private string _log_sta_tlo;
        private string _log_no_abrev;
        private LogLocalidade _log_localidade;
        private Logbairro _log_Bairro;

        public Logbairro LogBairro
        {
            get { return _log_Bairro; }
            set { _log_Bairro = value; }
        }

        public LogLocalidade LogLocalidade
        {
            get { return _log_localidade; }
            set { _log_localidade = value; }
        }

        public string Log_no_abrev
        {
            get { return _log_no_abrev; }
            set { _log_no_abrev = value; }
        }

        public string Log_sta_tlo
        {
            get { return _log_sta_tlo; }
            set { _log_sta_tlo = value; }
        }

        public string Tlo_tx
        {
            get { return _tlo_tx; }
            set { _tlo_tx = value; }
        }

        public string Cep
        {
            get { return _cep; }
            set { _cep = value; }
        }

        public string Log_complemento
        {
            get { return _log_complemento; }
            set { _log_complemento = value; }
        }

        public string Log_no
        {
            get { return _log_no; }
            set { _log_no = value; }
        }

        public int Bai_nu_fim
        {
            get { return _bai_nu_fim; }
            set { _bai_nu_fim = value; }
        }

        public int Bai_nu_ini
        {
            get { return _bai_nu_ini; }
            set { _bai_nu_ini = value; }
        }

        public int Loc_nu
        {
            get { return _loc_nu; }
            set { _loc_nu = value; }
        }

        public string Ufe_sg
        {
            get { return _ufe_sg; }
            set { _ufe_sg = value; }
        }

        public int Log_nu
        {
            get { return _log_nu; }
            set { _log_nu = value; }
        }
    }
}
