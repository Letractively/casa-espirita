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
    public partial class viewTipoObra : System.Web.UI.Page
    {
        Utils utils = new Utils();

        #region funcoes
        public DataTable dtbPesquisa
        {
            get
            {
                if (Session["_dtbPesquisa_cadTiposObras"] != null)
                    return (DataTable)Session["_dtbPesquisa_cadTiposObras"];
                else
                    return null;
            }
            set { Session["_dtbPesquisa_cadTiposObras"] = value; }
        }
        private void Pesquisar(string campo, string valor)
        {
            DataTable tabela = new DataTable("tabela");

            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("CODIGO", Type.GetType("System.Int32"));
            DataColumn coluna3 = new DataColumn("DESCRICAO", Type.GetType("System.String"));
            DataColumn coluna4 = new DataColumn("QTDDIAS", Type.GetType("System.Int32"));

            tabela.Columns.Add(coluna1);
            tabela.Columns.Add(coluna2);
            tabela.Columns.Add(coluna3);
            tabela.Columns.Add(coluna4);


            TiposObrasBL tiposBL = new TiposObrasBL();
            List<TiposObras> tipos;

            if (campo != null && valor.Trim() != "")
                tipos = tiposBL.PesquisarBL(campo, valor);
            else
                tipos = tiposBL.PesquisarBL();

            foreach (TiposObras tipoObra in tipos)
            {

                DataRow linha = tabela.NewRow();

                linha["ID"] = tipoObra.Id;
                linha["CODIGO"] = tipoObra.Codigo;
                linha["DESCRICAO"] = tipoObra.Descricao;
                linha["QTDDIAS"] = tipoObra.QtdDias;

                tabela.Rows.Add(linha);
            }

            dtbPesquisa = tabela;
            dtgTiposObras.DataSource = tabela;
            dtgTiposObras.DataBind();
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                Pesquisar(null, null);
        }


        protected void btnInserir_Click(object sender, EventArgs e)
        {
            Response.Redirect("cadTipoObra.aspx?operacao=new");
        }

        protected void btnBusca_Click(object sender, EventArgs e)
        {
            Pesquisar(ddlCampo.SelectedValue, txtBusca.Text);
        }

        protected void dtgTiposObras_SelectedIndexChanged(object sender, EventArgs e)
        {
            int str_tipo = 0;
            str_tipo = utils.ComparaIntComZero(dtgTiposObras.SelectedDataKey[0].ToString());
            Response.Redirect("cadTipoObra.aspx?id_bai=" + str_tipo.ToString() + "&operacao=edit");
        }

        protected void dtgTiposObras_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (this.Master.VerificaPermissaoUsuario("EXCLUIR"))
            {
                TiposObrasBL tipoBL = new TiposObrasBL();
                TiposObras tipos = new TiposObras();
                tipos.Id = utils.ComparaIntComZero(dtgTiposObras.DataKeys[e.RowIndex][0].ToString());
                tipoBL.ExcluirBL(tipos);
                Pesquisar(null, null);
            }
            else
                Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);
        }

        protected void dtgTiposObras_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dtgTiposObras.DataSource = dtbPesquisa;
            dtgTiposObras.PageIndex = e.NewPageIndex;
            dtgTiposObras.DataBind();
        }

        protected void dtgTiposObras_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow) //se for uma linha de dados
                utils.CarregarEfeitoGrid("#c8defc", "#ffffff", e);
        }

        protected void dtgTiposObras_Sorting(object sender, GridViewSortEventArgs e)
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
                dtgTiposObras.DataSource = m_DataView;
                dtgTiposObras.DataBind();
            }
        }
    }
}