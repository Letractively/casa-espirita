using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataObjects;
using BusinessLayer;
using FG;

namespace Admin
{
    public partial class cadTitulo : System.Web.UI.Page
    {
        Utils utils = new Utils();
        string v_operacao = "";

        #region funcoes
        private void CarregarDDLPessoa()
        {
            PessoasBL pesBL = new PessoasBL();
            List<Pessoas> pessoa = pesBL.PesquisarBL();

            ddlPessoa.Items.Add(new ListItem());
            foreach (Pessoas ltPes in pessoa)
                ddlPessoa.Items.Add(new ListItem(ltPes.Codigo.ToString() + " - " + ltPes.Nome, ltPes.Id.ToString()));

            ddlPessoa.SelectedIndex = 0;
        }

        private void CarregarDDlPortador(DropDownList ddl)
        {
            PortadoresBL porBL = new PortadoresBL();
            List<Portadores> portador = porBL.PesquisarBL();

            ddlPortador.Items.Add(new ListItem());
            foreach (Portadores ltPor in portador)
                ddlPortador.Items.Add(new ListItem(ltPor.Codigo.ToString() + " - " + ltPor.Descricao, ltPor.Id.ToString()));
            ddlPortador.SelectedIndex = 0;
        }


        private void CarregarDDlTipoDocumento(DropDownList ddl)
        {

            TiposDocumentosBL tidBL = new TiposDocumentosBL();
            List<TiposDocumentos> tipodocumento = tidBL.PesquisarBL();

            ddlTipoDocumento.Items.Add(new ListItem());
            foreach (TiposDocumentos ltTip in tipodocumento)
                ddlTipoDocumento.Items.Add(new ListItem(ltTip.Codigo.ToString() + " - " + ltTip.Descricao, ltTip.Id.ToString()));
            ddlTipoDocumento.SelectedIndex = 0;
        }

        private void carregarDados(int id_tit)
        {

            TitulosBL titBL = new TitulosBL();

            List<Titulos> tit = titBL.PesquisarBL(id_tit);

            foreach (Titulos ltTit in tit)
            {
                hfId.Value = ltTit.Id.ToString();
                txtNumero.Text = ltTit.Numero.ToString();
                txtParcela.Text = ltTit.Parcela.ToString();
                txtValor.Text = ltTit.Valor.ToString();
                ddlPessoa.SelectedValue = ltTit.Pessoaid.ToString();
                ddlPortador.SelectedValue = ltTit.Portadorid.ToString();
                txtDataVencimento.Text = ltTit.DataVencimento.ToString();
                txtDataEmissao.Text = ltTit.DataEmissao.ToString();
                ddlTipoDocumento.SelectedValue = ltTit.TipoDocumentoId.ToString();
            }

        }


        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            int id_age = 0;

            if (!IsPostBack)
            {
                if (Request.QueryString["operacao"] != null)
                {
                    v_operacao = Request.QueryString["operacao"];

                    if (v_operacao == "edit")
                        if (Request.QueryString["id_age"] != null)
                            id_age = Convert.ToInt32(Request.QueryString["id_age"].ToString());
                }

                CarregarDDLPessoa();

            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {

            TitulosBL titBL = new TitulosBL();
            Titulos titulos = new Titulos();

            titulos.Id = utils.ComparaIntComZero(hfId.Value);
            titulos.Numero = Convert.ToInt32(txtNumero.Text);
            titulos.Parcela = Convert.ToInt32(txtParcela.Text);
            titulos.Valor = Convert.ToDecimal(txtValor.Text);
            titulos.Pessoaid = utils.ComparaIntComNull(ddlPessoa.SelectedValue);
            titulos.Portadorid = utils.ComparaIntComNull(ddlPortador.SelectedValue);
            titulos.DataVencimento = Convert.ToDateTime(txtDataVencimento.Text);
            titulos.DataEmissao = Convert.ToDateTime(txtDataEmissao.Text);
            titulos.TipoDocumentoId = utils.ComparaIntComNull(ddlTipoDocumento.SelectedValue);
            titulos.Tipo = txtTipo.Text;

            //if (titulos.Id > 0)
            //{
            //    if (this.Master.VerificaPermissaoUsuario("EDITAR"))
            //        titBL.EditarBL(titulos);
            //    else
            //        Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);

            //}
            //else
            //{
            //    if (this.Master.VerificaPermissaoUsuario("INSERIR"))
            //        titBL.InserirBL(titulos);
            //    else
            //        Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);

            //}

            Response.Redirect("viewTitulo.aspx");
        }

    }
}