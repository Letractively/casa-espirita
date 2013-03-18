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
                tit.Id = int.Parse(dr["ID"].ToString());
                tit.Numero = int.Parse(dr["NUMERO"].ToString());
                tit.Parcela = int.Parse(dr["PARCELA"].ToString());
                tit.Valor = int.Parse(dr["VALOR"].ToString());
                tit.Pessoaid = utils.ComparaIntComNull(dr["PESSOAID"].ToString());
                tit.Portadorid = utils.ComparaIntComNull(dr["PORTADORID"].ToString());
                tit.DataVencimento = DateTime.Parse(dr["DATAVENCIMENTO"].ToString());
                tit.DataEmissao = DateTime.Parse(dr["DATAEMISSAO"].ToString());
                tit.TipoDocumentoId = utils.ComparaIntComNull(dr["TIPODOCUMENTOID"].ToString());
                tit.Tipo = dr["TIPO"].ToString();

                int id = 0;
                if (tit.Pessoaid != null)
                {
                    id = Convert.ToInt32(tit.Pessoaid);
                    List<Pessoas> pessoas = pesDA.PesquisarDA();
                    Pessoas pes = new Pessoas();

                    foreach (Pessoas ltPes in pessoas)
                    {
                        pes.Nome = ltPes.Nome;
                        pes.CpfCnpj = ltPes.CpfCnpj;
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

                
                Titulos.Add(tit);
            }
            return titulos;
        }
        #endregion

        public bool InserirDA(Titulos tit)
        {
            SqlParameter[] paramsToSP = new SqlParameter[9];

            paramsToSP[0] = new SqlParameter("@numero", tit.Numero);
            paramsToSP[1] = new SqlParameter("@parcela", tit.Parcela);
            paramsToSP[2] = new SqlParameter("@valor", tit.Valor);
            paramsToSP[3] = new SqlParameter("@pessoaid", tit.Pessoaid);
            paramsToSP[4] = new SqlParameter("@portadorid", tit.Portadorid);
            paramsToSP[5] = new SqlParameter("@datavencimento", tit.DataVencimento);
            paramsToSP[6] = new SqlParameter("@dataemissao", tit.DataEmissao);
            paramsToSP[7] = new SqlParameter("@tipodocumentoid", tit.TipoDocumentoId);
            paramsToSP[8] = new SqlParameter("@tipo", tit.Tipo);

            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_insert_titulos", paramsToSP);

            return true;
        }

        public bool EditarDA(Titulos tit)
        {
            SqlParameter[] paramsToSP = new SqlParameter[10];

            paramsToSP[0] = new SqlParameter("@id", tit.Id);
            paramsToSP[1] = new SqlParameter("@numero", tit.Numero);
            paramsToSP[2] = new SqlParameter("@parcela", tit.Parcela);
            paramsToSP[3] = new SqlParameter("@valor", tit.Valor);
            paramsToSP[4] = new SqlParameter("@pessoaid", tit.Pessoaid);
            paramsToSP[5] = new SqlParameter("@portadorid", tit.Portadorid);
            paramsToSP[6] = new SqlParameter("@datavencimento", tit.DataVencimento);
            paramsToSP[7] = new SqlParameter("@dataemissao", tit.DataEmissao);
            paramsToSP[8] = new SqlParameter("@tipodocumentoid", tit.TipoDocumentoId);
            paramsToSP[9] = new SqlParameter("@tipo", tit.Tipo);

            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_update_titulos", paramsToSP);

            return true;
        }

        public bool ExcluirDA(Titulos tit)
        {
            SqlParameter[] paramsToSP = new SqlParameter[1];

            paramsToSP[0] = new SqlParameter("@id", tit.Id);

            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_delete_titulos", paramsToSP);

            return true;
        }

        public List<Titulos> PesquisarDA()
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, string.Format(@"SELECT * FROM TITULOS ORDER BY CODIGO "));

            List<Titulos> titulos = CarregarObjTitulos(dr);

            return titulos;

        }

        public List<Titulos> PesquisarDA(int id_tit)
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                       CommandType.Text, string.Format(@"SELECT * " +
                                                                                       " FROM TITULOS WHERE ID = {0}", id_tit));

            List<Titulos> titulos = CarregarObjTitulos(dr);

            return titulos;
        }

        public List<Titulos> PesquisarDA(string campo, string valor)
        {
            string consulta;

            switch (campo.ToUpper())
            {
                case "CODIGO":
                    consulta = string.Format("SELECT * FROM TITULOS WHERE CODIGO = {0}", utils.ComparaIntComZero(valor));
                    break;
                case "DESCRICAO":
                    consulta = string.Format("SELECT * FROM TITULOS WHERE DESCRICAO  LIKE '%{0}%'", valor);
                    break;
                default:
                    consulta = "";
                    break;
            }

            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, consulta);

            List<Titulos> titulos = CarregarObjTitulos(dr);

            return titulos;
        }

        public override List<Base> Pesquisar(string descricao, string tipo)
        {
            SqlDataReader dr;

            if (tipo == "C")
            {
                int codigo = 0;
                Int32.TryParse(descricao, out codigo);

                dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                       CommandType.Text, string.Format(@"SELECT * " +
                                                                                       " FROM  WHERE CODIGO = '{0}'", codigo));
            }
            else
            {
                dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                      CommandType.Text, string.Format(@"SELECT * " +
                                                                                       " FROM TITULOS WHERE DESCRICAO LIKE '%{0}%'", descricao));
            }

            List<Base> ba = new List<Base>();

            while (dr.Read())
            {
                Base bas = new Base();
                bas.PesId1 = int.Parse(dr["ID"].ToString());
                bas.PesCodigo = dr["CODIGO"].ToString();
                bas.PesDescricao = dr["DESCRICAO"].ToString();

                ba.Add(bas);
            }
            return ba;
        }
    }
}