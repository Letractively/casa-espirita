using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using FG;
using DataObjects;
using BusinessLayer;


namespace Admin
{
    public partial class viewExemplar : System.Web.UI.Page
    {
        Utils utils = new Utils();
        #region funcoes
        public DataTable dtbPesquisa
        {
            get
            {
                if (Session["_dtbPesquisa_cadBai"] != null)
                    return (DataTable)Session["_dtbPesquisa_cadBai"];
                else
                    return null;
            }
            set { Session["_dtbPesquisa_cadBai"] = value; }
        }

        private void Pesquisar(string campo, string valor)
        {
            DataTable tabela = new DataTable("tabela");

            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("CODIGO", Type.GetType("System.Int32"));
            DataColumn coluna3 = new DataColumn("DESCRICAO", Type.GetType("System.String"));
            DataColumn coluna4 = new DataColumn("TOMBO", Type.GetType("System.Int32"));
            DataColumn coluna5 = new DataColumn("STATUS", Type.GetType("System.String"));


            tabela.Columns.Add(coluna1);
            tabela.Columns.Add(coluna2);
            tabela.Columns.Add(coluna3);
            tabela.Columns.Add(coluna4);
            tabela.Columns.Add(coluna5);

            ExemplaresBL exemBL = new ExemplaresBL();
            List<Exemplares> exemplares;

            if (campo != null && valor.Trim() != "")
                exemplares = exemBL.PesquisarBL(campo, valor);
            else
                exemplares = exemBL.PesquisarBL();

            foreach (Exemplares exem in exemplares)
            {

                DataRow linha = tabela.NewRow();

                linha["ID"] = exem.Id;              
                linha["TOMBO"] = exem.Tombo;
                linha["STATUS"] = exem.Status;
                if (exem.Obras != null)
                {
                    linha["CODIGO"] = exem.Obras.Codigo;
                    linha["DESCRICAO"] = exem.Obras.Titulo;
                }


                tabela.Rows.Add(linha);
            }

            dtbPesquisa = tabela;
            dtgExemplar.DataSource = tabela;
            dtgExemplar.DataBind();
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                Pesquisar(null, null);
        }

        
        protected void btnInserir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/cadExemplar.aspx?operacao=new");
        }

        protected void dtgExemplar_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {           
            dtgExemplar.DataSource = dtbPesquisa;
            dtgExemplar.PageIndex = e.NewPageIndex;
            dtgExemplar.DataBind();
        }

        protected void dtgExemplar_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (this.Master.VerificaPermissaoUsuario("EXCLUIR"))
            {
                ExemplaresBL exemBL = new ExemplaresBL();
                Exemplares exemplares = new Exemplares();
                exemplares.Id = utils.ComparaIntComZero(dtgExemplar.DataKeys[e.RowIndex][0].ToString());
                exemBL.ExcluirBL(exemplares);
                Pesquisar(null, null);
            }
            else
                Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);
        }

        protected void dtgExemplar_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow) 
                utils.CarregarEfeitoGrid("#c8defc", "#ffffff", e);

            if (e.Row.RowType == DataControlRowType.DataRow)
                utils.CarregarJsExclusao("Deseja excluir este registro?", 1, e);
        }

        protected void dtgExemplar_Sorting(object sender, GridViewSortEventArgs e)
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
                dtgExemplar.DataSource = m_DataView;
                dtgExemplar.DataBind();
            }
        }

        protected void dtgExemplar_SelectedIndexChanged(object sender, EventArgs e)
        {
            int str_exem = 0;
            str_exem = utils.ComparaIntComZero(dtgExemplar.SelectedDataKey[0].ToString());
            Response.Redirect("cadExemplar.aspx?id_exem=" + str_exem.ToString() + "&operacao=edit");
        }
    }
}