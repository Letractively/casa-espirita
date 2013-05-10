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
    public partial class viewPortador : System.Web.UI.Page
    {
        Utils utils = new Utils();

        #region funcoes

        public DataTable dtbPesquisa
        {
            get
            {
                if (Session["_dtbPesquisa_cadPor"] != null)
                    return (DataTable)Session["_dtbPesquisa_cadPor"];
                else
                    return null;
            }
            set { Session["_dtbPesquisa_cadPor"] = value; }
        }

        private void Pesquisar(string valor)
        {
            DataTable tabela = new DataTable();
            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("CODIGO", Type.GetType("System.Int32"));
            DataColumn coluna3 = new DataColumn("DESCRICAO", Type.GetType("System.String"));
            DataColumn coluna4 = new DataColumn("CODAGENCIA", Type.GetType("System.String"));
            DataColumn coluna5 = new DataColumn("CODBANCO", Type.GetType("System.String"));
            DataColumn coluna6 = new DataColumn("DESBANCO", Type.GetType("System.String"));
            DataColumn coluna7 = new DataColumn("DESAGENCIA", Type.GetType("System.String"));

            tabela.Columns.Add(coluna1);
            tabela.Columns.Add(coluna2);
            tabela.Columns.Add(coluna3);
            tabela.Columns.Add(coluna4);
            tabela.Columns.Add(coluna5);
            tabela.Columns.Add(coluna6);
            tabela.Columns.Add(coluna7);

            PortadoresBL porBL = new PortadoresBL();
            List<Portadores> portadores;
                        
            portadores = porBL.PesquisarBuscaBL(valor);
            
            foreach (Portadores ltPor in portadores)
            {
                DataRow linha = tabela.NewRow();

                linha["ID"] = ltPor.Id;
                linha["CODIGO"] = ltPor.Codigo;
                linha["DESCRICAO"] = ltPor.Descricao;

                if (ltPor.Banco != null)
                {
                    linha["CODBANCO"] = ltPor.Banco.Codigo.ToString();
                    linha["DESBANCO"] = ltPor.Banco.Descricao;
                }
                else
                {
                    linha["CODBANCO"] = "";
                    linha["DESBANCO"] = ""; 
                }

                if (ltPor.Agencia != null)
                {
                    linha["CODAGENCIA"] = ltPor.Agencia.Codigo.ToString();
                    linha["DESAGENCIA"] = ltPor.Agencia.Descricao;
                }
                else
                {
                    linha["CODAGENCIA"] = "";
                    linha["DESAGENCIA"] = "";
 
                }
                tabela.Rows.Add(linha);                
            }
            
            dtbPesquisa = tabela;
            dtgPortadores.DataSource = tabela;
            dtgPortadores.DataBind();
 
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                Pesquisar(null);
        }           

        protected void btnInserir_Click(object sender, EventArgs e)
        {
            Response.Redirect("cadPortador.aspx?operacao=new");
        }

        protected void dtgPortadores_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (this.Master.VerificaPermissaoUsuario("EXCLUIR"))
            {
                PortadoresBL porBL = new PortadoresBL();
                Portadores por = new Portadores();
                por.Id = utils.ComparaIntComZero(dtgPortadores.DataKeys[e.RowIndex][0].ToString());
                porBL.ExcluirBL(por);
                Pesquisar(null);
            }
            else
                Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);
        }

        protected void dtgPortadores_SelectedIndexChanged(object sender, EventArgs e)
        {
            int str_por = 0;
            str_por = utils.ComparaIntComZero(dtgPortadores.SelectedDataKey[0].ToString());
            Response.Redirect("cadPortador.aspx?id_por=" + str_por.ToString() + "&operacao=edit");
        }

        protected void btnBusca_Click(object sender, EventArgs e)
        {
            Pesquisar(txtBusca.Text);    
        }

        protected void dtgPortadores_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dtgPortadores.DataSource = dtbPesquisa;
            dtgPortadores.PageIndex = e.NewPageIndex;
            dtgPortadores.DataBind();
        }

        protected void dtgPortadores_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow) 
                utils.CarregarEfeitoGrid("#c8defc", "#ffffff", e);

            if (e.Row.RowType == DataControlRowType.DataRow)
                utils.CarregarJsExclusao("Deseja excluir este registro?", 1, e);
        }

        protected void dtgPortadores_Sorting(object sender, GridViewSortEventArgs e)
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
                dtgPortadores.DataSource = m_DataView;
                dtgPortadores.DataBind();
            }
        }
    }
}