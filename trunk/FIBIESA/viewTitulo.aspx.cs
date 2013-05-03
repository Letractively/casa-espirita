using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using DataObjects;
using BusinessLayer;
using FG;


namespace Admin
{
    public partial class viewTitulo : System.Web.UI.Page
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
            DataTable tabela = new DataTable();
            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("NUMERO", Type.GetType("System.Int32"));
            DataColumn coluna3 = new DataColumn("PESSOAID", Type.GetType("System.String"));
            DataColumn coluna4 = new DataColumn("PORTADORID", Type.GetType("System.Int32"));
            DataColumn coluna5 = new DataColumn("VALORPAGO", Type.GetType("System.String"));

            tabela.Columns.Add(coluna1);
            tabela.Columns.Add(coluna2);
            tabela.Columns.Add(coluna3);
            tabela.Columns.Add(coluna4);
            tabela.Columns.Add(coluna5);

            TitulosBL titBL = new TitulosBL();
            List<Titulos> titulos;

            titulos = titBL.PesquisarBuscaBL(valor);

            foreach (Titulos ltTit in titulos)
            {
                DataRow linha = tabela.NewRow();

                linha["ID"] = ltTit.Id;
                linha["NUMERO"] = ltTit.Numero;
                linha["PESSOAID"] = ltTit.Pessoaid;
                linha["PORTADORID"] = ltTit.Pessoaid;
                linha["VALORPAGO"] = ltTit.Pessoaid;

                tabela.Rows.Add(linha);
            }

            dtbPesquisa = tabela;
            dtgTitulo.DataSource = tabela;
            dtgTitulo.DataBind();
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                Pesquisar(null);
        }

        protected void btnInserir_Click(object sender, EventArgs e)
        {
            Response.Redirect("cadTitulo.aspx?operacao=new");
        }

        protected void dtgTitulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int str_con = 0;
            str_con = utils.ComparaIntComZero(dtgTitulo.SelectedDataKey[0].ToString());
            Response.Redirect("cadTitulo.aspx?id_con=" + str_con.ToString() + "&operacao=edit");
        }

        protected void dtgTitulo_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            ContasBL conBL = new ContasBL();
            Contas contas = new Contas();
            contas.Id = utils.ComparaIntComZero(dtgTitulo.DataKeys[e.RowIndex][0].ToString());
            conBL.ExcluirBL(contas);
            Pesquisar(null);
            
            
            //if (this.Master.VerificaPermissaoUsuario("EXCLUIR"))
            //{
            //    ContasBL conBL = new ContasBL();
            //    Contas contas = new Contas();
            //    contas.Id = utils.ComparaIntComZero(dtgTitulo.DataKeys[e.RowIndex][0].ToString());
            //    conBL.ExcluirBL(contas);
            //    Pesquisar(null);
            //}
            //else
            //    Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);
        }

        protected void btnBusca_Click(object sender, EventArgs e)
        {
            Pesquisar(txtBusca.Text);
        }

        protected void dtgTitulo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dtgTitulo.DataSource = dtbPesquisa;
            dtgTitulo.PageIndex = e.NewPageIndex;
            dtgTitulo.DataBind();
        }

        protected void dtgTitulo_Sorting(object sender, GridViewSortEventArgs e)
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
                dtgTitulo.DataSource = m_DataView;
                dtgTitulo.DataBind();
            }
        }

        protected void dtgTitulo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                utils.CarregarEfeitoGrid("#c8defc", "#ffffff", e);

            if (e.Row.RowType == DataControlRowType.DataRow)
                utils.CarregarJsExclusao("Deseja excluir este registro?", 1, e);
        }
    }
}