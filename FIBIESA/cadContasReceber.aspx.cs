using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataObjects;
using BusinessLayer;
using FG;

namespace FIBIESA
{
    public partial class cadContasReceber : System.Web.UI.Page
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
            List<TiposDocumentos> tipoDoc = tipDBL.PesquisarBL("CR");

            ddlTipoDoc.Items.Clear();
            ddlTipoDoc.Items.Add(new ListItem());
            foreach (TiposDocumentos ltTip in tipoDoc)
                ddlTipoDoc.Items.Add(new ListItem(ltTip.Codigo + " - " + ltTip.Descricao, ltTip.Id.ToString()));

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
            txtDataEmissao.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtDataVencimento.Text = "";
            hfId.Value = "";
            hfIdPessoa.Value = "";
        }

        private void ExibirMensagem(string mensagem)
        {
            ClientScript.RegisterStartupScript(System.Type.GetType("System.String"), "Alert",
               "<script language='javascript'> { window.alert(\"" + mensagem + "\") }</script>");
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
            }

        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewContasReceber.aspx");
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            TitulosBL titBL = new TitulosBL();
            Titulos titulos = new Titulos();
            titulos.Id = utils.ComparaIntComZero(hfId.Value);
            titulos.Numero = utils.ComparaIntComZero(txtTitulo.Text);
            titulos.Parcela = utils.ComparaIntComZero(txtParcela.Text);
            titulos.Pessoaid = utils.ComparaIntComZero(hfIdPessoa.Value);
            titulos.DataEmissao = Convert.ToDateTime(txtDataEmissao.Text);
            titulos.DataVencimento = Convert.ToDateTime(txtDataVencimento.Text);
            titulos.Valor = utils.ComparaDecimalComZero(txtValor.Text);
            titulos.TipoDocumentoId = utils.ComparaIntComZero(ddlTipoDoc.SelectedValue);
            titulos.Tipo = "R";

            if (titulos.Id > 0)
            {
                if (this.Master.VerificaPermissaoUsuario("EDITAR"))
                {
                    if (titBL.EditarBL(titulos))
                        ExibirMensagem("Título atualizado com sucesso !");
                    else
                        ExibirMensagem("Não foi possível atualizar o título. Revise as informações.");
                }
                else
                    Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);

            }
            else
            {
                if (this.Master.VerificaPermissaoUsuario("INSERIR"))
                {
                    if (titBL.InserirBL(titulos))
                    {
                        ExibirMensagem("Título gravado com sucesso !");
                        LimparCampos();
                    }
                    else
                        ExibirMensagem("Não foi possível gravar o título. Revise as informações.");
                }
                else
                    Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);
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
    }
}