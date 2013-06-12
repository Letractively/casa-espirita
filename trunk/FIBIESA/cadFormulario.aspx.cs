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
    public partial class cadFormulario : System.Web.UI.Page
    {
        Utils utils = new Utils();
        string v_operacao = "";

        #region funcoes
        private void CarregarDados(int id_for)
        {
            FormulariosBL forBL = new FormulariosBL();
            List<Formularios> formularios = forBL.PesquisarBL(id_for);

            foreach (Formularios ltFor in formularios)
            {
                hfId.Value = ltFor.Id.ToString();
                lblCodigo.Text = ltFor.Codigo.ToString();
                txtDescricao.Text = ltFor.Descricao;
                txtNome.Text = ltFor.Nome;
                ddlTipo.SelectedValue = ltFor.Tipo;
                ddlModulo.SelectedValue = ltFor.Modulo;
            }

        }
        
        private void ExibirMensagem(string mensagem)
        {
            ClientScript.RegisterStartupScript(System.Type.GetType("System.String"), "Alert",
               "<script language='javascript'> { window.alert(\"" + mensagem + "\") }</script>");
        }

        private void LimparCampos()
        {
            lblCodigo.Text = "";
            txtDescricao.Text = "";
            txtNome.Text = "";
            ddlModulo.SelectedIndex = 0;
            ddlTipo.SelectedIndex = 0;
            txtDescricao.Focus();
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            int id_for = 0;
                        
            if (!IsPostBack)
            {
                if (Request.QueryString["operacao"] != null && Request.QueryString["id_for"] != null)
                {
                    v_operacao = Request.QueryString["operacao"];

                    if (v_operacao == "edit")
                    {
                        id_for = Convert.ToInt32(Request.QueryString["id_for"].ToString());
                        CarregarDados(id_for);
                    }                   
                }
                else
                    lblCodigo.Text = "Código gerado automaticamente";

                txtDescricao.Focus();

            }
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/viewFormulario.aspx");
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            FormulariosBL forBL = new FormulariosBL();
            Formularios formulario = new Formularios();

            formulario.Id = utils.ComparaIntComZero(hfId.Value);
            formulario.Codigo = utils.ComparaIntComZero(lblCodigo.Text);
            formulario.Descricao = txtDescricao.Text;
            formulario.Nome = txtNome.Text;
            formulario.Tipo = ddlTipo.SelectedValue;
            formulario.Modulo = ddlModulo.SelectedValue;

            if (formulario.Id > 0)
                if(forBL.EditarBL(formulario))                
                    ExibirMensagem("Dados atualizados com sucesso !");
                else
                    ExibirMensagem("Não foi possível salvar o formulário. Revise as informações !");
            else
            {
                if (forBL.InserirBL(formulario))
                {
                    ExibirMensagem("Dados gravados com sucesso !");
                    LimparCampos();
                }
                else
                    ExibirMensagem("Não foi possível salvar o formulário. Revise as informações !");
            }
                        
        }
                
                
    }
}