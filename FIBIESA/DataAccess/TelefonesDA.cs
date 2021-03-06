﻿using System;
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
    public class TelefonesDA
    {
        public bool InserirDA(Telefones tel)
        {
            SqlParameter[] paramsToSP = new SqlParameter[3];

          
            paramsToSP[0] = new SqlParameter("@descricao", tel.Descricao);            
            paramsToSP[1] = new SqlParameter("@numero", tel.Numero);
            paramsToSP[2] = new SqlParameter("@pessoaid", tel.PessoaId);

            try
            {
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_insert_telefones", paramsToSP);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool EditarDA(Telefones tel)
        {
            SqlParameter[] paramsToSP = new SqlParameter[4];

            paramsToSP[0] = new SqlParameter("@id", tel.Id);         
            paramsToSP[1] = new SqlParameter("@descricao", tel.Descricao);            
            paramsToSP[2] = new SqlParameter("@numero", tel.Numero);
            paramsToSP[3] = new SqlParameter("@pessoaid", tel.PessoaId);

            try
            {
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_update_telefones", paramsToSP);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool ExcluirDA(Telefones tel)
        {
            SqlParameter[] paramsToSP = new SqlParameter[1];

            paramsToSP[0] = new SqlParameter("@id", tel.Id);

            try
            {
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_delete_telefones", paramsToSP);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool ExcluirDA(int id_pes)
        {
            try
            {

                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                               CommandType.Text, string.Format(@"DELETE TELEFONES WHERE PESSOAID = {0}", id_pes));

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<Telefones> PesquisarDA()
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, @"SELECT * FROM TELEFONES ");

            List<Telefones> telefones = new List<Telefones>();

            while (dr.Read())
            {
                Telefones tel = new Telefones();
                tel.Id = int.Parse(dr["ID"].ToString());
                tel.Descricao = dr["DESCRICAO"].ToString();                
                tel.Numero = dr["NUMERO"].ToString();
                tel.PessoaId = int.Parse(dr["PESSOAID"].ToString());

                telefones.Add(tel);
            }

            return telefones;
        }

        public List<Telefones> PesquisarDA(int id_pes)
        {
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, string.Format(@"SELECT * FROM TELEFONES WHERE PESSOAID = {0}", id_pes));

            List<Telefones> telefones = new List<Telefones>();

            while (dr.Read())
            {
                Telefones tel = new Telefones();
                tel.Id = int.Parse(dr["ID"].ToString());               
                tel.Descricao = dr["DESCRICAO"].ToString();               
                tel.Numero = dr["NUMERO"].ToString();
                tel.PessoaId = int.Parse(dr["PESSOAID"].ToString());

                telefones.Add(tel);
            }

            return telefones;
        }

        public int RetornarMaxCodigoDA()
        {
            int codigo = 0;
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["conexao"].ToString(),
                                                                CommandType.Text, string.Format(@"SELECT COALESCE(MAX(CODIGO),1) COD FROM TELEFONES "));

           while(dr.Read())
            codigo = Convert.ToInt32(dr["COD"].ToString());

            return codigo;
        }
    }
}
