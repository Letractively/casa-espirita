using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataObjects
{
    public class JurosMultas
    {
        private Int32 _id;
        public Int32 Id
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
        
        private Int32 _percjurosdias;
        public Int32 PercJurosDias
        {
            get { return _percjurosdias; }
            set { _percjurosdias = value; }
        }

        private Int32 _percjurosmes;
        public Int32 PercJurosMes
        {
            get { return _percjurosmes; }
            set { _percjurosmes = value; }
        }

        private Int32 _percmultadias;
        public Int32 PercMultaDias
        {
            get { return _percmultadias; }
            set { _percmultadias = value; }
        }

        private Int32 _percmultames;
        public Int32 PercMultaMes
        {
            get { return _percmultames; }
            set { _percmultames = value; }
        }
    
    }
}
