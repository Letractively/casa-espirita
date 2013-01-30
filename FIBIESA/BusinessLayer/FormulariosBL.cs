using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using DataAccess;

namespace BusinessLayer
{
    public class FormulariosBL
    {
        public bool InserirBL(Formularios form)
        {
            /*criar as regras de negocio*/
            FormulariosDA formulariosDA = new FormulariosDA();

            return formulariosDA.InserirDA(form);
        }

        public bool EditarBL(Formularios form)
        {
            /*criar as regras de negocio*/
            FormulariosDA formulariosDA = new FormulariosDA();

            return formulariosDA.EditarDA(form);
        }

        public bool ExcluirBL(Formularios form)
        {
            /*criar as regras de negocio*/
            FormulariosDA formulariosDA = new FormulariosDA();

            return formulariosDA.ExcluirDA(form);
        }

        public List<Formularios> PesquisarBL()
        {
            /*criar as regras de negocio*/
            FormulariosDA formulariosDA = new FormulariosDA();

            return formulariosDA.PesquisarDA();
        }

        public List<Formularios> PesquisarBL(int id_for)
        {
            /*criar as regras de negocio*/
            FormulariosDA formulariosDA = new FormulariosDA();

            return formulariosDA.PesquisarDA(id_for);
        }
    }
}
