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
    public partial class viewObra : System.Web.UI.Page
    {
        Utils utils = new Utils();

        #region funcoes
        public DataTable dtbPesquisa
        {
            get
            {
                if (Session["_dtbPesquisa_cadObras"] != null)
                    return (DataTable)Session["_dtbPesquisa_cadObras"];
                else
                    return null;
            }
            set { Session["_dtbPesquisa_cadObras"] = value; }
        }
        private void Pesquisar(string valor)
        {
            DataTable tabela = new DataTable("tabela");

            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("CODIGO", Type.GetType("System.Int32"));
            DataColumn coluna3 = new DataColumn("TITULO", Type.GetType("System.String"));
            DataColumn coluna4 = new DataColumn("ISBN", Type.GetType("System.String"));
            DataColumn coluna5 = new DataColumn("TIPODESC", Type.GetType("System.String"));

            tabela.Columns.Add(coluna1);
            tabela.Columns.Add(coluna2);
            tabela.Columns.Add(coluna3);
            tabela.Columns.Add(coluna4);
            tabela.Columns.Add(coluna5);

            ObrasBL obraBL = new ObrasBL();
            List<Obras> obras;

            obras = obraBL.PesquisarBuscaBL(valor);

            foreach (Obras obrinha in obras)
            {

                DataRow linha = tabela.NewRow();

                linha["ID"] = obrinha.Id;
                linha["CODIGO"] = obrinha.Codigo;
                linha["TITULO"] = obrinha.Titulo;
                linha["ISBN"] = obrinha.Isbn;
                if (obrinha.TiposObras != null)
                    linha["TIPODESC"] = obrinha.TiposObras.Descricao;
                else
                    linha["TIPODESC"] = "";


                tabela.Rows.Add(linha);
            }

            dtbPesquisa = tabela;
            dtgObras.DataSource = tabela;
            dtgObras.DataBind();
        }
        private void ExibirMensagem(string mensagem)
        {
            ClientScript.RegisterStartupScript(System.Type.GetType("System.String"), "Alert",
              "<script language='javascript'> { window.alert(\"" + mensagem + "\") }</script>");
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnInserir_Click(object sender, EventArgs e)
        {
            Response.Redirect("cadObra.aspx?operacao=new");
        }

        protected void btnBusca_Click(object sender, EventArgs e)
        {
            Pesquisar(txtBusca.Text);
        }

        protected void dtgObras_SelectedIndexChanged(object sender, EventArgs e)
        {
            int str_bai = 0;
            str_bai = utils.ComparaIntComZero(dtgObras.SelectedDataKey[0].ToString());
            Response.Redirect("cadObra.aspx?id_bai=" + str_bai.ToString() + "&operacao=edit");
        }

        protected void dtgObras_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            ObrasBL obraBL = new ObrasBL();
            Obras obras = new Obras();
            obras.Id = utils.ComparaIntComZero(dtgObras.DataKeys[e.RowIndex][0].ToString());

            if (obraBL.ExcluirBL(obras))
                ExibirMensagem("Registro excluído com sucesso !");
            else
                ExibirMensagem("Não foi possível excluir o registro, existem registros dependentes");

            Pesquisar(null);

        }

        protected void dtgObras_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dtgObras.DataSource = dtbPesquisa;
            dtgObras.PageIndex = e.NewPageIndex;
            dtgObras.DataBind();
        }

        protected void dtgObras_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                utils.CarregarEfeitoGrid("#c8defc", "#ffffff", e);

            if (e.Row.RowType == DataControlRowType.DataRow)
                utils.CarregarJsExclusao("Deseja excluir este registro?", 1, e);
        }

        protected void dtgObras_Sorting(object sender, GridViewSortEventArgs e)
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
                dtgObras.DataSource = m_DataView;
                dtgObras.DataBind();
            }
        }


    }
}