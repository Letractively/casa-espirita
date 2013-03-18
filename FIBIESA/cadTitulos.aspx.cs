using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using DataObjects;
using FG;
using System.Data;
using System.Data.SqlClient;

namespace Admin
{
    public partial class cadTitulos : System.Web.UI.Page
    {
        Utils utils = new Utils();
        string v_operacao = "";

        #region funcoes
        private void CarregarDDLBanco()
        {
            BancosBL banBL = new BancosBL();
            List<Bancos> bancos = banBL.PesquisarBL();

            ddlBanco.Items.Add(new ListItem());
            foreach (Bancos ltBan in bancos)
                ddlBanco.Items.Add(new ListItem(ltBan.Codigo.ToString() + " - " + ltBan.Descricao, ltBan.Id.ToString()));

            ddlBanco.SelectedIndex = 0;
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
                txtPessoa.Text = ltTit.Pessoaid.ToString();
                txtPortador.Text = ltTit.Portadorid.ToString();
                txtDataVencimento.Text = ltTit.DataVencimento.ToString();
                txtDataEmissao.Text = ltTit.DataEmissao.ToString();
                txtTipoDocumento.Text = ltTit.TipoDocumentoId.ToString();
                txtTipo.Text = ltTit.Tipo.ToString();

                hfIdPessoa.Value = ltTit.Pessoaid.ToString();
                if (ltTit.Pessoaid != null)
                {
                    txtPessoa.Text = ltTit.Pessoaid.Codigo.ToString();
                    lblDesPessoa.Text = ltTit.Pessoaid.Descricao;
                }
                             
            }

        }
        private void CarregarAtributos()
        {
            txtCodigo.Attributes.Add("onkeypress", "return(Inteiros(this,event))");
            txtRanking.Attributes.Add("onkeypress", "return(Inteiros(this,event))");
            txtCep.Attributes.Add("onkeypress", "mascara(this,'00000-000')");
        }
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
        #endregion




        protected void Page_Load(object sender, EventArgs e)
        {
            int id_tit = 0;

            CarregarAtributos();

            if (!IsPostBack)
            {
                if (Request.QueryString["operacao"] != null)
                {
                    v_operacao = Request.QueryString["operacao"];

                    if (v_operacao == "edit")
                        if (Request.QueryString["id_tit"] != null)
                            id_tit = Convert.ToInt32(Request.QueryString["id_tit"].ToString());
                }

                CarregarDDLBanco();

                if (v_operacao.ToLower() == "edit")
                    carregarDados(id_tit);
            }
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewTitulos.aspx");
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            TitulosBL titBL = new TitulosBL();
            Titulos titulos = new Titulos();

            titulos.Id = utils.ComparaIntComZero(hfId.Value);
            titulos.Numero = utils.ComparaIntComZero(txtNumero.Text);
            titulos.Parcela = utils.ComparaIntComZero(txtParcela.Text);
            titulos.Valor = utils.ComparaIntComZero(txtValor.Text);
            titulos.Pessoaid = utils.ComparaIntComZero(hfIdPessoa.Value);
            titulos.Portadorid = utils.ComparaIntComZero(hfIdPortador.Value);
            titulos.DataVencimento = utils.ComparaDataComNull(txtDataVencimento.Text);
            titulos.DataEmissao = utils.ComparaDataComNull(txtDataEmissao.Text);
            titulos.TipoDocumentoId = utils.ComparaIntComZero(hfIdTipoDocumento.Value);
            titulos.Tipo = txtTipo.Text;

            if (titulos.Id > 0)
            {
                if (this.Master.VerificaPermissaoUsuario("EDITAR"))
                   titBL.EditarBL(titulos);
                else
                    Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);

            }
            else
            {
                if (this.Master.VerificaPermissaoUsuario("INSERIR"))                
                    titBL.InserirBL(titulos);
                else
                    Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);

            }

            Response.Redirect("viewTitulos.aspx");
        }

        protected void btnPesPessoa_Click(object sender, EventArgs e)
        {
            Session["tabelaPesquisa"] = null;
            DataTable dt = CriarDtPesquisa();


            PessoasBL peaBL = new PessoasBL();
            Pessoas pe = new Pessoas();
            List<Pessoas> pessoas = peaBL.PesquisarBL();

            foreach (Pessoas pes in pessoas)
            {
                DataRow linha = dt.NewRow();

                linha["ID"] = pes.Id;
                linha["CODIGO"] = pes.Codigo;
                linha["NOME"] = pes.Nome;

                dt.Rows.Add(linha);
            }

            Session["tabelaPesquisa"] = null;

            if (dt.Rows.Count > 0)
                Session["tabelaPesquisa"] = dt;


            Session["objBLPesquisa"] = peaBL;
            Session["objPesquisa"] = pe;
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "WinOpen('/Pesquisar.aspx?caixa=" + txtPessoa.ClientID + "&id=" + hfIdPessoa.ClientID + "&lbl=" + lblDesPessoa.ClientID + "','',600,500);", true);
        }

        protected void btnPesPortador_Click(object sender, EventArgs e)
        {
            Session["tabelaPesquisa"] = null;
            DataTable dt = CriarDtPesquisa();

            PortadoresBL potBL = new PortadoresBL();
            Portadores pt = new Portadores();
            List<Portadores> portador = potBL.PesquisarBL();

            foreach (Portadores cat in portador)
            {
                DataRow linha = dt.NewRow();

                linha["ID"] = cat.Id;
                linha["CODIGO"] = cat.Codigo;
                linha["DESCRICAO"] = cat.Descricao;

                dt.Rows.Add(linha);
            }

            Session["tabelaPesquisa"] = null;

            if (dt.Rows.Count > 0)
                Session["tabelaPesquisa"] = dt;


            Session["objBLPesquisa"] = potBL;
            Session["objPesquisa"] = pt;

            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "WinOpen('/Pesquisar.aspx?caixa=" + txtPortador.ClientID + "&id=" + hfIdPortador.ClientID + "&lbl=" + lblDesPortador.ClientID + "','',600,500);", true);
        }

        protected void btnPesTipoDocumento_Click(object sender, EventArgs e)
        {
            Session["tabelaPesquisa"] = null;
            DataTable dt = CriarDtPesquisa();

            TiposDocumentosBL tipBL = new TiposDocumentosBL();
            TiposDocumentos tp = new TiposDocumentos();
            List<TiposDocumentos> TiposDocumentos = tipBL.PesquisarBL();

            foreach (TiposDocumentos cat in TiposDocumentos)
            {
                DataRow linha = dt.NewRow();

                linha["ID"] = cat.Id;
                linha["CODIGO"] = cat.Codigo;
                linha["DESCRICAO"] = cat.Descricao;

                dt.Rows.Add(linha);
            }

            Session["tabelaPesquisa"] = null;

            if (dt.Rows.Count > 0)
                Session["tabelaPesquisa"] = dt;


            Session["objBLPesquisa"] = tipBL;
            Session["objPesquisa"] = tp;

            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "WinOpen('/Pesquisar.aspx?caixa=" + txtTipoDocumento.ClientID + "&id=" + hfIdTipoDocumento.ClientID + "&lbl=" + lblDesTipoDocumento.ClientID + "','',600,500);", true);
        }
              
    }
}