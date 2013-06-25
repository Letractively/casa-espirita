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
        Utils utils = new Utils();
        string v_operacao = "";

        #region funcoes
        private void CarregarDados(int id_bai)
        {
            AutoresBL auBL = new AutoresBL();
            List<Autores> autores = auBL.PesquisarBL(id_bai);

            foreach (Autores ltAutor in autores)
            {
                hfId.Value = ltAutor.Id.ToString();
                lblCodigo.Text = ltAutor.Codigo.ToString();
                txtDescricao.Text = ltAutor.Descricao;
                ddlTiposAutores.SelectedValue = ltAutor.TipoId.ToString();
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
            ddlTiposAutores.SelectedIndex = 0;
        }
        #endregion

        private void CarregaTiposAutores()
        {
            TiposDeAutoresBL tipos = new TiposDeAutoresBL();
            List<TiposDeAutores> listao = tipos.PesquisarBL();

            ddlTiposAutores.Items.Clear();
            ddlTiposAutores.Items.Add(new ListItem("Selecione", ""));
            foreach (TiposDeAutores tp in listao)
            {
                ddlTiposAutores.Items.Add(new ListItem(tp.Descricao, tp.Id.ToString()));
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
                else
                    lblCodigo.Text = "Código gerado automaticamente.";

                txtDescricao.Focus();
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
            aut.Codigo = utils.ComparaIntComZero(lblCodigo.Text);
            aut.Descricao = txtDescricao.Text;
            aut.TipoId = utils.ComparaIntComZero(ddlTiposAutores.SelectedValue);

            if (aut.Id > 0)
            {

                if (auBL.EditarBL(aut))
                    ExibirMensagem("Autor atualizado com sucesso !");
                else
                    ExibirMensagem("Não foi possível atualizar o autor. Revise as informações.");
            }
            else
            {

                if (auBL.InserirBL(aut))
                {
                    ExibirMensagem("Autor gravado com sucesso !");
                    LimparCampos();
                    txtDescricao.Focus();
                }
                else
                    ExibirMensagem("Não foi possível gravar o autor. Revise as informações.");

            }
        }
    }
}