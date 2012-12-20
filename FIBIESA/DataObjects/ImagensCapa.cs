using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataObjects
{
    public class ImagensCapa
    {
        //Lendo e escrevendo arquivos binarios em C#:
        //http://www.akadia.com/services/dotnet_read_write_blob.html
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private int _obraId;

        public int ObraId
        {
            get { return _obraId; }
            set { _obraId = value; }
        }
        private byte[] _imagem;

        public byte[] Imagem
        {
            get { return _imagem; }
            set { _imagem = value; }
        }
    }
}
