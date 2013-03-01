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
                txtCodigo.Text = ltCat.Codigo.ToString();
                txtDescricao.Text = ltCat.Descricao;	 
	        }            
        }
        private void CarregarAtributos()
        {
            txtCodigo.Attributes.Add("onkeypress", "return(Inteiros(this,event))");            
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            int id_cat = 0;

            CarregarAtributos();

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
            categorias.Codigo = utils.ComparaIntComZero(txtCodigo.Text);
            categorias.Descricao = txtDescricao.Text;

            if (categorias.Id > 0)
            {
                if (this.Master.VerificaPermissaoUsuario("EDITAR"))
                    catBL.EditarBL(categorias);
                else
                    Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);
            }
            else
            {
                if(this.Master.VerificaPermissaoUsuario("INSERIR"))
                    catBL.InserirBL(categorias);
                else
                    Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);
            }

            Response.Redirect("viewCategoria.aspx");
        }
    }
}