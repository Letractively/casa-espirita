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

        private Int32 _eventoId;
        public Int32 EventoId
        {
            get { return _eventoId; }
            set { _eventoId = value; }
        }

        private DateTime? _dataInicial;
        public DateTime? DataInicial
        {
            get { return _dataInicial; }
            set { _dataInicial = value; }
        }

        private DateTime? _dataFinal;
        public DateTime? DataFinal
        {
            get { return _dataFinal; }
            set { _dataFinal = value; }
        }

        private Int32 _nromax;
        public Int32 Nromax
        {
            get { return _nromax; }
            set { _nromax = value; }
        }

        private string _sala;
        public string Sala
        {
            get { return _sala; }
            set { _sala = value; }
        }

        private DateTime? _horaIni;
        public DateTime? HoraIni
        {
            get { return _horaIni; }
            set { _horaIni = value; }
        }

        private DateTime? _horaFim;
        public DateTime? HoraFim
        {
            get { return _horaFim; }
            set { _horaFim = value; }
        }

        private string _diaSemana;
        public string DiaSemana
        {
            get { return _diaSemana; }
            set { _diaSemana = value; }
        }

        private Int32? _pessoaId;
        public Int32? PessoaId
        {
            get { return _pessoaId; }
            set { _pessoaId = value; }
        }

        private Pessoas _pessoa;
        public Pessoas Pessoa
        {
            get { return _pessoa; }
            set { _pessoa = value; }
        }

        private Eventos _evento;
        public Eventos Evento
        {
            get { return _evento; }
            set { _evento = value; }
        }
    
    }
}
