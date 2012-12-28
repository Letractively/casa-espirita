﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using System.Data;
using System.Data.SqlClient;
using InfrastructureSqlServer.Helpers;
using System.Configuration;

namespace DataAccess
{
    public class EstadosDA
    {
        public bool InserirDA(Estados est)
        {
            SqlParameter[] paramsToSP = new SqlParameter[2];

            paramsToSP[0] = new SqlParameter("@uf",est.Uf);
            paramsToSP[1] = new SqlParameter("@descricao", est.Descricao);

            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["conexao"].ToString(), CommandType.StoredProcedure, "stp_insert_estados", paramsToSP);
    
            return true;
        }

        public bool EditarDA(Estados est)
        {
            return true;
        }

        public bool ExcluirDA(Estados est)
        {
            return true;
        }

        public List<Estados> PesquisarDA()
        {
            List<Estados> estados = new List<Estados>();
            return estados;
        }
    }
}