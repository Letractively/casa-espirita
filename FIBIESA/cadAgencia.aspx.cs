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
    public partial class cadAgencia : System.Web.UI.Page
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

        private void carregarDados(int id_age)
        {
            AgenciasBL ageBL = new AgenciasBL();

            List<Agencias> age = ageBL.PesquisarBL(id_age);

            foreach (Agencias ltAge in age)
            {
                hfId.Value = ltAge.Id.ToString();
                txtCodigo.Text = ltAge.Codigo.ToString();
                txtDescricao.Text = ltAge.Descricao;
                txtCep.Text = ltAge.Cep;
                txtEndereco.Text = ltAge.Endereco;
                txtRanking.Text = ltAge.Ranking.ToString();
                txtComplemento.Text = ltAge.Complemento.ToString();
                ddlBanco.SelectedValue = ltAge.BairroId.ToString();
                if (ltAge.Bairro != null)
                {
                    txtBairro.Text = ltAge.Bairro.Codigo.ToString();
                    lblDesBairro.Text = ltAge.Bairro.Descricao;
                }
                             
                hfIdCidade.Value = ltAge.CidadeId.ToString();
                if (ltAge.Cidade != null)
                {                    
                    txtCidade.Text = ltAge.Cidade.Codigo.ToString();
                    lblDesCidade.Text = ltAge.Cidade.Descricao;
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
            int id_age = 0;

            CarregarAtributos();

            if (!IsPostBack)
            {
                if (Request.QueryString["operacao"] != null)
                {
                    v_operacao = Request.QueryString["operacao"];

                    if (v_operacao == "edit")
                        if (Request.QueryString["id_age"] != null)
                            id_age = Convert.ToInt32(Request.QueryString["id_age"].ToString());
                }

                CarregarDDLBanco();

                if (v_operacao.ToLower() == "edit")
                    carregarDados(id_age);
            }
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewAgencia.aspx");
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            AgenciasBL ageBL = new AgenciasBL();
            Agencias agencias = new Agencias();

            agencias.Id = utils.ComparaIntComZero(hfId.Value);
            agencias.Codigo = utils.ComparaIntComZero(txtCodigo.Text);
            agencias.Descricao = txtDescricao.Text;
            agencias.Cep = txtCep.Text;
            agencias.CidadeId = utils.ComparaIntComNull(hfIdCidade.Value);
            agencias.BairroId = utils.ComparaIntComNull(hfIdBairro.Value);
            agencias.BancoId = utils.ComparaIntComZero(ddlBanco.SelectedValue);
            agencias.Endereco = txtEndereco.Text;
            agencias.Complemento = txtComplemento.Text;
            agencias.Ranking = utils.ComparaIntComZero(txtRanking.Text);

          
            if (agencias.Id > 0)
            {
                if (this.Master.VerificaPermissaoUsuario("EDITAR"))
                   ageBL.EditarBL(agencias);
                else
                    Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);

            }
            else
            {
                if (this.Master.VerificaPermissaoUsuario("INSERIR"))                
                    ageBL.InserirBL(agencias);
                else
                    Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);

            }

            Response.Redirect("viewAgencia.aspx");
        }

        protected void btnPesCidade_Click(object sender, EventArgs e)
        {
            Session["tabelaPesquisa"] = null;
            DataTable dt = CriarDtPesquisa();

            CidadesBL cidBL = new CidadesBL();
            Cidades ci = new Cidades();
            List<Cidades> cidades = cidBL.PesquisarBL();

            foreach (Cidades cid in cidades)
            {
                DataRow linha = dt.NewRow();

                linha["ID"] = cid.Id;
                linha["CODIGO"] = cid.Codigo;
                linha["DESCRICAO"] = cid.Descricao;

                dt.Rows.Add(linha);
            }

            Session["tabelaPesquisa"] = null;

            if (dt.Rows.Count > 0)
                Session["tabelaPesquisa"] = dt;


            Session["objBLPesquisa"] = cidBL;
            Session["objPesquisa"] = ci;
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "WinOpen('/Pesquisar.aspx?caixa=" + txtCidade.ClientID + "&id=" + hfIdCidade.ClientID + "&lbl=" + lblDesCidade.ClientID + "','',600,500);", true);
        }

        protected void btnPesBairro_Click(object sender, EventArgs e)
        {
            Session["tabelaPesquisa"] = null;
            DataTable dt = CriarDtPesquisa();

            BairrosBL baiBL = new BairrosBL();
            Bairros ba = new Bairros();
            List<Bairros> bairros = baiBL.PesquisarBL();

            foreach (Bairros cat in bairros)
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


            Session["objBLPesquisa"] = baiBL;
            Session["objPesquisa"] = ba;

            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "WinOpen('/Pesquisar.aspx?caixa=" + txtBairro.ClientID + "&id=" + hfIdBairro.ClientID + "&lbl=" + lblDesBairro.ClientID + "','',600,500);", true);
        }

        
              
    }
}