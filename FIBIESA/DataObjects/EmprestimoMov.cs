using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataObjects
{
    public class EmprestimoMov
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private int? _emprestimoId;
        public int? EmprestimoId
        {
            get { return _emprestimoId; }
            set { _emprestimoId = value; }
        }

        private DateTime? _dataEmprestimo;
        public DateTime? DataEmprestimo
        {
            get { return _dataEmprestimo; }
            set { _dataEmprestimo = value; }
        }

        private DateTime? _dataDevolucao;
        public DateTime? DataDevolucao
        {
            get { return _dataDevolucao; }
            set { _dataDevolucao = value; }
        }

        private DateTime? _dataPrevistaEmprestimo;
        public DateTime? DataPrevistaEmprestimo
        {
            get { return _dataPrevistaEmprestimo; }
            set { _dataPrevistaEmprestimo = value; }
        }

        private Obras _obras;
        public Obras Obras
        {
            get { return _obras; }
            set { _obras = value; }
        }

        private Exemplares _exemplares;
        public Exemplares Exemplares
        {
            get { return _exemplares; }
            set { _exemplares = value; }
        }

        private string _situacao;
        public string Situacao
        {
            get { return _situacao; }
            set { _situacao = value; }
        }

        private Int16 _qtdeDias;
        public Int16 QtdeDias
        {
            get { return _qtdeDias; }
            set { _qtdeDias = value; }
        }

        private Int32 _pessoaId;
        public Int32 PessoaId
        {
            get { return _pessoaId; }
            set { _pessoaId = value; }
        }

        private string _titulo;
        public string Titulo
        {
            get { return _titulo; }
            set { _titulo = value; }
        }

               
    }
}
