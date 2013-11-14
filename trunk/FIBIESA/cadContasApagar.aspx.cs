using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataObjects;
using BusinessLayer;
using FG;
using System.Data;

namespace FIBIESA
{
    public partial class cadContasApagar : System.Web.UI.Page
    {
        Utils utils = new Utils();
        string v_operacao = "";

        #region funcoes

        private void CarregarDados(int id_tit)
        {
            TitulosBL titBL = new TitulosBL();
            List<Titulos> titulos = titBL.PesquisarBL(id_tit);

            foreach (Titulos ltTit in titulos)
            {
                hfId.Value = ltTit.Id.ToString();
                txtTitulo.Text = ltTit.Numero.ToString();
                txtValor.Text = ltTit.Valor.ToString();
                txtParcela.Text = ltTit.Parcela.ToString();
                txtDataEmissao.Text = ltTit.DataEmissao.ToString("dd/MM/yyyy");
                txtDataVencimento.Text = ltTit.DataVencimento.ToString("dd/MM/yyyy");
                txtDtPagamento.Text = ltTit.DtPagamento != null ? Convert.ToDateTime(ltTit.DtPagamento).ToString("dd/MM/yyyy") : "";
                txtVlrPago.Text = ltTit.ValorPago.ToString();
                txtObs.Text = ltTit.Obs.ToString();

                if (ltTit.Pessoas != null)
                {
                    hfIdPessoa.Value = ltTit.Pessoas.Id.ToString();
                    txtFornecedor.Text = ltTit.Pessoas.Codigo.ToString();
                    lblDesFornecedor.Text = ltTit.Pessoas.Nome != "" ? ltTit.Pessoas.Nome : ltTit.Pessoas.NomeFantasia;
                }
                ddlTipoDoc.SelectedValue = ltTit.TipoDocumentoId.ToString();
            }

        }

        private void CarregarDdlTipoDoc()
        {
            TiposDocumentosBL tipDBL = new TiposDocumentosBL();
            List<TiposDocumentos> tipoDoc = tipDBL.PesquisarBL("CP");

            ddlTipoDoc.Items.Clear();
            ddlTipoDoc.Items.Add(new ListItem("Selecione", ""));
            foreach (TiposDocumentos ltTip in tipoDoc)
                ddlTipoDoc.Items.Add(new ListItem(ltTip.Descricao, ltTip.Id.ToString()));

            ddlTipoDoc.SelectedIndex = 0;
        }

        private void LimparCampos()
        {
            txtTitulo.Text = "";
            ddlTipoDoc.SelectedIndex = 0;
            txtValor.Text = "";
            txtParcela.Text = "";
            txtFornecedor.Text = "";
            lblDesFornecedor.Text = "";
            txtDataEmissao.Text = "";
            txtDataVencimento.Text = "";
            hfId.Value = "";
            hfIdPessoa.Value = "";
            txtVlrPago.Text = "";
            txtDtPagamento.Text = "";
        }

        private void ExibirMensagem(string mensagem)
        {
            ScriptManager.RegisterStartupScript(
                                   updPrincipal,
                                   this.GetType(),
                                   "Alert",
                                   "window.alert(\"" + mensagem + "\");",
                                   true);
        }

        public void CarregarPesquisa(string conteudo)
        {
            DataTable dt = new DataTable();
            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("CODIGO", Type.GetType("System.String"));
            DataColumn coluna3 = new DataColumn("DESCRICAO", Type.GetType("System.String"));

            dt.Columns.Add(coluna1);
            dt.Columns.Add(coluna2);
            dt.Columns.Add(coluna3);

            PessoasBL pesBL = new PessoasBL();
            Pessoas pe = new Pessoas();
            List<Pessoas> pessoas = pesBL.PesquisarBuscaBL(conteudo);

            foreach (Pessoas pes in pessoas)
            {
                DataRow linha = dt.NewRow();

                linha["ID"] = pes.Id;
                linha["CODIGO"] = pes.Codigo;
                linha["DESCRICAO"] = pes.Nome;

                dt.Rows.Add(linha);
            }


            grdPesquisa.DataSource = dt;
            grdPesquisa.DataBind();
        }

