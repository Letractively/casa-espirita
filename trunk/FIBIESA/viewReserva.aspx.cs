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
    public partial class viewReserva : System.Web.UI.Page
    {
        Utils utils = new Utils();

        #region funcoes
        public DataTable dtbPesquisa
        {
            get
            {
                if (Session["_dtbPesquisa_cadReserva"] != null)
                    return (DataTable)Session["_dtbPesquisa_cadReserva"];
                else
                    return null;
            }
            set { Session["_dtbPesquisa_cadReserva"] = value; }
        }
        private void Pesquisar(string valor)
        {
            DataTable tabela = new DataTable("tabela");

            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("titulo", Type.GetType("System.String"));
            DataColumn coluna3 = new DataColumn("nome", Type.GetType("System.String"));

            tabela.Columns.Add(coluna1);
            tabela.Columns.Add(coluna2);
            tabela.Columns.Add(coluna3);            
            
            EmprestimosBL emprestimBL = new EmprestimosBL();
            List<ViewEmprestimos> emprestimos;
            
            emprestimos = emprestimBL.PesquisarBuscaBL(valor);

            foreach (ViewEmprestimos visao in emprestimos)
            {
                DataRow linha = tabela.NewRow();

                linha["ID"] = visao.Id;
                linha["TITULO"] = visao.Titulo;
                linha["NOME"] = visao.Nome;

                tabela.Rows.Add(linha);
            }

            dtbPesquisa = tabela;
            dtgReservas.DataSource = tabela;
            dtgReservas.DataBind();
            
        }

        public void ExibirMensagem(string mensagem)
        {
            ClientScript.RegisterStartupScript(System.Type.GetType("System.String"), "Alert",
               "<script language='javascript'> { window.alert(\"" + mensagem + "\") }</script>");
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Busca_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnInserir_Click(object sender, EventArgs e)
        {
            Response.Redirect("cadReserva.aspx?operacao=new");
        }

        protected void dtgReservas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dtgReservas.DataSource = dtbPesquisa;
            dtgReservas.PageIndex = e.NewPageIndex;
            dtgReservas.DataBind();
        }

        protected void dtgReservas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                utils.CarregarEfeitoGrid("#c8defc", "#ffffff", e);

            if (e.Row.RowType == DataControlRowType.DataRow)
                utils.CarregarJsExclusao("Deseja excluir este registro?", 1, e);

        }

        protected void dtgReservas_SelectedIndexChanged(object sender, EventArgs e)
        {
            int str_reser = 0;
            str_reser = utils.ComparaIntComZero(dtgReservas.SelectedDataKey[0].ToString());
            Response.Redirect("cadReserva.aspx?id_emp=" + str_reser.ToString() + "&operacao=edit");
        }

        protected void dtgReservas_Sorting(object sender, GridViewSortEventArgs e)
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
                dtgReservas.DataSource = m_DataView;
                dtgReservas.DataBind();
            }
        }
    }
}