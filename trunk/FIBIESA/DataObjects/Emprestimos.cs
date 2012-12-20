using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataObjects
{
    public class Emprestimos
    {
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private int _exemplarId;

        public int ExemplarId
        {
            get { return _exemplarId; }
            set { _exemplarId = value; }
        }
        private int _pessoaId;

        public int PessoaId
        {
            get { return _pessoaId; }
            set { _pessoaId = value; }
        }

    }
}
