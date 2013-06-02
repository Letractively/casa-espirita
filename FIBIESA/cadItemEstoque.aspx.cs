using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataObjects;
using BusinessLayer;
using System.Data;
using FG;

namespace Admin
{
    public partial class cadItemEstoque : System.Web.UI.Page
    {
        Utils utils = new Utils();

        #region
        private DataTable CriarDtPesquisa()
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
        private void CarregarAtributos()
        {
            txtData.Attributes.Add("onkeypress", "return(formatar(this,'##/##/####',event))");
            txtQtdMin.Attributes.Add("onkeypress", "return(Reais(this,event))");
            txtVlrMedio.Attributes.Add("onkeypress", "return(Reais(this,event))");
            txtVlrVenda.Attributes.Add("onkeypress", "return(Reais(this,event))");           
        }
        private void CarregarDados(int id_obra)
        {
            ItensEstoqueBL itEsBL = new ItensEstoqueBL();
            List<ItensEstoque> itensEstoque = itEsBL.PesquisarMovObraBL(id_obra);

            if (itensEstoque.Count > 0)
            {
                foreach (ItensEstoque ltItEs in itensEstoque)
                {
                    hfId.Value = ltItEs.Id.ToString();
                    hfIdItem.Value = ltItEs.ObraId.ToString();
                    txtData.Text = ltItEs.Data.ToString("dd/MM/yyyy");
                    txtQtdMin.Text = ltItEs.QtdMinima.ToString();
                    txtVlrMedio.Text = ltItEs.VlrCusto.ToString();
                    txtVlrVenda.Text = ltItEs.VlrVenda.ToString();
                    chkControlaEstoque.Checked = ltItEs.ControlaEstoque;
                    ddlStatus.SelectedValue = ltItEs.Status == true ? "A" : "I";
                }
            }

        }
        private void LimparCampos()
        {
            hfId.Value = "";
            lblDesItem.Text = "";
            txtData.Text = "";
            txtQtdMin.Text = "";
            txtVlrMedio.Text = "";
            txtVlrVenda.Text = "";
            chkControlaEstoque.Checked = false;
            ddlStatus.SelectedValue = "A";
            txtData.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
        public void ExibirMensagem(string mensagem)
        {
            ClientScript.RegisterStartupScript(System.Type.GetType("System.String"), "Alert",
               "<script language='javascript'> { window.alert(\"" + mensagem + "\") }</script>");
        }
        public void CarregarPesquisaItem(string conteudo)
        {
            DataTable dt = new DataTable();
            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("CODIGO", Type.GetType("System.String"));
            DataColumn coluna3 = new DataColumn("TITULO", Type.GetType("System.String"));

            dt.Columns.Add(coluna1);
            dt.Columns.Add(coluna2);
            dt.Columns.Add(coluna3);

            ObrasBL obBL = new ObrasBL();
            Obras obras = new Obras();
            List<Obras> ltObra = obBL.PesquisarBuscaBL(conteudo);

            foreach (Obras litE in ltObra)
            {
                DataRow linha = dt.NewRow();

                linha["ID"] = litE.Id;
                linha["CODIGO"] = litE.Codigo;
                linha["TITULO"] = litE.Titulo;

                dt.Rows.Add(linha);

            }

            grdPesquisaItem.DataSource = dt;
            grdPesquisaItem.DataBind();
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarAtributos();
                txtData.Text = DateTime.Now.ToString("dd/MM/yyyy");
                txtItem.Focus();
            }
        }

        protected void btnPesItem_Click(object sender, EventArgs e)
        {
            CarregarPesquisaItem(null);
            ModalPopupExtenderPesItem.Enabled = true;
            ModalPopupExtenderPesItem.Show();
        }

        protected void txtItem_TextChanged(object sender, EventArgs e)
        {
            LimparCampos();
            ObrasBL obrBL = new ObrasBL();
            List<Obras> obras = obrBL.PesquisarBL("CODIGO", txtItem.Text);

            lblDesItem.Text = "";
            hfIdItem.Value = "";
            foreach (Obras ltObr in obras)
            {
                hfIdItem.Value = ltObr.Id.ToString();
                lblDesItem.Text = ltObr.Titulo;
            }

            CarregarDados(utils.ComparaIntComZero(hfIdItem.Value));

            if (hfIdItem.Value == null || hfIdItem.Value == string.Empty)
            {
                hfIdItem.Value = "";
                txtItem.Text = "";
                ExibirMensagem("Item não cadastrado !");
                txtItem.Focus();
            }
            else
                txtQtdMin.Focus();
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/default.aspx");
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            ItensEstoqueBL itEsBL = new ItensEstoqueBL();
            ItensEstoque itEstoque = new ItensEstoque();
            itEstoque.Id = utils.ComparaIntComZero(hfId.Value);
            itEstoque.ObraId = utils.ComparaIntComZero(hfIdItem.Value);
            itEstoque.Data = Convert.ToDateTime(txtData.Text);
            itEstoque.QtdMinima = utils.ComparaIntComZero(txtQtdMin.Text);
            itEstoque.VlrCusto = utils.ComparaDecimalComZero(txtVlrMedio.Text);
            itEstoque.VlrVenda = utils.ComparaDecimalComZero(txtVlrVenda.Text);
            itEstoque.ControlaEstoque = chkControlaEstoque.Checked;
            itEstoque.Status = ddlStatus.SelectedValue == "A" ? true : false;

            if (itEstoque.Id > 0)
            {
                if (this.Master.VerificaPermissaoUsuario("EDITAR"))
                {
                    if (itEsBL.EditarBL(itEstoque))
                        ExibirMensagem("Atualização realizada com sucesso !");
                    else
                        ExibirMensagem("Não foi possível atualizar as informações. Revise as informações !");
                }
                else
                    Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);

            }
            else
            {
                if (this.Master.VerificaPermissaoUsuario("INSERIR"))
                    if (itEsBL.InserirBL(itEstoque))
                        ExibirMensagem("Atualização realizada com sucesso !");
                    else
                        ExibirMensagem("Não foi possível atualizar as informações. Revise as informações !");
                else
                    Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);
            }

        }
        
        protected void btnSelectItem_Click(object sender, EventArgs e)
        {

            LimparCampos();
            ImageButton btndetails = sender as ImageButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;

            hfIdItem.Value = grdPesquisaItem.DataKeys[gvrow.RowIndex].Value.ToString();
            txtItem.Text = gvrow.Cells[2].Text;
            lblDesItem.Text = gvrow.Cells[3].Text;

            ModalPopupExtenderPesItem.Enabled = false;
            ModalPopupExtenderPesItem.Hide();            
            CarregarDados(utils.ComparaIntComZero(hfIdItem.Value));
            txtQtdMin.Focus();

        }

        protected void grdPesquisaItem_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                utils.CarregarEfeitoGrid("#c8defc", "#ffffff", e);
        }

        protected void btnCanelItem_Click(object sender, EventArgs e)
        {
            ModalPopupExtenderPesItem.Enabled = false;
        }

        protected void txtPesItem_TextChanged(object sender, EventArgs e)
        {
            CarregarPesquisaItem(txtPesItem.Text);
            ModalPopupExtenderPesItem.Enabled = true;
            ModalPopupExtenderPesItem.Show();
            txtPesItem.Text = "";
        }
    }
}