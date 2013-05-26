using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLayer;
using DataObjects;
using FG;

namespace FIBIESA
{
    public partial class viewRelItensEstoque : System.Web.UI.Page
    {
        Utils utils = new Utils();
        #region funcoes
        public void CarregarPesquisaItem(string conteudo)
        {
            DataTable dt = new DataTable();
            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("CODIGO", Type.GetType("System.String"));
            DataColumn coluna3 = new DataColumn("DESCRICAO", Type.GetType("System.String"));

            dt.Columns.Add(coluna1);
            dt.Columns.Add(coluna2);
            dt.Columns.Add(coluna3);

            ItensEstoqueBL itemBl = new ItensEstoqueBL();
            ItensEstoque item = new ItensEstoque();

            List<ItensEstoque> lItens =  itemBl.PesquisarBuscaBL(conteudo);

            foreach (ItensEstoque pes in lItens)
            {
                DataRow linha = dt.NewRow();

                linha["ID"] = pes.Id;
                linha["CODIGO"] = pes.Obra.Codigo;
                linha["DESCRICAO"] = pes.Obra.Titulo;

                dt.Rows.Add(linha);
            }


            grdPesquisaItem.DataSource = dt;
            grdPesquisaItem.DataBind();
        }
        #endregion

        public DataTable dtGeral;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["IntItem"] = null;
            }
        }

        #region Click

        protected void btnPesItem_Click(object sender, EventArgs e)
        {

            CarregarPesquisaItem(null);
            ModalPopupExtenderPesquisaItem.Enabled = true;
            ModalPopupExtenderPesquisaItem.Show();

        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {

            ImageButton btndetails = sender as ImageButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;

            if (Session["IntItem"] != null && Session["IntItem"] != string.Empty)
                txtItem.Text = Session["IntItem"].ToString() + ",";

            txtItem.Text = txtItem.Text + gvrow.Cells[2].Text;
            Session["IntItem"] = txtItem.Text;
            ModalPopupExtenderPesquisaItem.Hide();
            ModalPopupExtenderPesquisaItem.Enabled = false;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ModalPopupExtenderPesquisaItem.Enabled = false;
        }

        protected void btnRelatorio_Click(object sender, EventArgs e)
        {
            ItensEstoqueBL itensEstoqueBL = new ItensEstoqueBL();
            ItensEstoque itensEstoque = new ItensEstoque();

            
            byte? controlaestoque = null;

            if (utils.ComparaIntComZero(ddlControlaEst.SelectedValue) > 0)
                controlaestoque = Convert.ToByte(ddlControlaEst.SelectedValue);
            

            byte? blStatus = null;
            string status = "Todos";
            if (ddlStatus.SelectedValue != string.Empty)
            {
                blStatus = Convert.ToByte(ddlStatus.SelectedValue);
                status = ddlStatus.SelectedItem.Text;
            }

            Session["ldsRel"] = itensEstoqueBL.PesquisarItensEstoqueDataSetBL(txtItem.Text, controlaestoque, blStatus).Tables[0];
            if (((DataTable)Session["ldsRel"]).Rows.Count != 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "WinOpen('/Relatorios/RelItensEstoque.aspx?status=" + status + "','',590,805);", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "alert('Sua pesquisa não retornou dados.');", true);
            }
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/default.aspx");
        }

        #endregion
        protected void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            CarregarPesquisaItem(txtPesquisa.Text);
            ModalPopupExtenderPesquisaItem.Enabled = true;
            ModalPopupExtenderPesquisaItem.Show();
            txtPesquisa.Text = "";
        }

        protected void txtItem_TextChanged(object sender, EventArgs e)
        {
            if (txtItem.Text == "")
                Session["IntItem"] = null;
            Session["IntItem"] = txtItem.Text;
        }        

        protected void grdPesquisaItem_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                utils.CarregarEfeitoGrid("#c8defc", "#ffffff", e);
        }
    }
}