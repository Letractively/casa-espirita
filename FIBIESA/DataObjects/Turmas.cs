using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataObjects
{
    public class Turmas
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

        private Int32 _cursoId;
        public Int32 CursoId
        {
            get { return _cursoId; }
            set { _cursoId = value; }
        }

        private DateTime _dataInicial;
        public DateTime DataInicial
        {
            get { return _dataInicial; }
            set { _dataInicial = value; }
        }

        private DateTime _dataFinal;
        public DateTime DataFinal
        {
            get { return _dataFinal; }
            set { _dataFinal = value; }
        }
    
    }
}
