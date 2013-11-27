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

        public StringBuilder ArquivoRemessaMontarHeader(StringBuilder header, Portadores portador, string seq)
        {
            InstituicoesBL instBL = new InstituicoesBL();
            DataSet dsInst = instBL.PesquisarDsBL();
            
            //posicoes 001 - 009 
            header.Append("01REMESSA"); 

            //posicoes 010 - 026 brancos
            utils.IncluirCampoAlfanumerico(header, " ", 17);

            //posicoes 027 - 039     
            utils.IncluirCampoNumerico(header, portador.CodCedente.ToString(), 13);
            
            //posicoes 040 - 046 brancos
            utils.IncluirCampoAlfanumerico(header, " ", 7);

            if (dsInst.Tables[0].Rows.Count != 0)
            {
                //posicoes 047 - 076 nome da empresa
                utils.IncluirCampoAlfanumerico(header,utils.RemoveAcentos(dsInst.Tables[0].Rows[0]["razao"].ToString()), 30);                
            }
            
            //posicoes 077 - 087 
            header.Append("041BANRISUL");

            //posicoes 088 - 094 brancos
            utils.IncluirCampoAlfanumerico(header, " ", 7);

            //posicoes 095 - 100 
            header.Append(DateTime.Now.ToString("ddMMyy"));

            //posicoes 101 - 109 brancos
            utils.IncluirCampoAlfanumerico(header, " ", 9);

            //posicoes 110 - 113
            if (portador.Carteira == "R" || portador.Carteira == "S" || portador.Carteira == "X")
            {
                header.Append("0808");
                //posicoes 114 - 114 branco
                utils.IncluirCampoAlfanumerico(header, " ", 1);

                // posicoes 115 - 115
                header.Append("P");

                //posicoes 116 - 116
                utils.IncluirCampoAlfanumerico(header, " ", 1);

                //posicoes 117 - 126
                utils.IncluirCampoAlfanumerico(header, portador.CodEmpBanriMicro, 10);
               
            }
            else
            {
                //posicoes 110 - 113 e 114 ao 126
                utils.IncluirCampoAlfanumerico(header, " ", 17); 
            }                    

            //posicoes 127 - 394 brancos
            utils.IncluirCampoAlfanumerico(header, " ", 268);

            //posicoes 395 - 400
            utils.IncluirCampoNumerico(header, seq, 6);

            return header;
        }

        public StringBuilder ArquivoRemessaMontarTransacao(StringBuilder transacao, Titulos titulo, Remessa remessa, string seq, string codCedente)
        {
            decimal v_taxa_juro = 0;

            //posicoes 001 - 001
            transacao.Append("1");

            //posicoes 002 - 017
            utils.IncluirCampoAlfanumerico(transacao, " ", 16);

            //posicoes 018 - 030 codigo cedente
            utils.IncluirCampoNumerico(transacao, codCedente, 13); 

            //posicoes 031 - 037 brancos
            utils.IncluirCampoAlfanumerico(transacao," ", 7);

            //posicoes 038 - 062 
            utils.IncluirCampoAlfanumerico(transacao,titulo.Id.ToString(), 25);
                        
            //posicoes 063 - 072 nosso numero
            transacao.Append("0000000000");

            //posicoes 073 - 104 mensagem no bloqueto
            utils.IncluirCampoAlfanumerico(transacao, " ", 32);

            //posicoes 105 - 107 brancos
            utils.IncluirCampoAlfanumerico(transacao," ", 3);

            //posicoes 108 -108 tipo de carteira
            transacao.Append(titulo.Portador.Carteira != null ? titulo.Portador.Carteira : "0");

            //posicoes 109 - 110 codigo de ocorrencia
            transacao.Append(remessa.CodOcorrencia);

            //posicoes 111 - 120 seu numero
            utils.IncluirCampoAlfanumerico(transacao, titulo.Numero.ToString(), 10);

            //posicoes 121 - 126 data de vencimento
            transacao.Append(titulo.DataVencimento.ToString("ddMMyy"));

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
            transacao.Append(titulo.DataEmissao.ToString("ddMMyy"));

            //posicoes 157 - 158 instrucao 1 e  //posicoes 159 - 160 instrucao 2
            if (titulo.Portador.Carteira == "R" || titulo.Portador.Carteira == "S" || titulo.Portador.Carteira == "X" || titulo.Portador.Carteira == "N")
                utils.IncluirCampoAlfanumerico(transacao, " ", 4);
            else
            {
                utils.IncluirCampoNumerico(transacao, remessa.Instrucao1, 2);
                utils.IncluirCampoNumerico(transacao, remessa.Instrucao2, 2);
            }

            //posicoes 161 - 161 código de mora
            if (titulo.Portador.Carteira == "R" || titulo.Portador.Carteira == "S" || titulo.Portador.Carteira == "X" || titulo.Portador.Carteira == "N")
                transacao.Append(" ");
            else
                utils.IncluirCampoNumerico(transacao, remessa.JuroMora, 1);

            //posicoes 162 - 173 
            if (titulo.Portador.Carteira == "R" || titulo.Portador.Carteira == "S" || titulo.Portador.Carteira == "X" || titulo.Portador.Carteira == "N")
                utils.IncluirCampoAlfanumerico(transacao, string.Empty, 12);
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
            utils.IncluirCampoAlfanumerico(transacao, titulo.Pessoas.Endereco, 40);

            //posicoes 315 - 321 
            utils.IncluirCampoAlfanumerico(transacao, " ", 7);

            //posicoes 322 - 324 taxa para multa.
            utils.IncluirCampoNumerico(transacao, "0", 3);

            //posicoes 325 - 326 n° dias para multa apos vencimento
            utils.IncluirCampoNumerico(transacao, "0", 2);

            //posicoes 327 - 334 cep 
            utils.IncluirCampoNumerico(transacao, titulo.Pessoas.Cep, 8);

            //posicoes 335 - 349 cidade
            utils.IncluirCampoAlfanumerico(transacao, titulo.Pessoas.Cidade.Descricao, 15);

            //posicoes 350 - 351 UF
            utils.IncluirCampoAlfanumerico(transacao, titulo.Pessoas.Cidade.Estados.Descricao, 2);

            //posices 352 - 355 taxa para pagamento antecipado
            utils.IncluirCampoNumerico(transacao, "0", 3);

            //posicoes 356 - 356 brancos
            utils.IncluirCampoAlfanumerico(transacao, "", 1);

            //posicoes 357 - 369 valor para calculo desconto
            utils.IncluirCampoNumerico(transacao, "0", 12);

            //posicoes 370 - 371 n° dias para protesto ou devolução
            if (titulo.Portador.Carteira == "R" || titulo.Portador.Carteira == "S" || titulo.Portador.Carteira == "X" || titulo.Portador.Carteira == "N")
                utils.IncluirCampoAlfanumerico(transacao, " ", 2);
            else
            {
                if (remessa.Instrucao1 == "09" || remessa.Instrucao1 == "15")
                    utils.IncluirCampoNumerico(transacao, remessa.DiasProtesto, 2);
                else if (remessa.Instrucao2 == "09" || remessa.Instrucao2 == "15")
                    utils.IncluirCampoNumerico(transacao, remessa.DiasProtesto, 2);
                else
                    utils.IncluirCampoNumerico(transacao, "0", 2);

            }

            //posicoes 372 - 394 brancos
            utils.IncluirCampoAlfanumerico(transacao, " ", 13);

            //posicoes 395 - 400 sequencial
            utils.IncluirCampoNumerico(transacao, seq, 6);
            
            return transacao;
        }

        public StringBuilder ArquivoRemessaMontarTrailler(StringBuilder trailler, string valor, string seq)
        {
            //posicoes 001 - 001
            trailler.Append("9");

            //posicoes 002 - 027
            utils.IncluirCampoAlfanumerico(trailler, " ", 26);

            //posicoes 028 - 040
            utils.IncluirCampoNumerico(trailler, valor, 13); 

            //posicoes 041 - 395 
            utils.IncluirCampoAlfanumerico(trailler, " ", 354);

            //posicoes 395 - 400 sequencia do registro
            utils.IncluirCampoNumerico(trailler, seq, 6);

            return trailler;
        }

        public List<Titulos> PesquisarBuscaBL(SelecaoTitulos selTitulos)
        {
            TitulosDA titulosDA = new TitulosDA();

            return titulosDA.PesquisarBuscaDA(selTitulos);
        }

        public bool CodigoJaUtilizadoBL(Int32 codigo, string tipo )
        {
            TitulosDA exeDA = new TitulosDA();

            return exeDA.CodigoJaUtilizadoDA(codigo, tipo);
        }
    }
}
