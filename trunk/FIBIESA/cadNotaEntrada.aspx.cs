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

            NotasEntradaItensBL notEitBL = new NotasEntradaItensBL();
            List<NotasEntradaItens> notEit = notEitBL.PesquisarBL();

            foreach (NotasEntrada ltNotEn in notasEntrada)
            {
                txtNumero.Text = ltNotEn.Numero.ToString();
                txtSerie.Text = ltNotEn.Serie.ToString();
                txtData.Text = ltNotEn.Data.ToString("dd/MM/yyyy");
            }

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
            }
        }

        protected void btnPesItem_Click(object sender, EventArgs e)
        {
            Session["tabelaPesquisa"] = null;
            DataTable dt = CriarDtPesquisa();
            ItensEstoqueBL itEstBL = new ItensEstoqueBL();
            ItensEstoque itEstoque = new ItensEstoque();
            List<ItensEstoque> ltItEst = itEstBL.PesquisarBL();

            foreach (ItensEstoque litE in ltItEst)
            {
                DataRow linha = dt.NewRow();

                if (litE.Obra != null)
                {
                    linha["ID"] = litE.Id;
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

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            NotasEntradaBL ntEBL = new NotasEntradaBL();
            NotasEntrada notaEntrada = new NotasEntrada();
            NotasEntradaItensBL ntEiBL = new NotasEntradaItensBL();
            NotasEntradaItens notaEntradaItens = new NotasEntradaItens();

            notaEntrada.Numero = utils.ComparaIntComZero(txtNumero.Text);
            notaEntrada.Serie = utils.ComparaShortComZero(txtSerie.Text);
            notaEntrada.Data = Convert.ToDateTime(txtData.Text);

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

                            ntEiBL.InserirBL(notaEntradaItens);
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

            txtTotItens.Text = dtItens.Rows.Count.ToString();
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

            if (utils.ComparaIntComZero(hfIdItem.Value) <= 0)               
            {
                ExibirMensagem("Item não cadastrado !");
                txtItem.Text = "";
                lblDesItem.Text = "";
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

        
    }
}