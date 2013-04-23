using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FG;
using DataObjects;
using BusinessLayer;
using System.Data;

namespace FIBIESA
{
    public partial class cadManVenda : System.Web.UI.Page
    {
        Utils utils = new Utils();
        string v_operacao = "";

        #region funcoes

        private void CarregarDados(Int32 venId)
        {
            DataTable dtItens = new DataTable();

            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));          
            DataColumn coluna2 = new DataColumn("QUANTIDADE", Type.GetType("System.Int32"));
            DataColumn coluna3 = new DataColumn("VALOR", Type.GetType("System.Decimal"));          
            DataColumn coluna4 = new DataColumn("DESCONTO", Type.GetType("System.Decimal"));
            DataColumn coluna5 = new DataColumn("CODIGO", Type.GetType("System.Int32"));
            DataColumn coluna6 = new DataColumn("DESCRICAO", Type.GetType("System.String"));
            DataColumn coluna7 = new DataColumn("SITUACAO", Type.GetType("System.String"));


            dtItens.Columns.Add(coluna1);
            dtItens.Columns.Add(coluna2);
            dtItens.Columns.Add(coluna3);
            dtItens.Columns.Add(coluna4);
            dtItens.Columns.Add(coluna5);
            dtItens.Columns.Add(coluna6);
            dtItens.Columns.Add(coluna7);
          
            VendasBL venBL = new VendasBL();
            List<Vendas> ltVenda = venBL.PesquisarBL(venId);

            foreach (Vendas vendas in ltVenda)
            {
                hfIdVenda.Value = vendas.Id.ToString();
                lblNumero.Text = vendas.Numero.ToString();
                lblCliente.Text = vendas.Pessoas.Nome;
                lblData.Text = vendas.Data.ToString("dd/MM/yyyy");
            }

            VendaItensBL venItBl = new VendaItensBL();
            List<VendaItens> venItens = venItBl.PesquisarBL(venId);
           
            foreach (VendaItens ltVenItens in venItens)
            {

                DataRow linha = dtItens.NewRow();

                linha["ID"] = ltVenItens.Id;                
                linha["QUANTIDADE"] = ltVenItens.Quantidade;
                linha["VALOR"] = ltVenItens.Valor;               
                linha["DESCONTO"] = ltVenItens.Desconto;
                linha["CODIGO"] = ltVenItens.Obras.Codigo;
                linha["DESCRICAO"] = ltVenItens.Obras.Titulo;
                linha["SITUACAO"] = ltVenItens.Situacao;

                dtItens.Rows.Add(linha);
            }

            dtgItens.DataSource = dtItens;
            dtgItens.DataBind();
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            int id_vend = 0;

            if (!IsPostBack)
            {                

                if (Request.QueryString["operacao"] != null && Request.QueryString["id_vend"] != null)
                {
                    v_operacao = Request.QueryString["operacao"];

                    if (v_operacao == "edit")
                    {
                        id_vend = Convert.ToInt32(Request.QueryString["id_vend"].ToString());
                        CarregarDados(id_vend);
                    }
                }               
            }
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/viewManVenda.aspx");
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {

        }

        protected void dtgItens_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                utils.CarregarEfeitoGrid("#c8defc", "#ffffff", e);
        }


    }
}