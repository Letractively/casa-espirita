using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using DataObjects;
using System.Data;

namespace BusinessLayer
{
    public class TurmasDiarioBL
    {
        private bool IsValid(TurmasDiario tur)
        {
            bool valido;
            valido = tur.Obs.Length <= 500 && tur.TurmaId > 0;
            valido = tur.Data != null;

            return valido;
        }

        public Int32 InserirBL(TurmasDiario tur)
        {
            if (IsValid(tur))
            {
                TurmasDiarioDA turmasDA = new TurmasDiarioDA();

                return turmasDA.InserirDA(tur);
            }
            else
                return 0;

        }

        public bool EditarBL(TurmasDiario tur)
        {
            if (tur.Id > 0 && IsValid(tur))
            {
                TurmasDiarioDA turmasDA = new TurmasDiarioDA();

                return turmasDA.EditarDA(tur);
            }
            else
                return false;
        }

        public bool ExcluirBL(TurmasDiario tur)
        {
            if (tur.Id > 0)
            {
                TurmasDiarioDA turmasDA = new TurmasDiarioDA();

                return turmasDA.ExcluirDA(tur);
            }
            else
                return false;
        }

        public DataSet PesquisarBL(int id_tur, DateTime data)
        {
            TurmasDiarioDA turmasDA = new TurmasDiarioDA();

            return turmasDA.PesquisarDA(id_tur, data);
        }
    }
}
