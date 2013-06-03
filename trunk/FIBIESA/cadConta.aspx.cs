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
        private void CarregarDDLAgencia(int id_ban)
        {
            AgenciasBL ageBL = new AgenciasBL();
            List<Agencias> agencias = ageBL.PesquisarBanBL(id_ban);

            ddlAgencia.Items.Clear();
            ddlAgencia.Items.Add(new ListItem("Selecione",""));
            foreach (Agencias ltAge in agencias)
                ddlAgencia.Items.Add(new ListItem(ltAge.Codigo.ToString() + " - " + ltAge.Descricao, ltAge.Id.ToString()));

            ddlAgencia.SelectedIndex = 0;
        }

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
                if (ltCon.Agencia != null)
                {
                    ddlBanco.SelectedValue = ltCon.Agencia.BancoId.ToString();
                    CarregarDDLAgencia(utils.ComparaIntComZero(ltCon.Agencia.BancoId.ToString()));
                    ddlAgencia.SelectedValue = ltCon.AgenciaId.ToString();
                }
            }

        }

        private void CarregarDDLBanco()
        {
            BancosBL banBL = new BancosBL();
            List<Bancos> bancos = banBL.PesquisarBL();

            ddlBanco.Items.Add(new ListItem("Selecione", ""));
            foreach (Bancos ltBan in bancos)
                ddlBanco.Items.Add(new ListItem(ltBan.Codigo.ToString() + " - " + ltBan.Descricao, ltBan.Id.ToString()));

             ddlBanco.SelectedIndex = 0;
        }

        private void ExibirMensagem(string mensagem)
        {
            ClientScript.RegisterStartupScript(System.Type.GetType("System.String"), "Alert",
               "<script language='javascript'> { window.alert(\"" + mensagem + "\") }</script>");
        }

        private void CarregarAtributos()
        {
            txtCodigo.Attributes.Add("onkeypress", "return(Inteiros(this,event))");
            txtDigito.Attributes.Add("onkeypress", "return(Inteiros(this,event))");            
        }

        private void LimparCampos()
        {
            txtDescricao.Text = "";
            txtCodigo.Text = "";
            txtDigito.Text = "";
            txtTitular.Text = "";
            ddlBanco.SelectedIndex = 0;
            ddlAgencia.Items.Clear();

        }
       
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            int id_con = 0;

            if (!IsPostBack)
            {

                if (Request.QueryString["operacao"] != null)
                {
                    v_operacao = Request.QueryString["operacao"];

                    if (v_operacao == "edit")
                        if (Request.QueryString["id_con"] != null)
                            id_con = Convert.ToInt32(Request.QueryString["id_con"].ToString());
                }

                CarregarDDLBanco();

                if (v_operacao.ToLower() == "edit")
                    CarregarDados(id_con);                
            }
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
            contas.Codigo = utils.ComparaIntComZero(txtCodigo.Text);
            contas.Descricao = txtDescricao.Text;
            contas.Titular = txtTitular.Text;
            contas.AgenciaId = utils.ComparaIntComZero(ddlAgencia.SelectedValue);
            contas.Digito = txtDigito.Text;

            if (contas.Id > 0)
            {
                if (this.Master.VerificaPermissaoUsuario("EDITAR"))
                   if(conBL.EditarBL(contas))
                       ExibirMensagem("Conta atualizada com sucesso !");
                   else
                       ExibirMensagem("Não foi possível atualizar a conta. Revise as informações.");
                else
                    Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);

            }
            else
            {
                if (this.Master.VerificaPermissaoUsuario("INSERIR"))
                    if(conBL.InserirBL(contas))
                    {
                        ExibirMensagem("Conta gravada com sucesso !");
                        LimparCampos();
                        ddlBanco.Focus();
                    }
                    else
                        ExibirMensagem("Não foi possível gravar a conta. Revise as informações.");
                else
                    Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);
            }
        }

        protected void ddlBanco_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarDDLAgencia(utils.ComparaIntComZero(ddlBanco.SelectedValue));
        }

            
    }
}