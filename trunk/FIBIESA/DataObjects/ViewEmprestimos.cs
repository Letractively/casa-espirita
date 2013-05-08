using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataObjects
{
    public class ViewEmprestimos : Base
    {
        private Int32 _id;
        public Int32 Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _status;
        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }

        private Int32 _emprestimoid;
        public Int32 EmprestimoId
        {
            get { return _emprestimoid; }
            set { _emprestimoid = value; }
        }

        private Int32 _exemplarid;
        public Int32 ExemplarId
        {
            get { return _exemplarid; }
            set { _exemplarid = value; }
        }

        private Int32 _pessoaid;
        public Int32 PessoaId
        {
            get { return _pessoaid; }
            set { _pessoaid = value; }
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

        private string _titulo;
        public string Titulo
        {
            get { return _titulo; }
            set { _titulo = value; }
        }

        private DateTime _dtEmprestimo;
        public DateTime DtEmprestimo
        {
            get { return _dtEmprestimo; }
            set { _dtEmprestimo = value; }
        }


        private DateTime _dtPrevistaDevolucao;
        public DateTime DtPrevistaDevolucao
        {
            get { return _dtPrevistaDevolucao; }
            set { _dtPrevistaDevolucao = value; }
        }


        private Int32 _codigo;
        public Int32 Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        private Int32 _tombo;
        public Int32 Tombo
        {
            get { return _tombo; }
            set { _tombo = value; }
        }



    }
}
