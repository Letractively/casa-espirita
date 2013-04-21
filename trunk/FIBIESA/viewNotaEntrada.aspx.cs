using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLayer;
using DataObjects;
using FG;


namespace Admin
{
    public partial class viewNotaEntrada : System.Web.UI.Page
    {
        Utils utils = new Utils();
        #region funcoes
        public DataTable dtbPesquisa
        {
            get
            {
                if (Session["_dtbPesquisa_cadNotaE"] != null)
                    return (DataTable)Session["_dtbPesquisa_cadNotaE"];
                else
                    return null;
            }
            set { Session["_dtbPesquisa_cadNotaE"] = value; }
        }
        private void Pesquisar(string valor)
        {
            DataTable tabela = new DataTable();
            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("NUMERO", Type.GetType("System.Int32"));
            DataColumn coluna3 = new DataColumn("SERIE", Type.GetType("System.Int32"));
            DataColumn coluna4 = new DataColumn("DATA", Type.GetType("System.String"));

            tabela.Columns.Add(coluna1);
            tabela.Columns.Add(coluna2);
            tabela.Columns.Add(coluna3);
            tabela.Columns.Add(coluna4);
            
            NotasEntradaBL ntEBL = new NotasEntradaBL();
            List<NotasEntrada> notasEntrada = ntEBL.PesquisarBL();

            notasEntrada = ntEBL.PesquisarBuscaBL(valor);
            
            foreach (NotasEntrada ltNtE in notasEntrada)
            {
                DataRow linha = tabela.NewRow();

                linha["ID"] = ltNtE.Id;
                linha["NUMERO"] = ltNtE.Numero;
                linha["SERIE"] = ltNtE.Serie;
                linha["DATA"] = ltNtE.Data.ToString("dd/MM/yyyy");

                tabela.Rows.Add(linha);
            }

            dtbPesquisa = tabela;
            dtgNotaEntrada.DataSource = tabela;
            dtgNotaEntrada.DataBind();

        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                Pesquisar(null);
        }

        protected void btnInserir_Click(object sender, EventArgs e)
        {
            Response.Redirect("cadNotaEntrada.aspx?operacao=new");
        }

        protected void dtgNotaEntrada_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (this.Master.VerificaPermissaoUsuario("EXCLUIR"))
            {
                NotasEntradaBL ntEBL = new NotasEntradaBL();
                NotasEntrada notaEntrada = new NotasEntrada();
                notaEntrada.Id = utils.ComparaIntComZero(dtgNotaEntrada.DataKeys[e.RowIndex][0].ToString());
                ntEBL.ExcluirBL(notaEntrada);
                Pesquisar(null);
            }
            else
                Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);
        }

        protected void dtgNotaEntrada_SelectedIndexChanged(object sender, EventArgs e)
        {
            int str_ntE = 0;
            str_ntE = utils.ComparaIntComZero(dtgNotaEntrada.SelectedDataKey[0].ToString());
            Response.Redirect("cadNotaEntrada.aspx?id_ntE=" + str_ntE.ToString() + "&operacao=edit");
        }

        protected void btnBusca_Click(object sender, EventArgs e)
        {
            Pesquisar(txtBusca.Text); 
        }

        protected void dtgNotaEntrada_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dtgNotaEntrada.DataSource = dtbPesquisa;
            dtgNotaEntrada.PageIndex = e.NewPageIndex;
            dtgNotaEntrada.DataBind();
        }

        protected void dtgNotaEntrada_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                utils.CarregarEfeitoGrid("#c8defc", "#ffffff", e);

            if (e.Row.RowType == DataControlRowType.DataRow)
                utils.CarregarJsExclusao("Deseja excluir este registro?", 1, e);
        }

        protected void dtgNotaEntrada_Sorting(object sender, GridViewSortEventArgs e)
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
                dtgNotaEntrada.DataSource = m_DataView;
                dtgNotaEntrada.DataBind();
            }
        }
               
    }
}