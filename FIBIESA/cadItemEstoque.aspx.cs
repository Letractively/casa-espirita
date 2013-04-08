using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataObjects;
using BusinessLayer;
using System.Data;
using FG;

namespace Admin
{
    public partial class cadItemEstoque : System.Web.UI.Page
    {
        Utils utils = new Utils();
  
        #region
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
            txtQtd.Attributes.Add("onkeypress", "return(Reais(this,event))");
            txtQtdMin.Attributes.Add("onkeypress", "return(Reais(this,event))");
            txtVlrMedio.Attributes.Add("onkeypress", "return(Reais(this,event))");
            txtVlrVenda.Attributes.Add("onkeypress", "return(Reais(this,event))");         
            btnExcluir.Attributes.Add("onclick", "return confirm('Deseja excluir as informações ?');"); 
        }
        private void CarregarDados(int id_obra)
        {
            ItensEstoqueBL itEsBL = new ItensEstoqueBL();
            List<ItensEstoque> itensEstoque = itEsBL.PesquisarMovObraBL(id_obra);

            if (itensEstoque.Count > 0)
            {
                foreach (ItensEstoque ltItEs in itensEstoque)
                {
                    hfId.Value = ltItEs.Id.ToString();
                    hfIdItem.Value = ltItEs.ObraId.ToString();
                    txtData.Text = ltItEs.Data.ToString("dd/MM/yyyy");
                    txtQtdMin.Text = ltItEs.QtdMinima.ToString();
                    txtVlrMedio.Text = ltItEs.VlrCusto.ToString();
                    txtVlrVenda.Text = ltItEs.VlrVenda.ToString();
                    chkControlaEstoque.Checked = ltItEs.ControlaEstoque;
                    ddlStatus.SelectedValue = ltItEs.Status == true ? "A" : "I";
                }
            }
            else
            {
                hfIdItem.Value = "";
                txtItem.Text = "";
                ExibirMensagem("Item não cadastrado !");
            }

        }
        private void LimparCampos()
        {
            hfId.Value = "";
            lblDesItem.Text = "";
            txtData.Text = "";            
            txtQtd.Text = "";
            txtQtdMin.Text = "";
            txtVlrMedio.Text = "";
            txtVlrVenda.Text = "";
            chkControlaEstoque.Checked = false;
            ddlStatus.SelectedValue = "I";
        }
        public void ExibirMensagem(string mensagem)
        {
            ClientScript.RegisterStartupScript(System.Type.GetType("System.String"), "Alert",
               "<script language='javascript'> { window.alert(\"" + mensagem + "\") }</script>");
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            CarregarAtributos();
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

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/default.aspx");
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            ItensEstoqueBL itEsBL = new ItensEstoqueBL();
            ItensEstoque itEstoque = new ItensEstoque();
            itEstoque.Id = utils.ComparaIntComZero(hfId.Value);
            itEstoque.ObraId = utils.ComparaIntComZero(hfIdItem.Value);
            itEstoque.Data = Convert.ToDateTime(txtData.Text);
            itEstoque.QtdMinima = utils.ComparaIntComZero(txtQtdMin.Text);
            itEstoque.VlrCusto = utils.ComparaDecimalComZero(txtVlrMedio.Text);
            itEstoque.VlrVenda = utils.ComparaDecimalComZero(txtVlrVenda.Text);
            itEstoque.ControlaEstoque = chkControlaEstoque.Checked;
            itEstoque.Status = ddlStatus.SelectedValue == "A"? true : false;
            
            if (itEstoque.Id > 0)
            {
                if (this.Master.VerificaPermissaoUsuario("EDITAR"))
                {
                    if (itEsBL.EditarBL(itEstoque))
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
                    if(itEsBL.InserirBL(itEstoque))
                        ExibirMensagem("Atualização realizada com sucesso !");
                    else
                        ExibirMensagem("Não foi possível atualizar as informações. Revise as informações !");
                else
                    Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);
            }
                       
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {   
            if (this.Master.VerificaPermissaoUsuario("EXCLUIR"))
            {
               ItensEstoqueBL itEsBL = new ItensEstoqueBL();
               ItensEstoque itEstoque = new ItensEstoque();
               itEstoque.Id = utils.ComparaIntComZero(hfId.Value);
               if (itEstoque.Id > 0)
               {
                   if (itEsBL.ExcluirBL(itEstoque))
                       ExibirMensagem("Informações excluídas com sucesso !");
                   hfIdItem.Value = "";
                   txtItem.Text = "";                   
                   LimparCampos();
               }
            }
            else
                Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);
        }
    }
}