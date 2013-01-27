using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using DataAccess;
using System.Data;

namespace BusinessLayer
{
    public class CursosBL : BaseBL
    {
        public bool InserirBL(Cursos cur)
        {
            /*criar as regras de negocio*/
            CursosDA cursosDA = new CursosDA();

            return cursosDA.InserirDA(cur);
        }

        public bool EditarBL(Cursos cur)
        {
            /*criar as regras de negocio*/
            CursosDA cursosDA = new CursosDA();

            return cursosDA.EditarDA(cur);
        }

        public bool ExcluirBL(Cursos cur)
        {
            /*criar as regras de negocio*/
            CursosDA cursosDA = new CursosDA();

            return cursosDA.ExcluirDA(cur);
        }

        public List<Cursos> PesquisarBL()
        {
            /*criar as regras de negocio*/
            CursosDA cursosDA = new CursosDA();

            return cursosDA.PesquisarDA();
        }

        public List<Cursos> PesquisarBL(int cur)
        {
            CursosDA cursosDA = new CursosDA();

            return cursosDA.PesquisarDA(cur);
        }

        public override List<Base> Pesquisar(string codDes, string tipo)
        {
            CursosDA curDA = new CursosDA();

            return curDA.Pesquisar(codDes, tipo);
        }

    }
}
