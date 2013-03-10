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
                ddlBanco.SelectedValue = ltPor.BancoId.ToString(); 
                ddlAgencia.SelectedValue = ltPor.AgenciaId.ToString();                           
            }

        }
        
        private void CarregarDDLAgencia()
        {
            AgenciasBL ageBL = new AgenciasBL();
            List<Agencias> agencias = ageBL.PesquisarBL();

            ddlAgencia.Items.Add(new ListItem());
            foreach (Agencias ltAge in agencias)
                ddlAgencia.Items.Add(new ListItem(ltAge.Codigo.ToString() + " - " + ltAge.Descricao, ltAge.Id.ToString()));

            ddlAgencia.SelectedIndex = 0;
        }
        
        private void CarregarDDLBanco()
        {
            BancosBL banBL = new BancosBL();
            List<Bancos> bancos = banBL.PesquisarBL();

            ddlBanco.Items.Add(new ListItem());
            foreach (Bancos ltBan in bancos)
                ddlBanco.Items.Add(new ListItem(ltBan.Codigo.ToString() + " - " + ltBan.Descricao, ltBan.Id.ToString()));

            ddlBanco.SelectedIndex = 0;
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

                CarregarDDLAgencia();
                CarregarDDLBanco();

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
            portadores.AgenciaId = utils.ComparaIntComNull(ddlAgencia.SelectedValue);
            portadores.BancoId = utils.ComparaIntComNull(ddlBanco.SelectedValue);

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

                
    }
}