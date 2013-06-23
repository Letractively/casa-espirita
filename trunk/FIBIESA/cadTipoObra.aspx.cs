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
    public partial class cadTipoObra : System.Web.UI.Page
    {
        Utils utils = new Utils();
        string v_operacao = "";

        #region funcoes
        public DataTable dtbPesquisa
        {
            get
            {
                if (Session["_dtbPesquisa_cadTipoObra"] != null)
                    return (DataTable)Session["_dtbPesquisa_cadTipoObra"];
                else
                    return null;
            }
            set { Session["_dtbPesquisa_cadTipoObra"] = value; }
        }

        private void CarregarDados(int id_bai)
        {

            TiposObrasBL tipoBL = new TiposObrasBL();
            List<TiposObras> tipos = tipoBL.PesquisarBL(id_bai);

            foreach (TiposObras ltBai in tipos)
            {
                hfId.Value = ltBai.Id.ToString();
                lblCodigo.Text = ltBai.Codigo.ToString();
                txtDescricao.Text = ltBai.Descricao;
                txtQtdDias.Text = ltBai.QtdDias.ToString();
            }

        }
        private void CarregarAtributos()
        {
            txtQtdDias.Attributes.Add("onkeypress", "return(Reais(this,event))");
        }

        private void ExibirMensagem(string mensagem)
        {
            ClientScript.RegisterStartupScript(System.Type.GetType("System.String"), "Alert",
               "<script language='javascript'> { window.alert(\"" + mensagem + "\") }</script>");
        }

        private void LimparCampos()
        {
            txtDescricao.Text = "";
            txtQtdDias.Text = "";
            lblCodigo.Text = "Código gerado automaticamente.";
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
                else
                    lblCodigo.Text = "Código gerado automaticamente.";

                txtDescricao.Focus();
            }
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewTipoObra.aspx");
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {

            TiposObrasBL tipoBL = new TiposObrasBL();
            TiposObras tipos = new TiposObras();
            tipos.Id = utils.ComparaIntComZero(hfId.Value);
            tipos.Codigo = utils.ComparaIntComZero(lblCodigo.Text);
            tipos.Descricao = txtDescricao.Text;
            tipos.QtdDias = utils.ComparaIntComZero(txtQtdDias.Text);

            if (tipos.Id > 0)
            {

                if (tipoBL.EditarBL(tipos))
                {
                    ExibirMensagem("Categoria atualizada com sucesso !");
                    txtDescricao.Focus();
                }
                else
                    ExibirMensagem("Não foi possível atualizar a categoria. Revise as informações.");


            }
            else
            {

                if (tipoBL.InserirBL(tipos))
                {
                    ExibirMensagem("Categoria gravada com sucesso !");
                    LimparCampos();
                    txtDescricao.Focus();
                }
                else
                    ExibirMensagem("Não foi possível gravar a categoria. Revise as informações.");

            }

        }
    }
}