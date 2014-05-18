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
            ScriptManager.RegisterStartupScript(
                                   updPrincipal,
                                   this.GetType(),
                                   "Alert",
                                   "window.alert(\"" + mensagem + "\");",
                                   true);
        }
        private void LimparCampos()
        {
            hfIdItem.Value = "";
            lblDesItem.Text = "";
            lblQtdAtual.Text = "";
            txtQtde.Text = "";
            txtItem.Text = "";
            txtData.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
        private void CarregarDados(int id_ItEst)
        {
            MovimentosEstoqueBL movEsBL = new MovimentosEstoqueBL();
            Int32 total = movEsBL.PesquisarTotalMovimentosBL(id_ItEst, "");

            lblQtdAtual.Text = total.ToString();
        }
        public void CarregarPesquisaItem(string conteudo)
        {
            DataTable dt = new DataTable();
            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("CODIGO", Type.GetType("System.String"));
            DataColumn coluna3 = new DataColumn("TITULO", Type.GetType("System.String"));
            DataColumn coluna4 = new DataColumn("VALOR", Type.GetType("System.Decimal"));
            DataColumn coluna5 = new DataColumn("QUANTIDADE", Type.GetType("System.String"));

            dt.Columns.Add(coluna1);
            dt.Columns.Add(coluna2);
            dt.Columns.Add(coluna3);
            dt.Columns.Add(coluna4);
            dt.Columns.Add(coluna5);

            ItensEstoqueBL itEstBL = new ItensEstoqueBL();
            ItensEstoque itEstoque = new ItensEstoque();
            List<ItensEstoque> ltItEst = itEstBL.PesquisarBuscaBL(conteudo);

            foreach (ItensEstoque litE in ltItEst)
            {
                DataRow linha = dt.NewRow();

                if (litE.Obra != null)
                {
                    linha["ID"] = litE.Id;
                    linha["CODIGO"] = litE.Obra.Codigo;
                    linha["TITULO"] = litE.Obra.Titulo;
                    linha["VALOR"] = litE.VlrVenda.ToString();
                    linha["QUANTIDADE"] = litE.QtdEstoque.ToString();

                    dt.Rows.Add(linha);
                }
            }

            grdPesquisaItem.DataSource = dt;
            grdPesquisaItem.DataBind();
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

                if (mvEstBL.InserirBL(movEstoque))
                    ExibirMensagem("Estoque atualizado com sucesso!");
                else
                    ExibirMensagem("Não foi possível gravar o movimento. Revise as informações !");

            }

            txtQtde.Text = "";
            LimparCampos();
            
        }

        protected void txtItem_TextChanged(object sender, EventArgs e)
        {
            hfIdItem.Value = "";
            ItensEstoqueBL itEstBL = new ItensEstoqueBL();
            ItensEstoque itEstoque = new ItensEstoque();
            List<ItensEstoque> ltItEst = itEstBL.PesquisarBL("CODIGO", txtItem.Text, 1);

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
            CarregarPesquisaItem(null);
            ModalPopupExtenderPesItem.Enabled = true;
            ModalPopupExtenderPesItem.Show();
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/default.aspx");
        }

        protected void btnCanelItem_Click(object sender, EventArgs e)
        {
            ModalPopupExtenderPesItem.Enabled = false;
        }

        protected void grdPesquisaItem_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                utils.CarregarEfeitoGrid("#c8defc", "#ffffff", e);
        }

        protected void btnSelectItem_Click(object sender, EventArgs e)
        {
                     
            ImageButton btndetails = sender as ImageButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;

            hfIdItem.Value = grdPesquisaItem.DataKeys[gvrow.RowIndex].Value.ToString();
            txtItem.Text = gvrow.Cells[2].Text;
            lblDesItem.Text = gvrow.Cells[3].Text;

            if (utils.ComparaIntComZero(hfIdItem.Value) > 0)
                CarregarDados(utils.ComparaIntComZero(hfIdItem.Value));

            ModalPopupExtenderPesItem.Enabled = false;
            ModalPopupExtenderPesItem.Hide();
            txtQtde.Focus();          

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            CarregarPesquisaItem(txtPesItem.Text);
            ModalPopupExtenderPesItem.Enabled = true;
            ModalPopupExtenderPesItem.Show();
            txtPesItem.Text = "";
        }

       

    }
}