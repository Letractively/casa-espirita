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

        private int _emprestimoId;
        public int EmprestimoId
        {
            get { return _emprestimoId; }
            set { _emprestimoId = value; }
        }

        private DateTime _dataEmprestimo;
        public DateTime DataEmprestimo
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

        private DateTime _dataPrevistaEmprestimo;
        public DateTime DataPrevistaEmprestimo
        {
            get { return _dataPrevistaEmprestimo; }
            set { _dataPrevistaEmprestimo = value; }
        }
    }
}
