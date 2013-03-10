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
    public partial class cadExemplar : System.Web.UI.Page
    {
        Utils utils = new Utils();
        string v_operacao = "";

        #region funcoes
        public DataTable dtbPesquisa
        {
            get
            {
                if (Session["_dtbPesquisa_cadExemp"] != null)
                    return (DataTable)Session["_dtbPesquisa_cadExemp"];
                else
                    return null;
            }
            set { Session["_dtbPesquisa_cadExemp"] = value; }
        }

        private void CarregarDados(int id_bai)
        {
            
            BairrosBL baiBL = new BairrosBL();
            List<Bairros> bairros = baiBL.PesquisarBL(id_bai);

            foreach (Bairros ltBai in bairros)
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
            Response.Redirect("viewBairro.aspx");
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {

            BairrosBL baiBL = new BairrosBL();
            Bairros bairros = new Bairros();
            bairros.Id = utils.ComparaIntComZero(hfId.Value);
            bairros.Codigo = utils.ComparaIntComZero(txtCodigo.Text);
            bairros.Descricao = txtDescricao.Text;

            if (bairros.Id > 0)
            {
                if (this.Master.VerificaPermissaoUsuario("EDITAR"))
                    baiBL.EditarBL(bairros);
                else
                    Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);

            }
            else
            {
                if (this.Master.VerificaPermissaoUsuario("INSERIR"))
                    baiBL.InserirBL(bairros);
                else
                    Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);
            }

            Response.Redirect("viewBairro.aspx");
        }
    }
}