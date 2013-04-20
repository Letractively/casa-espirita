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
            txtValor.Text = "";
            txtQuantidade.Text = "";
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
            dtgItens.DataSource = null;
            dtgItens.DataBind(); 
        }

        public void ExibirMensagem(string mensagem)
        {
            ClientScript.RegisterStartupScript(System.Type.GetType("System.String"), "Alert",
               "<script language='javascript'> { window.alert(\"" + mensagem + "\") }</script>");
        }

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            CriarDtItens();

            if (!IsPostBack)
            {
                Session["dtItens"] = null;
                hfOrdem.Value = "1";
            }                
        }

       
        protected void btnPesItem_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "WinOpen('/PesquisarItens.aspx?caixa=" + txtItem.ClientID + "&id=" + hfIdItem.ClientID + "&lbl=" + lblDesItem.ClientID +"&valor="+ txtValor.ClientID + "&valoruni="+txtValorUni.ClientID +"','',600,500);", true);
        }

        protected void btnPesCliente_Click(object sender, EventArgs e)
        {
            Session["tabelaPesquisa"] = null;

            DataTable dt = CriarTabelaPesquisa();

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

            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "WinOpen('/Pesquisar.aspx?caixa=" + txtCliente.ClientID + "&id=" + hfIdPessoa.ClientID + "&lbl=" + lblDesCliente.ClientID + "','',600,500);", true);
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
            linha["VALOR"] = utils.ComparaDecimalComZero(txtValor.Text) * utils.ComparaDecimalComZero(txtQuantidade.Text) - utils.ComparaDecimalComZero(txtDesconto.Text);
            linha["VALORUNI"] = utils.ComparaDecimalComZero(txtValor.Text); 
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

            vendas.Data = DateTime.Now;
            vendas.Situacao = "A";
            vendas.PessoaId = utils.ComparaIntComZero(hfIdPessoa.Value);
            
            if (Session["usuario"] != null)
            {
                List<Usuarios> usuarios;
                usuarios = (List<Usuarios>)Session["usuario"];

                foreach (Usuarios usu in usuarios)
                {
                    vendas.UsuarioId = usu.Id;
                }
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

                            if (venItBL.InserirBL(vendaItens))
                            {
                                ExibirMensagem("Venda gravada com sucesso !");
                                LimparCamposGeral();
                            }
                            else
                                ExibirMensagem("Não foi possível gravar a venda. Revise as informações!");
                        }
                    }
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
                LimparCampos();
            }
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
            }

            if (utils.ComparaIntComZero(hfIdPessoa.Value) <= 0)
            {
                ExibirMensagem("Cliente não cadastrado !");
                txtCliente.Text = "";
                lblDesCliente.Text = "";
            }
        }

                               
               
    }
}