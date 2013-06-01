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
        private bool IsValid(Turmas tur)
        {
            bool valido;
            valido = tur.Descricao.Length <= 70 && tur.EventoId > 0;
            valido = valido && tur.Nromax > 0 && tur.DataInicial != null && tur.DataFinal != null;

            return valido;
        }

        public Int32 InserirBL(Turmas tur)
        {
            if (IsValid(tur))
            {
                TurmasDA turmasDA = new TurmasDA();

                return turmasDA.InserirDA(tur);
            }
            else
                return 0;
               
        }

        public bool EditarBL(Turmas tur)
        {
            if (tur.Id > 0 && IsValid(tur))
            {
                TurmasDA turmasDA = new TurmasDA();

                return turmasDA.EditarDA(tur);
            }
            else
                return false;
        }

        public bool ExcluirBL(Turmas tur)
        {
            if (tur.Id > 0)
            {
                TurmasDA turmasDA = new TurmasDA();

                return turmasDA.ExcluirDA(tur);
            }
            else
                return false;
        }

        public List<Turmas> PesquisarBL()
        {
            /*criar as regras de negocio*/
            TurmasDA turmasDA = new TurmasDA();

            return turmasDA.PesquisarDA();
        }

        public DataSet PesquisarBL(int tur)
        {
            TurmasDA turmasDA = new TurmasDA();

            return turmasDA.PesquisarDA(tur);
        }

        public List<Turmas> PesquisarEveBL(int id_eve)
        {
            TurmasDA turmasDA = new TurmasDA();

            return turmasDA.PesquisarEveDA(id_eve);
        }

        public List<Turmas> PesquisarBL(int id_tur, int id_eve)
        {
            TurmasDA turmasDA = new TurmasDA();

            return turmasDA.PesquisarDA(id_tur, id_eve);
        }

        public List<Turmas> PesquisarBL(string campo, string valor)
        {
            TurmasDA turmasDA = new TurmasDA();

            return turmasDA.PesquisarDA(campo, valor);
        }

        public List<Turmas> PesquisarBuscaBL(string valor)
        {
            TurmasDA eveDA = new TurmasDA();

            return eveDA.PesquisarBuscaDA(valor);
        }

        public override List<Base> Pesquisar(string codDes)
        {
            TurmasDA turDA = new TurmasDA();

            return turDA.Pesquisar(codDes);
        }

        public DataSet PesquisarDataset(string codEvento,string codTurma, string dataIni, string dataIniF, string dataFim, string dataFimF,Boolean tumasAberto)
        {
            TurmasDA turmaDA = new TurmasDA();

            return turmaDA.PesquisarDataSet(codEvento,codTurma, dataIni, dataIniF, dataFim, dataFimF,tumasAberto);
        }

    }
}
