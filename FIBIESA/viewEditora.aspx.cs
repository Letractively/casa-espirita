using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using FG;
using BusinessLayer;
using DataObjects;


namespace Admin
{
    public partial class viewEditora : System.Web.UI.Page
    {
        //dtgEditoras
        Utils utils = new Utils();

        #region funcoes
        public DataTable dtbPesquisa
        {
            get
            {
                if (Session["_dtbPesquisa_cadEditoras"] != null)
                    return (DataTable)Session["_dtbPesquisa_cadEditoras"];
                else
                    return null;
            }
            set { Session["_dtbPesquisa_cadEditoras"] = value; }
        }
        private void Pesquisar(string campo, string valor)
        {
            DataTable tabela = new DataTable("tabela");
            
            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("CODIGO", Type.GetType("System.Int32"));
            DataColumn coluna3 = new DataColumn("DESCRICAO", Type.GetType("System.String"));

            tabela.Columns.Add(coluna1);
            tabela.Columns.Add(coluna2);
            tabela.Columns.Add(coluna3);
            
            
            EditorasBL ediBL = new EditorasBL();            
            List<Editoras> editoras;

            if (campo != null && valor.Trim() != "")
                editoras = ediBL.PesquisarBL(campo, valor);
            else
                editoras = ediBL.PesquisarBL();
                       
            foreach (Editoras bai in editoras)
            {
                
                DataRow linha = tabela.NewRow();
                
                linha["ID"] = bai.Id;
                linha["CODIGO"] = bai.Codigo;
                linha["DESCRICAO"] = bai.Descricao;

               
                tabela.Rows.Add(linha);
            }

            dtbPesquisa = tabela;
            dtgEditoras.DataSource = tabela;           
            dtgEditoras.DataBind();
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
                Pesquisar(null, null);
        }

     
        protected void btnInserir_Click(object sender, EventArgs e)
        {
            Response.Redirect("cadEditora.aspx?operacao=new");
        }
            
        protected void btnBusca_Click(object sender, EventArgs e)
        {
            Pesquisar(ddlCampo.SelectedValue, txtBusca.Text);     
        }

        protected void dtgEditoras_SelectedIndexChanged(object sender, EventArgs e)
        {
            int str_bai = 0;
            str_bai = utils.ComparaIntComZero(dtgEditoras.SelectedDataKey[0].ToString());
            Response.Redirect("cadEditora.aspx?id_bai=" + str_bai.ToString() + "&operacao=edit");
        }

        protected void dtgEditoras_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (this.Master.VerificaPermissaoUsuario("EXCLUIR"))
            {
                EditorasBL edBL = new EditorasBL();
                Editoras editoras = new Editoras();
                editoras.Id = utils.ComparaIntComZero(dtgEditoras.DataKeys[e.RowIndex][0].ToString());
                edBL.ExcluirBL(editoras);
                Pesquisar(null, null);
            }
            else
                Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);
        }

        protected void dtgEditoras_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dtgEditoras.DataSource = dtbPesquisa;
            dtgEditoras.PageIndex = e.NewPageIndex;
            dtgEditoras.DataBind();
        }

        protected void dtgEditoras_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow) 
                utils.CarregarEfeitoGrid("#c8defc", "#ffffff", e);

            if (e.Row.RowType == DataControlRowType.DataRow)
                utils.CarregarJsExclusao("Deseja excluir este registro?", 1, e);
        }

        protected void dtgEditoras_Sorting(object sender, GridViewSortEventArgs e)
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
                dtgEditoras.DataSource = m_DataView;
                dtgEditoras.DataBind();
            }
        }
               
      
    }
}
