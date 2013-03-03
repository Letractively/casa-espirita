using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataObjects
{
    public class Usuarios
    {
        private Int32 _id;
        public Int32 Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _login;
        public string Login
        {
            get { return _login; }
            set { _login = value; }
        }

        private string _senha;
        public string Senha
        {
            get { return _senha; }
            set { _senha = value; }
        }

        private string _nome;
        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        private string _status;
        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }

        private DateTime? _dtInicio;
        public DateTime? DtInicio
        {
            get { return _dtInicio; }
            set { _dtInicio = value; }
        }

        private DateTime? _dtFim;
        public DateTime? DtFim
        {
            get { return _dtFim; }
            set { _dtFim = value; }
        }

        private string _tipo;
        public string Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private Int32? _pessoaId;
        public Int32? PessoaId
        {
            get { return _pessoaId; }
            set { _pessoaId = value; }
        }

        private Int32? _nrTentLogin;
        public Int32? NrTentLogin
        {
            get { return _nrTentLogin; }
            set { _nrTentLogin = value; }
        }

        private DateTime? _dhTentLogin;
        public DateTime? DhTentLogin
        {
            get { return _dhTentLogin; }
            set { _dhTentLogin = value; }
        }

        private Int32 _categoriaId;
        public Int32 CategoriaId
        {
            get { return _categoriaId; }
            set { _categoriaId = value; }
        }

        private Categorias _categoria;
        public Categorias Categoria
        {
            get { return _categoria; }
            set { _categoria = value; }
        }

        private Pessoas _pessoa;
        public Pessoas Pessoa
        {
            get { return _pessoa; }
            set { _pessoa = value; }
        }

    }
}
