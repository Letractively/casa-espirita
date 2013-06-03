using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FG;
using System.Data;
using DataObjects;
using BusinessLayer;

namespace FIBIESA
{
    public partial class cadAcertoEstoque1 : System.Web.UI.Page
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
            txtItem.Attributes.Add("onkeypress", "return(Reais(this,event))");
        }

        public void ExibirMensagem(string mensagem)
        {           
            ClientScript.RegisterStartupScript(System.Type.GetType("System.String"), "Alert",
               "<script language='javascript'> { window.alert(\"" + mensagem + "\") }</script>");
        }

        private void LimparCampos()
        {            
            hfIdItem.Value = "";
            lblDesItem.Text = "";
            lblQtdAtual.Text = "";
            txtQtde.Text = "";            
        }
        private void CarregarDados(int id_ItEst)
        {
            MovimentosEstoqueBL movEsBL = new MovimentosEstoqueBL();
            Int32 total = movEsBL.PesquisarTotalMovimentosBL(id_ItEst,"");

            lblQtdAtual.Text = total.ToString(); 
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            CarregarAtributos();
            if (!IsPostBack)
            {
                txtData.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            MovimentosEstoqueBL mvEstBL = new MovimentosEstoqueBL();
            MovimentosEstoque movEstoque = new MovimentosEstoque();

            if (Session["usuario"] != null)
            {
                List<Usuarios> usuarios;
                usuarios = (List<Usuarios>)Session["usuario"];

                foreach (Usuarios usu in usuarios)
                {
                    movEstoque.UsuarioId = usu.Id;
                }
            }
                      
            movEstoque.ItemEstoqueId = utils.ComparaIntComZero(hfIdItem.Value);
            movEstoque.Quantidade = utils.ComparaIntComZero(txtQtde.Text);
            movEstoque.Data = Convert.ToDateTime(txtData.Text);
            movEstoque.Tipo = rblTipoMov.SelectedValue;

            if (movEstoque.ItemEstoqueId > 0 && movEstoque.UsuarioId > 0)
            {
                if (this.Master.VerificaPermissaoUsuario("INSERIR"))
                    if (mvEstBL.InserirBL(movEstoque))
                        ExibirMensagem("Dados gravados com sucesso !");
                    else
                        ExibirMensagem("Não foi possível gravar o movimento. Revise as informações !");
                else
                    Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);
            }

            txtQtde.Text = "";  
            CarregarDados(utils.ComparaIntComZero(hfIdItem.Value));
           
        }

        protected void txtItem_TextChanged(object sender, EventArgs e)
        {
            hfIdItem.Value = ""; 
            ItensEstoqueBL itEstBL = new ItensEstoqueBL();
            ItensEstoque itEstoque = new ItensEstoque();
            List<ItensEstoque> ltItEst = itEstBL.PesquisarBL("CODIGO", txtItem.Text,1);
          
            foreach (ItensEstoque ltItEstoque in ltItEst)
            {                
                hfIdItem.Value = ltItEstoque.Id.ToString();
                txtItem.Text = ltItEstoque.Obra.Codigo.ToString();
                lblDesItem.Text = ltItEstoque.Obra.Titulo;
            }

            if (utils.ComparaIntComZero(hfIdItem.Value) > 0)
                CarregarDados(utils.ComparaIntComZero(hfIdItem.Value));
            else
            {
                ExibirMensagem("Item não cadastrado !");
                txtItem.Text = "";
                LimparCampos();
            }
        }

        protected void btnPesItem_Click(object sender, EventArgs e)
        {
            Session["tabelaPesquisa"] = null;
            DataTable dt = CriarDtPesquisa();
            ItensEstoqueBL itEstBL = new ItensEstoqueBL();
            ItensEstoque itEstoque = new ItensEstoque();
            List<ItensEstoque> ltItEst = itEstBL.PesquisarBL(1);

            foreach (ItensEstoque litE in ltItEst)
            {
                DataRow linha = dt.NewRow();

                if (litE.Obra != null)
                {
                    linha["ID"] = litE.Obra.Id;
                    linha["CODIGO"] = litE.Obra.Codigo;
                    linha["DESCRICAO"] = litE.Obra.Titulo;

                    dt.Rows.Add(linha);
                }

            }

            if (dt.Rows.Count > 0)
                Session["tabelaPesquisa"] = dt;


            Session["objBLPesquisa"] = itEstBL;
            Session["objPesquisa"] = itEstoque;

            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "WinOpen('/Pesquisar.aspx?caixa=" + txtItem.ClientID + "&id=" + hfIdItem.ClientID + "&lbl=" + lblDesItem.ClientID + "','',600,500);", true);
            
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/default.aspx");
        }

  
        
    }
}