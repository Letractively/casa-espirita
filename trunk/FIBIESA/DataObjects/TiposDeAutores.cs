using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataObjects
{
    public class TiposDeAutores
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
        private string _descricao;

        public string Descricao //40
        {
            get { return _descricao; }
            set { _descricao = value; }
        }
    }
}
