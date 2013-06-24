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
    public partial class cadCategoria : System.Web.UI.Page
    {
        Utils utils = new Utils();
        string v_operacao = "";

        #region funcoes
        private void carregarDados(int id_cat)
        {
            CategoriasBL catBL = new CategoriasBL();
            Categorias categorias = new Categorias();
            List<Categorias> cat = catBL.PesquisarBL(id_cat);

            foreach (Categorias ltCat in cat)
            {
                hfId.Value = ltCat.Id.ToString();
                lblCodigo.Text = ltCat.Codigo.ToString();
                txtDescricao.Text = ltCat.Descricao;
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
            hfId.Value = "";
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            int id_cat = 0;

            if (!Page.IsPostBack)
            {
                if (Request.QueryString["operacao"] != null)
                {
                    v_operacao = Request.QueryString["operacao"];

                    if (v_operacao == "edit")
                        if (Request.QueryString["id_cat"] != null)
                            id_cat = Convert.ToInt32(Request.QueryString["id_cat"].ToString());
                }

                if (v_operacao.ToLower() == "edit")
                    carregarDados(id_cat);
                else
                    lblCodigo.Text = "Código gerado automaticamente.";

                txtDescricao.Focus();
            }

        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewCategoria.aspx");
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {

            CategoriasBL catBL = new CategoriasBL();
            Categorias categorias = new Categorias();

            categorias.Id = utils.ComparaIntComZero(hfId.Value);
            categorias.Codigo = utils.ComparaIntComZero(lblCodigo.Text);
            categorias.Descricao = txtDescricao.Text;

            if (categorias.Id > 0)
            {

                if (catBL.EditarBL(categorias))
                    ExibirMensagem("Categoria atualizada com sucesso !");
                else
                    ExibirMensagem("Não foi possível atualizar a categoria. Revise as informações.");

            }
            else
            {

                if (catBL.InserirBL(categorias))
                {
                    ExibirMensagem("Categoria gravada com sucesso !");
                    LimparCampos();
                }

            }

            txtDescricao.Focus();

        }
    }
}