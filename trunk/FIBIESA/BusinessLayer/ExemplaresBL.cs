using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using DataAccess;
using System.Data;

namespace BusinessLayer
{
    public class ExemplaresBL : BaseBL
    {        
        public bool InserirBL(Exemplares instancia)
        {
            /*criar as regras de negocio*/
            ExemplaresDA varDA = new ExemplaresDA();

            return varDA.InserirDA(instancia);
        }

        public bool EditarBL(Exemplares instancia)
        {
            /*criar as regras de negocio*/
            ExemplaresDA varDA = new ExemplaresDA();

            return varDA.EditarDA(instancia);
        }

        public bool ExcluirBL(Exemplares instancia)
        {
            /*criar as regras de negocio*/
            ExemplaresDA varDA = new ExemplaresDA();

            return varDA.ExcluirDA(instancia);
        }

        public List<Exemplares> PesquisarBL()
        {
            /*criar as regras de negocio*/
            ExemplaresDA varDA = new ExemplaresDA();

            return varDA.PesquisarDA();
        }

        public DataSet PesquisarBL(int bai)
        {
            ExemplaresDA varDA = new ExemplaresDA();

            return varDA.PesquisarDA(bai);
        }

        public List<Exemplares> PesquisarBL(string campo, string valor)
        {
            ExemplaresDA varDA = new ExemplaresDA();

            return varDA.PesquisarDA(campo, valor);
        }

        public List<Exemplares> PesquisarBuscaBL(string valor)
        {
            /*criar as regras de negocio*/
            ExemplaresDA exeDA = new ExemplaresDA();

            return exeDA.PesquisarBuscaDA(valor);
        }

        public override List<Base> Pesquisar(string codDes)
        {
            ExemplaresDA varDA = new ExemplaresDA();

            return varDA.Pesquisar(codDes);
        }

        public List<Exemplares> PesquisarDisponiveis(string valor)
        {
            ExemplaresDA varDA = new ExemplaresDA();

            return varDA.PesquisarDisponiveis(valor);
        }
    }
}
