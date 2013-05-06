using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using DataObjects;
using BusinessLayer;
using FG;

namespace Admin
{
    public partial class viewConta : System.Web.UI.Page
    {
        Utils utils = new Utils();
        #region funcoes
        public DataTable dtbPesquisa
        {
            get
            {
                if (Session["_dtbPesquisa_cadCon"] != null)
                    return (DataTable)Session["_dtbPesquisa_cadCon"];
                else
                    return null;
            }
            set { Session["_dtbPesquisa_cadCon"] = value; }
        }

        private void Pesquisar(string valor)
        {
            DataTable tabela = new DataTable();
            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("CODIGO", Type.GetType("System.Int32"));
            DataColumn coluna3 = new DataColumn("DESCRICAO", Type.GetType("System.String"));            
            DataColumn coluna4 = new DataColumn("DESCAGENCIA", Type.GetType("System.String"));
            DataColumn coluna5 = new DataColumn("DESBANCO", Type.GetType("System.String"));

            tabela.Columns.Add(coluna1);
            tabela.Columns.Add(coluna2);
            tabela.Columns.Add(coluna3);
            tabela.Columns.Add(coluna4);
            tabela.Columns.Add(coluna5);
            
            ContasBL conBL = new ContasBL();
            List<Contas> contas;
            BancosBL banBL = new BancosBL();
            List<Bancos> bancos;
                        
            contas = conBL.PesquisarBuscaBL(valor);
            
            foreach (Contas ltCon in contas)
            {
                DataRow linha = tabela.NewRow();

                linha["ID"] = ltCon.Id;
                linha["CODIGO"] = ltCon.Codigo;
                linha["DESCRICAO"] = ltCon.Descricao;
                if (ltCon.Agencia != null)
                {                  
                    linha["DESCAGENCIA"] = ltCon.Agencia.Codigo.ToString() + " - " +ltCon.Agencia.Descricao.ToString();

                    bancos = banBL.PesquisarBL(utils.ComparaIntComZero(ltCon.Agencia.BancoId.ToString()));
                    foreach (Bancos ltBan in bancos)
	                    linha["DESBANCO"] = ltBan.Codigo.ToString() +" - "+ ltBan.Descricao;
	                
                }
                                                              

                tabela.Rows.Add(linha);
            }

            dtbPesquisa = tabela;
            dtgContas.DataSource = tabela;
            dtgContas.DataBind();
        }   
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                Pesquisar(null);
        }

        protected void btnInserir_Click(object sender, EventArgs e)
        {
            Response.Redirect("cadConta.aspx?operacao=new");
        }

        protected void dtgContas_SelectedIndexChanged(object sender, EventArgs e)
        {
            int str_con = 0;
            str_con = utils.ComparaIntComZero(dtgContas.SelectedDataKey[0].ToString());
            Response.Redirect("cadConta.aspx?id_con=" + str_con.ToString() + "&operacao=edit");
        }

        protected void dtgContas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (this.Master.VerificaPermissaoUsuario("EXCLUIR"))
            {
                ContasBL conBL = new ContasBL();
                Contas contas = new Contas();
                contas.Id = utils.ComparaIntComZero(dtgContas.DataKeys[e.RowIndex][0].ToString());
                conBL.ExcluirBL(contas);
                Pesquisar(null);
            }
            else
                Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);
        }

        protected void btnBusca_Click(object sender, EventArgs e)
        {
            Pesquisar(txtBusca.Text); 
        }

        protected void dtgContas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dtgContas.DataSource = dtbPesquisa;
            dtgContas.PageIndex = e.NewPageIndex;
            dtgContas.DataBind();
        }

        protected void dtgContas_Sorting(object sender, GridViewSortEventArgs e)
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
                dtgContas.DataSource = m_DataView;
                dtgContas.DataBind();
            }
        }

        protected void dtgContas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow) 
                utils.CarregarEfeitoGrid("#c8defc", "#ffffff", e);

            if (e.Row.RowType == DataControlRowType.DataRow)
                utils.CarregarJsExclusao("Deseja excluir este registro?", 1, e);
        }
    }
}