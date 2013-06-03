using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using DataAccess;

namespace BusinessLayer
{
    public class TiposDocumentosBL : BaseBL
    {
        private bool IsValid(TiposDocumentos tdo)
        {
            bool valido;
            valido = tdo.Descricao.Length <= 40 && (tdo.Aplicacao == "CP" || tdo.Aplicacao =="CR");

            return valido;
        }

        public bool InserirBL(TiposDocumentos tdo)
        {
            if (IsValid(tdo))
            {
                TiposDocumentosDA tdoDA = new TiposDocumentosDA();

                return tdoDA.InserirDA(tdo);
            }
            else
                return false;
        }

        public bool EditarBL(TiposDocumentos tdo)
        {
            if (tdo.Id > 0 && IsValid(tdo))
            {
                TiposDocumentosDA tdoDA = new TiposDocumentosDA();

                return tdoDA.EditarDA(tdo);
            }
            else
                return false;
        }

        public bool ExcluirBL(TiposDocumentos tdo)
        {
            if (tdo.Id > 0)
            {
                TiposDocumentosDA tdoDA = new TiposDocumentosDA();

                return tdoDA.ExcluirDA(tdo);
            }
            else
                return false;
        }

        public List<TiposDocumentos> PesquisarBL(string aplicacao)
        {
            /*criar as regras de negocio*/
            TiposDocumentosDA tdoDA = new TiposDocumentosDA();

            return tdoDA.PesquisarDA(aplicacao);
        }

        public List<TiposDocumentos> PesquisarBL(int tdo)
        {
            TiposDocumentosDA tdoDA = new TiposDocumentosDA();

            return tdoDA.PesquisarDA(tdo);
        }

        public List<TiposDocumentos> PesquisarBL(string campo, string valor)
        {
            TiposDocumentosDA tiposDocDA = new TiposDocumentosDA();

            return tiposDocDA.PesquisarDA(campo, valor);
        }

        public List<TiposDocumentos> PesquisarBuscaBL(string valor)
        {
            /*criar as regras de negocio*/
            TiposDocumentosDA tiposDocDA = new TiposDocumentosDA();

            return tiposDocDA.PesquisarBuscaDA(valor);
        }

        public override List<Base> Pesquisar(string codDes)
        {
            TiposDocumentosDA tdoDA = new TiposDocumentosDA();

            return tdoDA.Pesquisar(codDes);
        }
    }
}
