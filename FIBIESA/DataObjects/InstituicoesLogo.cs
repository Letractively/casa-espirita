using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataObjects
{
    public class InstituicoesLogo
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private int _instituicoesId;
        public int InstituicoesId
        {
            get { return _instituicoesId; }
            set { _instituicoesId = value; }
        }

        private byte[] _imagem;
        public byte[] Imagem
        {
            get { return _imagem; }
            set { _imagem = value; }
        }
                
        private string _extensao;
        public string Extensao
        {
            get { return _extensao; }
            set { _extensao = value; }
        }
    }
}
