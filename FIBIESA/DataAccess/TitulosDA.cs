using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using System.Data;
using System.Data.SqlClient;
using InfrastructureSqlServer.Helpers;
using System.Configuration;
using FG;

namespace DataAccess
{
    public class TitulosDA : BaseDA
    {
        Utils utils = new Utils();

        #region funcoes

       private List<Titulos> CarregarObjTitulos(SqlDataReader dr)
        {
            List<Titulos> titulos = new List<Titulos>();
            PessoasDA pesDA = new PessoasDA();
            PortadoresDA porDA = new PortadoresDA();
            TiposDocumentosDA tipDA = new TiposDocumentosDA();
            
            while (dr.Read())
            {
                Titulos tit = new Titulos();
                tit.Id = utils.ComparaIntComZero(dr["ID"].ToString());
                tit.Numero = utils.ComparaIntComZero(dr["NUMERO"].ToString());
                tit.Parcela = utils.ComparaIntComZero(dr["PARCELA"].ToString());
                tit.Valor = utils.ComparaDecimalComZero(dr["VALOR"].ToString());
                tit.Pessoaid = utils.ComparaIntComNull(dr["PESSOAID"].ToString());
                tit.Portadorid = utils.ComparaIntComNull(dr["PORTADORID"].ToString());
                tit.DataVencimento = DateTime.Parse(dr["DTVENCIMENTO"].ToString());
                tit.DataEmissao = DateTime.Parse(dr["DTEMISSAO"].ToString());
                tit.TipoDocumentoId = utils.ComparaIntComNull(dr["TIPODOCUMENTOID"].ToString());
                tit.Tipo = dr["TIPO"].ToString();
                tit.DtPagamento = utils.ComparaDataComNull(dr["dtPagamento"].ToString());
                tit.ValorPago = utils.ComparaDecimalComZero(dr["valorpago"].ToString()); 
                tit.Obs = dr["obs"].ToString();

                int id = 0;

                if (tit.Pessoaid != null)
                {
                    id = Convert.ToInt32(tit.Pessoaid);
                    List<Pessoas> pessoas = pesDA.PesquisarDA(id);
                    Pessoas pes = new Pessoas();
                    
                    foreach (Pessoas ltPes in pessoas)
                    {
                        pes.Id = ltPes.Id;
                        pes.Codigo = ltPes.Codigo;
                        pes.Nome = ltPes.Nome;
                        pes.CpfCnpj = ltPes.CpfCnpj;
                        pes.Endereco = ltPes.Endereco;
                    }

                    tit.Pessoas = pes;
                }


                if (tit.Portadorid != null)
                {
                    id = Convert.ToInt32(tit.Portadorid);
                    List<Portadores> portadores = porDA.PesquisarDA(id);
                    Portadores por = new Portadores();

                    foreach (Portadores ltPor in portadores)
                    {
                        por.Id = ltPor.Id;
                        por.Codigo = ltPor.Codigo;
                        por.Descricao = ltPor.Descricao;
                    }

                    tit.Portador = por;
                }

                if (tit.TipoDocumentoId > 0)
                {
                    id = Convert.ToInt32(tit.TipoDocumentoId);
                    List<TiposDocumentos> tiposdocumentos = tipDA.PesquisarDA(id);
                    TiposDocumentos tip = new TiposDocumentos();
                    foreach (TiposDocumentos ltTip in tiposdocumentos)
                    {
                        tip.Codigo = ltTip.Codigo;
                        tip.Descricao = ltTip.Descricao;
                    }

                    tit.TiposDocumentos = tip;
                }
                titulos.Add(tit);    
            }
            return titulos;
        }
        #endregion

