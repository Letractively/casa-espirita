using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using DataObjects;
using FG;

namespace Admin
{
    public partial class cadAutor : System.Web.UI.Page
    {
        /*Utils utils = new Utils();
        string v_operacao = "";

        #region funcoes
        public DataTable dtbPesquisa
        {
            get
            {
                if (Session["_dtbPesquisa_cadAutores"] != null)
                    return (DataTable)Session["_dtbPesquisa_cadAutores"];
                else
                    return null;
            }
            set { Session["_dtbPesquisa_cadAutores"] = value; }
        }

        private void CarregarDados(int id_bai)
        {
            AutoresBL auBL = new AutoresBL();
            List<Autores> autores = auBL.PesquisarBL(id_bai);

            foreach (Autores ltAutor in autores)
            {
                hfId.Value = ltAutor.Id.ToString();
                txtCodigo.Text = ltAutor.Codigo.ToString();
                txtDescricao.Text = ltAutor.Descricao;
                ddlTiposAutores.SelectedValue = ltAutor.TipoId.ToString();
            }

        }
        private void CarregarAtributos()
        {
            txtCodigo.Attributes.Add("onkeypress", "return(Inteiros(this,event))");
        }
        #endregion


        private void CarregaTiposAutores()
        {
            TiposDeAutoresBL tipos = new TiposDeAutoresBL();
            List<TiposDeAutores> listao = tipos.PesquisarBL();
            
            ddlTiposAutores.Items.Clear();
            foreach (TiposDeAutores tp in listao)
            {   
                ddlTiposAutores.Items.Add(new ListItem(tp.Codigo + " - " + tp.Descricao, tp.Id.ToString()));
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.CarregaTiposAutores();

                int id_bai = 0;

                if (Request.QueryString["operacao"] != null)
                {
                    v_operacao = Request.QueryString["operacao"];

                    if (v_operacao == "edit")
                        if (Request.QueryString["id_bai"] != null)
                            id_bai = Convert.ToInt32(Request.QueryString["id_bai"].ToString());
                }

                if (v_operacao.ToLower() == "edit")
                    CarregarDados(id_bai);
            }
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewAutor.aspx");
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {

            AutoresBL auBL = new AutoresBL();
            Autores aut = new Autores();
            aut.Id = utils.ComparaIntComZero(hfId.Value);
            aut.Codigo = utils.ComparaIntComZero(txtCodigo.Text);
            aut.Descricao = txtDescricao.Text;
            aut.TipoId = utils.ComparaIntComZero(ddlTiposAutores.SelectedValue);

            if (aut.Id > 0)
            {
                if (this.Master.VerificaPermissaoUsuario("EDITAR"))
                    auBL.EditarBL(aut);
                else
                    Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);

            }
            else
            {
                if (this.Master.VerificaPermissaoUsuario("INSERIR"))
                    auBL.InserirBL(aut);
                else
                    Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);
            }

            Response.Redirect("viewAutor.aspx");
        */

    }
}