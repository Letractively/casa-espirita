﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DataObjects;
using BusinessLayer;

namespace FIBIESA
{
    public partial class cadVenda : System.Web.UI.Page
    {
        DataTable dtItens = new DataTable();

        #region funcoes
        private DataTable CriarTabelaPesquisa()
        {
            DataTable dt = new DataTable();
            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("CODIGO", Type.GetType("System.String"));
            DataColumn coluna3 = new DataColumn("DESCRICAO", Type.GetType("System.String"));

            dt.Columns.Add(coluna1);
            dt.Columns.Add(coluna2);
            dt.Columns.Add(coluna3);

            return dt;
 
        }
        private void CriarDtItens()
        {
            if (dtItens.Columns.Count == 0)
            {                
                DataColumn coluna1 = new DataColumn("ITEMESTOQUEID", Type.GetType("System.Int32"));
                DataColumn coluna2 = new DataColumn("QUANTIDADE", Type.GetType("System.Int32"));
                DataColumn coluna3 = new DataColumn("VALOR", Type.GetType("System.Decimal"));
                DataColumn coluna4 = new DataColumn("DESCONTO", Type.GetType("System.Decimal"));
              
                dtItens.Columns.Add(coluna1);
                dtItens.Columns.Add(coluna2);
                dtItens.Columns.Add(coluna3);
                dtItens.Columns.Add(coluna4);               
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            CriarDtItens();
        }

       
        protected void btnPesItem_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "WinOpen('/PesquisarItens.aspx?caixa=" + txtItem.ClientID + "&id=" + hfIdItem.ClientID + "&lbl=" + lblDesItem.ClientID +"&valor"+ txtValor.ClientID +"','',600,500);", true);
        }

        protected void btnPesCliente_Click(object sender, EventArgs e)
        {
            Session["tabelaPesquisa"] = null;

            DataTable dt = CriarTabelaPesquisa();

            PessoasBL pesBL = new PessoasBL();
            Pessoas pe = new Pessoas();
            List<Pessoas> pessoas = pesBL.PesquisarBL();

            foreach (Pessoas pes in pessoas)
            {
                DataRow linha = dt.NewRow();

                linha["ID"] = pes.Id;
                linha["CODIGO"] = pes.Codigo;
                linha["DESCRICAO"] = pes.Nome;

                dt.Rows.Add(linha);
            }

            if (dt.Rows.Count > 0)
                Session["tabelaPesquisa"] = dt;


            Session["objBLPesquisa"] = pesBL;
            Session["objPesquisa"] = pe;

            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "WinOpen('/Pesquisar.aspx?caixa=" + txtCliente.ClientID + "&id=" + hfIdPessoa.ClientID + "&lbl=" + lblDesCliente.ClientID + "','',600,500);", true);
        }

        protected void btnInserir_Click(object sender, EventArgs e)
        {
            DataRow linha = dtItens.NewRow();
            linha["ITEMESTOQUEID"] = hfIdItem.Value;
            linha["QUANTIDADE"] = txtQuantidade.Text;
            linha["VALOR"] = txtValor.Text;
            linha["DESCONTO"] = txtDesconto.Text;

            dtItens.Rows.Add(linha);

            dtgItens.DataSource = dtItens;
            dtgItens.DataBind();            
        }

        protected void btnFinalizar_Click(object sender, EventArgs e)
        {
            if (dtgItens.Rows.Count > 0)
            {
                
            }
        }
       
    }
}