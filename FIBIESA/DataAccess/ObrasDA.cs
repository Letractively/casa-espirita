using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using FG;
using System.Data.SqlClient;
using InfrastructureSqlServer.Helpers;
using System.Configuration;
using System.Data;

namespace DataAccess
{
    public class ObrasDA : BaseDA
    {
        Utils utils = new Utils();
        #region funcoes
        private List<Obras> CarregarObjObras(SqlDataReader dr)
        {
            List<Obras> obra = new List<Obras>();

            while (dr.Read())
            {
                Obras obrinha = new Obras();
                obrinha.Id = int.Parse(dr["ID"].ToString());
                obrinha.Codigo = int.Parse(dr["CODIGO"].ToString());
                obrinha.Titulo = dr["TITULO"].ToString();
                obrinha.NroEdicao = utils.ComparaShortComNull(dr["NROEDICAO"].ToString());
                obrinha.EditoraId = utils.ComparaIntComNull(dr["EDITORAID"].ToString());
                obrinha.LocalPublicacao = dr["LOCALPUBLICACAO"].ToString();
                obrinha.NroPaginas = utils.ComparaIntComNull(dr["NROPAGINAS"].ToString());
                obrinha.DataPublicacao = utils.ComparaDataComNull(dr["DATAPUBLICACAO"].ToString());
                obrinha.Isbn = dr["ISBN"].ToString();
                obrinha.AssuntosAborda = dr["ASSUNTOSABORDA"].ToString();               
                obrinha.DataReimpressao = utils.ComparaDataComNull(dr["DATAREIMPRESSAO"].ToString());
                //obrinha.ImagemCapa = utils.ComparaIntComNull(dr["IMAGEMCAPA"].ToString());
                obrinha.Volume = utils.ComparaIntComNull(dr["VOLUME"].ToString());
                obrinha.OrigemId = utils.ComparaIntComNull(dr["ORIGEMID"].ToString());
                obrinha.TiposObraId = utils.ComparaIntComNull(dr["TIPOSOBRAID"].ToString());

                TiposObrasDA tObDA = new TiposObrasDA();
                List<TiposObras> tOb = tObDA.PesquisarDA(utils.ComparaIntComZero(obrinha.TiposObraId.ToString()));
                TiposObras tiposObras = new TiposObras();

                foreach (TiposObras lttObr in tOb)
                {
                    tiposObras.Id = lttObr.Id;
                    tiposObras.Codigo = lttObr.Codigo;
                    tiposObras.Descricao = lttObr.Descricao;

                    obrinha.TiposObras = tiposObras;
                }

                obra.Add(obrinha);
            }

            return obra;
        }
        #endregion

        public bool InserirDA(Obras instancia)
        {
            SqlParameter[] paramsToSP = new SqlParameter[14];

            paramsToSP[0] = new SqlParameter("@codigo", instancia.Codigo);
            paramsToSP[1] = new SqlParameter("@titulo", instancia.Titulo);
            paramsToSP[2] = new SqlParameter("@nroEdicao", instancia.NroEdicao);
            paramsToSP[3] = new SqlParameter("@editoraId", instancia.EditoraId);
            paramsToSP[4] = new SqlParameter("@localPublicacao", instancia.LocalPublicacao);
            paramsToSP[5] = new SqlParameter("@datapublicacao", instancia.DataPublicacao);
            paramsToSP[6] = new SqlParameter("@nroPaginas", instancia.NroPaginas);            
            paramsToSP[7] = new SqlParameter("@isbn", instancia.Isbn);                     
            paramsToSP[8] = new SqlParameter("@assuntosAborda", instancia.AssuntosAborda);
            paramsToSP[9] = new SqlParameter("@tipo", 0);
            paramsToSP[10] = new SqlParameter("@dataReimpressao", instancia.DataReimpressao);
            paramsToSP[11] = new SqlParameter("@volume", instancia.Volume);
            paramsToSP[12] = new SqlParameter("@origemId", instancia.OrigemId);            
            paramsToSP[13] = new SqlParameter("@tiposObraId", instancia.TiposObraId);

            try
            {
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                            CommandType.StoredProcedure, "stp_insert_Obras", paramsToSP);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool EditarDA(Obras instancia)
        {
            SqlParameter[] paramsToSP = new SqlParameter[14];

            paramsToSP[0] = new SqlParameter("@id", instancia.Id);
            paramsToSP[1] = new SqlParameter("@codigo", instancia.Codigo);
            paramsToSP[2] = new SqlParameter("@titulo", instancia.Titulo);
            paramsToSP[3] = new SqlParameter("@nroEdicao", instancia.NroEdicao);
            paramsToSP[4] = new SqlParameter("@editoraId", instancia.EditoraId);
            paramsToSP[5] = new SqlParameter("@localPublicacao", instancia.LocalPublicacao);
            paramsToSP[6] = new SqlParameter("@datapublicacao", instancia.DataPublicacao);
            paramsToSP[7] = new SqlParameter("@nroPaginas", instancia.NroPaginas);
            paramsToSP[8] = new SqlParameter("@isbn", instancia.Isbn);
            paramsToSP[9] = new SqlParameter("@tiposObraId", instancia.TiposObraId);
            paramsToSP[10] = new SqlParameter("@assuntosAborda", instancia.AssuntosAborda);
            paramsToSP[11] = new SqlParameter("@volume", instancia.Volume);
            paramsToSP[12] = new SqlParameter("@origemId", instancia.OrigemId);
            paramsToSP[13] = new SqlParameter("@dataReimpressao", instancia.DataReimpressao);

            try
            {
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                CommandType.StoredProcedure, "stp_update_obras", paramsToSP);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public bool ExcluirDA(Obras instancia)
        {
            SqlParameter[] paramsToSP = new SqlParameter[1];

            paramsToSP[0] = new SqlParameter("@id", instancia.Id);

            try
            {
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                CommandType.StoredProcedure, "stp_delete_obras", paramsToSP);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<Obras> PesquisarDA()
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(
                ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                CommandType.Text, string.Format(@"SELECT * FROM OBRAS "));
            return CarregarObjObras(dr);
        }

        public List<Obras> PesquisarDA(int id)
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(
                ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                CommandType.Text, string.Format(@"SELECT * FROM OBRAS  WHERE ID = {0}", id));
            return CarregarObjObras(dr);
        }

        public List<Obras> PesquisarDA(string campo, string valor)
        {
            StringBuilder consulta = new StringBuilder("SELECT * FROM OBRAS ");

            switch (campo.ToUpper())
            {
                case "CODIGO":
                    consulta.Append(string.Format("WHERE CODIGO = {0}", utils.ComparaIntComZero(valor)));
                    break;
                case "TITULO":
                    consulta.Append(string.Format("WHERE TITULO  LIKE '%{0}%'", valor));
                    break;
                default:
                    break;
            }

            SqlDataReader dr = SqlHelper.ExecuteReader(
                ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                CommandType.Text, consulta.ToString());

            return CarregarObjObras(dr);
        }

        public override List<Base> Pesquisar(string descricao, string tipo)
        {
            SqlDataReader dr;

            if (tipo == "C")
            {
                int codigo = 0;
                Int32.TryParse(descricao, out codigo);

                dr = SqlHelper.ExecuteReader(
                    ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                    CommandType.Text, string.Format(@"SELECT * FROM OBRAS WHERE CODIGO = '{0}'", codigo));
            }
            else
            {
                dr = SqlHelper.ExecuteReader(
                    ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                    CommandType.Text, string.Format(@"SELECT * FROM OBRAS WHERE TITULO LIKE '%{0}%'", descricao));
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
