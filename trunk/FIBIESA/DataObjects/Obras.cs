using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataObjects
{
    public class Obras : Base
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
        
        private string _titulo;	//100
        public string Titulo
        {
            get { return _titulo; }
            set { _titulo = value; }
        }
        
        private int? _nroEdicao;//4
        public int? NroEdicao
        {
            get { return _nroEdicao; }
            set { _nroEdicao = value; }
        }
        
        private int? _editoraId;
        public int? EditoraId
        {
            get { return _editoraId; }
            set { _editoraId = value; }
        }
        
        private string _localPublicacao;
        public string LocalPublicacao
        {
            get { return _localPublicacao; }
            set { _localPublicacao = value; }
        }
        
        private DateTime? _dataPublicacao;//date 
        public DateTime? DataPublicacao
        {
            get { return _dataPublicacao; }
            set { _dataPublicacao = value; }
        }
        
        private int? _nroPaginas;//	4
        public int? NroPaginas
        {
            get { return _nroPaginas; }
            set { _nroPaginas = value; }
        }
        
        private string _isbn;//	13
        public string Isbn
        {
            get { return _isbn; }
            set { _isbn = value; }
        }
        
        private string _assuntosAborda;//4000
        public string AssuntosAborda
        {
            get { return _assuntosAborda; }
            set { _assuntosAborda = value; }
        }
                      
        private DateTime? _dataReimpressao; 
        public DateTime? DataReimpressao
        {
            get { return _dataReimpressao; }
            set { _dataReimpressao = value; }
        }
        
        private int? _imagemCapa;
        public int? ImagemCapa
        {
            get { return _imagemCapa; }
            set { _imagemCapa = value; }
        }
        
        private int? _volume;
        public int? Volume
        {
            get { return _volume; }
            set { _volume = value; }
        }
         
        private int? _tiposObraId;
        public int? TiposObraId
        {
            get { return _tiposObraId; }
            set { _tiposObraId = value; }
        }

        private TiposObras _tiposObras;
        public TiposObras TiposObras
        {
            get { return _tiposObras; }
            set { _tiposObras = value; }
        }

        private string _cdu;

        public string Cdu
        {
            get { return _cdu; }
            set { _cdu = value; }
        }
        

    }
}
