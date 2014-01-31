using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataObjects
{
    public class Logbairro
    {
        private int _bai_nu;
        private string ufe_sg;
        private int loc_nu;
        private string _bai_no;
        private string _bai_no_abrev;

        public string Bai_no_abrev
        {
            get { return _bai_no_abrev; }
            set { _bai_no_abrev = value; }
        }

        public string Bai_no
        {
            get { return _bai_no; }
            set { _bai_no = value; }
        }

        public int Loc_nu
        {
            get { return loc_nu; }
            set { loc_nu = value; }
        }

        public string Ufe_sg
        {
            get { return ufe_sg; }
            set { ufe_sg = value; }
        }

        public int Bai_nu
        {
            get { return _bai_nu; }
            set { _bai_nu = value; }
        }
    }
}
