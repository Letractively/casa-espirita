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
    public partial class cadBairro : System.Web.UI.Page
    {
        Utils utils = new Utils();
        string v_operacao = "";

        #region funcoes

        private void CarregarDados(int id_bai)
        {
            BairrosBL baiBL = new BairrosBL();
            List<Bairros> bairros = baiBL.PesquisarBL(id_bai);

            foreach (Bairros ltBai in bairros)
            {
                hfId.Value = ltBai.Id.ToString();
                lblCodigo.Text = ltBai.Codigo.ToString();
                txtDescricao.Text = ltBai.Descricao;

                if (ltBai.Cidade != null)
                {
                    ddlUf.SelectedValue = ltBai.Cidade.EstadoId.ToString();
                    CarregarDdlCidade(utils.ComparaIntComZero(ddlUf.SelectedValue));
                }

                ddlCidade.SelectedValue = ltBai.CidadeId.ToString();
            }

        }

        private void CarregarDdlUF()
        {
            EstadosBL estBL = new EstadosBL();
            List<Estados> estados = estBL.PesquisarBL();

            ddlUf.Items.Add(new ListItem("Selecione", ""));
            foreach (Estados ltUF in estados)
                ddlUf.Items.Add(new ListItem(ltUF.Uf + " - " + ltUF.Descricao, ltUF.Id.ToString()));

            ddlUf.SelectedIndex = 0;
        }

        private void CarregarDdlCidade(int id_uf)
        {
            CidadesBL cidBL = new CidadesBL();
            List<Cidades> cidades = cidBL.PesquisaCidUfDA(id_uf);

            ddlCidade.Items.Clear();
            ddlCidade.Items.Add(new ListItem("Selecione", ""));
            foreach (Cidades ltCid in cidades)
                ddlCidade.Items.Add(new ListItem(ltCid.Descricao, ltCid.Id.ToString()));

            ddlCidade.SelectedIndex = 0;
        }

        private void ExibirMensagem(string mensagem)
        {
            ScriptManager.RegisterStartupScript(
                                    updPrincipal,
                                    this.GetType(),
                                    "Alert",
                                    "window.alert(\"" + mensagem + "\");",
                                    true);
        }

        private void LimparCampos()
        {
            txtDescricao.Text = "";
            ddlUf.SelectedIndex = 0;
            ddlCidade.Items.Clear();
            lblCodigo.Text = "Código gerado automaticamente.";
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            int id_bai = 0;

            if (!IsPostBack)
            {
                CarregarDdlUF();

                if (Request.QueryString["operacao"] != null && Request.QueryString["id_bai"] != null)
                {
                    v_operacao = Request.QueryString["operacao"];

                    if (v_operacao == "edit")
                    {
                        id_bai = Convert.ToInt32(Request.QueryString["id_bai"].ToString());
                        CarregarDados(id_bai);
                    }
                }
                else
                    lblCodigo.Text = "Código gerado automaticamente.";

                txtDescricao.Focus();
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
            bairros.Codigo = utils.ComparaIntComZero(lblCodigo.Text);
            bairros.Descricao = txtDescricao.Text;
            bairros.CidadeId = utils.ComparaIntComNull(ddlCidade.SelectedValue);

            if (bairros.Id > 0)
            {

                if (baiBL.EditarBL(bairros))
                    ExibirMensagem("Bairro atualizado com sucesso !");
                else
                    ExibirMensagem("Não foi possível atualizar o bairro. Revise as informações.");


            }
            else
            {
                if (baiBL.InserirBL(bairros))
                {
                    ExibirMensagem("Bairro gravado com sucesso !");
                    LimparCampos();
                    txtDescricao.Focus();
                }
                else
                    ExibirMensagem("Não foi possível gravar o bairro. Revise as informações.");

            }

        }

        protected void ddlUf_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarDdlCidade(utils.ComparaIntComZero(ddlUf.SelectedValue));
            ddlCidade.Focus();
        }

    }
}