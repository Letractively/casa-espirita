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
    public partial class cadEditora : System.Web.UI.Page
    {
        Utils utils = new Utils();
        string v_operacao = "";

        #region funcoes
        public DataTable dtbPesquisa
        {
            get
            {
                if (Session["_dtbPesquisa_cadEditoras"] != null)
                    return (DataTable)Session["_dtbPesquisa_cadEditoras"];
                else
                    return null;
            }
            set { Session["_dtbPesquisa_cadEditoras"] = value; }
        }

        private void CarregarDados(int id_bai)
        {
            EditorasBL edBL = new EditorasBL();
            List<Editoras> editora = edBL.PesquisarBL(id_bai);

            foreach (Editoras ltBai in editora)
            {
                hfId.Value = ltBai.Id.ToString();
                lblCodigo.Text = ltBai.Codigo.ToString();
                txtDescricao.Text = ltBai.Descricao;
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
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            int id_bai = 0;

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
            Response.Redirect("viewEditora.aspx");
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {

            EditorasBL edBL = new EditorasBL();
            Editoras editoras = new Editoras();
            editoras.Id = utils.ComparaIntComZero(hfId.Value);
            editoras.Codigo = utils.ComparaIntComZero(lblCodigo.Text);
            editoras.Descricao = txtDescricao.Text;

            if (editoras.Id > 0)
            {

                if (edBL.EditarBL(editoras))
                    ExibirMensagem("Editora atualizada com sucesso !");
                else
                    ExibirMensagem("Não foi possível atualizar a editora. Revise as informações.");

            }
            else
            {
                if (edBL.InserirBL(editoras))
                {
                    ExibirMensagem("Editora gravada com sucesso !");
                    LimparCampos();
                    txtDescricao.Focus();
                }
                else
                    ExibirMensagem("Não foi possível gravar a editora. Revise as informações.");

            }
        }
    }
}