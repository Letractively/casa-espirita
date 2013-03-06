using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataObjects;
using BusinessLayer;
using FG;
using System.Data;

namespace Admin
{
    public partial class cadTipoAutor : System.Web.UI.Page
    {
        Utils utils = new Utils();
        string v_operacao = "";

        #region funcoes
        public DataTable dtbPesquisa
        {
            get
            {
                if (Session["_dtbPesquisa_cadTipoAutor"] != null)
                    return (DataTable)Session["_dtbPesquisa_cadTipoAutor"];
                else
                    return null;
            }
            set { Session["_dtbPesquisa_cadTipoAutor"] = value; }
        }

        private void CarregarDados(int id_bai)
        {
            TiposDeAutoresBL tipoaBL = new TiposDeAutoresBL();
            List<TiposDeAutores> tipos = tipoaBL.PesquisarBL(id_bai);

            foreach (TiposDeAutores ltBai in tipos)
            {
                hfId.Value = ltBai.Id.ToString();
                txtCodigo.Text = ltBai.Codigo.ToString();
                txtDescricao.Text = ltBai.Descricao;
            }

        }
        private void CarregarAtributos()
        {
            txtCodigo.Attributes.Add("onkeypress", "return(Inteiros(this,event))");
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            int id_bai = 0;

            CarregarAtributos();

            if (!IsPostBack)
            {

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
            Response.Redirect("viewTipoAutor.aspx");
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {

            TiposDeAutoresBL tipoauBL = new TiposDeAutoresBL();
            TiposDeAutores tipos = new TiposDeAutores();
            tipos.Id = utils.ComparaIntComZero(hfId.Value);
            tipos.Codigo = utils.ComparaIntComZero(txtCodigo.Text);
            tipos.Descricao = txtDescricao.Text;

            if (tipos.Id > 0)
            {
                if (this.Master.VerificaPermissaoUsuario("EDITAR"))
                    tipoauBL.EditarBL(tipos);
                else
                    Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);

            }
            else
            {
                if (this.Master.VerificaPermissaoUsuario("INSERIR"))
                    tipoauBL.InserirBL(tipos);
                else
                    Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);
            }

            Response.Redirect("viewTipoAutor.aspx");
        }
    }
}