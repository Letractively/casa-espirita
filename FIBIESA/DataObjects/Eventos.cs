using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataObjects
{
    public class Eventos : Base
    {
        private Int32 _id;
        public Int32 Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private Int32 _codigo;
        public Int32 Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        private string _descricao;
        public string Descricao
        {
            get { return _descricao; }
            set { _descricao = value; }
        }

        private DateTime _dtInicio;
        public DateTime DtInicio
        {
            get { return _dtInicio; }
            set { _dtInicio = value; }
        }

        private DateTime _dtFim;
        public DateTime DtFim
        {
            get { return _dtFim; }
            set { _dtFim = value; }
        }

    }
}
