using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataObjects
{
    public class Doacoes
    {
        private Int32 _id;
        public Int32 Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private Int32 _pessoaId;
        public Int32 PessoaId
        {
            get { return _pessoaId; }
            set { _pessoaId = value; }
        }

        private DateTime _data;
        public DateTime Data
        {
            get { return _data; }
            set { _data = value; }
        }

        private float _valor;
        private float Valor
        {
            get { return _valor; }
            set { _valor = value; }
        }

        private Int32 _usuarioId;
        private Int32 UsuarioId
        {
            get { return _usuarioId; }
            set { _usuarioId = value; }
        }
    
    }
}
