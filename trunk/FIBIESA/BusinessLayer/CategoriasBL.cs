using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using DataObjects;

namespace BusinessLayer
{
    public class CategoriasBL : BaseBL
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

        public bool ExcluirBL(Categorias cat)
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

        public List<Categorias> PesquisarBL(int id_cat)
        {
            CategoriasDA categoriasDA = new CategoriasDA();

            return categoriasDA.PesquisarDA(id_cat);
        }

        public List<Categorias> PesquisarBL(string campo, string valor)
        {
            CategoriasDA categoriasDA = new CategoriasDA();

            return categoriasDA.PesquisarDA(campo, valor);
        }

        public override List<Base> Pesquisar(string codDes, string tipo)
        {
            CategoriasDA catDA = new CategoriasDA();

            return catDA.Pesquisar(codDes, tipo);
        }
    }
}
