﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using InfrastructureSqlServer.Helpers;
using FG;

namespace DataAccess
{
    public class PessoasDA : BaseDA
    {
        Utils utils = new Utils();

        #region funcoes
        private List<Pessoas> CarregarObjPessoa(SqlDataReader dr)
        {
            List<Pessoas> pessoas = new List<Pessoas>();

            while (dr.Read())
            {
                Pessoas pes = new Pessoas();
                pes.Id = utils.ComparaIntComZero(dr["ID"].ToString());
                pes.Codigo = utils.ComparaIntComZero(dr["CODIGO"].ToString());
                pes.Nome = dr["NOME"].ToString();
                pes.NomeFantasia = dr["NOMEFANTASIA"].ToString();
                pes.CpfCnpj = dr["CPFCNPJ"].ToString();
                pes.Rg = dr["RG"].ToString();
                pes.NomeMae = dr["NOMEMAE"].ToString();
                pes.NomePai = dr["NOMEPAI"].ToString();
                pes.DtNascimento = utils.ComparaDataComNull(dr["DTNASCIMENTO"].ToString());
                pes.EstadoCivil = dr["ESTADOCIVIL"].ToString();                
                pes.Endereco = dr["ENDERECO"].ToString();
                pes.Numero = dr["NUMERO"].ToString();
                pes.BairroId = Convert.ToInt32(dr["BAIRROID"].ToString());
                pes.Cep = dr["CEP"].ToString();
                pes.CidadeId = Convert.ToInt32(dr["CIDADEID"].ToString());
                pes.Complemento = dr["COMPLEMENTO"].ToString();
                pes.EnderecoProf = dr["ENDERECOPROF"].ToString();
                pes.NumeroProf = dr["NUMEROPROF"].ToString();
                pes.CepProf = dr["CEPPROF"].ToString();
                pes.CidadeProfId = utils.ComparaIntComNull(dr["CIDADEPROF"].ToString());
                pes.ComplementoProf = dr["COMPLEMENTOPROF"].ToString();
                pes.Empresa = dr["EMPRESA"].ToString();
                pes.Email = dr["EMAIL"].ToString();
                pes.Tipo = dr["TIPO"].ToString();
                pes.Obs = dr["OBS"].ToString();
                pes.CategoriaId = Convert.ToInt32(dr["CATEGORIAID"].ToString());
                pes.EnvEmail = bool.Parse(dr["ENVEMAIL"].ToString());
                pes.RefNome = dr["REFNOME"].ToString();
                pes.RefTelefone = dr["REFTELEFONE"].ToString();
                pes.RefDDD = utils.ComparaShortComNull(dr["REFDDD"].ToString());
                pes.DtCadastro = DateTime.Parse(dr["DTCADASTRO"].ToString());
                pes.Status = utils.ComparaIntComZero(dr["STATUS"].ToString());
                pes.BairroProf = utils.ComparaIntComZero(dr["BAIRROPROFID"].ToString());
                pes.Sexo = dr["SEXO"].ToString();
                pes.TipoAssociado = dr["TIPOASSOCIADO"].ToString();

                Categorias catg = new Categorias();

                catg.Id = utils.ComparaIntComZero(dr["IDCATG"].ToString());
                catg.Codigo = utils.ComparaIntComZero(dr["CODCATG"].ToString());
                catg.Descricao = dr["DESCATG"].ToString();

                pes.Categorias = catg;
                
                CidadesDA cidDA = new CidadesDA();
                Cidades cid = new Cidades();
                DataSet dsCid = cidDA.PesquisaDA(pes.CidadeId);
                               
                if (dsCid.Tables[0].Rows.Count != 0)
                {
                    cid.Id = (Int32)dsCid.Tables[0].Rows[0]["id"];
                    cid.Codigo = (Int32)dsCid.Tables[0].Rows[0]["codigo"];
                    cid.Descricao = (string)dsCid.Tables[0].Rows[0]["descricao"];
                    cid.EstadoId = (Int32)dsCid.Tables[0].Rows[0]["estadoid"];

                    EstadosDA estDA = new EstadosDA();
                    DataSet dsEst = estDA.PesquisaDA(cid.EstadoId);
                    Estados est = new Estados();

                    if (dsEst.Tables[0].Rows.Count > 0)
                    {
                        est.Id = (Int32)dsEst.Tables[0].Rows[0]["id"];
                        est.Uf = (string)dsEst.Tables[0].Rows[0]["uf"];
                        est.Descricao = (string)dsEst.Tables[0].Rows[0]["descricao"];
                    }

                    cid.Estados = est;


                }

                pes.Cidade = cid;

                BairrosDA baiDA = new BairrosDA();                
                Bairros bai = new Bairros();
                DataSet dsBai;
                                
                dsBai = baiDA.PesquisaDA(pes.BairroId);
                if (dsBai.Tables[0].Rows.Count > 0)
                {
                    bai.Id = (Int32)dsBai.Tables[0].Rows[0]["id"];
                    bai.Codigo = (Int32)dsBai.Tables[0].Rows[0]["codigo"];
                    bai.Descricao = (string)dsBai.Tables[0].Rows[0]["descricao"];
                }

                pes.Bairro = bai;
                
                if (pes.CidadeProfId != null)
                {
                    dsCid.Clear();
                    dsCid = cidDA.PesquisaDA(pes.CidadeProfId != null ? utils.ComparaIntComZero(pes.CidadeProfId.ToString()) : 0);

                    if (dsCid.Tables[0].Rows.Count != 0)
                    {
                        cid.Id = (Int32)dsCid.Tables[0].Rows[0]["id"];
                        cid.Codigo = (Int32)dsCid.Tables[0].Rows[0]["codigo"];
                        cid.Descricao = (string)dsCid.Tables[0].Rows[0]["descricao"];
                        cid.EstadoId = (Int32)dsCid.Tables[0].Rows[0]["estadoid"];
                    }

                    pes.CidadeProf = cid;
                }

                pessoas.Add(pes);
            }
            return pessoas; 
        }

