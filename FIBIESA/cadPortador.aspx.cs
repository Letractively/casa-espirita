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
    public partial class cadPortador : System.Web.UI.Page
    {
        Utils utils = new Utils();
        string v_operacao = "";

        #region funcoes
        private void carregarDados(int id_por)
        {
            PortadoresBL porBL = new PortadoresBL();

            List<Portadores> por = porBL.PesquisarBL(id_por);

            foreach (Portadores ltPor in por)
            {
                hfId.Value = ltPor.Id.ToString();
                txtCodigo.Text = ltPor.Codigo.ToString();
                txtDescricao.Text = ltPor.Descricao;
                hfIdBanco.Value = ltPor.BancoId.ToString();
                txtBanco.Text = ltPor.Banco.Codigo.ToString();
                lblDesBanco.Text = ltPor.Banco.Descricao;
                hfIdAgencia.Value = ltPor.AgenciaId.ToString();
                txtAgencia.Text = ltPor.Agencia.Codigo.ToString();
                lblDesAgencia.Text = ltPor.Agencia.Descricao;
                           
            }

        }
        private void CarregarAtributos()
        {
            txtCodigo.Attributes.Add("onkeypress", "return(Inteiros(this,event))");
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            int id_por = 0;

            CarregarAtributos();

            if (!IsPostBack)
            {
                if (Request.QueryString["operacao"] != null)
                {
                    v_operacao = Request.QueryString["operacao"];

                    if (v_operacao == "edit")
                        if (Request.QueryString["id_por"] != null)
                            id_por = Convert.ToInt32(Request.QueryString["id_por"].ToString());
                }

                if (v_operacao.ToLower() == "edit")
                    carregarDados(id_por);
            }

        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewPortador.aspx");
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            PortadoresBL porBL = new PortadoresBL();
            Portadores portadores = new Portadores();

            portadores.Id = utils.ComparaIntComZero(hfId.Value);
            portadores.Codigo = utils.ComparaIntComZero(txtCodigo.Text);
            portadores.Descricao = txtDescricao.Text;
            portadores.AgenciaId = utils.ComparaIntComNull(hfIdAgencia.Value);
            portadores.BancoId = utils.ComparaIntComNull(hfIdBanco.Value);

            if (portadores.Id > 0)
            {
                if (this.Master.VerificaPermissaoUsuario("EDITAR"))
                    porBL.EditarBL(portadores);
                else
                    Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);
            }
            else
            {
                if (this.Master.VerificaPermissaoUsuario("INSERIR"))
                    porBL.InserirBL(portadores);
                else
                    Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);
            }

            Response.Redirect("viewPortador.aspx");
            

        }

        protected void btnPesBanco_Click(object sender, EventArgs e)
        {
            Session["tabelaPesquisa"] = null;
            DataTable dt = new DataTable();
            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("CODIGO", Type.GetType("System.String"));
            DataColumn coluna3 = new DataColumn("DESCRICAO", Type.GetType("System.String"));

            dt.Columns.Add(coluna1);
            dt.Columns.Add(coluna2);
            dt.Columns.Add(coluna3);

            BancosBL banBL = new BancosBL();
            List<Bancos> bancos = banBL.PesquisarBL();

            foreach (Bancos ban in bancos)
            {
                DataRow linha = dt.NewRow();

                linha["ID"] = ban.Id;
                linha["CODIGO"] = ban.Codigo;
                linha["DESCRICAO"] = ban.Descricao;

                dt.Rows.Add(linha);
            }

            Session["tabelaPesquisa"] = null;
            
            if (dt.Rows.Count > 0)
                Session["tabelaPesquisa"] = dt;

            BancosBL baBL = new BancosBL();
            Bancos bs = new Bancos();

            Session["objBLPesquisa"] = baBL;
            Session["objPesquisa"] = bs;

            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "WinOpen('/Pesquisar.aspx?caixa=" + txtBanco.ClientID + "&id=" + hfIdBanco.ClientID + "&lbl=" + lblDesBanco.ClientID + "','',600,500);", true);
        }

        protected void btnPesAgencia_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("CODIGO", Type.GetType("System.String"));
            DataColumn coluna3 = new DataColumn("DESCRICAO", Type.GetType("System.String"));

            dt.Columns.Add(coluna1);
            dt.Columns.Add(coluna2);
            dt.Columns.Add(coluna3);

            AgenciasBL ageBL = new AgenciasBL();
            List<Agencias> agencias = ageBL.PesquisarBL();

            foreach (Agencias age in agencias)
            {
                DataRow linha = dt.NewRow();

                linha["ID"] = age.Id;
                linha["CODIGO"] = age.Codigo;
                linha["DESCRICAO"] = age.Descricao;

                dt.Rows.Add(linha);
            }

            Session["tabelaPesquisa"] = null;

            if (dt.Rows.Count > 0)
                Session["tabelaPesquisa"] = dt;

            AgenciasBL agBL = new AgenciasBL();
            Agencias ag = new Agencias();

            Session["objBLPesquisa"] = agBL;
            Session["objPesquisa"] = ag;

            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "WinOpen('/Pesquisar.aspx?caixa=" + txtAgencia.ClientID + "&id=" + hfIdAgencia.ClientID + "&lbl=" + lblDesAgencia.ClientID + "','',600,500);", true);
            
        }
    }
}