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

namespace FIBIESA
{
    public partial class cadAcertoEstoque : System.Web.UI.Page
    {
        Utils utils = new Utils();
        #region funcoes
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

        private void CarregarAtributos()
        {
            txtData.Attributes.Add("onkeypress", "return(formatar(this,'##/##/####',event))");
            txtQtde.Attributes.Add("onkeypress", "return(Reais(this,event))");
            txtQtdAtual.Attributes.Add("onkeypress", "return(Reais(this,event))");
            txtItem.Attributes.Add("onkeypress", "return(Reais(this,event))");

        }

        public void ExibirMensagem(string mensagem)
        {
            ClientScript.RegisterStartupScript(System.Type.GetType("System.String"), "Alert",
               "<script language='javascript'> { window.alert(\"" + mensagem + "\") }</script>");
        }

        private void LimparCampos()
        {
            hfId.Value = "";
            lblDesItem.Text = "";
            txtData.Text = "";
            txtQtdAtual.Text = "";
            txtQtde.Text = "";            
        }
        private void CarregarDados(int id_ItEst)
        {
            MovimentosEstoqueBL movEsBL = new MovimentosEstoqueBL();
            List<MovimentosEstoque> movEstoque = movEsBL.PesquisarBL(id_ItEst);

            if (movEstoque.Count > 0)
            {
                foreach (MovimentosEstoque ltItEs in movEstoque)
                {
                    hfId.Value = ltItEs.Id.ToString();
                   // hfIdItem.Value = ltItEs.ObraId.ToString();
                    txtData.Text = ltItEs.Data.ToString("dd/MM/yyyy");
                   // txtQtdAtual.Text = ltItEs.QtdMinima.ToString();                    
                }
            }
            else
            {
                hfIdItem.Value = "";
                txtItem.Text = "";
                LimparCampos();
                ExibirMensagem("Item não cadastrado !");
            }

        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtData.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
        }

        protected void btnPesItem_Click(object sender, EventArgs e)
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

            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "WinOpen('/Pesquisar.aspx?caixa=" + txtItem.ClientID + "&id=" + hfIdItem.ClientID + "&lbl=" + lblDesItem.ClientID + "','',600,500);", true);

        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/default.aspx");
        }

        protected void txtItem_TextChanged(object sender, EventArgs e)
        {
            LimparCampos();
            ObrasBL obrBL = new ObrasBL();
            List<Obras> obras = obrBL.PesquisarBL("CODIGO", txtItem.Text);

            lblDesItem.Text = "";
            hfIdItem.Value = "";
            foreach (Obras ltObr in obras)
            {
                hfIdItem.Value = ltObr.Id.ToString();
                lblDesItem.Text = ltObr.Titulo;
            }

            CarregarDados(utils.ComparaIntComZero(hfIdItem.Value));
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            MovimentosEstoqueBL mvEstBL = new MovimentosEstoqueBL();
            MovimentosEstoque movEstoque = new MovimentosEstoque();

            movEstoque.Id = utils.ComparaIntComZero(hfId.Value);
            movEstoque.ItemEstoqueId = utils.ComparaIntComZero(hfIdItem.Value);
            movEstoque.Quantidade = utils.ComparaIntComZero(txtQtde.Text);
            movEstoque.Data = Convert.ToDateTime(txtData.Text);
            movEstoque.Tipo = rblTipoMov.SelectedValue;

            if (movEstoque.Id > 0)
            {
                if (this.Master.VerificaPermissaoUsuario("EDITAR"))
                {
                    if (mvEstBL.EditarBL(movEstoque))
                        ExibirMensagem("Atualização realizada com sucesso !");
                    else
                        ExibirMensagem("Não foi possível atualizar as informações. Revise as informações !");
                }
                else
                    Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);

            }
            else
            {
                if (this.Master.VerificaPermissaoUsuario("INSERIR"))
                    if (mvEstBL.InserirBL(movEstoque))
                        ExibirMensagem("Atualização realizada com sucesso !");
                    else
                        ExibirMensagem("Não foi possível atualizar as informações. Revise as informações !");
                else
                    Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);
            }
        }
    }
}