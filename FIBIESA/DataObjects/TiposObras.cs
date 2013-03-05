using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataObjects
{
    public class TiposObras
    {
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private int _codigo;

        public int Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }
        private string _descricao; //40

        public string Descricao
        {
            get { return _descricao; }
            set { _descricao = value; }
        }

        private int _qtdDias;

        public int QtdDias
        {
            get { return _qtdDias; }
            set { _qtdDias = value; }
        }

    }
}
