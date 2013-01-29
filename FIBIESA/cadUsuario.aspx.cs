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
                txtSenha.Text = usu.Senha;
                txtDtInicio.Text = usu.DtInicio.ToString();
                txtDtFim.Text = usu.DtFim.ToString();
                ddlStatus.SelectedValue = usu.Status.ToString();                
            }

        }
        private void CarregarAtributos()
        {
            txtDtInicio.Attributes.Add("onkeypress", "return(formatar(this,'##/##/####',event))");
            txtDtFim.Attributes.Add("onkeypress", "return(formatar(this,'##/##/####',event))");
            txtPessoa.Attributes.Add("onkeypress", "return(Inteiros(this,event))");
        }
        private DataTable CriarDtPesquisa()
        {
            DataTable dt = new DataTable();
            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("CODIGO", Type.GetType("System.String"));
            DataColumn coluna3 = new DataColumn("DESCRICAO", Type.GetType("System.String"));

            dt.Columns.Add(coluna1);
            dt.Columns.Add(coluna2);
            dt.Columns.Add(coluna3);

            return dt;
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

                if (v_operacao.ToLower() == "edit")
                    CarregarDados(id_usu);
            }
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewUsuario.aspx");
        }

        protected void btnPesPessoa_Click(object sender, EventArgs e)
        {
            Session["tabelaPesquisa"] = null;
            DataTable dt = CriarDtPesquisa();
            PessoasBL pesBL = new PessoasBL();
            Pessoas pe = new Pessoas();
            List<Pessoas> pessoas = pesBL.PesquisarBL();

            foreach (Pessoas pes in pessoas)
            {
                DataRow linha = dt.NewRow();

                linha["ID"] = pes.Id;
                linha["CODIGO"] = pes.Codigo;
                linha["DESCRICAO"] = pes.Nome;

                dt.Rows.Add(linha);
            }

            if (dt.Rows.Count > 0)
                Session["tabelaPesquisa"] = dt;


            Session["objBLPesquisa"] = pesBL;
            Session["objPesquisa"] = pe;

            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "WinOpen('/Pesquisar.aspx?caixa=" + txtPessoa.ClientID + "&id=" + hfIdPessoa.ClientID + "&lbl=" + lblDesPessoa.ClientID + "','',600,500);", true);
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            UsuariosBL usuBL = new UsuariosBL();
            Usuarios usuarios = new Usuarios();

            usuarios.Id = utils.ComparaIntComZero(hfId.Value);
            usuarios.PessoaId = utils.ComparaIntComZero(hfIdPessoa.Value);
            usuarios.Nome = txtNome.Text;
            usuarios.Email = txtEmail.Text;
            usuarios.Login = txtLogin.Text;
            usuarios.Senha = txtSenha.Text;
            usuarios.Status = ddlStatus.SelectedItem.Text;
            usuarios.DtInicio = Convert.ToDateTime(txtDtInicio.Text);
            usuarios.DtFim = Convert.ToDateTime(txtDtFim.Text);
            usuarios.CategoriaId = utils.ComparaIntComZero(hfIdCategoria.Value);

            if (usuarios.Id > 0)
                usuBL.EditarBL(usuarios);
            else
                usuBL.InserirBL(usuarios);
        }

        protected void btnPesCategoria_Click(object sender, EventArgs e)
        {
            Session["tabelaPesquisa"] = null;
            DataTable dt = CriarDtPesquisa();
            CategoriasBL catBL = new CategoriasBL();
            Categorias ca = new Categorias();
            List<Categorias> categorias = catBL.PesquisarBL();

            foreach (Categorias cat in categorias)
            {
                DataRow linha = dt.NewRow();

                linha["ID"] = cat.Id;
                linha["CODIGO"] = cat.Codigo;
                linha["DESCRICAO"] = cat.Descricao;

                dt.Rows.Add(linha);
            }

            if (dt.Rows.Count > 0)
                Session["tabelaPesquisa"] = dt;


            Session["objBLPesquisa"] = catBL;
            Session["objPesquisa"] = ca;

            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "WinOpen('/Pesquisar.aspx?caixa=" + txtCategoria.ClientID + "&id=" + hfIdCategoria.ClientID + "&lbl=" + lblDesCategoria.ClientID + "','',600,500);", true);
        }
              
               
    }
}