        private Int32 RetornaMaxCodigo()
        {
            Int32 codigo = 1;
            DataSet ds = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                          CommandType.Text, string.Format(@" SELECT ISNULL(MAX(CODIGO),0) + 1 as COD FROM PESSOAS "));

            if (ds.Tables[0].Rows.Count != 0)
                codigo = utils.ComparaIntComZero(ds.Tables[0].Rows[0]["COD"].ToString());

            return codigo;
        }
        #endregion

        public int InserirDA(Pessoas pes)
        {
            SqlParameter[] paramsToSP = new SqlParameter[34];
                        
            paramsToSP[0] = new SqlParameter("@nome", pes.Nome);
            paramsToSP[1] = new SqlParameter("@nomefantasia", pes.NomeFantasia);
            paramsToSP[2] = new SqlParameter("@cpfcnpj", pes.CpfCnpj);
            paramsToSP[3] = new SqlParameter("@rg", pes.Rg);
            paramsToSP[4] = new SqlParameter("@nomemae", pes.NomeMae);
            paramsToSP[5] = new SqlParameter("@nomepai", pes.NomePai);
            paramsToSP[6] = new SqlParameter("@dtnascimento", pes.DtNascimento);
            paramsToSP[7] = new SqlParameter("@estadocivil", pes.EstadoCivil);          
            paramsToSP[8] = new SqlParameter("@endereco", pes.Endereco);
            paramsToSP[9] = new SqlParameter("@numero", pes.Numero);
            paramsToSP[10] = new SqlParameter("@bairroid", pes.BairroId);
            paramsToSP[11] = new SqlParameter("@cep", pes.Cep);
            paramsToSP[12] = new SqlParameter("@cidadeid", pes.CidadeId);
            paramsToSP[13] = new SqlParameter("@complemento", pes.Complemento);
            paramsToSP[14] = new SqlParameter("@enderecoprof", pes.EnderecoProf);
            paramsToSP[15] = new SqlParameter("@numeroprof", pes.NumeroProf);            
            paramsToSP[16] = new SqlParameter("@cepprof", pes.CepProf);
            paramsToSP[17] = new SqlParameter("@cidadeprof", pes.CidadeProfId);
            paramsToSP[18] = new SqlParameter("@complementoprof", pes.ComplementoProf);
            paramsToSP[19] = new SqlParameter("@empresa", pes.Empresa);
            paramsToSP[20] = new SqlParameter("@email", pes.Email);
            paramsToSP[21] = new SqlParameter("@status", pes.Status);
            paramsToSP[22] = new SqlParameter("@tipo", pes.Tipo);
            paramsToSP[23] = new SqlParameter("@obs", pes.Obs);
            paramsToSP[24] = new SqlParameter("@categoriaid", pes.CategoriaId);            
            paramsToSP[25] = new SqlParameter("@envemail", pes.EnvEmail);
            paramsToSP[26] = new SqlParameter("@dtcadastro", pes.DtCadastro);
            paramsToSP[27] = new SqlParameter("@refnome", pes.RefNome);
            paramsToSP[28] = new SqlParameter("@reftelefone", pes.RefTelefone);
            paramsToSP[29] = new SqlParameter("@refddd", pes.RefDDD);       
            paramsToSP[30] = new SqlParameter("@codigo", RetornaMaxCodigo());
            paramsToSP[31] = new SqlParameter("@bairroProfId", pes.BairroProf);
            paramsToSP[32] = new SqlParameter("@sexo", pes.Sexo);
            paramsToSP[33] = new SqlParameter("@tipoassociado", pes.TipoAssociado);

            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_insert_pessoas", paramsToSP);

                DataTable tabela = ds.Tables[0];

                int id = utils.ComparaIntComZero(tabela.Rows[0]["ID"].ToString());

                return id;
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public bool EditarDA(Pessoas pes)
        {
            SqlParameter[] paramsToSP = new SqlParameter[35];

            paramsToSP[0] = new SqlParameter("@id", pes.Id);
            paramsToSP[1] = new SqlParameter("@codigo", pes.Codigo);
            paramsToSP[2] = new SqlParameter("@nome", pes.Nome);
            paramsToSP[3] = new SqlParameter("@nomefantasia", pes.NomeFantasia);
            paramsToSP[4] = new SqlParameter("@cpfcnpj", pes.CpfCnpj);
            paramsToSP[5] = new SqlParameter("@rg", pes.Rg);
            paramsToSP[6] = new SqlParameter("@nomemae", pes.NomeMae);
            paramsToSP[7] = new SqlParameter("@nomepai", pes.NomePai);
            paramsToSP[8] = new SqlParameter("@dtnascimento", pes.DtNascimento);
            paramsToSP[9] = new SqlParameter("@estadocivil", pes.EstadoCivil);            
            paramsToSP[10] = new SqlParameter("@endereco", pes.Endereco);
            paramsToSP[11] = new SqlParameter("@numero", pes.Numero);
            paramsToSP[12] = new SqlParameter("@bairroid", pes.BairroId);
            paramsToSP[13] = new SqlParameter("@cep", pes.Cep);
            paramsToSP[14] = new SqlParameter("@cidadeid", pes.CidadeId);
            paramsToSP[15] = new SqlParameter("@complemento", pes.Complemento);
            paramsToSP[16] = new SqlParameter("@enderecoprof", pes.EnderecoProf);
            paramsToSP[17] = new SqlParameter("@numeroprof", pes.NumeroProf);           
            paramsToSP[18] = new SqlParameter("@cepprof", pes.CepProf);
            paramsToSP[19] = new SqlParameter("@cidadeprof", pes.CidadeProfId);
            paramsToSP[20] = new SqlParameter("@complementoprof", pes.ComplementoProf);
            paramsToSP[21] = new SqlParameter("@empresa", pes.Empresa);
            paramsToSP[22] = new SqlParameter("@email", pes.Email);
            paramsToSP[23] = new SqlParameter("@obs", pes.Obs);
            paramsToSP[24] = new SqlParameter("@categoriaid", pes.CategoriaId);
            paramsToSP[25] = new SqlParameter("@tipo", pes.Tipo);
            paramsToSP[26] = new SqlParameter("@envemail", pes.EnvEmail);
            paramsToSP[27] = new SqlParameter("@refnome", pes.RefNome);
            paramsToSP[28] = new SqlParameter("@refddd", pes.RefDDD);
            paramsToSP[29] = new SqlParameter("@reftelefone", pes.RefTelefone);
            paramsToSP[30] = new SqlParameter("@dtcadastro", pes.DtCadastro);
            paramsToSP[31] = new SqlParameter("@status", pes.Status);
            paramsToSP[32] = new SqlParameter("@bairroProfId", pes.BairroProf);
            paramsToSP[33] = new SqlParameter("@sexo", pes.Sexo);
            paramsToSP[34] = new SqlParameter("@tipoassociado", pes.TipoAssociado);

            try
            {
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_update_pessoas", paramsToSP);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool ExcluirDA(Pessoas pes)
        {
            SqlParameter[] paramsToSP = new SqlParameter[1];

            paramsToSP[0] = new SqlParameter("@id", pes.Id);

            try
            {
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_delete_pessoas", paramsToSP);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<Pessoas> PesquisarDA()
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, @"SELECT P.*, C.ID IDCATG, C.CODIGO CODCATG, C.DESCRICAO DESCATG  " +
                                                                                   " FROM PESSOAS P " +
                                                                                   "     ,CATEGORIAS C " +
                                                                                   " WHERE P.CATEGORIAID = C.ID ");
            List<Pessoas> pessoas = CarregarObjPessoa(dr);
                       
            return pessoas; 
        }

        public List<Pessoas> PesquisarDA(int id_pes)
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, string.Format(@"SELECT P.*, C.ID IDCATG, C.CODIGO CODCATG, C.DESCRICAO DESCATG  " +
                                                                                                 " FROM PESSOAS P " +
                                                                                                 "     ,CATEGORIAS C " +
                                                                                                 " WHERE P.CATEGORIAID = C.ID " +
                                                                                                 " AND P.ID = {0}", id_pes));


            List<Pessoas> pessoas = CarregarObjPessoa(dr);
                       
            return pessoas;
        }

        public DataSet PesquisaDA(int id_pes)
        {
            DataSet ds = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                              CommandType.Text, string.Format(@"SELECT * FROM PESSOAS WHERE ID = {0}", id_pes));

            return ds;
        }

