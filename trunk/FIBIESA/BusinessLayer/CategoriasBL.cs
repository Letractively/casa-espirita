using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using DataObjects;

namespace BusinessLayer
{
    public class CategoriasBL
    {
        public bool InserirBL(Categorias cat)
        {
            /*criar as regras de negocio*/
            CategoriasDA categoriasDA = new CategoriasDA();

            return categoriasDA.InserirDA(cat);
        }

        public bool EditarBL(Categorias cat)
        {
            /*criar as regras de negocio*/
            CategoriasDA categoriasDA = new CategoriasDA();

            return categoriasDA.EditarDA(cat);
        }

        public bool ExcluirBL(CategoriasDA cat)
        {
            /*criar as regras de negocio*/
            CategoriasDA categoriasDA = new CategoriasDA();

            return categoriasDA.ExcluirDA(cat);
        }

        public List<Categorias> PesquisarBL()
        {
            /*criar as regras de negocio*/
            CategoriasDA categoriasDA = new CategoriasDA();

            return categoriasDA.PesquisarDA();
        }
    }
}
