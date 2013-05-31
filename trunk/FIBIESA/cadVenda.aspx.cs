using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DataObjects;
using BusinessLayer;
using FG;

namespace FIBIESA
{
    public partial class cadVenda : System.Web.UI.Page
    {

        DataTable dtItens = new DataTable();
        Utils utils = new Utils();
        #region funcoes
        public void CarregarPesquisaPessoa(string conteudo)
        {
            DataTable dt = new DataTable();
            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("CODIGO", Type.GetType("System.String"));
            DataColumn coluna3 = new DataColumn("DESCRICAO", Type.GetType("System.String"));

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
                linha["DESCRICAO"] = pes.Nome;

                dt.Rows.Add(linha);
            }


            grdPesquisa.DataSource = dt;
            grdPesquisa.DataBind();
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
        
        private DataTable CriarTabelaPesquisa()
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

        private void CriarDtItens()
        {
            DataColumn[] keys = new DataColumn[1];

            if (dtItens.Columns.Count == 0)
            {
                DataColumn coluna1 = new DataColumn("IDORDEM", Type.GetType("System.Int32"));
                DataColumn coluna2 = new DataColumn("ITEMESTOQUEID", Type.GetType("System.Int32"));
                DataColumn coluna3 = new DataColumn("QUANTIDADE", Type.GetType("System.Int32"));
                DataColumn coluna4 = new DataColumn("VALOR", Type.GetType("System.Decimal"));
                DataColumn coluna5 = new DataColumn("VALORUNI", Type.GetType("System.Decimal"));
                DataColumn coluna6 = new DataColumn("DESCONTO", Type.GetType("System.Decimal"));
                DataColumn coluna7 = new DataColumn("CODIGO", Type.GetType("System.Int32"));
                DataColumn coluna8 = new DataColumn("DESCRICAO", Type.GetType("System.String"));

                dtItens.Columns.Add(coluna1);
                dtItens.Columns.Add(coluna2);
                dtItens.Columns.Add(coluna3);
                dtItens.Columns.Add(coluna4);
                dtItens.Columns.Add(coluna5);
                dtItens.Columns.Add(coluna6);
                dtItens.Columns.Add(coluna7);
                dtItens.Columns.Add(coluna8);

                keys[0] = coluna1;

                dtItens.PrimaryKey = keys;
            }
        }

        private void LimparCampos()
        {
            txtItem.Text = "";
            hfIdItem.Value = "";
            lblValor.Text = "0,00";
            txtQuantidade.Text = "1";
            txtValorUni.Text = "";
            txtDesconto.Text = "";
            lblDesItem.Text = "";
        }

        private void LimparCamposGeral()
        {
            LimparCampos();
            txtValorTotal.Text = "";
            txtQtdItens.Text = "";
            txtCliente.Text = "";
            lblDesCliente.Text = "";
            hfIdPessoa.Value = "";
            Session["dtItens"] = null;
            dtgItens.DataSource = null;
            dtgItens.DataBind(); 
        }

        public void ExibirMensagem(string mensagem)
        {
            ClientScript.RegisterStartupScript(System.Type.GetType("System.String"), "Alert",
               "<script language='javascript'> { window.alert(\"" + mensagem + "\") }</script>");
        }

        private void CarregarAtributos()
        {
            txtQuantidade.Attributes.Add("onkeypress", "return(Reais(this,event))");
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            CriarDtItens();

            if (!IsPostBack)
            {
                CarregarAtributos();
                Session["dtItens"] = null;
                hfOrdem.Value = "1";
                txtQuantidade.Text = "1";
                lblValor.Text = "0,00";
                txtCliente.Focus();
            }           
     
        }
       
        protected void btnPesItem_Click(object sender, EventArgs e)
        {
            CarregarPesquisaItem(null);
            ModalPopupExtenderPesItem.Enabled = true;
            ModalPopupExtenderPesItem.Show();        
        }

        protected void btnPesCliente_Click(object sender, EventArgs e)
        {
            CarregarPesquisaPessoa(null);
            ModalPopupExtenderPesquisa.Enabled = true;
            ModalPopupExtenderPesquisa.Show(); 
        }

