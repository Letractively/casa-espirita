using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using InfrastructureSqlServer.Helpers;

namespace DataAccess
{
    public class PessoasDA
    {
        public bool InserirDA(Pessoas pes)
        {
            SqlParameter[] paramsToSP = new SqlParameter[32];

            paramsToSP[0] = new SqlParameter("@codigo", pes.Codigo);
            paramsToSP[1] = new SqlParameter("@nome", pes.Nome);
            paramsToSP[2] = new SqlParameter("@nomefantasia", pes.NomeFantasia);
            paramsToSP[3] = new SqlParameter("@cpfcnpj", pes.CpfCnpj);
            paramsToSP[4] = new SqlParameter("@rg", pes.Rg);
            paramsToSP[5] = new SqlParameter("@nomemae", pes.NomeMae);
            paramsToSP[6] = new SqlParameter("@nomepai", pes.NomePai);
            paramsToSP[7] = new SqlParameter("@dtnascimento", pes.DtNascimento);
            paramsToSP[8] = new SqlParameter("@estadocivil", pes.EstadoCivil);
            paramsToSP[9] = new SqlParameter("@naturalidade", pes.Naturalidade);
            paramsToSP[10] = new SqlParameter("@endereco", pes.Endereco);
            paramsToSP[11] = new SqlParameter("@numero", pes.Numero);
            paramsToSP[12] = new SqlParameter("@bairroid", pes.BairroId);
            paramsToSP[13] = new SqlParameter("@cep", pes.Cep);
            paramsToSP[14] = new SqlParameter("@cidadeid", pes.CidadeId);
            paramsToSP[15] = new SqlParameter("@complemento", pes.Complemento);
            paramsToSP[16] = new SqlParameter("@enderecoprof", pes.EnderecoProf);
            paramsToSP[17] = new SqlParameter("@numeroprof", pes.NumeroProf);
            paramsToSP[18] = new SqlParameter("@bairroprof", pes.BairroProf);
            paramsToSP[19] = new SqlParameter("@cepprof", pes.CepProf);
            paramsToSP[20] = new SqlParameter("@cidadeprofid", pes.CidadeProfId);
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

           // SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "", paramsToSP);

            return true;
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
            paramsToSP[19] = new SqlParameter("@bairroprof", pes.BairroProf);
            paramsToSP[20] = new SqlParameter("@cepprof", pes.CepProf);
            paramsToSP[21] = new SqlParameter("@cidadeprofid", pes.CidadeProfId);
            paramsToSP[22] = new SqlParameter("@complementoprof", pes.ComplementoProf);
            paramsToSP[23] = new SqlParameter("@empresa", pes.Empresa);
            paramsToSP[24] = new SqlParameter("@email", pes.Email);
            paramsToSP[25] = new SqlParameter("@obs", pes.Obs);
            paramsToSP[26] = new SqlParameter("@categoriaid", pes.CategoriaId);
            paramsToSP[27] = new SqlParameter("@tipo", pes.Tipo);
            paramsToSP[28] = new SqlParameter("@envemail", pes.EnvEmail);
            paramsToSP[29] = new SqlParameter("@refnome", pes.RefNome);
            paramsToSP[30] = new SqlParameter("@refddd", pes.RefDDD);
            paramsToSP[31] = new SqlParameter("@reftelefone", pes.RefTelefone);
            paramsToSP[32] = new SqlParameter("@dtcadastro", pes.DtCadastro);

            // SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "", paramsToSP);

            return true;
        }

        public bool ExcluirDA(Pessoas pes)
        {
            SqlParameter[] paramsToSP = new SqlParameter[1];

            paramsToSP[0] = new SqlParameter("@id", pes.Id);

            // SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "", paramsToSP);

            return true;
        }

        public List<Pessoas> PesquisarDA()
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, @"SELECT * FROM PESSOAS ");
            List<Pessoas> pessoas = new List<Pessoas>();