        public List<Pessoas> PesquisarPorGeneroDA(int id_cat)
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, string.Format(@"SELECT P.*, C.ID IDCATG, C.CODIGO CODCATG, C.DESCRICAO DESCATG  " +
                                                                                                 " FROM PESSOAS P " +
                                                                                                 "     ,CATEGORIAS C " +
                                                                                                 " WHERE P.CATEGORIAID = C.ID " +
                                                                                                 " AND P.CATEGORIAID = {0}", id_cat));
            List<Pessoas> pessoas = CarregarObjPessoa(dr);

            return pessoas;
        }

        public List<Pessoas> PesquisarDA(string campo, string valor)
        {
            StringBuilder consulta = new StringBuilder();

            consulta.Append(@"SELECT P.*, C.ID IDCATG, C.CODIGO CODCATG, C.DESCRICAO DESCATG  ");
            consulta.Append(@" FROM PESSOAS P, CATEGORIAS C WHERE P.CATEGORIAID = C.ID ");

            switch (campo.ToUpper())
            {
                case "CODIGO":
                    consulta.Append(string.Format(" AND P.CODIGO = {0}", utils.ComparaIntComZero(valor)));
                    break;
                case "NOME":
                    consulta.Append(string.Format(" AND P.NOME  LIKE '%{0}%'", valor));
                    break;
                case "NOMECODIGO":
                    consulta.Append(string.Format(" AND P.NOME  LIKE '%{0}%' OR CODIGO = {1}", valor, utils.ComparaIntComZero(valor)));
                    break;
                default:                    
                    break;
            }

            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, consulta.ToString());

            List<Pessoas> pessoas = CarregarObjPessoa(dr);

            return pessoas;
        }

        public List<Pessoas> PesquisarBuscaDA(string valor)
        {
            StringBuilder consulta = new StringBuilder();
            consulta.Append(@"SELECT P.*, C.ID IDCATG, C.CODIGO CODCATG, C.DESCRICAO DESCATG  ");
            consulta.Append(@" FROM PESSOAS P, CATEGORIAS C WHERE P.CATEGORIAID = C.ID ");

            if (valor != "" && valor != null)
                consulta.Append(string.Format(" AND P.CODIGO = {0} OR  P.NOME  LIKE '%{1}%'", utils.ComparaIntComZero(valor), valor));

            consulta.Append(" ORDER BY P.CODIGO ");

            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, consulta.ToString());

            List<Pessoas> pessoas = CarregarObjPessoa(dr);

            return pessoas;
        }

        public override List<Base> Pesquisar(string descricao)
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                      CommandType.Text, string.Format(@"SELECT * " +
                                                                                       " FROM PESSOAS WHERE CODIGO = '{0}' OR NOME LIKE '%{1}%'", utils.ComparaIntComZero(descricao), descricao));
            
            List<Base> ba = new List<Base>();

            while (dr.Read())
            {
                Base bas = new Base();
                bas.PesId1 = int.Parse(dr["ID"].ToString());
                bas.PesCodigo = dr["CODIGO"].ToString();
                bas.PesDescricao = dr["NOME"].ToString();

                ba.Add(bas);
            }
            return ba;
        }    
    }
}
