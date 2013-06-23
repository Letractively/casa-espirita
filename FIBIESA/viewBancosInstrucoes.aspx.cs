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

namespace FIBIESA
{
    public partial class viewBancosInstrucoes : System.Web.UI.Page
    {
        Utils utils = new Utils();

        #region funcoes
        public DataTable dtbPesquisa
        {
            get
            {
                if (Session["_dtbPesquisa_cadBanIns"] != null)
                    return (DataTable)Session["_dtbPesquisa_cadBanIns"];
                else
                    return null;
            }
            set { Session["_dtbPesquisa_cadBanIns"] = value; }
        }

        private void Pesquisar(string valor)
        {
            DataTable tabela = new DataTable("tabela");

            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("CODIGO", Type.GetType("System.Int32"));
            DataColumn coluna3 = new DataColumn("DESCRICAO", Type.GetType("System.String"));
            DataColumn coluna4 = new DataColumn("CODBANCO", Type.GetType("System.Int32"));
            DataColumn coluna5 = new DataColumn("DESBANCO", Type.GetType("System.String"));
            DataColumn coluna6 = new DataColumn("NRDIAS", Type.GetType("System.String"));

            tabela.Columns.Add(coluna1);
            tabela.Columns.Add(coluna2);
            tabela.Columns.Add(coluna3);
            tabela.Columns.Add(coluna4);
            tabela.Columns.Add(coluna5);
            tabela.Columns.Add(coluna6);

            BancosInstrucoesBL banBL = new BancosInstrucoesBL();

            List<BancosInstrucoes> bancos;

            bancos = banBL.PesquisarBuscaBL(valor);

            foreach (BancosInstrucoes ban in bancos)
            {

                DataRow linha = tabela.NewRow();

                linha["ID"] = ban.Id;
                linha["CODIGO"] = ban.Codigo;
                linha["DESCRICAO"] = ban.Descricao;
                linha["NRDIAS"] = ban.Nrdias ? "Sim" : "Não";
                if (ban.Bancos != null)
                {
                    linha["CODBANCO"] = ban.Bancos.Codigo;
                    linha["DESBANCO"] = ban.Bancos.Descricao;
                }
                else
                {
                    linha["CODBANCO"] = null;
                    linha["DESBANCO"] = null;
                }


                tabela.Rows.Add(linha);
            }

            dtbPesquisa = tabela;
            dtgBancos.DataSource = tabela;
            dtgBancos.DataBind();
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

        protected void dtgBancos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            BancosInstrucoesBL banBL = new BancosInstrucoesBL();
            BancosInstrucoes bancos = new BancosInstrucoes();
            bancos.Id = utils.ComparaIntComZero(dtgBancos.DataKeys[e.RowIndex][0].ToString());
          
            if (banBL.ExcluirBL(bancos))
                ExibirMensagem("Registro excluído com sucesso !");
            else
                ExibirMensagem("Não foi possível excluir o registro, existem registros dependentes");
            Pesquisar(null);

        }

        protected void dtgBancos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int str_ban = 0;
            str_ban = utils.ComparaIntComZero(dtgBancos.SelectedDataKey[0].ToString());
            Response.Redirect("cadBancosInstrucoes.aspx?id_banIns=" + str_ban.ToString() + "&operacao=edit");
        }

        protected void dtgBancos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dtgBancos.DataSource = dtbPesquisa;
            dtgBancos.PageIndex = e.NewPageIndex;
            dtgBancos.DataBind();
        }

        protected void dtgBancos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                utils.CarregarEfeitoGrid("#c8defc", "#ffffff", e);

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                utils.CarregarJsExclusao("Deseja excluir este registro?", 1, e);
            }
        }

        protected void dtgBancos_Sorting(object sender, GridViewSortEventArgs e)
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
                dtgBancos.DataSource = m_DataView;
                dtgBancos.DataBind();
            }
        }

        protected void btnBusca_Click(object sender, EventArgs e)
        {
            Pesquisar(txtBusca.Text);
        }

        protected void btnInserir_Click(object sender, EventArgs e)
        {
            Response.Redirect("cadBancosInstrucoes.aspx?operacao=new");
        }
    }
}