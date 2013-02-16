using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataObjects
{
    public class Agencias : Base
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

        private string _cep;
        public string Cep
        {
            get { return _cep; }
            set { _cep = value; }
        }

        private Int32? _bairroId;
        public Int32? BairroId
        {
            get { return _bairroId; }
            set { _bairroId = value; }
        }

        private string _endereco;
        public string Endereco;

        private string _complemento;
        public string Complemento
        {
          get { return _complemento; }
          set { _complemento = value; }
        }

        private Int32? _cidadeId;
        public Int32? CidadeId
        {
            get { return _cidadeId; }
            set { _cidadeId = value; }
        }

        private Int32 _ranking;
        public Int32 Ranking
        {
            get { return _ranking; }
            set { _ranking = value; }
        }

        private Int32 _bancoId;
        public Int32 BancoId
        {
            get { return _bancoId; }
            set { _bancoId = value; }
        }
    }
}
