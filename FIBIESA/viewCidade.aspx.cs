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
    public partial class viewCidade : System.Web.UI.Page
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

        private void Pesquisar(string campo, string valor)
        {
            DataTable tabela = new DataTable();

            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("CODIGO", Type.GetType("System.Int32"));
            DataColumn coluna3 = new DataColumn("DESCRICAO", Type.GetType("System.String"));
            DataColumn coluna4 = new DataColumn("ESTADOID", Type.GetType("System.Int32"));
            DataColumn coluna5 = new DataColumn("UF", Type.GetType("System.String"));
            DataColumn coluna6 = new DataColumn("DESESTADO",Type.GetType("System.String"));

            tabela.Columns.Add(coluna1);
            tabela.Columns.Add(coluna2);
            tabela.Columns.Add(coluna3);
            tabela.Columns.Add(coluna4);
            tabela.Columns.Add(coluna5);
            tabela.Columns.Add(coluna6);

            List<Cidades> cidades;

            CidadesBL cidBL = new CidadesBL();
            EstadosBL estBL = new EstadosBL();

            if (campo != null && valor.Trim() != "")
                cidades = cidBL.PesquisarBL(campo, valor);
            else
                cidades = cidBL.PesquisarBL();
            
            List<Estados> estados;
            
            foreach (Cidades cid in cidades)
            {
                DataRow linha = tabela.NewRow();

                linha["ID"] = cid.Id;
                linha["CODIGO"] = cid.Codigo;
                linha["DESCRICAO"] = cid.Descricao;
                linha["ESTADOID"] = cid.EstadoId;

                estados = estBL.PesquisarBL(cid.EstadoId);
                foreach (Estados est in estados)
                {
                    linha["UF"] = est.Uf;
                    linha["DESESTADO"] = est.Descricao;
                }

                tabela.Rows.Add(linha);
            }

            dtbPesquisa = tabela;
            dtgCidades.DataSource = tabela;
            dtgCidades.DataBind();
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
                Pesquisar(null, null);
        }
               
        protected void dtgCidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            int str_cid = 0;
            str_cid = utils.ComparaIntComZero(dtgCidades.SelectedDataKey[0].ToString());
            Response.Redirect("cadCidade.aspx?id_cid=" + str_cid.ToString() + "&operacao=edit");
        }

        protected void dtgCidades_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (this.Master.VerificaPermissaoUsuario("EXCLUIR"))
            {
                CidadesBL cidBL = new CidadesBL();
                Cidades cidades = new Cidades();
                cidades.Id = utils.ComparaIntComZero(dtgCidades.DataKeys[e.RowIndex][0].ToString());
                cidBL.ExcluirBL(cidades);
                Pesquisar(null, null);
            }
            else
                Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);
        }

        protected void btnInserir_Click(object sender, EventArgs e)
        {
            Response.Redirect("cadCidade.aspx?operacao=new");
        }

        protected void Busca_Click(object sender, EventArgs e)
        {
            Pesquisar(ddlCampo.SelectedValue, txtBusca.Text);   
        }

        protected void dtgCidades_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dtgCidades.DataSource = dtbPesquisa;
            dtgCidades.PageIndex = e.NewPageIndex;
            dtgCidades.DataBind();
        }

        protected void dtgCidades_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow) //se for uma linha de dados
                utils.CarregarEfeitoGrid("#c8defc", "#ffffff", e);
            
            if (e.Row.RowType == DataControlRowType.DataRow) //se for uma linha de dados
            {
                utils.CarregarJsExclusao("Deseja exlcuir este registro?", 1, e);
            }
        }

        protected void dtgCidades_Sorting(object sender, GridViewSortEventArgs e)
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
                dtgCidades.DataSource = m_DataView;
                dtgCidades.DataBind();
            }
        }
              
       
    }
}