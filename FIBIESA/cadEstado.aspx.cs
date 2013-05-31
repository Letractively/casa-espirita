using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataObjects;
using BusinessLayer;
using FG;

namespace Admin
{
    public partial class cadEstado : System.Web.UI.Page
    {        
        Utils utils = new Utils();
        string v_operacao = "";

        #region funcoes
        private void carregarDados(int id_est)
        {
            EstadosBL estBL = new EstadosBL();
            Estados estados = new Estados();
            List<Estados> est = estBL.PesquisarBL(id_est);

            foreach (Estados ltEst in est)
            {
                hfId.Value = ltEst.Id.ToString();
                txtUf.Text = ltEst.Uf;
                txtDescricao.Text = ltEst.Descricao;
            }

        }

        private void ExibirMensagem(string mensagem)
        {
            ClientScript.RegisterStartupScript(System.Type.GetType("System.String"), "Alert",
               "<script language='javascript'> { window.alert(\"" + mensagem + "\") }</script>");
        }

        private void LimparCampos()
        {
            txtDescricao.Text = "";
            txtUf.Text = "";
            txtDescricao.Focus();
        }
        
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            int id_est = 0;

            if (!Page.IsPostBack)
            {
                if (Request.QueryString["operacao"] != null)
                {
                    v_operacao = Request.QueryString["operacao"];

                    if (v_operacao == "edit")
                        if (Request.QueryString["id_est"] != null)
                            id_est = Convert.ToInt32(Request.QueryString["id_est"].ToString());
                }

                if (v_operacao.ToLower() == "edit")
                    carregarDados(id_est);

                txtUf.Focus();
            }

        }

        protected void bntSalvar_Click(object sender, EventArgs e)
        {
            EstadosBL estBL = new EstadosBL();
            Estados estados = new Estados();
            estados.Id = utils.ComparaIntComZero(hfId.Value);
            estados.Uf = txtUf.Text.ToUpper();
            estados.Descricao = txtDescricao.Text;

            if (estados.Id > 0)
            {
                if (this.Master.VerificaPermissaoUsuario("EDITAR"))
                    if (estBL.EditarBL(estados))
                       ExibirMensagem("Estado atualizado com sucesso !");
                    else
                       ExibirMensagem("Não foi possível atualizar o estado. Revise as informações.");
                else
                    Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);

            }
            else
            {
                if (this.Master.VerificaPermissaoUsuario("INSERIR"))
                {
                    if (estBL.InserirBL(estados))
                    {
                        ExibirMensagem("Estado gravado com sucesso !");
                        LimparCampos();
                    }
                }
                else
                    Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);
            }
            
        }

        protected void bntVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewEstado.aspx");
        }

        protected void txtUf_TextChanged(object sender, EventArgs e)
        {
            EstadosBL estBL = new EstadosBL();

            if (estBL.CodigoJaUtilizadoBL(txtUf.Text))
            {
                lblInformacao.Text = "A UF " + txtUf.Text.ToUpper() + " já existe. Informe uma nova UF.";
                txtUf.Text = "";
                txtUf.Focus();
            }
            else
            {
                lblInformacao.Text = "";
                txtDescricao.Focus();
            } 
        }
    }
}