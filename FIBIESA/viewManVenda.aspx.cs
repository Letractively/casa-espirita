using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using FG;
using DataObjects;
using BusinessLayer;


namespace Admin
{
    public partial class viewVenda : System.Web.UI.Page
    {

        Utils utils = new Utils();

        #region funcoes
        public DataTable dtbPesquisa
        {
            get
            {
                if (Session["_dtbPesquisa_manVenda"] != null)
                    return (DataTable)Session["_dtbPesquisa_manVenda"];
                else
                    return null;
            }
            set { Session["_dtbPesquisa_manVenda"] = value; }
        }
        private void Pesquisar(string valor)
        {
            DataTable tabela = new DataTable("tabela");

            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("NUMERO", Type.GetType("System.Int32"));            
            DataColumn coluna3 = new DataColumn("DATA", Type.GetType("System.String"));
            DataColumn coluna4 = new DataColumn("SITUACAO", Type.GetType("System.String"));
            DataColumn coluna5 = new DataColumn("NOMEPESSOA", Type.GetType("System.String"));
            DataColumn coluna6 = new DataColumn("NOMEUSUARIO", Type.GetType("System.String"));


            tabela.Columns.Add(coluna1);
            tabela.Columns.Add(coluna2);
            tabela.Columns.Add(coluna3);
            tabela.Columns.Add(coluna4);
            tabela.Columns.Add(coluna5);
            tabela.Columns.Add(coluna6);
           
            VendasBL venBL = new VendasBL();
            List<Vendas> vendas;

            vendas = venBL.PesquisarBuscaBL(valor);

            foreach (Vendas ven in vendas)
            {

                DataRow linha = tabela.NewRow();

                linha["ID"] = ven.Id;
                linha["NUMERO"] = ven.Numero;
                linha["DATA"] = ven.Data != null ? Convert.ToDateTime(ven.Data).ToString("dd/MM/yyyy") : "";
                linha["SITUACAO"] = ven.Situacao;
                linha["NOMEPESSOA"] = ven.Pessoas.Nome;
                linha["NOMEUSUARIO"] = ven.Usuarios.Login;

                tabela.Rows.Add(linha);
            }

            dtbPesquisa = tabela;
            dtgVendas.DataSource = tabela;
            dtgVendas.DataBind();
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

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            ImageButton btndetails = sender as ImageButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
            int ven_id = utils.ComparaIntComZero(dtgVendas.DataKeys[gvrow.RowIndex].Value.ToString());
            if(ven_id > 0)                                                                                                                                                                                                                                                                                                                                                                                                                                                           //l//c 
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(),
                    "WinOpen('/Relatorios/RelReciboVenda.aspx?vendaid=" + ven_id + "','',600,815);", true);            
        }

        protected void dtgVendas_SelectedIndexChanged(object sender, EventArgs e)
        {
            int str_ven = 0;
            str_ven = utils.ComparaIntComZero(dtgVendas.SelectedDataKey[0].ToString());
            Response.Redirect("cadManVenda.aspx?id_vend=" + str_ven.ToString() + "&operacao=edit");
        }

        protected void dtgVendas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dtgVendas.DataSource = dtbPesquisa;
            dtgVendas.PageIndex = e.NewPageIndex;
            dtgVendas.DataBind();
        }

        protected void dtgVendas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                utils.CarregarEfeitoGrid("#c8defc", "#ffffff", e);
        }

        protected void dtgVendas_Sorting(object sender, GridViewSortEventArgs e)
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
                dtgVendas.DataSource = m_DataView;
                dtgVendas.DataBind();
            }
        }

        protected void btnBusca_Click(object sender, EventArgs e)
        {
            Pesquisar(txtBusca.Text);
        }
              
    }
}
