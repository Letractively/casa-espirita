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
    public partial class cadNotaEntrada : System.Web.UI.Page
    {
        Utils utils = new Utils();
        DataTable dtItens = new DataTable();
        string v_operacao = ""; 

        #region funcoes

        public void ExibirMensagem(string mensagem)
        {
            ClientScript.RegisterStartupScript(System.Type.GetType("System.String"), "Alert",
               "<script language='javascript'> { window.alert(\"" + mensagem + "\") }</script>");
        }

        private void CarregarAtributos()
        {
            txtNumero.Attributes.Add("onkeypress", "return(Reais(this,event))");
            txtSerie.Attributes.Add("onkeypress", "return(Reais(this,event))");
            txtQtde.Attributes.Add("onkeypress", "return(Reais(this,event))");
            txtNumero.Attributes.Add("onkeypress", "return(Reais(this,event))");
            txtValor.Attributes.Add("onkeypress", "return(Reais(this,event))");
            txtValorVenda.Attributes.Add("onkeypress", "return(Reais(this,event))");
            txtTotItens.Attributes.Add("onkeypress", "return(Reais(this,event))");
            txtTotal.Attributes.Add("onkeypress", "return(Reais(this,event))");
            txtData.Attributes.Add("onkeypress", "return(formatar(this,'##/##/####',event))");
           
        }

        private void CriarDtItens()
        {
            DataColumn[] keys = new DataColumn[1];

            if (dtItens.Columns.Count == 0)
            {
                DataColumn coluna1 = new DataColumn("IDORDEM", Type.GetType("System.Int32"));
                DataColumn coluna2 = new DataColumn("IDITEM", Type.GetType("System.Int32"));
                DataColumn coluna3 = new DataColumn("DESCITEM", Type.GetType("System.String"));
                DataColumn coluna4 = new DataColumn("QUANTIDADE", Type.GetType("System.Int32"));
                DataColumn coluna5 = new DataColumn("VALOR", Type.GetType("System.Decimal"));
                DataColumn coluna6 = new DataColumn("VALORTOTAL", Type.GetType("System.Decimal"));
                DataColumn coluna7 = new DataColumn("VALORVENDA", Type.GetType("System.Decimal"));
                DataColumn coluna8 = new DataColumn("ITEMESTOQUEID", Type.GetType("System.Int32"));
                DataColumn coluna9 = new DataColumn("ID", Type.GetType("System.Int32"));

                dtItens.Columns.Add(coluna1);
                dtItens.Columns.Add(coluna2);
                dtItens.Columns.Add(coluna3);
                dtItens.Columns.Add(coluna4);
                dtItens.Columns.Add(coluna5);
                dtItens.Columns.Add(coluna6);
                dtItens.Columns.Add(coluna7);
                dtItens.Columns.Add(coluna8);
                dtItens.Columns.Add(coluna9);

                keys[0] = coluna1;

                dtItens.PrimaryKey = keys;
            }
        }

        private void LimparCamposItem()
        {
            txtItem.Text = "";
            lblDesItem.Text = "";
            txtQtde.Text = "";
            txtValor.Text = "";
            txtValorVenda.Text = "";           
        }

        private void CarregarDados(int id_pes)
        {
            int ordem = 0;

            NotasEntradaBL notEBL = new NotasEntradaBL();
            List<NotasEntrada> notasEntrada = notEBL.PesquisarBL(id_pes);
                       

            foreach (NotasEntrada ltNotEn in notasEntrada)
            {
                txtNumero.Text = ltNotEn.Numero.ToString();
                txtSerie.Text = ltNotEn.Serie.ToString();
                txtData.Text = ltNotEn.Data.ToString("dd/MM/yyyy");
            }

            NotasEntradaItensBL notEitBL = new NotasEntradaItensBL();
            List<NotasEntradaItens> notEit = notEitBL.PesquisarBL(id_pes);

            foreach (NotasEntradaItens ltNotEnt in notEit)
            {
                ordem++;
                DataRow linha = dtItens.NewRow();

                linha["IDORDEM"] = ordem;
                linha["ID"] = ltNotEnt.Id;
                linha["ITEMESTOQUEID"] = ltNotEnt.ItemEstoqueId;
                linha["IDITEM"] = ltNotEnt.Obra.Codigo;
                linha["DESCITEM"] = ltNotEnt.Obra.Titulo;
                linha["QUANTIDADE"] = ltNotEnt.Quantidade;
                linha["VALOR"] = ltNotEnt.Valor;
                linha["VALORTOTAL"] = ltNotEnt.Quantidade * ltNotEnt.Valor;
                //linha["VALORVENDA"] = ltNotEnt.v ;
    
                dtItens.Rows.Add(linha);
            }

            Session["tbItens"] = dtItens;
            dtgItens.DataSource = dtItens;
            dtgItens.DataBind();
            txtTotItens.Text = dtItens.Compute("sum(QUANTIDADE)", "").ToString();
            txtTotal.Text = dtItens.Compute("sum(VALORTOTAL)", "").ToString();
            ordem++;
            hfOrdem.Value = ordem.ToString(); //proxima ordem 

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
            CriarDtItens();
    
            int id_notE = 0;
            
            if (!IsPostBack)
            {
                Session["dtItens"] = null;
                hfOrdem.Value = "1";
                if (Request.QueryString["operacao"] != null)
                {
                    v_operacao = Request.QueryString["operacao"];

                    if (v_operacao == "edit")
                        if (Request.QueryString["id_ntE"] != null)
                            id_notE = Convert.ToInt32(Request.QueryString["id_ntE"].ToString());
                }

                if (v_operacao.ToLower() == "edit")
                    CarregarDados(id_notE);

                txtNumero.Focus();
            }
            
        }

        protected void btnPesItem_Click(object sender, EventArgs e)
        {
            CarregarPesquisaItem(null);
            ModalPopupExtenderPesItem.Enabled = true;
            ModalPopupExtenderPesItem.Show();      
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            NotasEntradaBL ntEBL = new NotasEntradaBL();
            NotasEntrada notaEntrada = new NotasEntrada();
            NotasEntradaItensBL ntEiBL = new NotasEntradaItensBL();
            NotasEntradaItens notaEntradaItens = new NotasEntradaItens();
            MovimentosEstoqueBL movEstBL = new MovimentosEstoqueBL();
            MovimentosEstoque movEstoque = new MovimentosEstoque();

            notaEntrada.Numero = utils.ComparaIntComZero(txtNumero.Text);
            notaEntrada.Serie = utils.ComparaShortComZero(txtSerie.Text);
            notaEntrada.Data = Convert.ToDateTime(txtData.Text);
            int usu_id = 0;

            if (Session["dtItens"] != null)
                dtItens = (DataTable)Session["dtItens"];

            if (this.Master.VerificaPermissaoUsuario("INSERIR"))
            {
                if (dtItens.Rows.Count > 0)
                {
                    int id = ntEBL.InserirBL(notaEntrada);

                    if (id > 0)
                    {
                        foreach (DataRow linha in dtItens.Rows)
                        {
                            notaEntradaItens.NotaEntradaId = id;
                            notaEntradaItens.ItemEstoqueId = utils.ComparaIntComZero(linha["ITEMESTOQUEID"].ToString());
                            notaEntradaItens.Quantidade = utils.ComparaIntComZero(linha["QUANTIDADE"].ToString());
                            notaEntradaItens.Valor = utils.ComparaDecimalComZero(linha["VALOR"].ToString());

                            Int32 notaE_item = ntEiBL.InserirBL(notaEntradaItens);

                            if (Session["usuario"] != null)
                            {
                                List<Usuarios> usuarios;
                                usuarios = (List<Usuarios>)Session["usuario"];

                                foreach (Usuarios usu in usuarios)
                                {
                                    usu_id = usu.Id;
                                }                                                                
                            }

                            if (notaE_item > 0)
                            {
                                movEstoque.UsuarioId = usu_id;
                                movEstoque.ItemEstoqueId = notaEntradaItens.ItemEstoqueId;
                                movEstoque.Quantidade = notaEntradaItens.Quantidade;
                                movEstoque.Data = DateTime.Now;
                                movEstoque.Tipo = "E";
                                movEstoque.NotaEntradaId = notaE_item;

                                if (movEstoque.ItemEstoqueId > 0 && movEstoque.UsuarioId > 0)
                                    movEstBL.InserirBL(movEstoque);
                            }
                        }
                    }
                }

            }
            else
                Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);

            Response.Redirect("viewNotaEntrada.aspx");

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
            linha["IDITEM"] = txtItem.Text;
            linha["DESCITEM"] = lblDesItem.Text;
            linha["QUANTIDADE"] = txtQtde.Text;
            linha["VALOR"] = txtValor.Text;
            linha["VALORTOTAL"] = utils.ComparaDecimalComZero(txtValor.Text) * utils.ComparaIntComZero(txtQtde.Text);
            linha["VALORVENDA"] = txtValorVenda.Text; 

            dtItens.Rows.Add(linha);

            Session["dtItens"] = dtItens;
            dtgItens.DataSource = dtItens;
            dtgItens.DataBind();
            LimparCamposItem();
                       
            txtTotItens.Text = dtItens.Compute("sum(QUANTIDADE)", "").ToString();
            txtTotal.Text = dtItens.Compute("sum(VALORTOTAL)","").ToString();
            hfOrdem.Value = (utils.ComparaIntComZero(hfOrdem.Value) + 1).ToString(); //proxima ordem 
          
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

            txtQtde.Focus();

            if (utils.ComparaIntComZero(hfIdItem.Value) <= 0)               
            {
                ExibirMensagem("Item não cadastrado !");
                txtItem.Text = "";
                lblDesItem.Text = "";
                txtItem.Focus();
            }
        }

        protected void txtValor_TextChanged(object sender, EventArgs e)
        {
            ParametrosBL parBL = new ParametrosBL();
            DataSet dsPar = parBL.PesquisarBL(2,"F");
            decimal percentual = 0;

            if (dsPar.Tables[0].Rows.Count != 0)
                percentual  = utils.ComparaDecimalComZero(dsPar.Tables[0].Rows[0]["VALOR"].ToString());

            txtValorVenda.Text = (utils.ComparaDecimalComZero(txtValor.Text) +
                                 ((utils.ComparaDecimalComZero(txtValor.Text) * percentual)/100)).ToString();
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/viewNotaEntrada.aspx");
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
        }

        protected void dtgItens_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                utils.CarregarEfeitoGrid("#c8defc", "#ffffff", e);
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
            
            ModalPopupExtenderPesItem.Enabled = false;
            ModalPopupExtenderPesItem.Hide();

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