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
    public partial class viewEstado : System.Web.UI.Page
    {
        Utils utils = new Utils();

        #region funcoes
        public DataTable dtbPesquisa
        {
            get
            {
                if (Session["_dtbPesquisa_cadEst"] != null)
                    return (DataTable)Session["_dtbPesquisa_cadEst"];
                else
                    return null;
            }
            set { Session["_dtbPesquisa_cadEst"] = value; }
        }

        private void Pesquisar(string campo, string valor)
        {
            DataTable tabela = new DataTable("tabela");
            /*Cria as colunas do datatable*/
            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("UF", Type.GetType("System.String"));
            DataColumn coluna3 = new DataColumn("DESCRICAO", Type.GetType("System.String"));

            /*Adiciona as colunas a datatable*/

            tabela.Columns.Add(coluna1);
            tabela.Columns.Add(coluna2);
            tabela.Columns.Add(coluna3);

            /*Efetua a pesquisa dos estados recebendo como retorno uma lista de estados*/
            EstadosBL estBL = new EstadosBL();
            //Esta pesquisando todos os livros sempre
            List<Estados> estados;

            if (campo != null && valor.Trim() != "")
                estados = estBL.PesquisarBL(campo, valor);
            else
                estados = estBL.PesquisarBL();

            /*Preenche as linhas do datatable com o retorno da consulta*/
            foreach (Estados est in estados)
            {
                /*Cria uma linha vazia*/
                DataRow linha = tabela.NewRow();
                /*Preenche as colunas desta linha vazia*/
                linha["ID"] = est.Id;
                linha["UF"] = est.Uf;
                linha["DESCRICAO"] = est.Descricao;

                /*Adiciona a linha vazia no datatable*/
                tabela.Rows.Add(linha);
            }
          
            dtbPesquisa = tabela;
            dtgEstados.DataSource = tabela;          
            dtgEstados.DataBind();
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
                Pesquisar(null,null);
        }
                          
        protected void btnBusca_Click(object sender, EventArgs e)
        {
            Pesquisar(ddlCampo.SelectedValue, txtBusca.Text); 
        }

        protected void btnInserir_Click(object sender, EventArgs e)
        {
            Response.Redirect("cadEstado.aspx?operacao=new");
        }

        protected void dtgEstados_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (this.Master.VerificaPermissaoUsuario("EXCLUIR"))
            {
                EstadosBL estBL = new EstadosBL();
                Estados estados = new Estados();
                estados.Id = utils.ComparaIntComZero(dtgEstados.DataKeys[e.RowIndex][0].ToString());
                estBL.ExcluirBL(estados);
                Pesquisar(null, null);
            }
            else
                Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);
        }

        protected void dtgEstados_SelectedIndexChanged(object sender, EventArgs e)
        {
            int str_Est = 0;
            str_Est = utils.ComparaIntComZero(dtgEstados.SelectedDataKey[0].ToString());
            Response.Redirect("cadEstado.aspx?id_est=" + str_Est.ToString() + "&operacao=edit");
        }

        protected void dtgEstados_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dtgEstados.DataSource = dtbPesquisa;
            dtgEstados.PageIndex = e.NewPageIndex;
            dtgEstados.DataBind();
        }

        protected void dtgEstados_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow) //se for uma linha de dados
                utils.CarregarEfeitoGrid("#c8defc", "#ffffff", e);
        }

        protected void dtgEstados_Sorting(object sender, GridViewSortEventArgs e)
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
                dtgEstados.DataSource = m_DataView;
                dtgEstados.DataBind();
            }
        }

        protected void GridProduto_SelectedIndexChanged(object sender, EventArgs e)
        {
                    }

    }
}