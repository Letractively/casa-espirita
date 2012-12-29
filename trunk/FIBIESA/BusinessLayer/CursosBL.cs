using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using DataAccess;

namespace BusinessLayer
{
    public class CursosBL
    {
        public bool InserirBL(Cursos cur)
        {
            
            CursosDA cursosDA = new CursosDA();

            return cursosDA.InserirDA(cur);
        }

        public bool EditarBL(Cursos cur)
        {
            
            CursosDA cursosDA = new CursosDA();

            return cursosDA.EditarDA(cur);
        }

        public bool ExcluirBL(Cursos cur)
        {
           
             CursosDA cursosDA = new CursosDA();

            return cursosDA.ExcluirDA(cur);
        }

        public List<Cursos> PesquisarBL()
        {
            
            CursosDA cursosDA = new CursosDA();

            return cursosDA.PesquisarDA();
        }
    }
}