        public bool InserirDA(Titulos tit)
        {
            SqlParameter[] paramsToSP = new SqlParameter[12];
            paramsToSP[0] = new SqlParameter("@numero", tit.Numero);
            paramsToSP[1] = new SqlParameter("@parcela", tit.Parcela);
            paramsToSP[2] = new SqlParameter("@valor", tit.Valor);
            paramsToSP[3] = new SqlParameter("@pessoaid", tit.Pessoaid);
            paramsToSP[4] = new SqlParameter("@portadorid", tit.Portadorid);
            paramsToSP[5] = new SqlParameter("@dtvencimento", tit.DataVencimento);
            paramsToSP[6] = new SqlParameter("@dtemissao", tit.DataEmissao);
            paramsToSP[7] = new SqlParameter("@tipodocumentoid", tit.TipoDocumentoId);
            paramsToSP[8] = new SqlParameter("@tipo", tit.Tipo);
            paramsToSP[9] = new SqlParameter("@dtPagamento", tit.DtPagamento);
            paramsToSP[10] = new SqlParameter("@valorPago", tit.ValorPago);
            paramsToSP[11] = new SqlParameter("@obs", tit.Obs);
            
            try
            {
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_insert_titulos", paramsToSP);
                
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool EditarDA(Titulos tit)
        {
            SqlParameter[] paramsToSP = new SqlParameter[13];
            paramsToSP[0] = new SqlParameter("@id", tit.Id);
            paramsToSP[1] = new SqlParameter("@numero", tit.Numero);
            paramsToSP[2] = new SqlParameter("@parcela", tit.Parcela);
            paramsToSP[3] = new SqlParameter("@valor", tit.Valor);
            paramsToSP[4] = new SqlParameter("@pessoaid", tit.Pessoaid);
            paramsToSP[5] = new SqlParameter("@portadorid", tit.Portadorid);
            paramsToSP[6] = new SqlParameter("@dtvencimento", tit.DataVencimento);
            paramsToSP[7] = new SqlParameter("@dtemissao", tit.DataEmissao);
            paramsToSP[8] = new SqlParameter("@tipodocumentoid", tit.TipoDocumentoId);
            paramsToSP[9] = new SqlParameter("@tipo", tit.Tipo);
            paramsToSP[10] = new SqlParameter("@dtPagamento", tit.DtPagamento);
            paramsToSP[11] = new SqlParameter("@valorPago", tit.ValorPago);
            paramsToSP[12] = new SqlParameter("@obs", tit.Obs);
          
            try
            {
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_update_titulos", paramsToSP);
                
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public bool ExcluirDA(Titulos tit)
        {
            SqlParameter[] paramsToSP = new SqlParameter[1];
            paramsToSP[0] = new SqlParameter("@id", tit.Id);

            try
            {
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_delete_titulos", paramsToSP);
                
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<Titulos> PesquisarDA()
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                            CommandType.Text, string.Format(@"SELECT * FROM TITULOS ORDER BY NUMERO "));
            List<Titulos> titulos = CarregarObjTitulos(dr);
            return titulos;
        }

        public List<Titulos> PesquisarDA(int id_tit)
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                            CommandType.Text, string.Format(@"SELECT * " +" FROM TITULOS WHERE ID = {0}", id_tit));
            List<Titulos> titulos = CarregarObjTitulos(dr);
            return titulos;
        }

        public List<Titulos> PesquisarBuscaDA(string tipo, string valor)
        {
            StringBuilder consulta = new StringBuilder(@"SELECT * FROM TITULOS WHERE 1 = 1 ");

            if (tipo != "" && tipo != null)
                consulta.Append(string.Format(" AND TIPO = '{0}'", tipo));

            if (valor != "" && valor != null)
                consulta.Append(string.Format(" AND NUMERO = {0}", utils.ComparaIntComZero(valor)));

            consulta.Append(" ORDER BY NUMERO ");

            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, consulta.ToString());

            List<Titulos> titulos = CarregarObjTitulos(dr);

            return titulos;
        }

        public override List<Base> Pesquisar(string obs)
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                      CommandType.Text, string.Format(@"SELECT * " +
                                                                                       " FROM TITULOS WHERE NUMERO = '{0}' OR  OBS LIKE '%{1}%'", utils.ComparaIntComZero(obs), obs));


            List<Base> ba = new List<Base>();

            while (dr.Read())
            {
                Titulos tit = new Titulos();
                tit.Id = int.Parse(dr["ID"].ToString());
                tit.Numero = int.Parse(dr["NUMERO"].ToString());
                tit.Obs = dr["OBS"].ToString();

                ba.Add(tit);
            }
            return ba;
        }

        public List<Titulos> PesquisarBuscaDA(string valor)
        {
            StringBuilder consulta = new StringBuilder(@"SELECT * FROM TITULOS ");

            if (valor != "" && valor != null)
                consulta.Append(string.Format(" WHERE NUMERO = {0} OR  OBS  LIKE '%{1}%'", utils.ComparaIntComZero(valor), valor));

            consulta.Append(" ORDER BY NUMERO ");

            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, consulta.ToString());

            List<Titulos> titulos = CarregarObjTitulos(dr);

            return titulos;
        }

        public DataSet PesquisarBuscaDataSetDA(string codTitulos, string codAssociados, string codPotadores, string tipoTitulo, string tipoDocumento, Boolean blAtrasados, string DataEmissaoIni, string DataEmissaoFim, string DataVencimentoIni, string DataVencimentoFim, string DataPagamentoIni, string DataPagamentoFim)
        {
            string consulta = "SELECT * FROM VIEW_TITULOS " +
                              " WHERE 1 = 1  ";

            if (tipoTitulo != string.Empty)
                consulta += " AND APLICACAO = '" + tipoTitulo + "' ";

            if (codAssociados != string.Empty)
                consulta += " AND CODIGOPESSOA IN (" + codAssociados + ")";

            if (codPotadores != string.Empty)
                consulta += " AND CODIGOPORTADOR IN (" + codPotadores + ")";

            if (codTitulos != string.Empty)
                consulta += " AND numero IN (" + codTitulos + ")";

            if (tipoDocumento != string.Empty)
                consulta += " AND tipoDocumentoId = " + tipoDocumento;

            if (blAtrasados)
                consulta += " AND (CONVERT(DATETIME,dtVencimento,103) < CONVERT(DATETIME,GETDATE(),103) AND dtPagamento IS NULL) ";

            if ((DataEmissaoIni != string.Empty) && (DataEmissaoFim != string.Empty))
            {                
                consulta += " AND DTEMISSAO BETWEEN CONVERT(DATETIME,'" + DataEmissaoIni + "',103) AND CONVERT(DATETIME,'" + DataEmissaoFim + "',103)";
            }

            if ((DataVencimentoIni != string.Empty) && (DataVencimentoFim != string.Empty))
            {

                consulta += " AND DTVENCIMENTO BETWEEN CONVERT(DATETIME,'" + DataVencimentoIni + "',103) AND CONVERT(DATETIME,'" + DataVencimentoFim + "',103)";
            }

            if ((DataPagamentoIni != string.Empty) && (DataPagamentoFim != string.Empty))
            {               
                consulta += " AND DTPAGAMENTO BETWEEN CONVERT(DATETIME,'" + DataPagamentoIni + "',103) AND CONVERT(DATETIME,'" + DataPagamentoFim + "',103)";
            }
            DataSet ds = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, consulta);


            return ds;
        }
        

    }
}