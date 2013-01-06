using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using DataAccess;

namespace BusinessLayer
{
    public class PermissoesBL
    {
        public bool InserirBL(Permissoes per)
        {
            /*criar as regras de negocio*/
            PermissoesDA permissoesDA = new PermissoesDA();

            return permissoesDA.InserirDA(per);
        }

        public bool EditarBL(Permissoes per)
        {
            /*criar as regras de negocio*/
            PermissoesDA permissoesDA = new PermissoesDA();

            return permissoesDA.EditarDA(per);
        }

        public bool ExcluirBL(Permissoes per)
        {
            /*criar as regras de negocio*/
            PermissoesDA permissoesDA = new PermissoesDA();

            return permissoesDA.ExcluirDA(per);
        }

        public List<Permissoes> PesquisarBL()
        {
            /*criar as regras de negocio*/
            PermissoesDA permissoesDA = new PermissoesDA();

            return permissoesDA.PesquisarDA();
        }

        public List<Permissoes> PesquisarBL(int id_per)
        {
            PermissoesDA permissoesDA = new PermissoesDA();

            return permissoesDA.PesquisarDA(id_per);
        }
    }
}
