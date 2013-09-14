using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataObjects
{
    public class Remessa
    {
        private string _codOcorrencia;
        public string CodOcorrencia
        {
            get { return _codOcorrencia; }
            set { _codOcorrencia = value; }
        }

        private string _instrucao1;
        public string Instrucao1
        {
            get { return _instrucao1; }
            set { _instrucao1 = value; }
        }

        private string _instrucao2;
        public string Instrucao2
        {
            get { return _instrucao2; }
            set { _instrucao2 = value; }
        }

        private string _juroMora;
        public string JuroMora
        {
            get { return _juroMora; }
            set { _juroMora = value; }
        }
    }
}
