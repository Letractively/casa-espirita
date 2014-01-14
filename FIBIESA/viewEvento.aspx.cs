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
    public partial class viewCurso : System.Web.UI.Page
    {
        Utils utils = new Utils();

        #region funcoes
        public DataTable dtbPesquisa
        {
            get
            {
                if (Session["_dtbPesquisa_cadEve"] != null)
                    return (DataTable)Session["_dtbPesquisa_cadEve"];
                else
                    return null;
            }
            set { Session["_dtbPesquisa_cadEve"] = value; }
        }

        private void Pesquisar(string valor)
        {
            DataTable tabela = new DataTable("cursos");

            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("CODIGO", Type.GetType("System.Int32"));
            DataColumn coluna3 = new DataColumn("DESCRICAO", Type.GetType("System.String"));

            tabela.Columns.Add(coluna1);
            tabela.Columns.Add(coluna2);
            tabela.Columns.Add(coluna3);

            EventosBL eveBL = new EventosBL();

            List<Eventos> eventos;

            eventos = eveBL.PesquisarBuscaBL(valor);

            foreach (Eventos cur in eventos)
            {

                DataRow linha = tabela.NewRow();

                linha["ID"] = cur.Id;
                linha["CODIGO"] = cur.Codigo;
                linha["DESCRICAO"] = cur.Descricao;


                tabela.Rows.Add(linha);
            }

            dtbPesquisa = tabela;
            dtgEventos.DataSource = tabela;
            dtgEventos.DataBind();
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
            Response.Redirect("cadEvento.aspx?operacao=new");
        }


        protected void btnBusca_Click(object sender, EventArgs e)
        {
            Pesquisar(txtBusca.Text);
        }

        protected void dtgCursos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int str_eve = 0;
            str_eve = utils.ComparaIntComZero(dtgEventos.SelectedDataKey[0].ToString());
            Response.Redirect("cadEvento.aspx?id_eve=" + str_eve.ToString() + "&operacao=edit");
        }

        protected void dtgCursos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            EventosBL eveBL = new EventosBL();
            Eventos eventos = new Eventos();
            eventos.Id = utils.ComparaIntComZero(dtgEventos.DataKeys[e.RowIndex][0].ToString());
            if (eveBL.ExcluirBL(eventos))
                ExibirMensagem("Evento excluído com sucesso!");
            else
                ExibirMensagem("Não foi possível excluir o registro, existem registros dependentes");
            Pesquisar(null);

        }

        protected void dtgEventos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dtgEventos.DataSource = dtbPesquisa;
            dtgEventos.PageIndex = e.NewPageIndex;
            dtgEventos.DataBind();
        }

        protected void dtgEventos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow) //se for uma linha de dados
                utils.CarregarEfeitoGrid("#c8defc", "#ffffff", e);

            if (e.Row.RowType == DataControlRowType.DataRow) //se for uma linha de dados
            {
                utils.CarregarJsExclusao("Deseja excluir este registro?", 1, e);
            }
        }

        protected void dtgEventos_Sorting(object sender, GridViewSortEventArgs e)
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
                dtgEventos.DataSource = m_DataView;
                dtgEventos.DataBind();
            }
        }


    }
}