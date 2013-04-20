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
        public bool InserirBL(Autores aut)
        {
            /*criar as regras de negocio*/
            AutoresDA autoresDA = new AutoresDA();

            return autoresDA.InserirDA(aut);
        }

        public bool EditarBL(Autores aut)
        {
            /*criar as regras de negocio*/
            AutoresDA autoresDA = new AutoresDA();

            return autoresDA.EditarDA(aut);
        }

        public bool ExcluirBL(Autores aut)
        {
            /*criar as regras de negocio*/
            AutoresDA autoresDA = new AutoresDA();

            return autoresDA.ExcluirDA(aut);
        }

        public List<Autores> PesquisarBL()
        {
            /*criar as regras de negocio*/
            AutoresDA autoresDA = new AutoresDA();

            return autoresDA.PesquisarDA();
        }

        public List<Autores> PesquisarBL(int aut)
        {
            AutoresDA autoresDA = new AutoresDA();

            return autoresDA.PesquisarDA(aut);
        }

        public List<Autores> PesquisarBuscaBL(string valor)
        {
            /*criar as regras de negocio*/
            AutoresDA autoresDA = new AutoresDA();

            return autoresDA.PesquisarBuscaDA(valor);
        }

        public List<Autores> PesquisarBL(string campo, string valor)
        {
            AutoresDA autoresDA = new AutoresDA();

            return autoresDA.PesquisarDA(campo, valor);
        }

      
    }
}
