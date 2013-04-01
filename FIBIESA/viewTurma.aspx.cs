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
    public partial class viewTurma : System.Web.UI.Page
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

        private void Pesquisar(string valor)
        {
            DataTable tabela = new DataTable();

            DataColumn coluna1 = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn coluna2 = new DataColumn("CODIGO", Type.GetType("System.Int32"));
            DataColumn coluna3 = new DataColumn("DESCRICAO", Type.GetType("System.String"));
            DataColumn coluna4 = new DataColumn("EVENTOID", Type.GetType("System.Int32"));
            DataColumn coluna5 = new DataColumn("DTINICIAL", Type.GetType("System.String"));
            DataColumn coluna6 = new DataColumn("DTFINAL", Type.GetType("System.String"));

            tabela.Columns.Add(coluna1);
            tabela.Columns.Add(coluna2);
            tabela.Columns.Add(coluna3);
            tabela.Columns.Add(coluna4);
            tabela.Columns.Add(coluna5);
            tabela.Columns.Add(coluna6);

            TurmasBL turBL = new TurmasBL();
            List<Turmas> turmas;

            turmas = turBL.PesquisarBuscaBL(valor);
            
            foreach (Turmas tur in turmas)
            {
                DataRow linha = tabela.NewRow();
                
                linha["ID"] = tur.Id;
                linha["CODIGO"] = tur.Codigo;
                linha["DESCRICAO"] = tur.Descricao;
                linha["EVENTOID"] = tur.EventoId;
                linha["DTINICIAL"] = tur.DataInicial.ToString("dd/MM/yyyy");
                linha["DTFINAL"] = tur.DataFinal.ToString("dd/MM/yyyy");

                EventosBL curBL = new EventosBL();
                List<Eventos> eventos = curBL.PesquisarBL(tur.EventoId);
                foreach (Eventos eve in eventos)
                {
                    linha["DESCRICAO"] = eve.Descricao;
                }

                tabela.Rows.Add(linha);
            }

            dtbPesquisa = tabela;
            dtgTurmas.DataSource = tabela;
            dtgTurmas.DataBind();
        }
        private void ExibirMensagem(string mensagem)
        {
            ClientScript.RegisterStartupScript(System.Type.GetType("System.String"), "Alert",
               "<script language='javascript'> { window.alert(\"" + mensagem + "\") }</script>");
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            Pesquisar(null);
        }

        protected void btnInserir_Click(object sender, EventArgs e)
        {
            Response.Redirect("cadTurma.aspx?operacao=new");
        }

        protected void dtgTurmas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            if (this.Master.VerificaPermissaoUsuario("EXCLUIR"))
            {
                TurmasBL turBL = new TurmasBL();
                Turmas turmas = new Turmas();
                turmas.Id = utils.ComparaIntComZero(dtgTurmas.DataKeys[e.RowIndex][0].ToString());
                if (turBL.ExcluirBL(turmas))
                    ExibirMensagem("Turma excluída com sucesso!");
                else
                    ExibirMensagem("Não foi possível excluir a turma.");

                Pesquisar(null);
            }
            else
                Response.Redirect("~/erroPermissao.aspx?nomeUsuario=" + ((Label)Master.FindControl("lblNomeUsuario")).Text + "&usuOperacao=operação", true);
        }


        protected void dtgTurma_SelectedIndexChanged(object sender, EventArgs e)
        {
            int str_tur = 0;
            str_tur = utils.ComparaIntComZero(dtgTurmas.SelectedDataKey[0].ToString());
            Response.Redirect("cadTurma.aspx?id_tur=" + str_tur.ToString() + "&operacao=edit");
        }

        protected void dtgTurmas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow) //se for uma linha de dados
                utils.CarregarEfeitoGrid("#c8defc", "#ffffff", e);

            if (e.Row.RowType == DataControlRowType.DataRow) //se for uma linha de dados
            {
                utils.CarregarJsExclusao("Deseja excluir este registro?", 1, e);
            }
        }

        protected void dtgTurmas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dtgTurmas.DataSource = dtbPesquisa;
            dtgTurmas.PageIndex = e.NewPageIndex;
            dtgTurmas.DataBind();
        }

        protected void dtgTurmas_Sorting(object sender, GridViewSortEventArgs e)
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
                dtgTurmas.DataSource = m_DataView;
                dtgTurmas.DataBind();
            }

        }

        protected void btnBusca_Click(object sender, EventArgs e)
        {
            Pesquisar(txtBusca.Text);
        }
    }
}