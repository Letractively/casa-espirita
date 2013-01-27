using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using DataAccess;
using System.Data;

namespace BusinessLayer
{
    public class TurmasBL : BaseBL
    {
        public bool InserirBL(Turmas tur)
        {
            /*criar as regras de negocio*/
            TurmasDA turmasDA = new TurmasDA();

            return turmasDA.InserirDA(tur);
        }

        public bool EditarBL(Turmas tur)
        {
            /*criar as regras de negocio*/
            TurmasDA turmasDA = new TurmasDA();

            return turmasDA.EditarDA(tur);
        }

        public bool ExcluirBL(Turmas tur)
        {
            /*criar as regras de negocio*/
            TurmasDA turmasDA = new TurmasDA();

            return turmasDA.ExcluirDA(tur);
        }

        public List<Turmas> PesquisarBL()
        {
            /*criar as regras de negocio*/
            TurmasDA turmasDA = new TurmasDA();

            return turmasDA.PesquisarDA();
        }

        public List<Turmas> PesquisarBL(int tur)
        {
            TurmasDA turmasDA = new TurmasDA();

            return turmasDA.PesquisarDA(tur);
        }

        public override List<Base> Pesquisar(string codDes, string tipo)
        {
            TurmasDA turDA = new TurmasDA();

            return turDA.Pesquisar(codDes, tipo);
        }

    }
}
