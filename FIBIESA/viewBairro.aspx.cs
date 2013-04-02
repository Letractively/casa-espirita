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
    public partial class viewBairro : System.Web.UI.Page
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
        private void Pesquisar(string valor)
        {
            DataTable tabela = new DataTable("tabela");
            
            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("CODIGO", Type.GetType("System.Int32"));
            DataColumn coluna3 = new DataColumn("DESCRICAO", Type.GetType("System.String"));

            tabela.Columns.Add(coluna1);
            tabela.Columns.Add(coluna2);
            tabela.Columns.Add(coluna3);
            
            BairrosBL baiBL = new BairrosBL();            
            List<Bairros> bairros;
                        
            bairros = baiBL.PesquisarBuscaBL(valor);
                                   
            foreach (Bairros bai in bairros)
            {
                
                DataRow linha = tabela.NewRow();
                
                linha["ID"] = bai.Id;
                linha["CODIGO"] = bai.Codigo;
                linha["DESCRICAO"] = bai.Descricao;

               
                tabela.Rows.Add(linha);
            }

            dtbPesquisa = tabela;
            dtgBairros.DataSource = tabela;           
            dtgBairros.DataBind();
        }

        public void ExibirMensagem(string mensagem)
        {
            ClientScript.RegisterStartupScript(System.Type.GetType("System.String"), "Alert",
               "<script language='javascript'> { window.alert(\"" + mensagem + "\") }</script>");
        }
      
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
                Pesquisar(null);
        }

     
        protected void btnInserir_Click(object sender, EventArgs e)
        {            
            Response.Redirect("cadBairro.aspx?operacao=new");
        }
            
        protected void btnBusca_Click(object sender, EventArgs e)
        {          
            Pesquisar(txtBusca.Text);     
        }

        protected void dtgBairros_SelectedIndexChanged(object sender, EventArgs e)
        {
            int str_bai = 0;
            str_bai = utils.ComparaIntComZero(dtgBairros.SelectedDataKey[0].ToString());
            Response.Redirect("cadBairro.aspx?id_bai=" + str_bai.ToString() + "&operacao=edit");
        }

        protected void dtgBairros_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (this.Master.VerificaPermissaoUsuario("EXCLUIR"))
            {
                BairrosBL baiBL = new BairrosBL();
                Bairros bairros = new Bairros();
                bairros.Id = utils.ComparaIntComZero(dtgBairros.DataKeys[e.RowIndex][0].ToString());
                if (baiBL.ExcluirBL(bairros))
                    ExibirMensagem("Bairro excluído com sucesso !");
                else
                    ExibirMensagem("Não foi possível excluir o bairro.");
                
                Pesquisar(null);
            }
            else
                Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);
        }

        protected void dtgBairros_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dtgBairros.DataSource = dtbPesquisa;
            dtgBairros.PageIndex = e.NewPageIndex;
            dtgBairros.DataBind();
        }

        protected void dtgBairros_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow) 
                utils.CarregarEfeitoGrid("#c8defc", "#ffffff", e);

            if (e.Row.RowType == DataControlRowType.DataRow)             
                utils.CarregarJsExclusao("Deseja excluir este registro?", 1, e);
            
        }

        protected void dtgBairros_Sorting(object sender, GridViewSortEventArgs e)
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
                dtgBairros.DataSource = m_DataView;
                dtgBairros.DataBind();
            }
        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
               
      
    }
}