        private void CarregarAtributos()
        {
            txtFornecedor.Attributes.Add("onkeypress", "return(Reais(this,event))");
            txtParcela.Attributes.Add("onkeypress", "return(Reais(this,event))");
            txtTitulo.Attributes.Add("onkeypress", "return(Reais(this,event))");
            txtDataEmissao.Attributes.Add("onkeypress", "return(formatar(this,'##/##/####',event))");
            txtDataVencimento.Attributes.Add("onkeypress", "return(formatar(this,'##/##/####',event))");
            txtDtPagamento.Attributes.Add("onkeypress", "return(formatar(this,'##/##/####',event))");
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            int id_tit = 0;

            if (!IsPostBack)
            {
                CarregarDdlTipoDoc();

                if (Request.QueryString["operacao"] != null && Request.QueryString["id_tit"] != null)
                {
                    v_operacao = Request.QueryString["operacao"];

                    if (v_operacao == "edit")
                    {
                        id_tit = Convert.ToInt32(Request.QueryString["id_tit"].ToString());
                        CarregarDados(id_tit);
                    }
                }

                CarregarAtributos();
            }
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewContasApagar.aspx");
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            TitulosBL titBL = new TitulosBL();
            Titulos titulos = new Titulos();
            titulos.Id = utils.ComparaIntComZero(hfId.Value);
            titulos.Numero = utils.ComparaIntComZero(txtTitulo.Text);
            titulos.Parcela = utils.ComparaIntComZero(txtParcela.Text);
            titulos.Pessoaid = utils.ComparaIntComNull(hfIdPessoa.Value);
            titulos.DataEmissao = Convert.ToDateTime(txtDataEmissao.Text);
            titulos.DataVencimento = Convert.ToDateTime(txtDataVencimento.Text);
            titulos.Valor = utils.ComparaDecimalComZero(txtValor.Text);
            titulos.TipoDocumentoId = utils.ComparaIntComZero(ddlTipoDoc.SelectedValue);
            titulos.DtPagamento = utils.ComparaDataComNull(txtDtPagamento.Text);
            titulos.ValorPago = utils.ComparaDecimalComZero(txtVlrPago.Text);
            titulos.Obs = txtObs.Text;
            titulos.Tipo = "P";

            if (titulos.Id > 0)
            {

                if (titBL.EditarBL(titulos))
                    ExibirMensagem("Título atualizado com sucesso !");
                else
                    ExibirMensagem("Não foi possível atualizar o título. Revise as informações.");

            }
            else
            {
                if (titBL.InserirBL(titulos))
                {
                    ExibirMensagem("Título gravado com sucesso !");
                    LimparCampos();
                }
                else
                    ExibirMensagem("Não foi possível gravar o título. Revise as informações.");

            }
        }

        protected void txtFornecedor_TextChanged(object sender, EventArgs e)
        {
            hfIdPessoa.Value = "";
            PessoasBL pesBL = new PessoasBL();
            Pessoas pessoa = new Pessoas();
            List<Pessoas> pes = pesBL.PesquisarBL("CODIGO", txtFornecedor.Text);

            foreach (Pessoas ltpessoa in pes)
            {
                hfIdPessoa.Value = ltpessoa.Id.ToString();
                txtFornecedor.Text = ltpessoa.Codigo.ToString();
                lblDesFornecedor.Text = ltpessoa.Nome;
                txtValor.Focus();
            }

            if (utils.ComparaIntComZero(hfIdPessoa.Value) <= 0)
            {
                ExibirMensagem("Fornecedor não cadastrado !");
                txtFornecedor.Text = "";
                lblDesFornecedor.Text = "";
                txtFornecedor.Focus();
            }
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {

            ImageButton btndetails = sender as ImageButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;

            hfIdPessoa.Value = grdPesquisa.DataKeys[gvrow.RowIndex].Value.ToString();
            txtFornecedor.Text = gvrow.Cells[2].Text;
            lblDesFornecedor.Text = gvrow.Cells[3].Text;

            ModalPopupExtenderPesquisa.Hide();
            ModalPopupExtenderPesquisa.Enabled = false;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ModalPopupExtenderPesquisa.Enabled = false;
        }

        protected void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            CarregarPesquisa(txtPesquisa.Text);
            ModalPopupExtenderPesquisa.Enabled = true;
            ModalPopupExtenderPesquisa.Show();
            txtPesquisa.Text = "";
        }

        protected void grdPesquisa_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                utils.CarregarEfeitoGrid("#c8defc", "#ffffff", e);
        }

        protected void btnPesFornecedor_Click(object sender, EventArgs e)
        {
            CarregarPesquisa(null);
            ModalPopupExtenderPesquisa.Enabled = true;
            ModalPopupExtenderPesquisa.Show();
        }

        protected void txtTitulo_TextChanged(object sender, EventArgs e)
        {
            TitulosBL titBL = new TitulosBL();

            if (titBL.CodigoJaUtilizadoBL(utils.ComparaIntComZero(txtTitulo.Text), "P"))
            {
                lblInformacao.Text = "O título número " + txtTitulo.Text + " já existe. Informe um novo número.";
                txtTitulo.Text = "";
                txtTitulo.Focus();
            }
            else
            {
                lblInformacao.Text = "";
                txtParcela.Focus();
            }
        }


    }
}