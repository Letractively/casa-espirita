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
    public class DoacoesBL
    {
        Utils utils = new Utils();

        private bool IsValid(Doacoes doa)
        {
            bool valido;
            valido = doa.PessoaId > 0 && doa.UsuarioId > 0;
            valido = valido && doa.Valor > 0  && utils.ComparaDataComNull(doa.Data) != null;

            return valido;
        }
        
        public Int32 InserirBL(Doacoes doa)
        {
           if(IsValid(doa))
           {
                DoacoesDA doacoesDA = new DoacoesDA();

                return doacoesDA.InserirDA(doa);
           }
           else
               return 0;
           
        }
             

        public bool ExcluirBL(Doacoes doa)
        {
            if(doa.Id > 0)
            {
                DoacoesDA doacoesDA = new DoacoesDA();

                return doacoesDA.ExcluirDA(doa);
            }
            else
                return false;
        }
        
        public List<Doacoes> PesquisarBL()
        {
            /*criar as regras de negocio*/
            DoacoesDA doacoesDA = new DoacoesDA();

            return doacoesDA.PesquisarDA();
        }

        public List<Doacoes> PesquisarBuscaBL(string valor)
        {
            DoacoesDA doacoesDA = new DoacoesDA();

            return doacoesDA.PesquisarBuscaDA(valor);
        }

        public List<Doacoes> PesquisarBL(int id_doa)
        {
            /*criar as regras de negocio*/
            DoacoesDA doacoesDA = new DoacoesDA();

            return doacoesDA.PesquisarDA(id_doa);
        }

        public DataSet PesquisarDataset(string codPessoa,string valorIni,string valorFim,string dataIni,string dataFim)
        {
            /*criar as regras de negocio*/
            DoacoesDA doacoesDA = new DoacoesDA();

            return doacoesDA.PesquisarDataset(codPessoa,valorIni,valorFim,dataIni,dataFim);
        }

        public DataSet PesquisarDataset(int id_doa)
        {
            /*criar as regras de negocio*/
            DoacoesDA doacoesDA = new DoacoesDA();

            return doacoesDA.PesquisarDataSet(id_doa);
        }
    }
}