            while (dr.Read())
            {
                Pessoas pes = new Pessoas();
                pes.Id = int.Parse(dr["ID"].ToString());
                pes.Nome = dr["NOME"].ToString();
                pes.NomeFantasia = dr["NOMEFANTASIA"].ToString();
                pes.CpfCnpj = dr["CPFCNPJ"].ToString();
                pes.Rg = dr["RG"].ToString();
                pes.NomeMae = dr["NOMEMAE"].ToString();
                pes.NomePai = dr["NOMEPAI"].ToString();
                pes.DtNascimento = DateTime.Parse(dr["DTNASCIMENTO"].ToString());
                pes.EstadoCivil = dr["ESTADOCIVIL"].ToString();
                pes.Naturalidade = int.Parse(dr["NATURALIDADE"].ToString());
                pes.Endereco = dr["ENDERECO"].ToString();
                pes.Numero = dr["NUMERO"].ToString();
                pes.BairroId = int.Parse(dr["BAIRROID"].ToString());
                pes.Cep = dr["CEP"].ToString();
                pes.CidadeId = int.Parse(dr["CIDADEID"].ToString());
                pes.Complemento = dr["COMPLEMENTO"].ToString();
                pes.EnderecoProf = dr["ENDERECOPROF"].ToString();
                pes.NumeroProf = dr["NUMEROPROF"].ToString();
                pes.CepProf = dr["CEPPROF"].ToString();
                pes.CidadeProfId = int.Parse(dr["CIDADEPROFID"].ToString());
                pes.ComplementoProf = dr["COMPLEMENTOPROF"].ToString();
                pes.Empresa = dr["EMPRESA"].ToString();
                pes.Email = dr["EMAIL"].ToString();
                pes.Tipo = dr["TIPO"].ToString();
                pes.Obs = dr["OBS"].ToString();
                pes.CategoriaId = int.Parse(dr["CATEGORIAID"].ToString());
                pes.EnvEmail = bool.Parse(dr["ENVEMAIL"].ToString());
                pes.RefNome = dr["REFNOME"].ToString();
                pes.RefTelefone = int.Parse(dr["REFTELEFONE"].ToString());
                pes.RefDDD = short.Parse(dr["REFDDD"].ToString());
                pes.DtCadastro = DateTime.Parse(dr["DTCADASTRO"].ToString());
                pes.Status = bool.Parse(dr["STATUS"].ToString());

                pessoas.Add(pes);
            }
            return pessoas; 
        }

        public List<Pessoas> PesquisarDA(int id_pes)
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, string.Format(@"SELECT * FROM PESSOAS WHERE ID = {0}",id_pes));
            List<Pessoas> pessoas = new List<Pessoas>();

            while (dr.Read())
            {
                Pessoas pes = new Pessoas();
                pes.Id = int.Parse(dr["ID"].ToString());
                pes.Nome = dr["NOME"].ToString();
                pes.NomeFantasia = dr["NOMEFANTASIA"].ToString();
                pes.CpfCnpj = dr["CPFCNPJ"].ToString();
                pes.Rg = dr["RG"].ToString();
                pes.NomeMae = dr["NOMEMAE"].ToString();
                pes.NomePai = dr["NOMEPAI"].ToString();
                pes.DtNascimento = DateTime.Parse(dr["DTNASCIMENTO"].ToString());
                pes.EstadoCivil = dr["ESTADOCIVIL"].ToString();
                pes.Naturalidade = int.Parse(dr["NATURALIDADE"].ToString());
                pes.Endereco = dr["ENDERECO"].ToString();
                pes.Numero = dr["NUMERO"].ToString();
                pes.BairroId = int.Parse(dr["BAIRROID"].ToString());
                pes.Cep = dr["CEP"].ToString();
                pes.CidadeId = int.Parse(dr["CIDADEID"].ToString());
                pes.Complemento = dr["COMPLEMENTO"].ToString();
                pes.EnderecoProf = dr["ENDERECOPROF"].ToString();
                pes.NumeroProf = dr["NUMEROPROF"].ToString();
                pes.CepProf = dr["CEPPROF"].ToString();
                pes.CidadeProfId = int.Parse(dr["CIDADEPROFID"].ToString());
                pes.ComplementoProf = dr["COMPLEMENTOPROF"].ToString();
                pes.Empresa = dr["EMPRESA"].ToString();
                pes.Email = dr["EMAIL"].ToString();
                pes.Tipo = dr["TIPO"].ToString();
                pes.Obs = dr["OBS"].ToString();
                pes.CategoriaId = int.Parse(dr["CATEGORIAID"].ToString());
                pes.EnvEmail = bool.Parse(dr["ENVEMAIL"].ToString());
                pes.RefNome = dr["REFNOME"].ToString();
                pes.RefTelefone = int.Parse(dr["REFTELEFONE"].ToString());
                pes.RefDDD = short.Parse(dr["REFDDD"].ToString());
                pes.DtCadastro = DateTime.Parse(dr["DTCADASTRO"].ToString());
                pes.Status = bool.Parse(dr["STATUS"].ToString());

                pessoas.Add(pes);
            }
            return pessoas;
        }
    }
}
