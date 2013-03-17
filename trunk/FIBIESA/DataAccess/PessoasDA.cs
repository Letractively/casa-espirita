using System;
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
                pes.Naturalidade = utils.ComparaIntComNull(dr["NATURALIDADE"].ToString());
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
                pes.RefTelefone = utils.ComparaShortComNull(dr["REFTELEFONE"].ToString());
                pes.RefDDD = utils.ComparaShortComNull(dr["REFDDD"].ToString());
                pes.DtCadastro = DateTime.Parse(dr["DTCADASTRO"].ToString());
                pes.Status = utils.ComparaIntComZero(dr["STATUS"].ToString());

                if (pes.CidadeId != null)
                {
                    CidadesDA cidDA = new CidadesDA();
                    Cidades cid = new Cidades();
                    DataSet dsCid = cidDA.PesquisaDA(pes.CidadeId != null ? utils.ComparaIntComZero(pes.CidadeId.ToString()) : 0);

                    if (dsCid.Tables[0].Rows.Count != 0)
                    {
                        cid.Id = (Int32)dsCid.Tables[0].Rows[0]["id"];
                        cid.Codigo = (Int32)dsCid.Tables[0].Rows[0]["codigo"];
                        cid.Descricao = (string)dsCid.Tables[0].Rows[0]["descricao"];
                        cid.EstadoId = (Int32)dsCid.Tables[0].Rows[0]["estadoid"];
                    }

                    pes.Cidade = cid;
                }

                pessoas.Add(pes);
            }
            return pessoas; 
        }
        #endregion

        public int InserirDA(Pessoas pes)
        {
            SqlParameter[] paramsToSP = new SqlParameter[32];
                        
            paramsToSP[0] = new SqlParameter("@nome", pes.Nome);
            paramsToSP[1] = new SqlParameter("@nomefantasia", pes.NomeFantasia);
            paramsToSP[2] = new SqlParameter("@cpfcnpj", pes.CpfCnpj);
            paramsToSP[3] = new SqlParameter("@rg", pes.Rg);
            paramsToSP[4] = new SqlParameter("@nomemae", pes.NomeMae);
            paramsToSP[5] = new SqlParameter("@nomepai", pes.NomePai);
            paramsToSP[6] = new SqlParameter("@dtnascimento", pes.DtNascimento);
            paramsToSP[7] = new SqlParameter("@estadocivil", pes.EstadoCivil);
            paramsToSP[8] = new SqlParameter("@naturalidade", pes.Naturalidade);
            paramsToSP[9] = new SqlParameter("@endereco", pes.Endereco);
            paramsToSP[10] = new SqlParameter("@numero", pes.Numero);
            paramsToSP[11] = new SqlParameter("@bairroid", pes.BairroId);
            paramsToSP[12] = new SqlParameter("@cep", pes.Cep);
            paramsToSP[13] = new SqlParameter("@cidadeid", pes.CidadeId);
            paramsToSP[14] = new SqlParameter("@complemento", pes.Complemento);
            paramsToSP[15] = new SqlParameter("@enderecoprof", pes.EnderecoProf);
            paramsToSP[16] = new SqlParameter("@numeroprof", pes.NumeroProf);            
            paramsToSP[17] = new SqlParameter("@cepprof", pes.CepProf);
            paramsToSP[18] = new SqlParameter("@cidadeprof", pes.CidadeProfId);
            paramsToSP[19] = new SqlParameter("@complementoprof", pes.ComplementoProf);
            paramsToSP[20] = new SqlParameter("@empresa", pes.Empresa);
            paramsToSP[21] = new SqlParameter("@email", pes.Email);
            paramsToSP[22] = new SqlParameter("@status", pes.Status);
            paramsToSP[23] = new SqlParameter("@tipo", pes.Tipo);
            paramsToSP[24] = new SqlParameter("@obs", pes.Obs);
            paramsToSP[25] = new SqlParameter("@categoriaid", pes.CategoriaId);            
            paramsToSP[26] = new SqlParameter("@envemail", pes.EnvEmail);
            paramsToSP[27] = new SqlParameter("@dtcadastro", pes.DtCadastro);
            paramsToSP[28] = new SqlParameter("@refnome", pes.RefNome);
            paramsToSP[29] = new SqlParameter("@reftelefone", pes.RefTelefone);
            paramsToSP[30] = new SqlParameter("@refddd", pes.RefDDD);       
            paramsToSP[31] = new SqlParameter("@codigo", pes.Codigo);
            //paramsToSP[17] = new SqlParameter("@bairroprof", pes.BairroProf);
                        
            DataSet ds = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_insert_pessoas", paramsToSP);

            DataTable tabela = ds.Tables[0];

            int id = utils.ComparaIntComZero(tabela.Rows[0]["ID"].ToString());
            
            return id;
        }

        public bool EditarDA(Pessoas pes)
        {
            SqlParameter[] paramsToSP = new SqlParameter[33];

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
            paramsToSP[10] = new SqlParameter("@naturalidade", pes.Naturalidade);
            paramsToSP[11] = new SqlParameter("@endereco", pes.Endereco);
            paramsToSP[12] = new SqlParameter("@numero", pes.Numero);
            paramsToSP[13] = new SqlParameter("@bairroid", pes.BairroId);
            paramsToSP[14] = new SqlParameter("@cep", pes.Cep);
            paramsToSP[15] = new SqlParameter("@cidadeid", pes.CidadeId);
            paramsToSP[16] = new SqlParameter("@complemento", pes.Complemento);
            paramsToSP[17] = new SqlParameter("@enderecoprof", pes.EnderecoProf);
            paramsToSP[18] = new SqlParameter("@numeroprof", pes.NumeroProf);           
            paramsToSP[19] = new SqlParameter("@cepprof", pes.CepProf);
            paramsToSP[20] = new SqlParameter("@cidadeprof", pes.CidadeProfId);
            paramsToSP[21] = new SqlParameter("@complementoprof", pes.ComplementoProf);
            paramsToSP[22] = new SqlParameter("@empresa", pes.Empresa);
            paramsToSP[23] = new SqlParameter("@email", pes.Email);
            paramsToSP[24] = new SqlParameter("@obs", pes.Obs);
            paramsToSP[25] = new SqlParameter("@categoriaid", pes.CategoriaId);
            paramsToSP[26] = new SqlParameter("@tipo", pes.Tipo);
            paramsToSP[27] = new SqlParameter("@envemail", pes.EnvEmail);
            paramsToSP[28] = new SqlParameter("@refnome", pes.RefNome);
            paramsToSP[29] = new SqlParameter("@refddd", pes.RefDDD);
            paramsToSP[30] = new SqlParameter("@reftelefone", pes.RefTelefone);
            paramsToSP[31] = new SqlParameter("@dtcadastro", pes.DtCadastro);
            paramsToSP[32] = new SqlParameter("@status", pes.Status);
            //paramsToSP[19] = new SqlParameter("@bairroprof", pes.BairroProf);

            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_update_pessoas", paramsToSP);

            return true;
        }

        public bool ExcluirDA(Pessoas pes)
        {
            SqlParameter[] paramsToSP = new SqlParameter[1];

            paramsToSP[0] = new SqlParameter("@id", pes.Id);

            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_delete_pessoas", paramsToSP);

            return true;
        }

        public List<Pessoas> PesquisarDA()
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, @"SELECT * FROM PESSOAS ");
            List<Pessoas> pessoas = CarregarObjPessoa(dr);
                       
            return pessoas; 
        }

        public List<Pessoas> PesquisarDA(int id_pes)
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, string.Format(@"SELECT * FROM PESSOAS WHERE ID = {0}",id_pes));
            List<Pessoas> pessoas = CarregarObjPessoa(dr);
                       
            return pessoas;
        }

        public List<Pessoas> PesquisarPorGeneroDA(int id_cat)
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, string.Format(@"SELECT * FROM PESSOAS WHERE CATEGORIAID = {0}", id_cat));
            List<Pessoas> pessoas = CarregarObjPessoa(dr);

            return pessoas;
        }

        public List<Pessoas> PesquisarDA(string campo, string valor)
        {
            string consulta;

            switch (campo.ToUpper())
            {
                case "CODIGO":
                    consulta = string.Format("SELECT * FROM PESSOAS WHERE CODIGO = {0}", utils.ComparaIntComZero(valor));
                    break;
                case "NOME":
                    consulta = string.Format("SELECT * FROM PESSOAS WHERE NOME  LIKE '%{0}%'", valor);
                    break;
                default:
                    consulta = "";
                    break;
            }

            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, consulta);

            List<Pessoas> pessoas = CarregarObjPessoa(dr);

            return pessoas;
        }

        public override List<Base> Pesquisar(string descricao, string tipo)
        {
            SqlDataReader dr;

            if (tipo == "C")
            {
                int codigo = 0;
                Int32.TryParse(descricao,out codigo);

                dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                       CommandType.Text, string.Format(@"SELECT * " +
                                                                                       " FROM PESSOAS WHERE CODIGO = '{0}'", codigo));
            }
            else
            {
                dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                      CommandType.Text, string.Format(@"SELECT * " +
                                                                                       " FROM PESSOAS WHERE NOME LIKE '%{0}%'", descricao));
            }

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
