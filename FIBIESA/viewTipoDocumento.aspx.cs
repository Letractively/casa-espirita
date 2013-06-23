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
    public partial class viewTipoDocumento : System.Web.UI.Page
    {
        Utils utils = new Utils();
        #region funcoes
        public DataTable dtbPesquisa
        {
            get
            {
                if (Session["_dtbPesquisa_cadTipD"] != null)
                    return (DataTable)Session["_dtbPesquisa_cadTipD"];
                else
                    return null;
            }
            set { Session["_dtbPesquisa_cadTipD"] = value; }
        }

        private void Pesquisar(string valor)
        {
            DataTable tabela = new DataTable();
            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("CODIGO", Type.GetType("System.Int32"));
            DataColumn coluna3 = new DataColumn("DESCRICAO", Type.GetType("System.String"));
            DataColumn coluna4 = new DataColumn("APLICACAO", Type.GetType("System.String"));

            tabela.Columns.Add(coluna1);
            tabela.Columns.Add(coluna2);
            tabela.Columns.Add(coluna3);
            tabela.Columns.Add(coluna4);

            TiposDocumentosBL tdoBL = new TiposDocumentosBL();
            List<TiposDocumentos> tDoc;

            tDoc = tdoBL.PesquisarBuscaBL(valor);

            foreach (TiposDocumentos ltTdoc in tDoc)
            {
                DataRow linha = tabela.NewRow();
                linha["ID"] = ltTdoc.Id;
                linha["CODIGO"] = ltTdoc.Codigo;
                linha["DESCRICAO"] = ltTdoc.Descricao;
                linha["APLICACAO"] = ltTdoc.Aplicacao;

                tabela.Rows.Add(linha);
            }

            dtbPesquisa = tabela;
            dtgTipoDocumento.DataSource = tabela;
            dtgTipoDocumento.DataBind();
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


        protected void btnInserir_Click(object sender, EventArgs e)
        {
            Response.Redirect("cadTipoDocumento.aspx");
        }

        protected void dtgTipoDocumento_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            TiposDocumentosBL tdoBL = new TiposDocumentosBL();
            TiposDocumentos tiposDocumento = new TiposDocumentos();
            tiposDocumento.Id = utils.ComparaIntComZero(dtgTipoDocumento.DataKeys[e.RowIndex][0].ToString());
         
            if (tdoBL.ExcluirBL(tiposDocumento))
                ExibirMensagem("Registro excluído com sucesso !");
            else
                ExibirMensagem("Não foi possível excluir o registro, existem registros dependentes");

            Pesquisar(null);
        }

        protected void dtgTipoDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            int str_tdo = 0;
            str_tdo = utils.ComparaIntComZero(dtgTipoDocumento.SelectedDataKey[0].ToString());
            Response.Redirect("cadTipoDocumento.aspx?id_tdo=" + str_tdo.ToString() + "&operacao=edit");
        }

        protected void dtgTipoDocumento_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dtgTipoDocumento.DataSource = dtbPesquisa;
            dtgTipoDocumento.PageIndex = e.NewPageIndex;
            dtgTipoDocumento.DataBind();
        }

        protected void dtgTipoDocumento_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                utils.CarregarEfeitoGrid("#c8defc", "#ffffff", e);

            if (e.Row.RowType == DataControlRowType.DataRow)
                utils.CarregarJsExclusao("Deseja excluir este registro?", 1, e);
        }

        protected void dtgTipoDocumento_Sorting(object sender, GridViewSortEventArgs e)
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
                dtgTipoDocumento.DataSource = m_DataView;
                dtgTipoDocumento.DataBind();
            }

        }

        protected void btnBusca_Click(object sender, EventArgs e)
        {
            Pesquisar(txtBusca.Text);
        }
    }
}