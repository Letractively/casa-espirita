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

    public class TitulosBL : BaseBL
    {
        Utils utils = new Utils();
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

        /// <summary>
        /// Retorna um numero de titulo válido, ou -1 se der erro.
        /// </summary>
        /// <returns></returns>
        public Int32 RetornaNovoNumero()
        {
            TitulosDA titulosDA = new TitulosDA();

            return titulosDA.RetornaNovoNumero();
        }

        public StringBuilder ArquivoRemessaMontarHeader(StringBuilder header, Titulos titulo)
        {
            InstituicoesBL instBL = new InstituicoesBL();
            DataSet dsInst = instBL.PesquisarDsBL();
            
            ////posicoes 001 - 009 
            //header.Append("01REMESSA"); 

            ////posicoes 010 - 026 brancos
            //utils.IncluirBrancos(header, 0, 16);

            ////posicoes 027 - 039     
            //header.Append(titulo.Portador.CodCedente.ToString());
            //utils.IncluirZeros(header, titulo.Portador.CodCedente.ToString().Length, 13);                       
            
            ////posicoes 040 - 046 brancos
            //utils.IncluirBrancos(header, 0, 7);

            //if (dsInst.Tables[0].Rows.Count != 0)
            //{
            //    //posicoes 047 - 076 nome da empresa
            //    utils.IncluirBrancos(header, dsInst.Tables[0].Rows[0]["razao"].ToString().Length, 30);
            //    header.Append((string)dsInst.Tables[0].Rows[0]["razao"].ToString());
            //}
            
            ////posicoes 077 - 087 
            //header.Append("041BANRISUL");

            ////posicoes 088 - 094 brancos
            //utils.IncluirBrancos(header,0, 7);

            ////posicoes 095 - 100 
            //header.Append(DateTime.Now.ToString("ddMMyy"));

            ////posicoes 101 - 109 brancos
            //utils.IncluirBrancos(header, 0, 9);

            ////posicoes 110 - 113
            //if (titulo.Portador.Carteira == "R" || titulo.Portador.Carteira == "S" || titulo.Portador.Carteira == "X")
            //{
            //    header.Append("0808");
            //    //posicoes 114 - 114 branco
            //    utils.IncluirBrancos(header, 0, 1);

            //    // posicoes 115 - 115
            //    header.Append("P");

            //    //posicoes 116 - 116
            //    utils.IncluirBrancos(header, 0, 1);

            //    //posicoes 117 - 126
            //    utils.IncluirBrancos(header, titulo.Portador.CodEmpBanriMicro.Length, 10);
            //    header.Append(titulo.Portador.CodEmpBanriMicro);
            //}
            //else
            //{
            //    //posicoes 110 - 113 e 114 ao 126
            //    utils.IncluirBrancos(header, 0, 17);
            //}                    

            ////posicoes 127 - 394 brancos
            //utils.IncluirBrancos(header, 0, 268);

            ////posicoes 395 - 400
            //header.Append("000001");

            return header;
        }

        public StringBuilder ArquivoRemessaMontarTransacao(StringBuilder transacao, Titulos titulo, Remessa remessa)
        {
            decimal v_taxa_juro = 0;

            //posicoes 001 - 001
            transacao.Append("1");

            //posicoes 002 - 017
            utils.IncluirCampoAlfanumerico(transacao, " ", 16);

            //posicoes 018 - 030 codigo cedente
            utils.IncluirCampoNumerico(transacao, titulo.Portador.CodCedente.ToString(), 13); 

            //posicoes 031 - 037 brancos
            utils.IncluirCampoAlfanumerico(transacao," ", 7);

            //posicoes 038 - 062 
            utils.IncluirCampoAlfanumerico(transacao,titulo.Id.ToString(), 25);
                        
            //posicoes 063 - 072 nosso numero
            transacao.Append("nosso numero");

            //posicoes 073 - 104 mensagem no bloqueto
            utils.IncluirCampoAlfanumerico(transacao, " ", 32);

            //posicoes 105 - 107 brancos
            utils.IncluirCampoAlfanumerico(transacao," ", 3);

            //posicoes 108 -108 tipo de carteira
            transacao.Append(titulo.Portador.Carteira != null ? titulo.Portador.Carteira : "0");
                        
            //posicoes 109 - 110 codigo de ocorrencia
            transacao.Append(remessa.CodOcorrencia);

            //posicoes 111 - 120 seu numero

            //posicoes 121 - 126 data de vencimento
            transacao.Append(titulo.DataVencimento.ToString("dd/MM/yy"));

            //posicoes 127 - 139 valor do título
            utils.IncluirCampoNumerico(transacao, titulo.Valor.ToString(), 13);

            //posicoes 140 - 142
            transacao.Append("041");

            //posicoes 123 - 147 brancos
            utils.IncluirCampoAlfanumerico(transacao, "", 5);

            //posicoes 148 - 149  tipo de documento 
            //cobrança credenciada banrisul CCB
            transacao.Append("08");

            //posicoes 150 - 150 aceite
            transacao.Append("A");

            //posicoes 151 - 156 
            transacao.Append(titulo.DataEmissao.ToString("dd/MM/yy"));

            //posicoes 157 - 158 instrucao 1 e  //posicoes 159 - 160 instrucao 2
            if (titulo.Portador.Carteira == "R" || titulo.Portador.Carteira == "S" || titulo.Portador.Carteira == "X" || titulo.Portador.Carteira =="N")
                utils.IncluirCampoAlfanumerico(transacao," ", 4);
            else
            {
                transacao.Append(remessa.Instrucao1);
                transacao.Append(remessa.Instrucao2);
            }
            
            //posicoes 161 - 161 código de mora
            if (titulo.Portador.Carteira == "R" || titulo.Portador.Carteira == "S" || titulo.Portador.Carteira == "X" || titulo.Portador.Carteira == "N")
                transacao.Append(" ");
            else
                transacao.Append(remessa.JuroMora);

            //posicoes 162 - 173 
            if (titulo.Portador.Carteira == "R" || titulo.Portador.Carteira == "S" || titulo.Portador.Carteira == "X" || titulo.Portador.Carteira == "N")
                utils.IncluirCampoAlfanumerico(transacao,string.Empty, 12);
            else
                utils.IncluirCampoNumerico(transacao, ((titulo.Valor * v_taxa_juro) / 100).ToString(), 12); 

            //posicoes 174 - 179 data de desconto
            utils.IncluirCampoNumerico(transacao, "0", 6);

            //posicoes 180 - 192 valor do desconto
            utils.IncluirCampoNumerico(transacao, "0", 13);

            //posicoes 193 - 205 valor IOF
            utils.IncluirCampoNumerico(transacao, "0", 13);

            //posicoes 206 - 218 valor do abatimento
            utils.IncluirCampoNumerico(transacao, "0", 13);

            //posicoes 219 - 220 tipo de inscrição do sacado
            //01 pessoa fisica, 02 pessoa juridica
            utils.IncluirCampoNumerico(transacao, titulo.Pessoas.Tipo == "F" ? "01" : "02", 2);

            //posicoes 221 - 234 cpf/cnfp
            utils.IncluirCampoNumerico(transacao, titulo.Pessoas.CpfCnpj, 14);

            //posicoes 235 - 269 nome do sacado
            utils.IncluirCampoAlfanumerico(transacao, titulo.Pessoas.Nome, 35);

            //posicoes 270 - 274 brancos
            utils.IncluirCampoAlfanumerico(transacao, " ", 5);

            //posicoes 275 - 314 endereco 
            utils.IncluirCampoAlfanumerico(transacao, titulo.Pessoas.Endereco,35);

            //posicoes 315 - 321 
            utils.IncluirCampoAlfanumerico(transacao," ", 7);
            
            return transacao;
        }

        public StringBuilder ArquivoRemessaMontarTrailler(StringBuilder trailler, Titulos titulo)
        {
            //posicoes 001 - 001
            trailler.Append("9");

            //posicoes 002 - 027
            utils.IncluirCampoAlfanumerico(trailler, " ", 26);

            ////posicoes 028 - 040
            //utils.IncluirZeros(trailler, titulo.Valor.ToString().Length, 13);
            //trailler.Append(titulo.Valor.ToString());

            ////posicoes 041 - 395 
            //utils.IncluirBrancos(trailler, 0, 353);

            ////posicoes 395 - 400 sequencia do registro
            //trailler.Append("000001");

            return trailler;
        }
        
    }
}
