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
using System.Data.SqlClient;

namespace FIBIESA
{
    public partial class viewDoacao : System.Web.UI.Page
    {
        Utils utils = new Utils();

        #region funcoes
        public DataTable dtbPesquisa
        {
            get
            {
                if (Session["_dtbPesquisa_cadDoa"] != null)
                    return (DataTable)Session["_dtbPesquisa_cadDoa"];
                else
                    return null;
            }
            set { Session["_dtbPesquisa_cadDoa"] = value; }
        }

        private void Pesquisar(string campo, string valor)
        {
            DataTable tabela = new DataTable();
            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("DATA", Type.GetType("System.String"));
            DataColumn coluna3 = new DataColumn("CODPESSOA", Type.GetType("System.Int32"));
            DataColumn coluna4 = new DataColumn("NOME", Type.GetType("System.String"));
            DataColumn coluna5 = new DataColumn("VALOR", Type.GetType("System.Decimal"));

            tabela.Columns.Add(coluna1);
            tabela.Columns.Add(coluna2);
            tabela.Columns.Add(coluna3);
            tabela.Columns.Add(coluna4);
            tabela.Columns.Add(coluna5);

            DoacoesBL doaBL = new DoacoesBL();
            List<Doacoes> doacoes;

            if (campo != null && valor.Trim() != "")
                doacoes = doaBL.PesquisarBL(campo, valor);
            else
                doacoes = doaBL.PesquisarBL();

            foreach (Doacoes ltDoa in doacoes)
            {
                DataRow linha = tabela.NewRow();

                linha["ID"] = ltDoa.Id;
                linha["DATA"] = ltDoa.Data.ToString("dd/MM/yyyy");
                linha["CODPESSOA"] = ltDoa.Pessoa.Codigo;
                linha["NOME"] = ltDoa.Pessoa.Nome;
                linha["VALOR"] = ltDoa.Valor;

                tabela.Rows.Add(linha);               
            }

            dtbPesquisa = tabela;
            dtgDoacao.DataSource = tabela;
            dtgDoacao.DataBind(); 
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                Pesquisar(null,null);
        }

        protected void btnInserir_Click(object sender, EventArgs e)
        {
            Response.Redirect("cadDoacao.aspx");
        }
                
        protected void dtgDoacao_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (this.Master.VerificaPermissaoUsuario("EXCLUIR"))
            {
                DoacoesBL doaBL = new DoacoesBL();
                Doacoes doacoes = new Doacoes();
                doacoes.Id = utils.ComparaIntComZero(dtgDoacao.DataKeys[e.RowIndex][0].ToString());
                doaBL.ExcluirBL(doacoes);
                Pesquisar(null,null);
            }
            else
                Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);
        }

        protected void dtgDoacao_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dtgDoacao.DataSource = dtbPesquisa;
            dtgDoacao.PageIndex = e.NewPageIndex;
            dtgDoacao.DataBind();
        }

        protected void dtgDoacao_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow) //se for uma linha de dados
                utils.CarregarEfeitoGrid("#c8defc", "#ffffff", e);
        }

        protected void dtgDoacao_Sorting(object sender, GridViewSortEventArgs e)
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
                dtgDoacao.DataSource = m_DataView;
                dtgDoacao.DataBind();
            }
        }

        protected void btnBusca_Click(object sender, EventArgs e)
        {
            Pesquisar(ddlCampo.SelectedValue, txtBusca.Text);
        }

        
    }
}