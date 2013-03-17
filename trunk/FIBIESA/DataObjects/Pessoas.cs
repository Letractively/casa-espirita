using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataObjects
{
    public class Pessoas : Base
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

        private string _nome;
        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        private string _nomeFantasia;
        public string NomeFantasia
        {
            get { return _nomeFantasia; }
            set { _nomeFantasia = value; }
        }

        private string _cpfCnpj;
        public string CpfCnpj
        {
            get { return _cpfCnpj; }
            set { _cpfCnpj = value; }
        }

        private string _rg;
        public string Rg
        {
            get { return _rg; }
            set { _rg = value; }
        }

        private string _nomeMae;
        public string NomeMae
        {
            get { return _nomeMae; }
            set { _nomeMae = value; }
        }

        private string _nomePai;
        public string NomePai
        {
            get { return _nomePai; }
            set { _nomePai = value; }
        }

        private DateTime? _dtNascimento;
        public DateTime? DtNascimento
        {
            get { return _dtNascimento; }
            set { _dtNascimento = value; }
        }

        private string _estadoCivil;
        public string EstadoCivil
        {
            get { return _estadoCivil; }
            set { _estadoCivil = value; }
        }

        private Int32? _naturalidade;
        public Int32? Naturalidade
        {
            get { return _naturalidade; }
            set { _naturalidade = value; }
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

        private Int32 _bairroId;
        public Int32 BairroId
        {
            get { return _bairroId; }
            set { _bairroId = value; }
        }

        private string _cep;
        public string Cep
        {
            get { return _cep; }
            set { _cep = value; }
        }

        private Int32 _cidadeId;
        public Int32 CidadeId
        {
            get { return _cidadeId; }
            set { _cidadeId = value; }
        }

        private string _complemento;
        public string Complemento
        {
            get { return _complemento; }
            set { _complemento = value; }
        }

        private string _enderecoProf;
        public string EnderecoProf
        {
            get { return _enderecoProf; }
            set { _enderecoProf = value; }
        }

        private string _numeroProf;
        public string NumeroProf
        {
            get { return _numeroProf; }
            set { _numeroProf = value; }
        }

        private Int32? _bairroProf;
        public Int32? BairroProf
        {
            get { return _bairroProf; }
            set { _bairroProf = value; }
        }

        private string _cepProf;
        public string CepProf
        {
            get { return _cepProf; }
            set { _cepProf = value; }
        }

        private Int32? _cidadeProfId;
        public Int32? CidadeProfId
        {
            get { return _cidadeProfId; }
            set { _cidadeProfId = value; }
        }

        private string _complementoProf;
        public string ComplementoProf
        {
            get { return _complementoProf; }
            set { _complementoProf = value; }
        }

        private string _empresa;
        public string Empresa
        {
            get { return _empresa; }
            set { _empresa = value; }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private string _obs;
        public string Obs
        {
            get { return _obs; }
            set { _obs = value; }
        }

        private Int32 _categoriaId;
        public Int32 CategoriaId
        {
            get { return _categoriaId; }
            set { _categoriaId = value; }
        }

        private string _tipo;
        public string Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }

        private Boolean _envEmail;
        public Boolean EnvEmail
        {
            get { return _envEmail; }
            set { _envEmail = value; }
        }

        private string _refNome;
        public string RefNome
        {
            get { return _refNome; }
            set { _refNome = value; }
        }

        private Int32? _refTelefone;
        public Int32? RefTelefone
        {
            get { return _refTelefone; }
            set { _refTelefone = value; }
        }

        private Int16? _refDDD;
        public Int16? RefDDD
        {
            get { return _refDDD; }
            set { _refDDD = value; }
        }

        private DateTime _dtCadastro;
        public DateTime DtCadastro
        {
            get { return _dtCadastro; }
            set { _dtCadastro = value; }
        }

        private int _status;
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }

        private Cidades _cidade;
        public Cidades Cidade
        {
            get { return _cidade; }
            set { _cidade = value; }
        }
               
    }
}
