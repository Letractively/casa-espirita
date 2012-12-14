using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataObjects
{
    public class Parametros
    {
        private Int32 _id;
        public Int32 Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _descricao;
        public string Descricao
        {
            get { return _descricao; }
            set { _descricao = value; }
        }

        private decimal _valor;
        public decimal Valor
        {
            get { return _valor; }
            set { _valor = value; }
        }

        private string _modulo;
        public string Modulo
        {
            get { return _modulo; }
            set { _modulo = value; }
        }
    }
}
