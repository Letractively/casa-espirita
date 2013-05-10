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

        private Decimal _valor;
        public Decimal Valor
        {
            get { return _valor; }
            set { _valor = value; }
        }

        private Int32 _usuarioId;
        public Int32 UsuarioId
        {
            get { return _usuarioId; }
            set { _usuarioId = value; }
        }

        private Usuarios _usuario;
        public Usuarios Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        private Pessoas _pessoa;
        public Pessoas Pessoa
        {
            get { return _pessoa; }
            set { _pessoa = value; }
        }
        
        private string _acao;
        public string Acao
        {
            get { return _acao; }
            set { _acao = value; }
        }

    
    }
}
