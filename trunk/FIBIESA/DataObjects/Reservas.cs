using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataObjects
{
    public class Reservas
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private int _pessoaId;
        public int PessoaId
        {
            get { return _pessoaId; }
            set { _pessoaId = value; }
        }

        private int _exemplarId;
        public int ExemplarId
        {
            get { return _exemplarId; }
            set { _exemplarId = value; }
        }

        private DateTime _dataInicio;
        public DateTime DataInicio
        {
            get { return _dataInicio; }
            set { _dataInicio = value; }
        }

        private DateTime _dataFim;
        public DateTime DataFim
        {
            get { return _dataFim; }
            set { _dataFim = value; }
        }
    }
}
