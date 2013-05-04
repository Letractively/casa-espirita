using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using DataAccess;

namespace BusinessLayer
{
    public class AgenciasBL : BaseBL
    {
        private bool IsValid(Agencias age)
        {
            bool valido;
            valido = age.Descricao.Length <= 70;
            valido = valido && age.Codigo > 0 && age.CidadeId > 0 && age.BairroId > 0;
            
            if(age.Endereco != null)
                valido = valido && age.Endereco.Length <= 70;

            if (age.Complemento != null)
                valido = valido && age.Complemento.Length <= 40;

            if (age.Cep != null)
                valido = valido && age.Cep.Length <= 20;
            return valido;
        }

        public bool InserirBL(Agencias age)
        {
            if (IsValid(age))
            {
                AgenciasDA ageDA = new AgenciasDA();

                return ageDA.InserirDA(age);
            }
            else
                return false;
        }

        public bool EditarBL(Agencias age)
        {
            if (age.Id > 0 && IsValid(age))
            {
                AgenciasDA ageDA = new AgenciasDA();

                return ageDA.EditarDA(age);
            }
            else
                return false;
                
        }

        public bool ExcluirBL(Agencias age)
        {
            if (age.Id > 0)
            {
                AgenciasDA ageDA = new AgenciasDA();

                return ageDA.ExcluirDA(age);
            }
            else
                return false;
        }

        public List<Agencias> PesquisarBL()
        {            
            AgenciasDA ageDA = new AgenciasDA();

            return ageDA.PesquisarDA();
        }

        public List<Agencias> PesquisarBuscaBL(string valor)
        {         
            AgenciasDA ageDA = new AgenciasDA();

            return ageDA.PesquisarBuscaDA(valor);
        }

        public List<Agencias> PesquisarBL(int age)
        {
            AgenciasDA ageDA = new AgenciasDA();

            return ageDA.PesquisarDA(age);
        }

        public List<Agencias> PesquisarBanDA(int id_ban)
        {
            AgenciasDA ageDA = new AgenciasDA();

            return ageDA.PesquisarBanDA(id_ban); 
        }
        
        public override List<Base> Pesquisar(string codDes)
        {
            AgenciasDA ageDA = new AgenciasDA();

            return ageDA.Pesquisar(codDes);
        }
    }
}
