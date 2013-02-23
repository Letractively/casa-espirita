using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataObjects
{
    public class NotasEntrada
    {
        private Int32 _id;
        public Int32 Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private Int32 _numero;
        public Int32 Numero
        {
            get { return _numero; }
            set { _numero = value; }
        }

        private Int16 _serie;
        public Int16 Serie
        {
            get { return _serie; }
            set { _serie = value; }
        }

        private DateTime _data;
        public DateTime Data
        {
            get { return _data; }
            set { _data = value; }
        }

    }
}
