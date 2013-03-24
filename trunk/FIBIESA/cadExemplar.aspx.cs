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
       
        private void CarregarDados(int id_exe)
        {

            ExemplaresBL exeBL = new ExemplaresBL();
            List<Exemplares> exemplares = exeBL.PesquisarBL(id_exe);

            foreach (Exemplares ltExe in exemplares)
            {
                hfId.Value = ltExe.Id.ToString();
                txtTombo.Text = ltExe.Tombo.ToString();
                ddlStatus.SelectedValue = ltExe.Status;
                hfIdObra.Value = ltExe.Obraid.ToString();

                if (ltExe.Obras != null)
                {                   
                    txtObra.Text = ltExe.Obras.Codigo.ToString();
                    lblDesObra.Text = ltExe.Obras.Titulo;
                }
            }

        }

        private void CarregarAtributos()
        {
           txtTombo.Attributes.Add("onkeypress", "return(Inteiros(this,event))");
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
            int id_exe = 0;

            CarregarAtributos();

            if (!IsPostBack)
            {

                if (Request.QueryString["operacao"] != null)
                {
                    v_operacao = Request.QueryString["operacao"];

                    if (v_operacao == "edit")
                        if (Request.QueryString["id_exem"] != null)
                            id_exe = Convert.ToInt32(Request.QueryString["id_exem"].ToString());
                }

                if (v_operacao.ToLower() == "edit")
                    CarregarDados(id_exe);
            }
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewExemplar.aspx");
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {

            ExemplaresBL exeBL = new ExemplaresBL();
            Exemplares exemplares = new Exemplares();
            exemplares.Id = utils.ComparaIntComZero(hfId.Value);
            exemplares.Obraid = utils.ComparaIntComZero(hfIdObra.Value);
            exemplares.Tombo = utils.ComparaIntComZero(txtTombo.Text);
            exemplares.Status = ddlStatus.SelectedValue;

            if (exemplares.Id > 0)
            {
                if (this.Master.VerificaPermissaoUsuario("EDITAR"))
                    exeBL.EditarBL(exemplares);
                else
                    Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);

            }
            else
            {
                if (this.Master.VerificaPermissaoUsuario("INSERIR"))
                    exeBL.InserirBL(exemplares);
                else
                    Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);
            }

            Response.Redirect("viewExemplar.aspx");
        }

        protected void btnPesObra_Click(object sender, EventArgs e)
        {
            Session["tabelaPesquisa"] = null;
            DataTable dt = CriarDtPesquisa();
            ObrasBL obBL = new ObrasBL();
            Obras obr = new Obras();
            List<Obras> obras = obBL.PesquisarBL();

            foreach (Obras ltobr in obras)
            {
                DataRow linha = dt.NewRow();

                linha["ID"] = ltobr.Id;
                linha["CODIGO"] = ltobr.Codigo;
                linha["DESCRICAO"] = ltobr.Titulo;

                dt.Rows.Add(linha);
            }

            if (dt.Rows.Count > 0)
                Session["tabelaPesquisa"] = dt;


            Session["objBLPesquisa"] = obBL;
            Session["objPesquisa"] = obr;

            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "WinOpen('/Pesquisar.aspx?caixa=" + txtObra.ClientID + "&id=" + hfIdObra.ClientID + "&lbl=" + lblDesObra.ClientID + "','',600,500);", true);
        }

       
    }
}