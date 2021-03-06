﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataObjects
{
    public class TurmasParticipantes
    {
        private Int32 _id;
        public Int32 Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private Int32 _turmaId;
        public Int32 TurmaId
        {
            get { return _turmaId; }
            set { _turmaId = value; }
        }

        private Int32 _pessoaId;
        public Int32 PessoaId
        {
            get { return _pessoaId; }
            set { _pessoaId = value; }
        }

        private Turmas _turma;
        public Turmas Turma
        {
            get { return _turma; }
            set { _turma = value; }
        }

        private Pessoas _pessoa;
        public Pessoas Pessoa
        {
            get { return _pessoa; }
            set { _pessoa = value; }
        }
    
    }
}
