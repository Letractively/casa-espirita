using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataObjects;
using BusinessLayer;
using System.Data;
using System.Data.SqlClient;
using FG;

namespace Admin
{
    public partial class cadConta : System.Web.UI.Page
    {
        Utils utils = new Utils();
        string v_operacao = "";

        #region funcoes
        private void CarregarDados(int id_con)
        {
            ContasBL conBL = new ContasBL();
            List<Contas> contas = conBL.PesquisarBL(id_con);

            foreach (Contas ltCon in contas)
            {
                hfId.Value = ltCon.Id.ToString();
                txtCodigo.Text = ltCon.Codigo.ToString();
                txtDescricao.Text = ltCon.Descricao;
                txtTitular.Text = ltCon.Titular;
                txtDigito.Text = ltCon.Digito;
                hfIdAgencia.Value = ltCon.AgenciaId.ToString();

                if (ltCon.Agencia != null)
                {
                    txtAgencia.Text = ltCon.Agencia.Codigo.ToString();
                    lblDesAgencia.Text = ltCon.Agencia.Descricao; 
                }
            }

        }
        private void CarregarAtributos()
        {
            txtCodigo.Attributes.Add("onkeypress", "return(Inteiros(this,event))");
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            int id_con = 0;

            CarregarAtributos();

            if (!IsPostBack)
            {

                if (Request.QueryString["operacao"] != null)
                {
                    v_operacao = Request.QueryString["operacao"];

                    if (v_operacao == "edit")
                        if (Request.QueryString["id_con"] != null)
                            id_con = Convert.ToInt32(Request.QueryString["id_con"].ToString());
                }

                if (v_operacao.ToLower() == "edit")
                    CarregarDados(id_con);
            }
        }

        protected void btnPesAgencia_Click(object sender, EventArgs e)
        {
            Session["tabelaPesquisa"] = null;
            DataTable dt = new DataTable();
            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("CODIGO", Type.GetType("System.String"));
            DataColumn coluna3 = new DataColumn("DESCRICAO", Type.GetType("System.String"));

            dt.Columns.Add(coluna1);
            dt.Columns.Add(coluna2);
            dt.Columns.Add(coluna3);

            AgenciasBL ageBL = new AgenciasBL();
            List<Agencias> agencias = ageBL.PesquisarBL();

            foreach (Agencias con in agencias)
            {
                DataRow linha = dt.NewRow();

                linha["ID"] = con.Id;
                linha["CODIGO"] = con.Codigo;
                linha["DESCRICAO"] = con.Descricao;

                dt.Rows.Add(linha);
            }

            if (dt.Rows.Count > 0)
                Session["tabelaPesquisa"] = dt;
                        
            Agencias ag = new Agencias();

            Session["objBLPesquisa"] = ageBL;
            Session["objPesquisa"] = ag;

            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "WinOpen('/Pesquisar.aspx?caixa=" + txtAgencia.ClientID + "&id=" + hfIdAgencia.ClientID + "&lbl=" + lblDesAgencia.ClientID + "','',600,500);", true);
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewConta.aspx");
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            ContasBL conBL = new ContasBL();
            Contas contas = new Contas();

            contas.Id = utils.ComparaIntComZero(hfId.Value);
            contas.Descricao = txtDescricao.Text;
            contas.Titular = txtTitular.Text;
            contas.AgenciaId = utils.ComparaIntComZero(hfIdAgencia.Value);
            contas.Digito = txtDigito.Text;

            if (contas.Id > 0)
            {
                if (this.Master.VerificaPermissaoUsuario("EDITAR"))
                    conBL.EditarBL(contas);
                else
                    Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);

            }
            else
            {
                if (this.Master.VerificaPermissaoUsuario("INSERIR"))
                    conBL.InserirBL(contas);
                else
                    Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);
            }

            Response.Redirect("viewConta.aspx");


        }

            
    }
}