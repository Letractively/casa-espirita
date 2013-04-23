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
    public partial class cadMovimentoEstoque : System.Web.UI.Page
    {
        Utils utils = new Utils();
        #region funcoes
        private void Pesquisar(int item_id, DateTime? data)
        {              
            DataTable tabela = new DataTable();
            DataColumn coluna1 = new DataColumn("CODITEM", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("DESCITEM", Type.GetType("System.String"));
            DataColumn coluna3 = new DataColumn("DATA", Type.GetType("System.String"));
            DataColumn coluna4 = new DataColumn("VLRCUSTO", Type.GetType("System.Decimal"));
            DataColumn coluna5 = new DataColumn("USUNOME", Type.GetType("System.String"));
            DataColumn coluna6 = new DataColumn("QTDE", Type.GetType("System.Int32"));
            DataColumn coluna7 = new DataColumn("NOTAENT", Type.GetType("System.Int32"));
            DataColumn coluna8 = new DataColumn("VENDANUM", Type.GetType("System.Int32"));
            DataColumn coluna9 = new DataColumn("NOTAENTSERIE", Type.GetType("System.Int16"));
            DataColumn coluna10 = new DataColumn("TIPO", Type.GetType("System.String"));
            DataColumn coluna11 = new DataColumn("VLRVENDA", Type.GetType("System.Decimal"));

            tabela.Columns.Add(coluna1);
            tabela.Columns.Add(coluna2);
            tabela.Columns.Add(coluna3);
            tabela.Columns.Add(coluna4);
            tabela.Columns.Add(coluna5);
            tabela.Columns.Add(coluna6);
            tabela.Columns.Add(coluna7);
            tabela.Columns.Add(coluna8);
            tabela.Columns.Add(coluna9);
            tabela.Columns.Add(coluna10);
            tabela.Columns.Add(coluna11);

            MovimentosEstoqueBL movEst = new MovimentosEstoqueBL();
            List<MovimentosEstoque> movEstoque = movEst.PesquisarBL(item_id, data);
           
            foreach (MovimentosEstoque ltMovEst in movEstoque)
            {
                DataRow linha = tabela.NewRow();

                linha["DATA"] = ltMovEst.Data.ToString("dd/MM/yyyy");
                linha["VLRCUSTO"] = ltMovEst.Valor;
                linha["USUNOME"] = ltMovEst.Usuarios.Login;
                linha["QTDE"] = ltMovEst.Quantidade;
                if (ltMovEst.NotaEntrada != null)
                {
                    linha["NOTAENT"] = utils.ComparaIntComZero(ltMovEst.NotaEntrada.Numero.ToString());
                    linha["NOTAENTSERIE"] = utils.ComparaShortComZero(ltMovEst.NotaEntrada.Serie.ToString());
                }
                                
                linha["VENDANUM"] = ltMovEst.NumeroVenda != null ? utils.ComparaIntComNull(ltMovEst.NumeroVenda.ToString()): 0 ;
                                               
                linha["TIPO"] = ltMovEst.Tipo;
                linha["VLRVENDA"] = ltMovEst.Valor;
                                
                if (ltMovEst.Obras != null)
                {
                    linha["CODITEM"] = ltMovEst.Obras.Codigo.ToString();
                    linha["DESCITEM"] = ltMovEst.Obras.Titulo;
                }

                tabela.Rows.Add(linha);

            }

            dtgMovItem.DataSource = tabela;
            dtgMovItem.DataBind();
            txtQtdTotal.Text = movEst.PesquisarTotalMovimentosBL(item_id, txtData.Text).ToString();
            
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

        private void CarregarAtributos()
        {
            txtData.Attributes.Add("onkeypress", "return(formatar(this,'##/##/####',event))");
            txtItem.Attributes.Add("onkeypress", "return(Reais(this,event))");
        }

        public void ExibirMensagem(string mensagem)
        {
            ClientScript.RegisterStartupScript(System.Type.GetType("System.String"), "Alert",
               "<script language='javascript'> { window.alert(\"" + mensagem + "\") }</script>");
        }

        private void LimparCampos()
        {
            txtItem.Text = "";
            lblDesItem.Text = "";
            txtQtdTotal.Text = "";
            dtgMovItem.DataSource = null;
            dtgMovItem.DataBind();
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
            ItensEstoqueBL itEstBL = new ItensEstoqueBL();
            ItensEstoque itEstoque = new ItensEstoque();
            List<ItensEstoque> ltItEst = itEstBL.PesquisarBL(1);

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

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/default.aspx");
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            Pesquisar(utils.ComparaIntComZero(hfIdItem.Value), utils.ComparaDataComNull(txtData.Text));
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
                LimparCampos();
            }
        }

                       
    }
}