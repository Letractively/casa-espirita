using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataObjects
{
    public class Autores
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
        private string _descricao;

        public string Descricao //70
        {
            get { return _descricao; }
            set { _descricao = value; }
        }
        private int _tipoId;

        public int TipoId
        {
            get { return _tipoId; }
            set { _tipoId = value; }
        }
        private int _obraId;

        public int ObraId
        {
            get { return _obraId; }
            set { _obraId = value; }
        }
    }
}
