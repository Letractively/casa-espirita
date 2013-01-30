using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataObjects
{
    public class Permissoes
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

        private Boolean _consultar;
        public Boolean Consultar
        {
            get { return _consultar; }
            set { _consultar = value; }
        }

        private Boolean _editar;
        public Boolean Editar
        {
            get { return _editar; }
            set { _editar = value; }
        }

        private Boolean _inserir;
        public Boolean Inserir
        {
            get { return _inserir; }
            set { _inserir = value; }
        }

        private Boolean _excluir;
        public Boolean Excluir
        {
            get { return _excluir; }
            set { _excluir = value; }
        }

        private Int32 _formularioId;
        public Int32 FormularioId
        {
            get { return _formularioId; }
            set { _formularioId = value; }
        }

        private Int32 _categoriaId;
        public Int32 CategoriaId
        {
            get { return _categoriaId; }
            set { _categoriaId = value; }
        }

        private Categorias _categoria;
        public Categorias Categoria
        {
            get { return _categoria; }
            set { _categoria = value; }
        }

        private Formularios _formulario;
        public Formularios Formulario
        {
            get { return _formulario; }
            set { _formulario = value; }
        }
    }
}
