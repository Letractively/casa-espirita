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
        private void CarregarDDLAgencia()
        {
            AgenciasBL ageBL = new AgenciasBL();
            List<Agencias> agencias = ageBL.PesquisarBL();

            ddlAgencia.Items.Add(new ListItem());
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
                ddlAgencia.SelectedValue = ltCon.AgenciaId.ToString();              
            }

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

                CarregarDDLAgencia();

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