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
        DataTable dtExcluidos = new DataTable();
        string v_operacao = "";

        #region funcoes
        
        public void ExibirMensagem(string mensagem)
        {
            ScriptManager.RegisterStartupScript(
                                     updPrincipal,
                                     this.GetType(),
                                     "Alert",
                                     "window.alert(\"" + mensagem + "\");",
                                     true);
        }

        private void CarregarAtributos()
        {
            txtNumero.Attributes.Add("onkeypress", "return(Reais(this,event))");
            txtSerie.Attributes.Add("onkeypress", "return(Reais(this,event))");
            txtQtde.Attributes.Add("onkeypress", "return(Reais(this,event))");
            txtNumero.Attributes.Add("onkeypress", "return(Reais(this,event))");
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
                hfId.Value = ltNotEn.Id.ToString();
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

            Session["dtItens"] = dtItens;
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

        private void CriaDtExcluidos()
        {
            if (dtExcluidos.Columns.Count == 0)
            {
                DataColumn coluna1 = new DataColumn("IDCODIGO", Type.GetType("System.String"));
                DataColumn coluna2 = new DataColumn("TIPO", Type.GetType("System.String"));

                dtExcluidos.Columns.Add(coluna1);
                dtExcluidos.Columns.Add(coluna2);
            }
        }

        private void ExcluirItens()
        {
            NotasEntradaItensBL neItBL = new NotasEntradaItensBL();
            NotasEntradaItens neItens = new NotasEntradaItens();

            if (Session["tbexcluidos"] != null)
            {
                dtExcluidos = (DataTable)Session["tbexcluidos"];
                foreach (DataRow row in dtExcluidos.Rows)
                {
                    switch (row["TIPO"].ToString().ToUpper())
                    {
                        case "I":
                            {
                                neItens.Id = utils.ComparaIntComZero(row["IDCODIGO"].ToString());
                                neItBL.ExcluirBL(neItens);
                                break;
                            }
                    }
                }
            }

        }

        private void LimparCampos()
        {
            txtNumero.Text = "";
            txtSerie.Text = "";
            txtData.Text = "";
            txtTotal.Text = "";
            txtTotItens.Text = "";
            LimparCamposItem();
            Session["dtItens"] = null;
            dtgItens.DataSource = null;
            dtgItens.DataBind();            
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            CarregarAtributos();
            CriarDtItens();
            CriaDtExcluidos();

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

            notaEntrada.Id = utils.ComparaIntComZero(hfId.Value);
            notaEntrada.Numero = utils.ComparaIntComZero(txtNumero.Text);
            notaEntrada.Serie = utils.ComparaShortComZero(txtSerie.Text);
            notaEntrada.Data = Convert.ToDateTime(txtData.Text);
            int usu_id = 0;

            if (Session["dtItens"] != null)
                dtItens = (DataTable)Session["dtItens"];

            if (dtItens.Rows.Count > 0)
            {

                if (Session["usuario"] != null)
                {
                    List<Usuarios> usuarios;
                    usuarios = (List<Usuarios>)Session["usuario"];

                    foreach (Usuarios usu in usuarios)
                    {
                        usu_id = usu.Id;
                    }
                }


                if (notaEntrada.Id == 0)
                {
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
                                    notaEntradaItens.UsuarioId = usu_id;
                                    notaEntradaItens.ValorVenda = utils.ComparaDecimalComZero(linha["VALORVENDA"].ToString());

                                    ntEiBL.InserirBL(notaEntradaItens);
                                }
                            }

                            LimparCampos();
                            ExibirMensagem("Nota de Entrada gravada com sucesso !");
                        }

                    }
                    else
                        Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);
                }
                else
                {
                    if (this.Master.VerificaPermissaoUsuario("EDITAR"))
                    {
                        ExcluirItens();
                        if (dtItens.Rows.Count > 0)
                        {
                            ntEBL.EditarBL(notaEntrada);

                            foreach (DataRow linha in dtItens.Rows)
                            {
                                notaEntradaItens.NotaEntradaId = notaEntrada.Id;
                                notaEntradaItens.Id = utils.ComparaIntComZero(linha["ID"].ToString());
                                notaEntradaItens.ItemEstoqueId = utils.ComparaIntComZero(linha["ITEMESTOQUEID"].ToString());
                                notaEntradaItens.Quantidade = utils.ComparaIntComZero(linha["QUANTIDADE"].ToString());
                                notaEntradaItens.Valor = utils.ComparaDecimalComZero(linha["VALOR"].ToString());
                                notaEntradaItens.UsuarioId = usu_id;
                                notaEntradaItens.ValorVenda = utils.ComparaDecimalComZero(linha["VALORVENDA"].ToString());

                                if (notaEntradaItens.Id > 0)
                                    ntEiBL.EditarBL(notaEntradaItens);
                                else
                                    ntEiBL.InserirBL(notaEntradaItens);

                            }
                        }

                        ExibirMensagem("Nota de Entrada atualizada com sucesso !");
                    }
                    else
                        Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);
                }
            }
            else
                ExibirMensagem("Não é possível salvar uma nota sem o(s) item(es) !");

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
            linha["VALORTOTAL"] = utils.ComparaDecimalComZero(String.Format("{0:C2}", txtValor.Text)) * utils.ComparaIntComZero(String.Format("{0:C2}", txtQtde.Text));
            linha["VALORVENDA"] = txtValorVenda.Text;

            dtItens.Rows.Add(linha);

            Session["dtItens"] = dtItens;
            dtgItens.DataSource = dtItens;
            dtgItens.DataBind();
            LimparCamposItem();

            txtTotItens.Text = dtItens.Compute("sum(QUANTIDADE)", "").ToString();
            txtTotal.Text = dtItens.Compute("sum(VALORTOTAL)", "").ToString();
            hfOrdem.Value = (utils.ComparaIntComZero(hfOrdem.Value) + 1).ToString(); //proxima ordem 

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
            DataSet dsPar = parBL.PesquisarBL(2, "F");
            decimal percentual = 0;

            if (dsPar.Tables[0].Rows.Count != 0)
                percentual = utils.ComparaDecimalComZero(dsPar.Tables[0].Rows[0]["VALOR"].ToString());

            txtValorVenda.Text = String.Format("{0:C2}",(utils.ComparaDecimalComZero(String.Format("{0:C2}", txtValor.Text)) +
                                 ((utils.ComparaDecimalComZero(String.Format("{0:C2}", txtValor.Text)) * percentual) / 100)));
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/viewNotaEntrada.aspx");
        }

        protected void dtgItens_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            object key = new object();
            object key2 = new object();
            key = dtgItens.DataKeys[e.RowIndex][0];
            key2 = dtgItens.DataKeys[e.RowIndex][1];

            if (Session["dtItens"] != null)
                dtItens = (DataTable)Session["dtItens"];

            if (dtItens.Rows.Contains(key))
                dtItens.Rows.Remove(dtItens.Rows.Find(key));

            Session["dtItens"] = dtItens;
            dtgItens.DataSource = dtItens;
            dtgItens.DataBind();


            if (utils.ComparaIntComZero(key2.ToString()) > 0)
            {
                if (Session["tbexcluidos"] != null)
                    dtExcluidos = (DataTable)Session["tbexcluidos"];

                DataRow row = dtExcluidos.NewRow();
                row["IDCODIGO"] = key2.ToString();
                row["TIPO"] = "I";
                dtExcluidos.Rows.Add(row);
                Session["tbexcluidos"] = dtExcluidos;
            }
        }

        protected void dtgItens_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                utils.CarregarEfeitoGrid("#c8defc", "#ffffff", e);
          
            if (e.Row.RowType == DataControlRowType.DataRow)
                utils.CarregarJsExclusao("Deseja excluir este item da nota de entrada?", 0, e);
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
            txtQtde.Focus();

        }

        protected void txtPesItem_TextChanged(object sender, EventArgs e)
        {
            CarregarPesquisaItem(txtPesItem.Text);
            ModalPopupExtenderPesItem.Enabled = true;
            ModalPopupExtenderPesItem.Show();
            txtPesItem.Text = "";
        }

        protected void txtNumero_TextChanged(object sender, EventArgs e)
        {
            NotasEntradaBL insBL = new NotasEntradaBL();

            if (insBL.CodigoJaUtilizadoBL(utils.ComparaIntComZero(txtNumero.Text)))
            {
                ExibirMensagem("O número " + txtNumero.Text + " já existe. Informe um novo número.");
                txtNumero.Text = "";
                txtNumero.Focus();
            }
            else
                txtSerie.Focus();              
        }

    }
}