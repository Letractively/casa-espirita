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
    public partial class viewCategoria : System.Web.UI.Page
    {
        Utils utils = new Utils();

        #region funcoes
        public DataTable dtbPesquisa
        {
            get
            {
                if (Session["_dtbPesquisa_cadForm"] != null)
                    return (DataTable)Session["_dtbPesquisa_cadForm"];
                else
                    return null;
            }
            set { Session["_dtbPesquisa_cadForm"] = value; }
        }

        public void ExibirMensagem(string mensagem)
        {
            ClientScript.RegisterStartupScript(System.Type.GetType("System.String"), "Alert",
               "<script language='javascript'> { window.alert(\"" + mensagem + "\") }</script>");
        }

        private void Pesquisar(string valor)
        {
            DataTable tabela = new DataTable("tabela");
            /*Cria as colunas do datatable*/
            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("CODIGO", Type.GetType("System.Int32"));
            DataColumn coluna3 = new DataColumn("DESCRICAO", Type.GetType("System.String"));

            /*Adiciona as colunas a datatable*/
            tabela.Columns.Add(coluna1);
            tabela.Columns.Add(coluna2);
            tabela.Columns.Add(coluna3);

            CategoriasBL catBL = new CategoriasBL();
            List<Categorias> categorias = catBL.PesquisarBL();


            categorias = catBL.PesquisarBuscaBL(valor);

            foreach (Categorias cat in categorias)
            {
                DataRow linha = tabela.NewRow();

                linha["ID"] = cat.Id;
                linha["CODIGO"] = cat.Codigo;
                linha["DESCRICAO"] = cat.Descricao;

                tabela.Rows.Add(linha);
            }

            dtbPesquisa = tabela;
            dtgCategorias.DataSource = tabela;
            dtgCategorias.DataBind();
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnBusca_Click(object sender, EventArgs e)
        {
            Pesquisar(txtBusca.Text);
        }

        protected void btnInserir_Click(object sender, EventArgs e)
        {
            Response.Redirect("cadCategoria.aspx");
        }

        protected void dtgCategorias_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            CategoriasBL catBL = new CategoriasBL();
            Categorias categorias = new Categorias();
            categorias.Id = utils.ComparaIntComZero(dtgCategorias.DataKeys[e.RowIndex][0].ToString());
           
            if (catBL.ExcluirBL(categorias))
                ExibirMensagem("Registro excluído com sucesso !");
            else
                ExibirMensagem("Não foi possível excluir o registro, existem registros dependentes");
            Pesquisar(null);

        }

        protected void dtgCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            int str_cat = 0;
            str_cat = Convert.ToInt32(dtgCategorias.SelectedDataKey[0].ToString());
            Response.Redirect("cadCategoria.aspx?id_cat=" + str_cat.ToString() + "&operacao=edit");
        }

        protected void dtgCategorias_Sorting(object sender, GridViewSortEventArgs e)
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
                dtgCategorias.DataSource = m_DataView;
                dtgCategorias.DataBind();
            }
        }

        protected void dtgCategorias_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dtgCategorias.DataSource = dtbPesquisa;
            dtgCategorias.PageIndex = e.NewPageIndex;
            dtgCategorias.DataBind();
        }

        protected void dtgCategorias_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                utils.CarregarEfeitoGrid("#c8defc", "#ffffff", e);

            if (e.Row.RowType == DataControlRowType.DataRow)
                utils.CarregarJsExclusao("Deseja excluir este registro?", 1, e);
        }
    }
}