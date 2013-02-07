using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataObjects
{
    public class Instituicoes
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

        private string _razao;
        public string Razao
        {
            get { return _razao; }
            set { _razao = value; }
        }

        private string _nomeFantasia;
        public string NomeFantasia
        {
            get { return _nomeFantasia; }
            set { _nomeFantasia = value; }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private string _cnpj;
        public string Cnpj
        {
            get { return _cnpj; }
            set { _cnpj = value; }
        }

        private int? _cidadeId;
        public int? CidadeId
        {
            get { return _cidadeId; }
            set { _cidadeId = value; }
        }

        private string _cep;
        public string Cep
        {
            get { return _cep; }
            set { _cep = value; }
        }

        private int? _bairroId;
        public int? BairroId
        {
            get { return _bairroId; }
            set { _bairroId = value; }
        }

        private string _endereco;
        public string Endereco
        {
            get { return _endereco; }
            set { _endereco = value; }
        }

        private string _numero;
        public string Numero
        {
            get { return _numero; }
            set { _numero = value; }
        }

        private string _complemento;
        public string Complemento
        {
            get { return _complemento; }
            set { _complemento = value; }
        }

        private InstituicoesLogo _instituicaoLogo;
        public InstituicoesLogo InstituicaoLogo
        {
            get { return _instituicaoLogo; }
            set { _instituicaoLogo = value; }
        }
    }
}
