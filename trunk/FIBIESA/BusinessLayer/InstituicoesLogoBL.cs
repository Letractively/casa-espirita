using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using DataObjects;


namespace BusinessLayer
{
    public class InstituicoesLogoBL
    {
        public bool InserirBL(InstituicoesLogo insL)
        {
            /*criar as regras de negocio*/
            InstituicoesLogoDA instituicaoLogoDA = new InstituicoesLogoDA();

            return instituicaoLogoDA.InserirDA(insL);
        }

        public bool EditarBL(InstituicoesLogo insL)
        {
            /*criar as regras de negocio*/
            InstituicoesLogoDA instituicaoLogoDA = new InstituicoesLogoDA();

            return instituicaoLogoDA.EditarDA(insL);
        }

        public bool ExcluirBL(InstituicoesLogo insL)
        {
            /*criar as regras de negocio*/
            InstituicoesLogoDA instituicaoLogoDA = new InstituicoesLogoDA();

            return instituicaoLogoDA.ExcluirDA(insL);
        }

        public List<InstituicoesLogo> PesquisarBL()
        {
            /*criar as regras de negocio*/
            InstituicoesLogoDA instituicoesLogoDA = new InstituicoesLogoDA();

            return instituicoesLogoDA.PesquisarDA();
        }

        public List<InstituicoesLogo> PesquisarBL(int insL)
        {
            InstituicoesLogoDA instituicoesLogoDA = new InstituicoesLogoDA();

            return instituicoesLogoDA.PesquisarDA(insL);
        }
    }
}