        protected void btnInserir_Click(object sender, EventArgs e)
        {
            if (Session["dtItens"] != null)
                dtItens = (DataTable)Session["dtItens"];

            DataRow linha = dtItens.NewRow();

            object key = new object();
            key = utils.ComparaIntComZero(hfOrdem.Value);

            linha["IDORDEM"] = key.ToString();
            linha["ITEMESTOQUEID"] = hfIdItem.Value;
            linha["QUANTIDADE"] = txtQuantidade.Text;            
            linha["VALOR"] = utils.ComparaDecimalComZero(txtValorUni.Text) * utils.ComparaDecimalComZero(txtQuantidade.Text) - utils.ComparaDecimalComZero(txtDesconto.Text);
            linha["VALORUNI"] = utils.ComparaDecimalComZero(txtValorUni.Text); 
            linha["DESCONTO"] = utils.ComparaIntComZero(txtDesconto.Text);
            linha["CODIGO"] = txtItem.Text;
            linha["DESCRICAO"] = lblDesItem.Text;

            dtItens.Rows.Add(linha);

            Session["dtItens"] = dtItens;
            dtgItens.DataSource = dtItens;
            dtgItens.DataBind();

            LimparCampos();
            txtQtdItens.Text = dtItens.Compute("sum(QUANTIDADE)", "").ToString();
            txtValorTotal.Text = dtItens.Compute("sum(VALOR)", "").ToString();
            hfOrdem.Value = (utils.ComparaIntComZero(hfOrdem.Value) + 1).ToString(); //proxima ordem 
        }

