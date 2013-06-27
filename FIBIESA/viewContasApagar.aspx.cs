using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using DataObjects;
using FG;
using System.Data;

namespace FIBIESA
{
    public partial class viewContasApagarReceber : System.Web.UI.Page
    {
        Utils utils = new Utils();

        #region funcoes
        public DataTable dtbPesquisa
        {
            get
            {
                if (Session["_dtbPesquisa_cadTit"] != null)
                    return (DataTable)Session["_dtbPesquisa_cadTit"];
                else
                    return null;
            }
            set { Session["_dtbPesquisa_cadTit"] = value; }
        }
        private void Pesquisar(string valor)
        {
            DataTable tabela = new DataTable("tabela");

            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("NUMERO", Type.GetType("System.Int32"));
            DataColumn coluna3 = new DataColumn("PARCELA", Type.GetType("System.Int32"));
            DataColumn coluna4 = new DataColumn("VALOR", Type.GetType("System.Decimal"));           
            DataColumn coluna5 = new DataColumn("DTEMISSAO", Type.GetType("System.String"));
            DataColumn coluna6 = new DataColumn("TIPODOC", Type.GetType("System.String"));
            DataColumn coluna7 = new DataColumn("DTPAGTO", Type.GetType("System.String"));
            DataColumn coluna8 = new DataColumn("VALORPAG", Type.GetType("System.Decimal"));

            tabela.Columns.Add(coluna1);
            tabela.Columns.Add(coluna2);
            tabela.Columns.Add(coluna3);
            tabela.Columns.Add(coluna4);
            tabela.Columns.Add(coluna5);
            tabela.Columns.Add(coluna6);
            tabela.Columns.Add(coluna7);
            tabela.Columns.Add(coluna8);
           
            TitulosBL titBL = new TitulosBL();
            List<Titulos> titulos;

            titulos = titBL.PesquisarBuscaBL("P", valor);

            foreach (Titulos tit in titulos)
            {

                DataRow linha = tabela.NewRow();

                linha["ID"] = tit.Id;
                linha["NUMERO"] = tit.Numero;
                linha["PARCELA"] = tit.Parcela;
                linha["VALOR"] = tit.Valor;
                linha["PARCELA"] = tit.Parcela;
                linha["DTEMISSAO"] = tit.DataEmissao.ToString("dd/MM/yyyy");
                if(tit.TiposDocumentos != null)
                    linha["TIPODOC"] = tit.TiposDocumentos.Descricao;
                else
                    linha["TIPODOC"] = "";

                linha["DTPAGTO"] = tit.DtPagamento.ToString() == string.Empty ? "" : string.Format("{0:dd/MM/yyyy}", (DateTime)tit.DtPagamento);
                linha["VALORPAG"] = tit.ValorPago;

                tabela.Rows.Add(linha);

            }

            dtbPesquisa = tabela;
            dtgTitulos.DataSource = tabela;
            dtgTitulos.DataBind();
        }

        public void ExibirMensagem(string mensagem)
        {
            ClientScript.RegisterStartupScript(System.Type.GetType("System.String"), "Alert",
               "<script language='javascript'> { window.alert(\"" + mensagem + "\") }</script>");
        }

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                Pesquisar(null);
        }

        protected void btnBusca_Click(object sender, EventArgs e)
        {
            Pesquisar(txtBusca.Text);
        }

        protected void btnInserir_Click(object sender, EventArgs e)
        {
            Response.Redirect("cadContasApagar.aspx?operacao=new");
        }

        protected void dtgTitulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int str_tit = 0;
            str_tit = utils.ComparaIntComZero(dtgTitulos.SelectedDataKey[0].ToString());
            Response.Redirect("cadContasApagar.aspx?id_tit=" + str_tit.ToString() + "&operacao=edit");
        }

        protected void dtgTitulos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            
                TitulosBL titBL = new TitulosBL();
                Titulos titulos = new Titulos();
                titulos.Id = utils.ComparaIntComZero(dtgTitulos.DataKeys[e.RowIndex][0].ToString());
                if (titBL.ExcluirBL(titulos))
                    ExibirMensagem("Título excluído com sucesso !");
                else
                    ExibirMensagem("Não foi possível excluir o registro, existem registros dependentes");

                Pesquisar(null);
            
        }

        protected void dtgTitulos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dtgTitulos.DataSource = dtbPesquisa;
            dtgTitulos.PageIndex = e.NewPageIndex;
            dtgTitulos.DataBind();
        }

        protected void dtgTitulos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                utils.CarregarEfeitoGrid("#c8defc", "#ffffff", e);

            if (e.Row.RowType == DataControlRowType.DataRow)
                utils.CarregarJsExclusao("Deseja excluir este registro?", 1, e);
        }

        protected void dtgTitulos_Sorting(object sender, GridViewSortEventArgs e)
        {
            if (dtbPesquisa != null)
            {
                string ordem = e.SortExpression;

                DataView m_DataView = new DataView(dtbPesquisa);

                if (ViewState["dtbPesquisa_sort"] != null)
                {
                    if (ViewState["dtbPesquisa_sort"].ToString() == e.SortExpression)
                    {
                        m_DataView.Sort = ordem + " DESC";
                        ViewState["dtbPesquisa_sort"] = null;
                    }
                    else
                    {
                        m_DataView.Sort = ordem;
                        ViewState["dtbPesquisa_sort"] = e.SortExpression;
                    }
                }
                else
                {
                    m_DataView.Sort = ordem;
                    ViewState["dtbPesquisa_sort"] = e.SortExpression;
                }

                dtbPesquisa = m_DataView.ToTable();
                dtgTitulos.DataSource = m_DataView;
                dtgTitulos.DataBind();
            }
        }
    }
}