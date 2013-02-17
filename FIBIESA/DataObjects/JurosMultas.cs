using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataObjects
{
    public class JurosMultas
    {
        private Decimal? _id;
        public Decimal? Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private DateTime _mesano;
        public DateTime MesAno
        {
            get { return _mesano; }
            set { _mesano = value; }
        }
        
        private Decimal? _percjurosdias;
        public Decimal? PercJurosDias
        {
            get { return _percjurosdias; }
            set { _percjurosdias = value; }
        }

        private Decimal? _percjurosmes;
        public Decimal? PercJurosMes
        {
            get { return _percjurosmes; }
            set { _percjurosmes = value; }
        }

        private Decimal? _percmultadias;
        public Decimal? PercMultaDias
        {
            get { return _percmultadias; }
            set { _percmultadias = value; }
        }

        private Decimal? _percmultames;
        public Decimal? PercMultaMes
        {
            get { return _percmultames; }
            set { _percmultames = value; }
        }
    
    }
}