        protected void btnFinalizar_Click(object sender, EventArgs e)
        {
            VendasBL venEBL = new VendasBL();
            Vendas vendas = new Vendas();
            VendaItensBL venItBL = new VendaItensBL();
            VendaItens vendaItens = new VendaItens();
            MovimentosEstoqueBL movEstBL = new MovimentosEstoqueBL();
            MovimentosEstoque movEstoque = new MovimentosEstoque();
            int usu_id = 0;

            vendas.Data = DateTime.Now;
            vendas.Situacao = "A";
            vendas.PessoaId = utils.ComparaIntComZero(hfIdPessoa.Value);
            
            if (Session["usuario"] != null)
            {
                List<Usuarios> usuarios;
                usuarios = (List<Usuarios>)Session["usuario"];
                
                foreach (Usuarios usu in usuarios)
                {
                    usu_id = usu.Id;
                }

                vendas.UsuarioId = usu_id;
            }
      
            if (Session["dtItens"] != null)
                dtItens = (DataTable)Session["dtItens"];

            if (this.Master.VerificaPermissaoUsuario("INSERIR"))
            {
                if (dtItens.Rows.Count > 0)
                {
                    int id = venEBL.InserirBL(vendas);

                    if (id > 0)
                    {
                        foreach (DataRow linha in dtItens.Rows)
                        {
                            vendaItens.VendaId = id;
                            vendaItens.ItemEstoqueId = utils.ComparaIntComZero(linha["ITEMESTOQUEID"].ToString());
                            vendaItens.Quantidade = utils.ComparaIntComZero(linha["QUANTIDADE"].ToString());
                            vendaItens.Valor = utils.ComparaDecimalComZero(linha["VALOR"].ToString());
                            vendaItens.Situacao = "A";
                            vendaItens.Desconto = utils.ComparaDecimalComZero(linha["DESCONTO"].ToString());

                            Int32 ven_item =  venItBL.InserirBL(vendaItens);

                            if (ven_item > 0)
                            {
                                
                                movEstoque.UsuarioId = usu_id;
                                movEstoque.ItemEstoqueId = vendaItens.ItemEstoqueId;
                                movEstoque.Quantidade = vendaItens.Quantidade;
                                movEstoque.Data = DateTime.Now;
                                movEstoque.Tipo = "S";
                                movEstoque.VendaItensId = ven_item;

                                if (movEstoque.ItemEstoqueId > 0 && movEstoque.UsuarioId > 0)
                                    movEstBL.InserirBL(movEstoque);                               
                            }
                            
                        }

                        if (id > 0)
                        {                          
                            if(chkImprimirRec.Checked)                                                                                                                                                                                                                                                                                                                                                                                                                                           //l//c 
                                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "WinOpen('/Relatorios/RelReciboVenda.aspx?vendaid=" + id + "','',600,850);", true);
                                                        
                            ExibirMensagem("Venda gravada com sucesso !");
                            LimparCamposGeral();
                            txtCliente.Focus();
                        }
                        else
                            ExibirMensagem("Não foi possível gravar a venda. Revise as informações!");                       
                    }
                    else
                        ExibirMensagem("Não foi possível gravar a venda. Revise as informações!");
                }
            }
            else
                Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);
                      
        }

        protected void txtItem_TextChanged(object sender, EventArgs e)
        {
            hfIdItem.Value = "";
            ItensEstoqueBL itEstBL = new ItensEstoqueBL();
            ItensEstoque itEstoque = new ItensEstoque();
            List<ItensEstoque> ltItEst = itEstBL.PesquisarBL("CODIGO", txtItem.Text, 1);
            bool controlaEstoque = false;
            Int32 totalEstoque = 0;
            Int32 qtdMinima = 0;

            foreach (ItensEstoque ltItEstoque in ltItEst)
            {
                hfIdItem.Value = ltItEstoque.Id.ToString();
                txtItem.Text = ltItEstoque.Obra.Codigo.ToString();
                lblDesItem.Text = ltItEstoque.Obra.Titulo;
                controlaEstoque = ltItEstoque.ControlaEstoque;
                qtdMinima = ltItEstoque.QtdMinima;
                txtValorUni.Text = ltItEstoque.VlrVenda.ToString();
                lblValor.Text = (ltItEstoque.VlrVenda * utils.ComparaIntComZero(txtQuantidade.Text)).ToString();

                if (controlaEstoque)
                {
                    MovimentosEstoqueBL movEstBL = new MovimentosEstoqueBL();
                    totalEstoque = movEstBL.PesquisarTotalMovimentosBL(ltItEstoque.Id, "");
                    if (totalEstoque <= 0)
                    {
                        ExibirMensagem("Estoque negativo, não será possível realizar a venda.");
                        txtItem.Text = "";
                        LimparCampos();
                    }
                    else
                    {
                        if (totalEstoque <= qtdMinima)
                            ExibirMensagem("Restam apenas "+ totalEstoque + " itens no estoque."); 
                    }
                }

            }

            if (utils.ComparaIntComZero(hfIdItem.Value) <= 0)
            {
                ExibirMensagem("Item não cadastrado !");
                txtItem.Text = "";
                LimparCampos();
                txtItem.Focus();
            }
            else
                txtValorUni.Focus();
           
        }

        protected void dtgItens_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            object key = new object();            
            key = dtgItens.DataKeys[e.RowIndex][0];

            if (Session["dtItens"] != null)
                dtItens = (DataTable)Session["dtItens"];

            if (dtItens.Rows.Contains(key))
                dtItens.Rows.Remove(dtItens.Rows.Find(key));

            Session["dtItens"] = dtItens;
            dtgItens.DataSource = dtItens;
            dtgItens.DataBind();
            txtQtdItens.Text = dtItens.Compute("sum(QUANTIDADE)", "").ToString();
            txtValorTotal.Text = dtItens.Compute("sum(VALOR)", "").ToString();
        }

        protected void txtCliente_TextChanged(object sender, EventArgs e)
        {
            hfIdPessoa.Value = "";
            PessoasBL pesBL = new PessoasBL();
            Pessoas pessoa = new Pessoas();
            List<Pessoas> pes = pesBL.PesquisarBL("CODIGO",txtCliente.Text);

            foreach (Pessoas ltpessoa in pes)
            {
                hfIdPessoa.Value = ltpessoa.Id.ToString();
                txtCliente.Text = ltpessoa.Codigo.ToString();
                lblDesCliente.Text = ltpessoa.Nome;
                txtItem.Focus();
            }

            if (utils.ComparaIntComZero(hfIdPessoa.Value) <= 0)
            {
                ExibirMensagem("Cliente não cadastrado !");
                txtCliente.Text = "";
                lblDesCliente.Text = "";
                txtCliente.Focus();
                hfIdPessoa.Value = "";
            }
        }

        protected void dtgItens_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                utils.CarregarEfeitoGrid("#c8defc", "#ffffff", e);
        }

        protected void txtQuantidade_TextChanged(object sender, EventArgs e)
        {
            lblValor.Text = (utils.ComparaDecimalComZero(txtValorUni.Text) * utils.ComparaIntComZero(txtQuantidade.Text)).ToString();
        }

        protected void grdPesquisa_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                utils.CarregarEfeitoGrid("#c8defc", "#ffffff", e);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ModalPopupExtenderPesquisa.Enabled = false;            
        }

        protected void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            CarregarPesquisaPessoa(txtPesquisa.Text);
            ModalPopupExtenderPesquisa.Enabled = true;
            ModalPopupExtenderPesquisa.Show();
            txtPesquisa.Text = "";
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {

            ImageButton btndetails = sender as ImageButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;

            hfIdPessoa.Value = grdPesquisa.DataKeys[gvrow.RowIndex].Value.ToString();
            txtCliente.Text = gvrow.Cells[2].Text;
            lblDesCliente.Text = gvrow.Cells[3].Text;
                        
            ModalPopupExtenderPesquisa.Hide();
            ModalPopupExtenderPesquisa.Enabled = false;

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
            txtValorUni.Text = gvrow.Cells[4].Text;
            
            ModalPopupExtenderPesItem.Hide();
            ModalPopupExtenderPesItem.Enabled = false;

        }

        protected void txtPesItem_TextChanged(object sender, EventArgs e)
        {
            CarregarPesquisaItem(txtPesItem.Text);
            ModalPopupExtenderPesItem.Enabled = true;
            ModalPopupExtenderPesItem.Show();
            txtPesItem.Text = "";
        }           
               
    }
}