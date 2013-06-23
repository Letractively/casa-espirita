using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using DataAccess;
using System.Data;

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

        public List<Permissoes> PesquisarBL(int id_cat)
        {
            PermissoesDA permissoesDA = new PermissoesDA();

            return permissoesDA.PesquisarDA(id_cat);
        }        

        public List<Permissoes> PesquisarBL(int id_categoria, int id_formulario)
        {
            PermissoesDA permissoesDA = new PermissoesDA();

            return permissoesDA.PesquisarDA(id_categoria, id_formulario);
        }

        public List<Permissoes> PesquisarBL(int id_categoria, string nome)
        {
            PermissoesDA permissoesDA = new PermissoesDA();

            return permissoesDA.PesquisarDA(id_categoria, nome);
        }   

        public DataSet PesquisarPermissoesBL(int id_categoria)
        {
            PermissoesDA permissoesDA = new PermissoesDA();

            return permissoesDA.PesquisarPermissoesDA(id_categoria);
        }

        public DataSet PesquisarModulosBL(int id_categoria)
        {
            PermissoesDA permissoesDA = new PermissoesDA();

            return permissoesDA.PesquisarModulosDA(id_categoria);
        }         
               
    }
}
