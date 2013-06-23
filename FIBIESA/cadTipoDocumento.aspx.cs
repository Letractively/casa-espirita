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
    public partial class cadTipoDocumento : System.Web.UI.Page
    {
        Utils utils = new Utils();
        string v_operacao = "";

        #region funcoes
        private void CarregarDados(int id_tdo)
        {
            TiposDocumentosBL tdoBL = new TiposDocumentosBL();
            List<TiposDocumentos> tiposDocumentos = tdoBL.PesquisarBL(id_tdo);

            foreach (TiposDocumentos ltTdo in tiposDocumentos)
            {
                hfId.Value = ltTdo.Id.ToString();
                lblCodigo.Text = ltTdo.Codigo.ToString();
                txtDescricao.Text = ltTdo.Descricao;
                ddlAplicacao.SelectedValue = ltTdo.Aplicacao;
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
            lblCodigo.Text = "Código gerado automaticamente.";
            ddlAplicacao.SelectedIndex = 0;
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            int id_tdo = 0;


            if (!IsPostBack)
            {

                if (Request.QueryString["operacao"] != null)
                {
                    v_operacao = Request.QueryString["operacao"];

                    if (v_operacao == "edit")
                        if (Request.QueryString["id_tdo"] != null)
                            id_tdo = Convert.ToInt32(Request.QueryString["id_tdo"].ToString());
                }

                if (v_operacao.ToLower() == "edit")
                    CarregarDados(id_tdo);
                else
                    lblCodigo.Text = "Código gerado automaticamente.";

                txtDescricao.Focus();
            }
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewTipoDocumento.aspx");
        }

        protected void btnInserir_Click(object sender, EventArgs e)
        {
            TiposDocumentosBL tdoBL = new TiposDocumentosBL();
            TiposDocumentos tiposDocumentos = new TiposDocumentos();

            tiposDocumentos.Id = utils.ComparaIntComZero(hfId.Value);
            tiposDocumentos.Codigo = utils.ComparaIntComZero(lblCodigo.Text);
            tiposDocumentos.Descricao = txtDescricao.Text;
            tiposDocumentos.Aplicacao = ddlAplicacao.SelectedValue;

            if (tiposDocumentos.Id > 0)
            {
                if (tdoBL.EditarBL(tiposDocumentos))
                {
                    ExibirMensagem("Tipo de documento atualizado com sucesso !");
                    txtDescricao.Focus();
                }
                else
                    ExibirMensagem("Não foi possível atualizar o tipo de documento. Revise as informações.");
            }
            else
            {
                if (tdoBL.InserirBL(tiposDocumentos))
                {
                    ExibirMensagem("Tipo de documento gravado com sucesso !");
                    LimparCampos();
                    txtDescricao.Focus();
                }
                else
                    ExibirMensagem("Não foi possível gravar o tipo de documento. Revise as informações.");

            }
        }

        
    }
}