using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using DataAccess;

namespace BusinessLayer
{
    public class ContasBL : BaseBL
    {
        private bool IsValid(Contas con)
        {
            bool valido;
            valido = con.Descricao.Length <= 100 && con.Titular.Length <= 70 && con.Digito.Length <= 2;
            valido = valido && con.Codigo > 0 && con.AgenciaId > 0;
                     
            return valido;
        }

        public bool InserirBL(Contas con)
        {
            if (IsValid(con))
            {
                ContasDA conDA = new ContasDA();

                return conDA.InserirDA(con);
            }
            else
                return false;
        }

        public bool EditarBL(Contas con)
        {
            if (con.Id > 0 && IsValid(con))
            {
                ContasDA conDA = new ContasDA();

                return conDA.EditarDA(con);
            }
            else
                return false;
        }

        public bool ExcluirBL(Contas con)
        {
            if (con.Id > 0)
            {
                ContasDA conDA = new ContasDA();

                return conDA.ExcluirDA(con);
            }
            else
                return false;
        }

        public List<Contas> PesquisarBL()
        {           
            ContasDA conDA = new ContasDA();

            return conDA.PesquisarDA();
        }

        public List<Contas> PesquisarBL(int con)
        {
            ContasDA conDA = new ContasDA();

            return conDA.PesquisarDA(con);
        }

        public List<Contas> PesquisarAgeDA(int id_age)
        {
            ContasDA conDA = new ContasDA();

            return conDA.PesquisarAgeDA(id_age);
        }

        public List<Contas> PesquisarBuscaBL(string valor)
        {
            /*criar as regras de negocio*/
            ContasDA conDA = new ContasDA();

            return conDA.PesquisarBuscaDA(valor);
        }

        public override List<Base> Pesquisar(string codDes)
        {
            ContasDA conDA = new ContasDA();

            return conDA.Pesquisar(codDes);
        }
    }
}
