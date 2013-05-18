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
    public partial class cadBanco : System.Web.UI.Page
    {
        Utils utils = new Utils();
        string v_operacao = "";

        #region funcoes
        private void CarregarDados(int id_ban)
        {
            BancosBL banBL = new BancosBL();
            List<Bancos> bancos = banBL.PesquisarBL(id_ban);

            foreach (Bancos ltBan in bancos)
            {
                hfId.Value = ltBan.Id.ToString();
                txtCodigo.Text = ltBan.Codigo.ToString();
                txtDescricao.Text = ltBan.Descricao;
            }

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
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            int id_ban = 0;
                        
            if (!IsPostBack)
            {

                if (Request.QueryString["operacao"] != null)
                {
                    v_operacao = Request.QueryString["operacao"];

                    if (v_operacao == "edit")
                        if (Request.QueryString["id_ban"] != null)
                            id_ban = Convert.ToInt32(Request.QueryString["id_ban"].ToString());
                }

                if (v_operacao.ToLower() == "edit")
                    CarregarDados(id_ban);

                txtCodigo.Focus();                  
            }
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewBanco.aspx");
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            BancosBL banBL = new BancosBL();
            Bancos bancos = new Bancos();

            bancos.Id = utils.ComparaIntComZero(hfId.Value);
            bancos.Codigo = utils.ComparaIntComZero(txtCodigo.Text);
            bancos.Descricao = txtDescricao.Text;

            if (bancos.Id > 0)
            {
                if (this.Master.VerificaPermissaoUsuario("EDITAR"))
                {
                    if (banBL.EditarBL(bancos))
                        ExibirMensagem("Banco atualizado com sucesso !");
                    else
                        ExibirMensagem("Não foi possível atualizar o banco. Revise as informações.");
                }
                else
                    Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);

            }
            else
            {
                if (this.Master.VerificaPermissaoUsuario("INSERIR"))                    
                    if (banBL.InserirBL(bancos))
                    {
                        ExibirMensagem("Banco gravado com sucesso !");
                        LimparCampos();
                        txtCodigo.Focus();
                    }
                    else
                        ExibirMensagem("Não foi possível gravar o banco. Revise as informações.");
                else
                    Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);
            }
                     
            
        }

        protected void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            BancosBL insBL = new BancosBL();

            if (insBL.CodigoJaUtilizadoBL(utils.ComparaIntComZero(txtCodigo.Text)))
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