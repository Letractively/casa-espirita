using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using DataAccess;

namespace BusinessLayer
{
    public class AutoresBL
    {
        public bool InserirBL(Autores bai)
        {
            /*criar as regras de negocio*/
            AutoresDA autoresDA = new AutoresDA();

            return autoresDA.InserirDA(bai);
        }

        public bool EditarBL(Autores bai)
        {
            /*criar as regras de negocio*/
            AutoresDA autoresDA = new AutoresDA();

            return autoresDA.EditarDA(bai);
        }

        public bool ExcluirBL(Autores bai)
        {
            /*criar as regras de negocio*/
            AutoresDA autoresDA = new AutoresDA();

            return autoresDA.ExcluirDA(bai);
        }

        public List<Autores> PesquisarBL()
        {
            /*criar as regras de negocio*/
            AutoresDA autoresDA = new AutoresDA();

            return autoresDA.PesquisarDA();
        }

        public List<Autores> PesquisarBL(int bai)
        {
            AutoresDA autoresDA = new AutoresDA();

            return autoresDA.PesquisarDA(bai);
        }

        public List<Autores> PesquisarBL(string campo, string valor)
        {
            AutoresDA autoresDA = new AutoresDA();

            return autoresDA.PesquisarDA(campo, valor);
        }

      
    }
}
