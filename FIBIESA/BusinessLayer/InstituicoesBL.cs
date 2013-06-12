using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using DataAccess;
using System.Data;
using FG;

namespace BusinessLayer
{
    public class InstituicoesBL
    {
        Utils utils = new Utils();

        private bool IsValid(Instituicoes ins)
        {
            bool valido;
            valido = ins.Razao.Length <= 70 && ins.Email.Length <= 100 && ins.Endereco.Length <= 40 
                     && ins.Cep.Length <= 10 && ins.NomeFantasia.Length <= 70 && ins.Complemento.Length <= 40 
                     && ins.telefone.Length <= 20 && ins.Cnpj.Length <= 20;

            return valido;
        }

        public bool InserirBL(Instituicoes ins)
        {
            if (IsValid(ins))
            {
                InstituicoesDA instituicaoDA = new InstituicoesDA();
                
                ins.Cnpj = utils.LimpaFormatacaoCNPJ(ins.Cnpj);
                
                return instituicaoDA.InserirDA(ins);
            }
            else
                return false;
        }

        public bool EditarBL(Instituicoes ins)
        {
            if (IsValid(ins) && ins.Id > 0)
            {
                InstituicoesDA instituicaoDA = new InstituicoesDA();
                
                ins.Cnpj = utils.LimpaFormatacaoCNPJ(ins.Cnpj);
                
                return instituicaoDA.EditarDA(ins);
            }
            else
                return false;
        }

        public bool ExcluirBL(Instituicoes ins)
        {
            if (ins.Id > 0)
            {
                InstituicoesDA instituicaoDA = new InstituicoesDA();

                return instituicaoDA.ExcluirDA(ins);
            }
            else
                return false;
        }

        public List<Instituicoes> PesquisarBL(bool instPrincipal)
        {
            /*criar as regras de negocio*/
            InstituicoesDA instituicoesDA = new InstituicoesDA();

            return instituicoesDA.PesquisarDA(instPrincipal);
        }

        public DataSet PesquisarDsBL()
        {
            /*criar as regras de negocio*/
            InstituicoesDA instituicoesDA = new InstituicoesDA();

            return instituicoesDA.PesquisarDsDA();
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

        public List<Instituicoes> PesquisarBuscaBL(string valor)
        {
            /*criar as regras de negocio*/
            InstituicoesDA instituicoesDA = new InstituicoesDA();

            return instituicoesDA.PesquisarBuscaDA(valor);
        }

        public bool CodigoJaUtilizadoBL(Int32 codigo)
        {
            InstituicoesDA insDA = new InstituicoesDA();

            return insDA.CodigoJaUtilizadoDA(codigo);
        }
    }
}
