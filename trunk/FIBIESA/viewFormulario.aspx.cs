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
    public partial class viewFormulario : System.Web.UI.Page
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
 
        private void Pesquisar(string valor)
        {
            DataTable tabela = new DataTable("tabela");

            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("CODIGO", Type.GetType("System.Int32"));
            DataColumn coluna3 = new DataColumn("DESCRICAO", Type.GetType("System.String"));

            tabela.Columns.Add(coluna1);
            tabela.Columns.Add(coluna2);
            tabela.Columns.Add(coluna3);

            FormulariosBL forBL = new FormulariosBL();
            List<Formularios> formularios;
            
            formularios = forBL.PesquisarBuscaBL(valor);
            
            foreach (Formularios formu in formularios)
            {

                DataRow linha = tabela.NewRow();

                linha["ID"] = formu.Id;
                linha["CODIGO"] = formu.Codigo;
                linha["DESCRICAO"] = formu.Descricao;


                tabela.Rows.Add(linha);
            }

            dtbPesquisa = tabela;
            dtgFormularios.DataSource = tabela;
            dtgFormularios.DataBind();
        }
        private string ConvertSortDirectionToSql(SortDirection sortDirection)
        {
            string newSortDirection = String.Empty;

            switch (sortDirection)
            {
                case SortDirection.Ascending:
                    newSortDirection = "ASC";
                    break;

                case SortDirection.Descending:
                    newSortDirection = "DESC";
                    break;
            }

            return newSortDirection;
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
            Response.Redirect("cadFormulario.aspx?operacao=new");
        }

        protected void dtgFormularios_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (this.Master.VerificaPermissaoUsuario("EXCLUIR"))
            {
                FormulariosBL formBL = new FormulariosBL();
                Formularios formularios = new Formularios();
                formularios.Id = utils.ComparaIntComZero(dtgFormularios.DataKeys[e.RowIndex][0].ToString());

                if (formBL.ExcluirBL(formularios))
                    ExibirMensagem("Registro excluído com sucesso !");
                else
                    ExibirMensagem("Não foi possível excluir o registro.");

                Pesquisar(null);
            }
            else
                Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);
           
        }

        protected void dtgFormularios_SelectedIndexChanged(object sender, EventArgs e)
        {
            int str_for = 0;
            str_for = utils.ComparaIntComZero(dtgFormularios.SelectedDataKey[0].ToString());
            Response.Redirect("cadFormulario.aspx?id_for=" + str_for.ToString() + "&operacao=edit");
        }

        protected void dtgFormularios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {            
            dtgFormularios.DataSource = dtbPesquisa;
            dtgFormularios.PageIndex = e.NewPageIndex;
            dtgFormularios.DataBind();
        }

        protected void dtgFormularios_Sorting(object sender, GridViewSortEventArgs e)
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
                dtgFormularios.DataSource = m_DataView;
                dtgFormularios.DataBind();
            }
        }

        protected void btnBusca_Click(object sender, EventArgs e)
        {
            Pesquisar(txtBusca.Text);            
        }

        protected void dtgFormularios_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow) 
                utils.CarregarEfeitoGrid("#c8defc", "#ffffff", e);

            if (e.Row.RowType == DataControlRowType.DataRow)
                utils.CarregarJsExclusao("Deseja excluir este registro?", 1, e);
        }

                
    }
}