﻿using System;
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
                obrinha.NroEdicao = int.Parse(dr["NROEDICAO"].ToString());
                obrinha.EditoraId = int.Parse(dr["EDITORAID"].ToString());
                obrinha.LocalPublicacao = int.Parse(dr["LOCALPUBLICACAO"].ToString());
                obrinha.NroPaginas = int.Parse(dr["NROPAGINAS"].ToString());
                obrinha.DataPublicacao = Convert.ToDateTime(dr["DATAPUBLICACAO"].ToString());
                obrinha.Isbn = int.Parse(dr["ISBN"].ToString());
                obrinha.AssuntosAborda = dr["ASSUNTOSABORDA"].ToString();
                obrinha.Obraid = int.Parse(dr["OBRAID"].ToString());
                obrinha.DataReimpressao = Convert.ToDateTime(dr["DATAREIMPRESSAO"].ToString());
                obrinha.ImagemCapa = int.Parse(dr["IMAGEMCAPA"].ToString());
                obrinha.Volume = int.Parse(dr["VOLUME"].ToString());
                obrinha.Origem = int.Parse(dr["ORIGEM"].ToString());

                obra.Add(obrinha);
            }

            return obra;
        }
        #endregion

        public bool InserirDA(Obras instancia)
        {
            SqlParameter[] paramsToSP = new SqlParameter[13];

            paramsToSP[0] = new SqlParameter("@codigo", instancia.Codigo);
            paramsToSP[1] = new SqlParameter("@titulo", instancia.Titulo);
            paramsToSP[2] = new SqlParameter("@nroEdicao", instancia.NroEdicao);
            paramsToSP[3] = new SqlParameter("@editoraId", instancia.EditoraId);
            paramsToSP[4] = new SqlParameter("@localPublicacao", instancia.LocalPublicacao);
            paramsToSP[5] = new SqlParameter("@datapublicacao", instancia.DataPublicacao);
            paramsToSP[6] = new SqlParameter("@nroPaginas", instancia.NroPaginas);
            paramsToSP[7] = new SqlParameter("@isbn", instancia.Isbn);
            //TODO: TIPO?? Que campo eh esse?
            paramsToSP[8] = new SqlParameter("@obraid", instancia.Obraid); 
            paramsToSP[9] = new SqlParameter("@assuntosAborda", instancia.AssuntosAborda);
            paramsToSP[10] = new SqlParameter("@volume", instancia.Volume);
            paramsToSP[11] = new SqlParameter("@origem", instancia.Origem);
            paramsToSP[12] = new SqlParameter("@dataReimpressao", instancia.DataReimpressao);


            return (SqlHelper.ExecuteNonQuery(
                ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                CommandType.StoredProcedure, "stp_insert_tiposObras", paramsToSP) > 0);
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
            //TODO: TIPO?? Que campo eh esse?
            paramsToSP[9] = new SqlParameter("@obraid", instancia.Obraid);
            paramsToSP[10] = new SqlParameter("@assuntosAborda", instancia.AssuntosAborda);
            paramsToSP[11] = new SqlParameter("@volume", instancia.Volume);
            paramsToSP[12] = new SqlParameter("@origem", instancia.Origem);
            paramsToSP[13] = new SqlParameter("@dataReimpressao", instancia.DataReimpressao);

            return (SqlHelper.ExecuteNonQuery(
                ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                CommandType.StoredProcedure, "stp_update_obras", paramsToSP) > 0);
        }

        public bool ExcluirDA(Obras instancia)
        {
            SqlParameter[] paramsToSP = new SqlParameter[1];

            paramsToSP[0] = new SqlParameter("@id", instancia.Id);

            return (SqlHelper.ExecuteNonQuery(
                ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                CommandType.StoredProcedure, "stp_delete_obras", paramsToSP) > 0);
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
                case "DESCRICAO":
                    consulta.Append(string.Format("WHERE DESCRICAO  LIKE '%{0}%'", valor));
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
                    CommandType.Text, string.Format(@"SELECT * FROM OBRAS WHERE DESCRICAO LIKE '%{0}%'", descricao));
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