using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataObjects
{
    public class Cidades
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

        private Int32 _estadoId;
        public Int32 EstadoId
        {
            get { return _estadoId; }
            set { _estadoId = value; }
        }


    
    }
}
