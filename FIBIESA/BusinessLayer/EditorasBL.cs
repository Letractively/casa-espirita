using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using DataAccess;

namespace BusinessLayer
{
    public class EditorasBL : BaseBL
    {
        private bool IsValid(Editoras instancia)
        {
            bool valido;
            valido = instancia.Descricao.Length <= 70;

            return valido;
        }

        public bool InserirBL(Editoras instancia)
        {
            if (IsValid(instancia))
            {
                EditorasDA varDA = new EditorasDA();

                return varDA.InserirDA(instancia);
            }
            else
                return false;
        }

        public bool EditarBL(Editoras instancia)
        {
            if (instancia.Id > 0 && IsValid(instancia))
            {
                EditorasDA varDA = new EditorasDA();

                return varDA.EditarDA(instancia);
            }
            else
                return false;
        }

        public bool ExcluirBL(Editoras instancia)
        {
            if (instancia.Id > 0)
            {
                EditorasDA varDA = new EditorasDA();

                return varDA.ExcluirDA(instancia);
            }
            else
                return false;
        }

        public List<Editoras> PesquisarBL()
        {
            /*criar as regras de negocio*/
            EditorasDA editorasDA = new EditorasDA();

            return editorasDA.PesquisarDA();
        }

        public List<Editoras> PesquisarBL(int bai)
        {
            EditorasDA editorasDA = new EditorasDA();

            return editorasDA.PesquisarDA(bai);
        }

        public List<Editoras> PesquisarBuscaBL(string valor)
        {
            /*criar as regras de negocio*/
            EditorasDA editorasDA = new EditorasDA();

            return editorasDA.PesquisarBuscaDA(valor);
        }

        public override List<Base> Pesquisar(string codDes)
        {
            EditorasDA edDA = new EditorasDA();

            return edDA.Pesquisar(codDes);
        }
    }
}
