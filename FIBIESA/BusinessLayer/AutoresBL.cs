using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using DataAccess;
using System.Data;

namespace BusinessLayer
{
    public class AutoresBL : BaseBL
    {
        public bool InserirBL(Autores instancia)
        {
            
            /*criar as regras de negocio*/
            AutoresDA varDA = new AutoresDA();

            return varDA.InserirDA(instancia);
        }

        public bool EditarBL(Autores instancia)
        {
            /*criar as regras de negocio*/
            AutoresDA varDA = new AutoresDA();

            return varDA.EditarDA(instancia);
        }

        public bool ExcluirBL(Autores instancia)
        {
            /*criar as regras de negocio*/
            AutoresDA varDA = new AutoresDA();

            return varDA.ExcluirDA(instancia);
        }

        public List<Autores> PesquisarBL()
        {
            /*criar as regras de negocio*/
            AutoresDA AutoresDA = new AutoresDA();

            return AutoresDA.PesquisarDA();
        }

        public List<Autores> PesquisarBL(int bai)
        {
            AutoresDA AutoresDA = new AutoresDA();

            return AutoresDA.PesquisarDA(bai);
        }

        public List<Autores> PesquisarBL(string campo, string valor)
        {
            AutoresDA AutoresDA = new AutoresDA();

            return AutoresDA.PesquisarDA(campo, valor);
        }

        public override List<Base> Pesquisar(string codDes, string tipo)
        {
            AutoresDA baiDA = new AutoresDA();

            return baiDA.Pesquisar(codDes, tipo);
        }
    }
}
