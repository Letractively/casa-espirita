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
    public partial class cadUsuario : System.Web.UI.Page
    {
        Utils utils = new Utils();
        string v_operacao = "";
        #region funcoes
        private void CarregarDDLCategoria()
        {
            CategoriasBL catBL = new CategoriasBL();
            List<Categorias> categorias = catBL.PesquisarBL();

            ddlCategoria.Items.Add(new ListItem("Selecione", ""));
            foreach (Categorias ltCat in categorias)
                ddlCategoria.Items.Add(new ListItem(ltCat.Codigo.ToString() + " - " + ltCat.Descricao, ltCat.Id.ToString()));

            ddlCategoria.SelectedIndex = 0;

        }
        private void CarregarDados(int id_usu)
        {
            UsuariosBL usuBL = new UsuariosBL();
            List<Usuarios> usuarios = usuBL.PesquisarBL(id_usu);

            foreach (Usuarios usu in usuarios)
            {
                hfId.Value = usu.Id.ToString();
                hfIdPessoa.Value = usu.PessoaId.ToString();
                txtNome.Text = usu.Nome;
                txtEmail.Text = usu.Email;
                txtLogin.Text = usu.Login;
                txtDtInicio.Text = usu.DtInicio.ToString("dd/MM/yyyy");
                txtDtFim.Text = usu.DtFim.ToString("dd/MM/yyyy");
                ddlStatus.SelectedValue = usu.Status.ToString();
                txtSenha.Attributes.Add("value", usu.Senha);
                txtConfirmarSenha.Attributes.Add("value", usu.Senha);


                if (usu.Categoria != null)
                    ddlCategoria.SelectedValue = usu.CategoriaId.ToString();

                if (usu.Pessoa != null)
                {
                    txtPessoa.Text = usu.Pessoa.Codigo.ToString();
                    lblDesPessoa.Text = usu.Pessoa.Nome;
                }
            }

        }
        private void CarregarAtributos()
        {
            txtDtInicio.Attributes.Add("onkeypress", "return(formatar(this,'##/##/####',event))");
            txtDtFim.Attributes.Add("onkeypress", "return(formatar(this,'##/##/####',event))");
            txtPessoa.Attributes.Add("onkeypress", "return(Inteiros(this,event))");
        }

        public void ExibirMensagem(string mensagem)
        {
            ScriptManager.RegisterStartupScript(
                                    upnlPesquisa,
                                    this.GetType(),
                                    "Alert",
                                    "window.alert(\"" + mensagem + "\");",
                                    true);
        }

        private void LimparCampos()
        {
            txtPessoa.Text = "";
            hfId.Value = "";
            hfIdPessoa.Value = "";
            lblDesPessoa.Text = "";
            txtNome.Text = "";
            txtEmail.Text = "";
            txtSenha.Text = "";
            txtConfirmarSenha.Text = "";
            txtDtInicio.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtDtFim.Text = DateTime.Now.AddYears(1).ToString("dd/MM/yyyy");
            txtLogin.Text = "";
            ddlCategoria.SelectedIndex = 0;
            ddlStatus.SelectedIndex = 0;
        }

        public void CarregarPesquisaPessoa(string conteudo)
        {
            DataTable dt = new DataTable();
            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("CODIGO", Type.GetType("System.String"));
            DataColumn coluna3 = new DataColumn("NOME", Type.GetType("System.String"));

            dt.Columns.Add(coluna1);
            dt.Columns.Add(coluna2);
            dt.Columns.Add(coluna3);

            PessoasBL pesBL = new PessoasBL();
            Pessoas pe = new Pessoas();
            List<Pessoas> pessoas = pesBL.PesquisarBuscaBL(conteudo);

            foreach (Pessoas pes in pessoas)
            {
                DataRow linha = dt.NewRow();

                linha["ID"] = pes.Id;
                linha["CODIGO"] = pes.Codigo;
                linha["NOME"] = pes.Nome;

                dt.Rows.Add(linha);
            }


            grdPesquisa.DataSource = dt;
            grdPesquisa.DataBind();
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            int id_usu = 0;
            CarregarAtributos();
            if (!IsPostBack)
            {
                if (Request.QueryString["operacao"] != null)
                {
                    v_operacao = Request.QueryString["operacao"];

                    if (v_operacao == "edit")
                        if (Request.QueryString["id_usu"] != null)
                            id_usu = Convert.ToInt32(Request.QueryString["id_usu"].ToString());
                }

                CarregarDDLCategoria();

                if (v_operacao.ToLower() == "edit")
                    CarregarDados(id_usu);
                else
                {
                    txtDtInicio.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    txtDtFim.Text = DateTime.Now.AddYears(1).ToString("dd/MM/yyyy");
                }

                txtPessoa.Focus();
            }
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewUsuario.aspx");
        }

        protected void btnPesPessoa_Click(object sender, EventArgs e)
        {
            CarregarPesquisaPessoa(null);
            ModalPopupExtenderPessoa.Enabled = true;
            ModalPopupExtenderPessoa.Show();
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            UsuariosBL usuBL = new UsuariosBL();
            Usuarios usuarios = new Usuarios();

            usuarios.Id = utils.ComparaIntComZero(hfId.Value);
            usuarios.PessoaId = utils.ComparaIntComNull(hfIdPessoa.Value);
            usuarios.Nome = txtNome.Text;
            usuarios.Email = txtEmail.Text;
            usuarios.Login = txtLogin.Text;
            usuarios.Senha = txtSenha.Text;
            usuarios.Status = ddlStatus.SelectedValue;
            usuarios.DtInicio = Convert.ToDateTime(txtDtInicio.Text);
            usuarios.DtFim = Convert.ToDateTime(txtDtFim.Text);
            usuarios.CategoriaId = utils.ComparaIntComZero(ddlCategoria.SelectedValue);

            if (usuarios.Id > 0)
            {

                if (usuBL.EditarBL(usuarios))
                    ExibirMensagem("Usuário atualizado com sucesso !");
                else
                    ExibirMensagem("Não foi possível atualizar o usuário. Revise as informações.");

            }
            else
            {
                if (usuarios.Senha == null || usuarios.Senha == string.Empty)
                {
                    lblInformacao.Text = "* Informe a senha";
                    txtSenha.Focus();
                    
                }
                else
                {
                    lblInformacao.Text = "";
                    if (usuBL.InserirBL(usuarios))
                    {
                        ExibirMensagem("Usuário gravado com sucesso !");
                        LimparCampos();
                    }
                }

            }
        }

        protected void txtPessoa_TextChanged(object sender, EventArgs e)
        {
            hfIdPessoa.Value = "";
            PessoasBL pesBL = new PessoasBL();
            Pessoas pessoa = new Pessoas();
            List<Pessoas> pes = pesBL.PesquisarBL("CODIGO", txtPessoa.Text);

            foreach (Pessoas ltpessoa in pes)
            {
                hfIdPessoa.Value = ltpessoa.Id.ToString();
                txtPessoa.Text = ltpessoa.Codigo.ToString();
                lblDesPessoa.Text = ltpessoa.Nome;
                txtNome.Text = ltpessoa.Nome;
                ddlCategoria.Focus();
            }

            if (utils.ComparaIntComZero(hfIdPessoa.Value) <= 0)
            {
                ExibirMensagem("Pessoa não cadastrada !");
                txtPessoa.Text = "";
                lblDesPessoa.Text = "";
                txtPessoa.Focus();
                hfIdPessoa.Value = "";
            }
        }

        protected void btnCanel_Click(object sender, EventArgs e)
        {
            ModalPopupExtenderPessoa.Enabled = false;
        }

        protected void grdPesquisa_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                utils.CarregarEfeitoGrid("#c8defc", "#ffffff", e);
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {

            ImageButton btndetails = sender as ImageButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;

            hfIdPessoa.Value = grdPesquisa.DataKeys[gvrow.RowIndex].Value.ToString();
            txtPessoa.Text = gvrow.Cells[2].Text;
            lblDesPessoa.Text = gvrow.Cells[3].Text;
            txtNome.Text = lblDesPessoa.Text;

            ModalPopupExtenderPessoa.Hide();
            ModalPopupExtenderPessoa.Enabled = false;

        }

        protected void txtPesPessoa_TextChanged(object sender, EventArgs e)
        {
            CarregarPesquisaPessoa(txtPesPessoa.Text);
            ModalPopupExtenderPessoa.Enabled = true;
            ModalPopupExtenderPessoa.Show();
            txtPesPessoa.Text = "";
        }
    }
}