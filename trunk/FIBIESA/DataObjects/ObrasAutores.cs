using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataObjects
{
    public class ObrasAutores
    {
        private Int32 _id;
        public Int32 Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private Int32 _obraId;
        public Int32 ObraId
        {
            get { return _obraId; }
            set { _obraId = value; }
        }

        private Int32 _autoresId;
        public Int32 AutoresId
        {
            get { return _autoresId; }
            set { _autoresId = value; }
        }

        private string _tipoAutor;
        public string TipoAutor
        {
            get { return _tipoAutor; }
            set { _tipoAutor = value; }
        }

        private string _autor;
        public string Autor
        {
            get { return _autor; }
            set { _autor = value; }
        }

        private Int32 _codAutor;
        public Int32 CodAutor
        {
            get { return _codAutor; }
            set { _codAutor = value; }
        }
    }
}
