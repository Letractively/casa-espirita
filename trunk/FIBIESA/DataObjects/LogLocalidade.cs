using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataObjects
{
    public class LogLocalidade
    {
        private int _loc_Nu;
        private string _ufe_Sg;
        private string _loc_No;
        private string _cep;
        private string _loc_In_Sit;
        private string _loc_In_Tipo_Loc;
        private int _loc_Nu_Sub;
        private string _loc_No_Abrev;
        private int _mun_Nu;

        public int Mun_Nu
        {
            get { return _mun_Nu; }
            set { _mun_Nu = value; }
        }

        public string Loc_No_Abrev
        {
            get { return _loc_No_Abrev; }
            set { _loc_No_Abrev = value; }
        }

        public int Loc_Nu_Sub
        {
            get { return _loc_Nu_Sub; }
            set { _loc_Nu_Sub = value; }
        }

        public string Loc_In_Tipo_Loc
        {
            get { return _loc_In_Tipo_Loc; }
            set { _loc_In_Tipo_Loc = value; }
        }

        public string Loc_In_Sit
        {
            get { return _loc_In_Sit; }
            set { _loc_In_Sit = value; }
        }
        public string Cep
        {
            get { return _cep; }
            set { _cep = value; }
        }

        public string Loc_No
        {
            get { return _loc_No; }
            set { _loc_No = value; }
        }

        public string Ufe_Sg
        {
            get { return _ufe_Sg; }
            set { _ufe_Sg = value; }
        }

        public int Loc_Nu
        {
            get { return _loc_Nu; }
            set { _loc_Nu = value; }
        }
    }
}
