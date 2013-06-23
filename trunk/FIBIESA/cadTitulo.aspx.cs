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
using System.Data.SqlClient;

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
        private void CarregarDDlPortador()
        {
            PortadoresBL porBL = new PortadoresBL();
            List<Portadores> portador = porBL.PesquisarBL();

            ddlPortador.Items.Add(new ListItem());
            foreach (Portadores ltPor in portador)
                ddlPortador.Items.Add(new ListItem(ltPor.Codigo.ToString() + " - " + ltPor.Descricao, ltPor.Id.ToString()));
            ddlPortador.SelectedIndex = 0;
        }
        private void CarregarDDlTipoDocumento()
        {

            TiposDocumentosBL tidBL = new TiposDocumentosBL();
            List<TiposDocumentos> tipodocumento = tidBL.PesquisarBL("CR");

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
                txtDataPagamento.Text = ltTit.DtPagamento.ToString();
                txtValorPago.Text = ltTit.ValorPago.ToString();
                txtObs.Text = ltTit.Obs.ToString();
            }

        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            int id_tit = 0;

            if (!IsPostBack)
            {
                if (Request.QueryString["operacao"] != null)
                {
                    v_operacao = Request.QueryString["operacao"];

                    if (v_operacao == "edit")
                        if (Request.QueryString["id_tit"] != null)
                            id_tit = Convert.ToInt32(Request.QueryString["id_tit"].ToString());
                }

                CarregarDDLPessoa();
                CarregarDDlPortador();
                CarregarDDlTipoDocumento();

                if (v_operacao.ToLower() == "edit")
                    carregarDados(id_tit);
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
            titulos.DtPagamento = Convert.ToDateTime(txtDataPagamento.Text);
            titulos.ValorPago = Convert.ToDecimal(txtValorPago.Text);
            titulos.Obs = txtObs.Text; 

            if (titulos.Id > 0)
                titBL.EditarBL(titulos);
            else
                titBL.InserirBL(titulos);
            

            Response.Redirect("viewTitulo.aspx");
        }

    }
}