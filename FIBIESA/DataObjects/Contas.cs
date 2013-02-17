using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataObjects
{
    public class Contas : Base
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

        private string _digito;
        public string Digito
        {
            get { return _digito; }
            set { _digito = value; }
        }

        private Int32? _agenciaId;
        public Int32? AgenciaId
        {
            get { return _agenciaId; }
            set { _agenciaId = value; }
        }

        private Agencias _agencia;
        public Agencias Agencia
        {
            get { return _agencia; }
            set { _agencia = value; }
        }

        private string _titular;
        public string Titular
        {
            get { return _titular; }
            set { _titular = value; }
        }
    }
}
