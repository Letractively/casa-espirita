using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataObjects
{
    public class Telefones
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

        private Int16 _ddd;
        public Int16 Ddd 
        {
            get { return _ddd; }
            set { _ddd = value; }
        }

        private Int32 _numero;
        public Int32 Numero
        {
            get { return _numero; }
            set { _numero = value; }
        }

        private Int32 _pessoaId;
        public Int32 PessoaId
        {
            get { return _pessoaId; }
            set { _pessoaId = value; }
        }
    }
}
