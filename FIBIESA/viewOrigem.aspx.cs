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
    public partial class viewOrigem : System.Web.UI.Page
    {
        Utils utils = new Utils();

        #region funcoes
        public DataTable dtbPesquisa
        {
            get
            {
                if (Session["_dtbPesquisa_cadOrigem"] != null)
                    return (DataTable)Session["_dtbPesquisa_cadOrigem"];
                else
                    return null;
            }
            set { Session["_dtbPesquisa_cadOrigem"] = value; }
        }
        private void Pesquisar(string valor)
        {
            DataTable tabela = new DataTable("tabela");

            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("CODIGO", Type.GetType("System.Int32"));
            DataColumn coluna3 = new DataColumn("DESCRICAO", Type.GetType("System.String"));

            tabela.Columns.Add(coluna1);
            tabela.Columns.Add(coluna2);
            tabela.Columns.Add(coluna3);

            OrigensBL origemBL = new OrigensBL();
            List<Origens> origens;

            origens = origemBL.PesquisarBuscaBL(valor);

            foreach (Origens bai in origens)
            {

                DataRow linha = tabela.NewRow();

                linha["ID"] = bai.Id;
                linha["CODIGO"] = bai.Codigo;
                linha["DESCRICAO"] = bai.Descricao;


                tabela.Rows.Add(linha);
            }

            dtbPesquisa = tabela;
            dtgOrigens.DataSource = tabela;
            dtgOrigens.DataBind();
        }

        private void ExibirMensagem(string mensagem)
        {
            ClientScript.RegisterStartupScript(System.Type.GetType("System.String"), "Alert",
               "<script language='javascript'> { window.alert(\"" + mensagem + "\") }</script>");
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnInserir_Click(object sender, EventArgs e)
        {
            Response.Redirect("cadOrigem.aspx?operacao=new");
        }

        protected void btnBusca_Click(object sender, EventArgs e)
        {
            Pesquisar(txtBusca.Text);
        }

        protected void dtgOrigens_SelectedIndexChanged(object sender, EventArgs e)
        {
            int str_origem = 0;
            str_origem = utils.ComparaIntComZero(dtgOrigens.SelectedDataKey[0].ToString());
            Response.Redirect("cadOrigem.aspx?id_bai=" + str_origem.ToString() + "&operacao=edit");
        }

        protected void dtgOrigens_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            OrigensBL origemBL = new OrigensBL();
            Origens origens = new Origens();
            origens.Id = utils.ComparaIntComZero(dtgOrigens.DataKeys[e.RowIndex][0].ToString());

            if (origemBL.ExcluirBL(origens))
                ExibirMensagem("Registro excluído com sucesso !");
            else
                ExibirMensagem("Não foi possível excluir o registro, existem registros dependentes");

            Pesquisar(null);

        }

        protected void dtgOrigens_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dtgOrigens.DataSource = dtbPesquisa;
            dtgOrigens.PageIndex = e.NewPageIndex;
            dtgOrigens.DataBind();
        }

        protected void dtgOrigens_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                utils.CarregarEfeitoGrid("#c8defc", "#ffffff", e);

            if (e.Row.RowType == DataControlRowType.DataRow)
                utils.CarregarJsExclusao("Deseja excluir este registro?", 1, e);
        }

        protected void dtgOrigens_Sorting(object sender, GridViewSortEventArgs e)
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
                dtgOrigens.DataSource = m_DataView;
                dtgOrigens.DataBind();
            }
        }


    }
}