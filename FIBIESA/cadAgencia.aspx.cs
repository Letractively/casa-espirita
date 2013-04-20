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
        private void CarregarDdlUF(DropDownList ddl)
        {
            EstadosBL estBL = new EstadosBL();
            List<Estados> estados = estBL.PesquisarBL();

            ddl.Items.Add(new ListItem());
            foreach (Estados ltUF in estados)
                ddl.Items.Add(new ListItem(ltUF.Uf + " - " + ltUF.Descricao, ltUF.Id.ToString()));

            ddl.SelectedIndex = 0;
        }
        private void CarregarDdlCidade(DropDownList ddl, int id_uf)
        {
            CidadesBL cidBL = new CidadesBL();
            List<Cidades> cidades = cidBL.PesquisaCidUfDA(id_uf);

            ddl.Items.Clear();
            ddl.Items.Add(new ListItem());
            foreach (Cidades ltCid in cidades)
                ddl.Items.Add(new ListItem(ltCid.Codigo + " - " + ltCid.Descricao, ltCid.Id.ToString()));

            ddl.SelectedIndex = 0;
        }
        private void CarregarDdlBairro(DropDownList ddl, int id_cid)
        {
            BairrosBL baiBL = new BairrosBL();
            List<Bairros> bairros = baiBL.PesquisarCidBL(id_cid);

            ddl.Items.Clear();
            ddl.Items.Add(new ListItem());
            foreach (Bairros ltBai in bairros)
                ddl.Items.Add(new ListItem(ltBai.Codigo + " - " + ltBai.Descricao, ltBai.Id.ToString()));

            ddl.SelectedIndex = 0;
        }
        private void carregarDados(int id_age)
        {
            AgenciasBL ageBL = new AgenciasBL();

            List<Agencias> age = ageBL.PesquisarBL(id_age);

            foreach (Agencias ltAge in age)
            {
                hfId.Value = ltAge.Id.ToString();
                lblCodigo.Text = ltAge.Codigo.ToString();
                txtDescricao.Text = ltAge.Descricao;
                txtCep.Text = ltAge.Cep;
                txtEndereco.Text = ltAge.Endereco;
                txtRanking.Text = ltAge.Ranking.ToString();
                txtComplemento.Text = ltAge.Complemento.ToString();
                ddlBanco.SelectedValue = ltAge.BancoId.ToString();

                if (ltAge.Cidade != null)
                {
                    ddlUF.SelectedValue = ltAge.Cidade.EstadoId.ToString();
                    CarregarDdlCidade(ddlCidades, ltAge.Cidade.EstadoId);
                    CarregarDdlBairro(ddlBairro, utils.ComparaIntComZero(ltAge.CidadeId.ToString()));
                    ddlCidades.SelectedValue = ltAge.CidadeId.ToString();
                    ddlBairro.SelectedValue = ltAge.BairroId.ToString();
                }                      
                             
            }

        }
        private void CarregarAtributos()
        {           
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
                CarregarDdlUF(ddlUF);

                if (v_operacao.ToLower() == "edit")
                    carregarDados(id_age);
                else
                    lblCodigo.Text = "Código gerado automaticamente."; 
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
            agencias.Codigo = utils.ComparaIntComZero(lblCodigo.Text);
            agencias.Descricao = txtDescricao.Text;
            agencias.Cep = txtCep.Text;
            agencias.CidadeId = utils.ComparaIntComNull(ddlCidades.SelectedValue);
            agencias.BairroId = utils.ComparaIntComNull(ddlBairro.SelectedValue);
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
                     
        protected void ddlUF_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarDdlCidade(ddlCidades, utils.ComparaIntComZero(ddlUF.SelectedValue));
            ddlBairro.Items.Clear();
        }

        protected void ddlCidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarDdlBairro(ddlBairro, utils.ComparaIntComZero(ddlCidades.SelectedValue));
        }

               
              
    }
}