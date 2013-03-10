using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using DataAccess;

namespace BusinessLayer
{
    public class InstituicoesBL
    {
        public bool InserirBL(Instituicoes ins)
        {
            /*criar as regras de negocio*/
            InstituicoesDA instituicaoDA = new InstituicoesDA();

            return instituicaoDA.InserirDA(ins);
        }

        public bool EditarBL(Instituicoes ins)
        {
            /*criar as regras de negocio*/
            InstituicoesDA instituicaoDA = new InstituicoesDA();

            return instituicaoDA.EditarDA(ins);
        }

        public bool ExcluirBL(Instituicoes ins)
        {
            /*criar as regras de negocio*/
            InstituicoesDA instituicaoDA = new InstituicoesDA();

            return instituicaoDA.ExcluirDA(ins);
        }

        public List<Instituicoes> PesquisarBL()
        {
            /*criar as regras de negocio*/
            InstituicoesDA instituicoesDA = new InstituicoesDA();

            return instituicoesDA.PesquisarDA();
        }

        public List<Instituicoes> PesquisarBL(string campo, string valor)
        {
            InstituicoesDA instDA = new InstituicoesDA();

            return instDA.PesquisarDA(campo, valor);
        }

        public List<Instituicoes> PesquisarBL(int ins)
        {
            InstituicoesDA instituicoesDA = new InstituicoesDA();

            return instituicoesDA.PesquisarDA(ins);
        }

    }
}
