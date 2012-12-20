using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using DataAccess;

namespace BusinessLayer
{
    public class EditorasBL
    {
        public bool InserirBL(Editoras instancia)
        {
            /*criar as regras de negocio*/
            EditorasDA varDA = new EditorasDA();

            return varDA.InserirDA(instancia);
        }

        public bool EditarBL(Editoras instancia)
        {
            /*criar as regras de negocio*/
            EditorasDA varDA = new EditorasDA();

            return varDA.EditarDA(instancia);
        }

        public bool ExcluirBL(Editoras instancia)
        {
            /*criar as regras de negocio*/
            EditorasDA varDA = new EditorasDA();

            return varDA.ExcluirDA(instancia);
        }

        public List<Editoras> PesquisarBL()
        {
            /*criar as regras de negocio*/
            EditorasDA varDA = new EditorasDA();

            return varDA.PesquisarDA();
        }
    }
}
