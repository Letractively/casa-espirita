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
            string id_age;

            foreach (Portadores ltPor in por)
            {
                hfId.Value = ltPor.Id.ToString();
                txtCodigo.Text = ltPor.Codigo.ToString();
                txtDescricao.Text = ltPor.Descricao;
                ddlBanco.SelectedValue = ltPor.BancoId.ToString();
                CarregarDDLAgencia(utils.ComparaIntComZero(ddlBanco.SelectedValue));
                ddlAgencia.SelectedValue = ltPor.AgenciaId.ToString();
                id_age = ltPor.AgenciaId.ToString();
                CarregarDDLConta(utils.ComparaIntComZero(id_age));
                ddlConta.SelectedValue = ltPor.ContaId.ToString();
            }

        }

        private void CarregarDDLAgencia(int id_ban)
        {
            AgenciasBL ageBL = new AgenciasBL();
            List<Agencias> agencias = ageBL.PesquisarBanBL(id_ban);

            ddlAgencia.Items.Clear();
            ddlAgencia.Items.Add(new ListItem("Selecione", ""));
            foreach (Agencias ltAge in agencias)
                ddlAgencia.Items.Add(new ListItem(ltAge.Codigo.ToString() + " - " + ltAge.Descricao, ltAge.Id.ToString()));

            ddlAgencia.SelectedIndex = 0;
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

        private void CarregarDDLConta(int age_id)
        {
            ContasBL conBL = new ContasBL();
            List<Contas> contas = conBL.PesquisarBL(age_id);

            ddlConta.Items.Clear();
            ddlConta.Items.Add(new ListItem("Selecione", ""));
            foreach (Contas ltCon in contas)
                ddlConta.Items.Add(new ListItem(ltCon.Codigo.ToString() + " - " + ltCon.Descricao, ltCon.Id.ToString()));

            ddlConta.SelectedIndex = 0;
        }

        private void ExibirMensagem(string mensagem)
        {
            ClientScript.RegisterStartupScript(System.Type.GetType("System.String"), "Alert",
               "<script language='javascript'> { window.alert(\"" + mensagem + "\") }</script>");
        }

        private void LimparCampos()
        {
            txtCodigo.Text = "";
            txtDescricao.Text = "";
            ddlAgencia.SelectedIndex = -1;
            ddlConta.SelectedIndex = -1;
            ddlBanco.SelectedIndex = 0;
        }

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            int id_por = 0;

            if (!IsPostBack)
            {
                if (Request.QueryString["operacao"] != null)
                {
                    v_operacao = Request.QueryString["operacao"];

                    if (v_operacao == "edit")
                        if (Request.QueryString["id_por"] != null)
                            id_por = Convert.ToInt32(Request.QueryString["id_por"].ToString());
                }

                CarregarDDLBanco();

                if (v_operacao.ToLower() == "edit")
                    carregarDados(id_por);

                txtCodigo.Focus();
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
            portadores.AgenciaId = utils.ComparaIntComNull(ddlAgencia.SelectedValue);
            portadores.BancoId = utils.ComparaIntComNull(ddlBanco.SelectedValue);
            portadores.ContaId = utils.ComparaIntComNull(ddlConta.SelectedValue);

            if (portadores.Id > 0)
            {

                if (porBL.EditarBL(portadores))
                    ExibirMensagem("Portador atualizado com sucesso !");
                else
                    ExibirMensagem("Não foi possível gravar o portador. Revise as informações.");

            }
            else
            {

                if (porBL.InserirBL(portadores))
                {
                    ExibirMensagem("Portador gravado com sucesso !");
                    LimparCampos();
                }
                else
                    ExibirMensagem("Não foi possível gravar o portador. Revise as informações.");

            }

        }

        protected void ddlBanco_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarDDLAgencia(utils.ComparaIntComZero(ddlBanco.SelectedValue));
        }

        protected void ddlAgencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarDDLConta(utils.ComparaIntComZero(ddlAgencia.SelectedValue));
        }

        protected void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            PortadoresBL porBL = new PortadoresBL();

            if (porBL.CodigoJaUtilizadoBL(utils.ComparaIntComZero(txtCodigo.Text)))
            {
                lblInformacao.Text = "O código " + txtCodigo.Text + " já existe. Informe um novo código.";
                txtCodigo.Text = "";
                txtCodigo.Focus();
            }
            else
            {
                lblInformacao.Text = "";
                txtDescricao.Focus();
            }

        }


    }
}