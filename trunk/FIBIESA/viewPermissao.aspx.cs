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

namespace Admin
{
    public partial class viewPermicao : System.Web.UI.Page
    {
        Utils utils = new Utils();

        #region funcoes
        public DataTable dtbPesquisa
        {
            get
            {
                if (Session["_dtbPesquisa_cadPer"] != null)
                    return (DataTable)Session["_dtbPesquisa_cadPer"];
                else
                    return null;
            }
            set { Session["_dtbPesquisa_cadPer"] = value; }
        }
        private void Pesquisar(string campo, string valor)
        {
            DataTable tabela = new DataTable("tabela");

            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("CODIGO", Type.GetType("System.Int32"));
            DataColumn coluna3 = new DataColumn("DESCRICAO", Type.GetType("System.String"));

            tabela.Columns.Add(coluna1);
            tabela.Columns.Add(coluna2);
            tabela.Columns.Add(coluna3);

            CategoriasBL catBL = new CategoriasBL();

            List<Categorias> categorias;

            if (campo != null && valor.Trim() != "")
                categorias = catBL.PesquisarBL(campo, valor);
            else
                categorias = catBL.PesquisarBL();

            foreach (Categorias cat in categorias)
            {

                DataRow linha = tabela.NewRow();

                linha["ID"] = cat.Id;
                linha["CODIGO"] = cat.Codigo;
                linha["DESCRICAO"] = cat.Descricao;

                tabela.Rows.Add(linha);
            }

            dtbPesquisa = tabela;
            dtgPermissoes.DataSource = tabela;
            dtgPermissoes.DataBind();
        }
        private string ConvertSortDirectionToSql(SortDirection sortDirection)
        {
            string newSortDirection = String.Empty;

            switch (sortDirection)
            {
                case SortDirection.Ascending:
                    newSortDirection = "ASC";
                    break;

                case SortDirection.Descending:
                    newSortDirection = "DESC";
                    break;
            }

            return newSortDirection;
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                Pesquisar(null, null);
        }

        protected void btnInserir_Click(object sender, EventArgs e)
        {
            Response.Redirect("cadPermissao.aspx?operacao=new");
        }

        protected void dtgPermissoes_SelectedIndexChanged(object sender, EventArgs e)
        {
            int str_per_cat = 0;
            str_per_cat = utils.ComparaIntComZero(dtgPermissoes.SelectedDataKey[0].ToString());
            Response.Redirect("cadPermissao.aspx?id_per_cat=" + str_per_cat.ToString());
        }

        protected void btnBusca_Click(object sender, EventArgs e)
        {
            Pesquisar(ddlCampo.SelectedValue, txtBusca.Text);
        }

        protected void dtgPermissoes_Sorting(object sender, GridViewSortEventArgs e)
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
                dtgPermissoes.DataSource = m_DataView;
                dtgPermissoes.DataBind();
            }


        }

        protected void dtgPermissoes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dtgPermissoes.DataSource = dtbPesquisa;
            dtgPermissoes.PageIndex = e.NewPageIndex;
            dtgPermissoes.DataBind();
        }

        protected void dtgPermissoes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow) //se for uma linha de dados
                utils.CarregarEfeitoGrid("#c8defc", "#ffffff", e);
        }

    }
}