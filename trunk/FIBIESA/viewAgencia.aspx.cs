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
    public partial class viewAgencia : System.Web.UI.Page
    {

        Utils utils = new Utils();

        #region funcoes
        public DataTable dtbPesquisa
        {
            get
            {
                if (Session["_dtbPesquisa_cadAge"] != null)
                    return (DataTable)Session["_dtbPesquisa_cadAge"];
                else
                    return null;
            }
            set { Session["_dtbPesquisa_cadAge"] = value; }
        }

        private void Pesquisar(string campo, string valor)
        {
            DataTable tabela = new DataTable();
            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("CODIGO", Type.GetType("System.Int32"));
            DataColumn coluna3 = new DataColumn("DESCRICAO", Type.GetType("System.String"));
            DataColumn coluna4 = new DataColumn("CODBANCO", Type.GetType("System.Int32"));
            DataColumn coluna5 = new DataColumn("DESBANCO", Type.GetType("System.String"));

            tabela.Columns.Add(coluna1);
            tabela.Columns.Add(coluna2);
            tabela.Columns.Add(coluna3);
            tabela.Columns.Add(coluna4);
            tabela.Columns.Add(coluna5);

            AgenciasBL ageBL = new AgenciasBL();
            List<Agencias> agencias;

            if (campo != null && valor.Trim() != "")
                agencias = ageBL.PesquisarBL(campo, valor);
            else
                agencias = ageBL.PesquisarBL();


            foreach (Agencias ltAge in agencias)
            {
                DataRow linha = tabela.NewRow();

                linha["ID"] = ltAge.Id;
                linha["CODIGO"] = ltAge.Codigo;
                linha["DESCRICAO"] = ltAge.Descricao;
                linha["CODBANCO"] = ltAge.Banco.Codigo;
                linha["DESBANCO"] = ltAge.Banco.Descricao;

                tabela.Rows.Add(linha);                
            }

            dtbPesquisa = tabela;
            dtgAgencia.DataSource = tabela;
            dtgAgencia.DataBind();
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                Pesquisar(null,null);

        }

        protected void btnInserir_Click(object sender, EventArgs e)
        {
            Response.Redirect("cadAgencia.aspx?operacao=new");
        }

        protected void dtgAgencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            int str_age = 0;
            str_age = utils.ComparaIntComZero(dtgAgencia.SelectedDataKey[0].ToString());
            Response.Redirect("cadAgencia.aspx?id_age=" + str_age.ToString() + "&operacao=edit");
        }

        protected void dtgAgencia_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (this.Master.VerificaPermissaoUsuario("EXCLUIR"))
            {
                AgenciasBL ageBL = new AgenciasBL();
                Agencias agencias = new Agencias();
                agencias.Id = utils.ComparaIntComZero(dtgAgencia.DataKeys[e.RowIndex][0].ToString());
                ageBL.ExcluirBL(agencias);
                Pesquisar(null,null);
            }
            else
                Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);
        }

        protected void dtgAgencia_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow) //se for uma linha de dados
                utils.CarregarEfeitoGrid("#c8defc", "#ffffff", e);
        }

        protected void dtgAgencia_Sorting(object sender, GridViewSortEventArgs e)
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
                dtgAgencia.DataSource = m_DataView;
                dtgAgencia.DataBind();
            }
        }

        protected void dtgAgencia_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dtgAgencia.DataSource = dtbPesquisa;
            dtgAgencia.PageIndex = e.NewPageIndex;
            dtgAgencia.DataBind();
        }

        protected void btnBusca_Click(object sender, EventArgs e)
        {
            Pesquisar(ddlCampo.SelectedValue, txtBusca.Text);    
        }

      
    }
}