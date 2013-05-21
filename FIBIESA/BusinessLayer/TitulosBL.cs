using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using DataAccess;
using System.Data;

namespace BusinessLayer
{

    public class TitulosBL : BaseBL
    {
        private bool IsValid(Titulos tit)
        {
            bool valido;            
            valido = tit.Tipo != "";
            valido = valido && tit.Numero > 0 && tit.Parcela > 0 && tit.TipoDocumentoId > 0;        
            if (tit.Obs != null)
                valido = valido && tit.Obs.Length <= 200;
            return valido;
        }

        public bool InserirBL(Titulos tit)
        {
            if (IsValid(tit))
            {
                TitulosDA titDA = new TitulosDA();
                return titDA.InserirDA(tit);
            }
            else
                return false;

        }

        public bool EditarBL(Titulos tit)
        {
            if (tit.Id > 0  && IsValid(tit))
            {
                TitulosDA titDA = new TitulosDA();
                return titDA.EditarDA(tit);
            }
            else
                return false;
        }

        public bool ExcluirBL(Titulos tit)
        {
            if (tit.Id > 0)
            {
                TitulosDA titDA = new TitulosDA();
                return titDA.ExcluirDA(tit);
            }
            else
                return false;
        }

        public List<Titulos> PesquisarBL()
        {
            TitulosDA titDA = new TitulosDA();
            return titDA.PesquisarDA();
        }

        public List<Titulos> PesquisarBL(int pes)
        {
            TitulosDA titDA = new TitulosDA();
            return titDA.PesquisarDA(pes);
        }
             
        public List<Titulos> PesquisarBuscaBL(string tipo, string valor)
        {            
            TitulosDA titulosDA = new TitulosDA();

            return titulosDA.PesquisarBuscaDA(tipo,valor);
        }

        public List<Titulos> PesquisarBuscaBL(string valor)
        {
            TitulosDA titulosDA = new TitulosDA();

            return titulosDA.PesquisarBuscaDA(valor);
        }

        public DataSet PesquisarBuscaDataSetBL(string codTitulos, string codAssociados, string codPotadores, string tipoTitulo, string tipoDocumento, Boolean blAtrasados, string DataEmissaoIni, string DataEmissaoFim, string DataVencimentoIni, string DataVencimentoFim, string DataPagamentoIni, string DataPagamentoFim)
        {
            TitulosDA titulosDA = new TitulosDA();

            return titulosDA.PesquisarBuscaDataSetDA(codTitulos, codAssociados, codPotadores, tipoTitulo, tipoDocumento, blAtrasados, DataEmissaoIni, DataEmissaoFim, DataVencimentoIni, DataVencimentoFim, DataPagamentoIni, DataPagamentoFim);
        }
        
    }
}
