using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataObjects
{
    public class Vendas
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private int _numero;
        public int Numero
        {
            get { return _numero; }
            set { _numero = value; }
        }

        private int _pessoaId;
        public int PessoaId
        {
            get { return _pessoaId; }
            set { _pessoaId = value; }
        }

        private int _usuarioId;
        public int UsuarioId
        {
            get { return _usuarioId; }
            set { _usuarioId = value; }
        }

        private DateTime? _data;
        public DateTime? Data
        {
            get { return _data; }
            set { _data = value; }
        }

        private string _situacao;
        public string Situacao
        {
            get { return _situacao; }
            set { _situacao = value; }
        }

        private Pessoas _pessoas;
        public Pessoas Pessoas
        {
            get { return _pessoas; }
            set { _pessoas = value; }
        }

        private Usuarios _usuarios;
        public Usuarios Usuarios
        {
            get { return _usuarios; }
            set { _usuarios = value; }
        }

    }
}
