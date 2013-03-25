using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using DataAccess;
using System.Data;

namespace BusinessLayer
{
    public class ObrasBL : BaseBL
    {
        public bool InserirBL(Obras instancia)
        {
            /*criar as regras de negocio*/
            ObrasDA varDA = new ObrasDA();

            return varDA.InserirDA(instancia);
        }

        public bool EditarBL(Obras instancia)
        {
            /*criar as regras de negocio*/
            ObrasDA varDA = new ObrasDA();

            return varDA.EditarDA(instancia);
        }

        public bool ExcluirBL(Obras instancia)
        {
            /*criar as regras de negocio*/
            ObrasDA varDA = new ObrasDA();

            return varDA.ExcluirDA(instancia);
        }

        public List<Obras> PesquisarBL()
        {
            /*criar as regras de negocio*/
            ObrasDA obrasDA = new ObrasDA();

            return obrasDA.PesquisarDA();
        }

        public DataSet PesquisarBL(int obra_id)
        {
            ObrasDA ObrasDA = new ObrasDA();

            return ObrasDA.PesquisarDA(obra_id);
        }

        public List<Obras> PesquisarBL(string campo, string valor)
        {
            ObrasDA obrasDA = new ObrasDA();

            return obrasDA.PesquisarDA(campo, valor);
        }

        public override List<Base> Pesquisar(string codDes, string tipo)
        {
            ObrasDA obraDA = new ObrasDA();

            return obraDA.Pesquisar(codDes, tipo);
        }
    }
}
