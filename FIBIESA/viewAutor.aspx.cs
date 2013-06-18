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
    public partial class viewAutor : System.Web.UI.Page
    {
        Utils utils = new Utils();

        #region funcoes
        public DataTable dtbPesquisa
        {
            get
            {
                if (Session["_dtbPesquisa_cadAutores"] != null)
                    return (DataTable)Session["_dtbPesquisa_cadAutores"];
                else
                    return null;
            }
            set { Session["_dtbPesquisa_cadAutores"] = value; }
        }

        private void ExibirMensagem(string mensagem)
        {
            ClientScript.RegisterStartupScript(System.Type.GetType("System.String"), "Alert",
               "<script language='javascript'> { window.alert(\"" + mensagem + "\") }</script>");
        }
        
        private void Pesquisar(string valor)
        {
            DataTable tabela = new DataTable("tabela");

            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("CODIGO", Type.GetType("System.Int32"));
            DataColumn coluna3 = new DataColumn("DESCRICAO", Type.GetType("System.String"));
            DataColumn coluna4 = new DataColumn("TIPODESC", Type.GetType("System.String"));

            tabela.Columns.Add(coluna1);
            tabela.Columns.Add(coluna2);
            tabela.Columns.Add(coluna3);
            tabela.Columns.Add(coluna4);

            AutoresBL autorBL = new AutoresBL();
            List<Autores> autores;

            autores = autorBL.PesquisarBuscaBL(valor);
            
            foreach (Autores autor in autores)
            {

                DataRow linha = tabela.NewRow();

                linha["ID"] = autor.Id;
                linha["CODIGO"] = autor.Codigo;
                linha["DESCRICAO"] = autor.Descricao;
                if(autor.TiposDeAutores != null)
                    linha["TIPODESC"] = autor.TiposDeAutores.Descricao;
                else
                    linha["TIPODESC"] = "";

                tabela.Rows.Add(linha);
            }

            dtbPesquisa = tabela;
            dtgAutores.DataSource = tabela;
            dtgAutores.DataBind();
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                Pesquisar(null);
        }

        protected void btnInserir_Click(object sender, EventArgs e)
        {
            Response.Redirect("cadAutor.aspx?operacao=new");
        }

        protected void btnBusca_Click(object sender, EventArgs e)
        {
            Pesquisar(txtBusca.Text);
        }

        protected void dtgBairros_SelectedIndexChanged(object sender, EventArgs e)
        {
            int str_bai = 0;
            str_bai = utils.ComparaIntComZero(dtgAutores.SelectedDataKey[0].ToString());
            Response.Redirect("cadAutor.aspx?id_bai=" + str_bai.ToString() + "&operacao=edit");
        }

        protected void dtgBairros_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (this.Master.VerificaPermissaoUsuario("EXCLUIR"))
            {
                AutoresBL autBL = new AutoresBL();
                Autores au = new Autores();
                au.Id = utils.ComparaIntComZero(dtgAutores.DataKeys[e.RowIndex][0].ToString());
                
                if (autBL.ExcluirBL(au))
                    ExibirMensagem("Registro excluído com sucesso !");
                else
                    ExibirMensagem("Não foi possível excluir o registro, existem registros dependentes");
                
                Pesquisar(null);
            }
            else
                Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);
        }

        protected void dtgBairros_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dtgAutores.DataSource = dtbPesquisa;
            dtgAutores.PageIndex = e.NewPageIndex;
            dtgAutores.DataBind();
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
                dtgAutores.DataSource = m_DataView;
                dtgAutores.DataBind();
            }
        }

               
    }
}